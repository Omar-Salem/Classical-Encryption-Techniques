namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;

    public class Ceaser : SecurityAlgorithm
    {
        readonly int key;

        #region Constructor

        public Ceaser(int key)
        {
            this.key = key;
        } 

        #endregion

        #region Public Methods

        public override string Encrypt(string plainText)
        {
            return Process(plainText, Mode.Encrypt);
        }

        public override string Decrypt(string cipher)
        {
            return Process(cipher, Mode.Decrypt);
        }

        #endregion

        #region Private Methods

        private string Process(string message, Mode mode)
        {
            string result = string.Empty;

            foreach (char c in message)
            {
                var charposition = alphabet[c];
                var res = Common.GetAlphabetPosition(charposition, key, mode);
                result += alphabet.Keys.ElementAt(res % 26);
            }

            return result;
        }

        #endregion
    }
}