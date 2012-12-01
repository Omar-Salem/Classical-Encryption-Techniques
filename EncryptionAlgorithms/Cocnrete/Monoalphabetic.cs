namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;

    public class Monoalphabetic : SecurityAlgorithm
    {
        readonly Dictionary<char, char> _alphabetShuffled;
        readonly Dictionary<char, char> _alphabetShuffledReverse;

        public Monoalphabetic()
        {
            _alphabetShuffledReverse = new Dictionary<char, char>();
            _alphabetShuffled = new Dictionary<char, char>();
            ShuffleAlphabet();
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
                switch (mode)
                {
                    case Mode.Encrypt:
                        result += _alphabetShuffled[token[i]];
                        break;
                    case Mode.Decrypt:
                        result += _alphabetShuffledReverse[token[i]];
                        break;
                }
            }

            return result;
        }

        private void ShuffleAlphabet()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            var alphabetCopy = alphabet.Keys.ToList();

            foreach (var character in alphabet.Keys)
            {
                int characterPosition = r.Next(0, alphabetCopy.Count);
                char randomCharacter = alphabetCopy[characterPosition];
                _alphabetShuffled.Add(character, randomCharacter);
                _alphabetShuffledReverse.Add(randomCharacter, character);
                alphabetCopy.RemoveAt(characterPosition);
            }
        }

        #endregion
    }
}