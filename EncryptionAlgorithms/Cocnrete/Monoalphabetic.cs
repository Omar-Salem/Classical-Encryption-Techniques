namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;

    public class Monoalphabetic : SecurityAlgorithm
    {
        readonly Dictionary<int, char> _alphabetShuffled;
        readonly Dictionary<char, int> _alphabetRandomReverse;

        public Monoalphabetic()
        {
            _alphabetRandomReverse = new Dictionary<char, int>();
            _alphabetShuffled = new Dictionary<int, char>();
        }

        #region Public Methods

        public override string Encrypt(string plainText)
        {
            return Process(plainText, Mode.Encrypt);
        }

        public override string Decrypt(string cipherText)
        {
            return Process(cipherText, Mode.Decrypt);
        }

        #endregion

        #region Private Methods

        private string Process(string token, Mode mode)
        {
            string result = "";

            for (int i = 0; i < token.Length; i++)
            {
                int nchar_position = alphabet[token[i]];
                result += _alphabetShuffled[nchar_position];
            }

            return result;
        }

        private void ShuffleAlphabet()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            while (_alphabetShuffled.Count != 26)
            {
                int characterPosition = r.Next(0, alphabet.Count);

                if (!_alphabetShuffled.Keys.Contains(characterPosition))
                {
                    char randomCharacter = alphabet.ElementAt(characterPosition).Key;
                    _alphabetShuffled.Add(characterPosition, randomCharacter);
                    _alphabetRandomReverse.Add(randomCharacter, characterPosition);
                    alphabet.Remove(randomCharacter);
                }
            }
        }

        #endregion
    }
}