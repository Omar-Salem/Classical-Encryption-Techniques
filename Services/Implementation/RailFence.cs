namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RailFence : ISecurity
    {
        #region ISecurity

        string ISecurity.Encrypt(string token, object[] param)
        {
            return Process(token, param[0], Mode.Encrypt);
        }

        string ISecurity.Decrypt(string token, object[] param)
        {
            return Process(token, param[0], Mode.Decrypt);
        }

        #endregion

        #region Private Methods

        private string Process(string token, object key, Mode mode)
        {
            int nRows = Convert.ToInt32(key);
            int nColumns = (int)Math.Ceiling((double)token.Length / (double)nRows);
            char[,] arrResult = FillArray(token, nRows, nColumns, mode);
            string strReturn = "";
            foreach (char c in arrResult)
            {
                strReturn += c;
            }
            return strReturn;
        }

        private char[,] FillArray(string token, int nRows, int nColumns, Mode mode)
        {
            int nchar_position = 0;
            int nLength = 0, nWidth = 0;
            char[,] arrReturn = new char[nRows, nColumns];
            switch (mode)
            {
                case Mode.Encrypt:
                    nLength = nRows;
                    nWidth = nColumns;
                    break;
                case Mode.Decrypt:
                    arrReturn = new char[nColumns, nRows];
                    nWidth = nRows;
                    nLength = nColumns;
                    break;
            }
            for (int i = 0; i < nWidth; i++)
            {
                for (int j = 0; j < nLength; j++)
                {
                    if (nchar_position < token.Length)
                    {
                        arrReturn[j, i] = token[nchar_position];
                    }
                    else
                    {
                        arrReturn[j, i] = '*';
                    }
                    nchar_position++;
                }
            }
            return arrReturn;
        } 

        #endregion
    }
}