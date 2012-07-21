namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Common
    {
        static Dictionary<char, int> alphabet = null;

        internal static int GetAlphabetPosition(int nTextposition, int nKeyposition, Mode mode)
        {
            int nReturn = 0;
            switch (mode)
            {
                case Mode.Encrypt:
                    nReturn = (nTextposition + nKeyposition) % 26;
                    break;
                case Mode.Decrypt:
                    nReturn = nTextposition - nKeyposition;
                    if (nReturn < 0)
                    {
                        nReturn += 26;
                    }
                    break;
            }
            return nReturn;
        }

        internal static Dictionary<char, int> Alphabet
        {
            get
            {
                if (alphabet == null)
                {
                    alphabet = new Dictionary<char, int>();
                    char c = 'a';
                    alphabet.Add(c, 0);
                    for (int i = 1; i < 26; i++)
                    {
                        alphabet.Add(++c, i);
                    }
                }
                return alphabet;
            }
        }

        internal static Dictionary<int, char> ConstructRandomAlphabet(Dictionary<char, int> alphabetRandomReverse)
        {
            Random r = new Random();
            var alphabetRandom = new Dictionary<int, char>();
            foreach (char c in alphabetRandom.Keys)
            {
                int nRandom = r.Next(0, 26);
                while (alphabetRandom.Keys.Contains(nRandom))
                {
                    nRandom = r.Next(0, 26);
                }
                alphabetRandom.Add(nRandom, c);
                alphabetRandomReverse.Add(c, nRandom);
            }
            return alphabetRandom;
        }

        internal static string Shift(string token, string Key, Mode mode, Dictionary<char, int> alphabetSorted)
        {
            string strReturn = "";
            int nTextposition, nKeyposition, nResPosition = 0;
            for (int i = 0; i < token.Length; i++)
            {
                nTextposition = alphabetSorted[token[i]];
                nKeyposition = alphabetSorted[Key[i]];
                nResPosition = GetAlphabetPosition(nTextposition, nKeyposition, mode);
                strReturn += alphabetSorted.Keys.ElementAt(nResPosition);
            }
            return strReturn;
        }
    }
}
