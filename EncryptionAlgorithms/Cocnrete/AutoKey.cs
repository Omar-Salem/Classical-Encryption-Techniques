namespace EncryptionAlgorithms
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    public class AutoKey : SecurityAlgorithm
    {
        #region Member Variables

        string _key; 

        #endregion

        #region Constructor

        public AutoKey(string key)
        {
            this._key = key;
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
            _key = DuplicateKey(message);
            return Common.Shift(message, _key, mode, alphabet);
        }

        private string DuplicateKey(string message)
        {
            if (_key.Length < message.Length)
            {
                int length = message.Length - _key.Length;

                for (int i = 0; i < length; i++)
                {
                    _key += message[i];
                }
            }

            return _key;
        }

        #endregion
    }
}