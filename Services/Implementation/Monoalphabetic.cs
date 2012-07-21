namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Monoalphabetic : ISecurity
    {
        readonly Dictionary<char, int> alphabetSorted;
        readonly Dictionary<int, char> alphabetRandom;
        readonly Dictionary<char, int> alphabetRandomReverse;

        public Monoalphabetic()
        {
            alphabetSorted = Common.Alphabet;
            alphabetRandomReverse = new Dictionary<char, int>();
            alphabetRandom = Common.ConstructRandomAlphabet(alphabetRandomReverse);
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
            string result = "";
            for (int i = 0; i < token.Length; i++)
            {
                int nchar_position = alphabetSorted[token[i]];
                result += alphabetRandom[nchar_position];
            }
            return result;
        } 

        #endregion
    }
}