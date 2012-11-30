using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionAlgorithms
{
    public abstract class SecurityAlgorithm
    {
        protected readonly Dictionary<char, int> alphabet;

        public SecurityAlgorithm()
        {
            alphabet = new Dictionary<char, int>();
            char c = 'a';
            alphabet.Add(c, 0);

            for (int i = 1; i < 26; i++)
            {
                alphabet.Add(++c, i);
            }
        }

        public abstract string Encrypt(string plainText);

        public abstract string Decrypt(string cipher);
    }
}
