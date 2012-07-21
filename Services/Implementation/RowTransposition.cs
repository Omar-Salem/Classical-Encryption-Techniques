namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RowTransposition : ISecurity
    {
        #region ISecurity

        string ISecurity.Encrypt(string token, object[] param)
        {
            int nColumns = 0, nRows = 0;
            Dictionary<int, int> dicRows_Positions = FillPositionsDictionary(token, param[0].ToString(), ref nColumns, ref nRows);
            char[,] Matrix_2 = new char[nRows, nColumns];

            //Fill Matrix
            int nchar_position = 0;
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    if (nchar_position < token.Length)
                    {
                        Matrix_2[i, j] = token[nchar_position];
                    }
                    else
                    {
                        Matrix_2[i, j] = '*';
                    }
                    nchar_position++;
                }
            }

            string result = "";
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nRows; j++)
                {
                    result += Matrix_2[j, dicRows_Positions[i + 1]];
                }
                result += " ";
            }
            return result;
        }

        string ISecurity.Decrypt(string token, object[] param)
        {
            int nColumns = 0, nRows = 0;
            Dictionary<int, int> dicRows_Positions = FillPositionsDictionary(token, param[0].ToString(), ref nColumns, ref nRows);
            char[,] arrMatrix = new char[nRows, nColumns];

            //Fill Matrix
            int nchar_position = 0;
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nRows; j++)
                {
                    arrMatrix[j, dicRows_Positions[i + 1]] = token[nchar_position];
                    nchar_position++;
                }
            }

            string result = "";
            foreach (char c in arrMatrix)
            {
                if (c != '*' && c != ' ')
                {
                    result += c;
                }
            }
            return result;
        }

        #endregion

        #region Private Methods

        private Dictionary<int, int> FillPositionsDictionary(string token, string key, ref int nColumns, ref int nRows)
        {
            var result = new Dictionary<int, int>();
            string[] arrRow_Numbers = key.Split(',');
            nColumns = arrRow_Numbers.Length;
            nRows = (int)Math.Ceiling((double)token.Length / (double)nColumns);
            /*  we need something to tell where to start
             *        4  3  1  2  5  6  7               Key
             *        
             *        0  1  2  3  4  5  6               Value
             */
            //attack postponed until two am xyz
            for (int i = 0; i < nColumns; i++)
            {
                result.Add(int.Parse(arrRow_Numbers[i]), i);
            }
            return result;
        }

        #endregion
    }
}