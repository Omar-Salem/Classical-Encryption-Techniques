namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlayFair : ISecurity
    {
        readonly Dictionary<char, int> alphabetSorted;

        public PlayFair()
        {
            alphabetSorted = Common.Alphabet;
        }

        #region ISecurity

        string ISecurity.Encrypt(string token, object[] param)
        {
            return Process(token, param, Mode.Encrypt);
        }

        string ISecurity.Decrypt(string token, object[] param)
        {
            return Process(token, param, Mode.Decrypt);
        }

        #endregion

        #region Private Methods

        private string Process(string token, object[] param, Mode mode)
        {
            List<char> lstKey = new List<char>();
            string key = param[0].ToString();

            //Key:Charcater
            //Value:Position
            Dictionary<char, string> dicCharacter_positions_in_Matrix = new Dictionary<char, string>();

            //Key:Position
            //Value:Charcater
            Dictionary<string, char> dicPosition_Character_in_Matrix = new Dictionary<string, char>();


            foreach (char c in key.ToLower().Trim())//get key..remove duplicates
            {
                if (!lstKey.Contains(c) && c != ' ')
                {
                    lstKey.Add(c);
                }
            }
            FillMatrix(lstKey, ref dicCharacter_positions_in_Matrix, ref dicPosition_Character_in_Matrix);
            if (mode == Mode.Encrypt)
            {
                token = RepairWord(token);
            }
            ////////////////////////////////////////////////
            string strReturn = "";
            for (int i = 0; i < token.Length; i += 2)
            {
                string strSubstring_of_2 = token.Substring(i, 2);//get characters from text by pairs
                //get Row & Column of each character
                string strR_C_1 = dicCharacter_positions_in_Matrix[strSubstring_of_2[0]];
                string strR_C_2 = dicCharacter_positions_in_Matrix[strSubstring_of_2[1]];

                if (strR_C_1[0] == strR_C_2[0])//Same Row, different Column
                {
                    int nNew_C1 = 0, nNew_C2 = 0;
                    switch (mode)
                    {
                        case Mode.Encrypt://Increment Columns
                            nNew_C1 = (int.Parse(strR_C_1[1].ToString()) + 1) % 5;
                            nNew_C2 = (int.Parse(strR_C_2[1].ToString()) + 1) % 5;
                            break;
                        case Mode.Decrypt://Decrement Columns
                            nNew_C1 = (int.Parse(strR_C_1[1].ToString()) - 1) % 5;
                            nNew_C2 = (int.Parse(strR_C_2[1].ToString()) - 1) % 5;
                            break;
                    }
                    nNew_C1 = RepairNegative(nNew_C1);
                    nNew_C2 = RepairNegative(nNew_C2);
                    strReturn += dicPosition_Character_in_Matrix[strR_C_1[0].ToString() + nNew_C1.ToString()];
                    strReturn += dicPosition_Character_in_Matrix[strR_C_2[0].ToString() + nNew_C2.ToString()];
                }

                else if (strR_C_1[1] == strR_C_2[1])//Same Column, different Row
                {
                    int nNew_R1 = 0, nNew_R2 = 0;

                    switch (mode)
                    {
                        case Mode.Encrypt://Increment Rows
                            nNew_R1 = (int.Parse(strR_C_1[0].ToString()) + 1) % 5;
                            nNew_R2 = (int.Parse(strR_C_2[0].ToString()) + 1) % 5;
                            break;
                        case Mode.Decrypt://Decrement Rows
                            nNew_R1 = (int.Parse(strR_C_1[0].ToString()) - 1) % 5;
                            nNew_R2 = (int.Parse(strR_C_2[0].ToString()) - 1) % 5;
                            break;
                    }
                    nNew_R1 = RepairNegative(nNew_R1);
                    nNew_R2 = RepairNegative(nNew_R2);
                    strReturn += dicPosition_Character_in_Matrix[nNew_R1.ToString() + strR_C_1[1].ToString()];
                    strReturn += dicPosition_Character_in_Matrix[nNew_R2.ToString() + strR_C_2[1].ToString()];
                }

                else//different Row & Column
                {
                    //1st character:row of 1st + col of 2nd
                    //2nd character:row of 2nd + col of 1st
                    strReturn += dicPosition_Character_in_Matrix[strR_C_1[0].ToString() + strR_C_2[1].ToString()];
                    strReturn += dicPosition_Character_in_Matrix[strR_C_2[0].ToString() + strR_C_1[1].ToString()];
                }
            }
            return strReturn;
        }

        private string RepairWord(string token)
        {
            string strTrimmed = token.Replace(" ", "");
            string strReturn = "";
            for (int i = 0; i < strTrimmed.Length; i++)
            {
                strReturn += strTrimmed[i];
                if (i < strTrimmed.Length - 1 && token[i] == token[i + 1]) //check if two consecutive letters are the same
                {
                    strReturn += 'x';
                }
            }

            if (strReturn.Length % 2 != 0)//check if length is even
            {
                strReturn += 'x';
            }
            return strReturn;
        }

        private void FillMatrix(List<char> lstKey, ref Dictionary<char, string> dicCharacter_positions_in_Matrix, ref Dictionary<string, char> dicPosition_Character_in_Matrix)
        {
            char[,] arrMatrix_PF = new char[5, 5];
            int nKeyPosition = 0, nchar_position = 0;
            List<char> lstAlphabet_PF = alphabetSorted.Keys.ToList();
            lstAlphabet_PF.Remove('j');
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (nchar_position < lstKey.Count)
                    {
                        arrMatrix_PF[i, j] = lstKey[nchar_position];//fill matrix with key
                        lstAlphabet_PF.Remove(lstKey[nchar_position]);
                        nchar_position++;
                    }

                    else//key finished...fill with rest of alphabet
                    {
                        arrMatrix_PF[i, j] = lstAlphabet_PF[nKeyPosition];
                        nKeyPosition++;
                    }

                    string strPosition = i.ToString() + j.ToString();
                    //store character positions in dictionary to avoid searching everytime
                    dicCharacter_positions_in_Matrix.Add(arrMatrix_PF[i, j], strPosition);
                    dicPosition_Character_in_Matrix.Add(strPosition, arrMatrix_PF[i, j]);
                }
            }
        }

        private int RepairNegative(int nNumber)
        {
            if (nNumber < 0)
            {
                nNumber += 5;
            }
            return nNumber;
        }
        #endregion
    }
}