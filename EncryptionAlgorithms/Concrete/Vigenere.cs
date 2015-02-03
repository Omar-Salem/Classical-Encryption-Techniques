namespace EncryptionAlgorithms
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    public class Vigenere : SecurityAlgorithm
    {
        string key;

        public Vigenere(string key)
        {
            this.key = key;
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

        private string Process(string message, Mode mode)
        {
            key = key.ToString().ToLower().Replace(" ", "");
            key = DuplicateKey(message, key);
            return Common.Shift(message, key, mode, alphabet);
        }

        private string DuplicateKey(string message, string key)
        {
            if (key.Length < message.Length)
            {
                int length = message.Length - key.Length;

                for (int i = 0; i < length; i++)
                {
                    key += key[i % key.Length];
                }
            }

            return key;
        }

        #endregion
    }
}