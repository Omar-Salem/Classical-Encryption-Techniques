namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vigenere : ISecurity
    {
        readonly Dictionary<char, int> alphabetSorted;

        public Vigenere()
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
            string Key = param.ToString().ToLower().Replace(" ", "");
            Key = DuplicateKey(token, Key);
            return Common.Shift(token, Key, mode, alphabetSorted);
        }

        private string DuplicateKey(string token, string Key)
        {
            if (Key.Length < token.Length)
            {
                int nLength = token.Length - Key.Length;
                for (int i = 0; i < nLength; i++)
                {
                    Key += Key[i % Key.Length];
                }
            }
            return Key;
        } 

        #endregion
    }
}