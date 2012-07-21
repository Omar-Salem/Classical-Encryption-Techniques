namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hill : ISecurity
    {
        readonly Dictionary<char, int> alphabetSorted;

        public Hill()
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
            MatrixClass m = new MatrixClass((int[,])param[0]);
            int key = Convert.ToInt32(param[1]);
            if (mode == Mode.Decrypt)
            {
                m = m.Inverse();
            }
            int npos = 0, nchar_position;
            string strSubstring, strReturn = "";
            while (npos < token.Length)
            {
                strSubstring = token.Substring(npos, key);
                npos += key;

                for (int i = 0; i < key; i++)
                {
                    nchar_position = 0;
                    for (int j = 0; j < key; j++)
                    {
                        nchar_position += (int)m[j, i].Numerator * alphabetSorted[strSubstring[j]];
                    }
                    strReturn += alphabetSorted.Keys.ElementAt(nchar_position % 26);
                }
            }
            return strReturn;
        } 

        #endregion
    }
}