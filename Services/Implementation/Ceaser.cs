namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Ceaser : ISecurity
    {
        readonly Dictionary<char, int> alphabetSorted;

        public Ceaser()
        {
            alphabetSorted = Common.Alphabet;
        }

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

        private string Process(string token, object param, Mode mode)
        {
            int nKey = Convert.ToInt16(param);
            int nchar_position, nRes;
            string strReturn = "";
            for (int i = 0; i < token.Length; i++)
            {
                nchar_position = alphabetSorted[token[i]];
                nRes = Common.GetAlphabetPosition(nchar_position, nKey, mode);
                strReturn += alphabetSorted.Keys.ElementAt(nRes % 26);
            }
            return strReturn;
        } 

        #endregion
    }
}