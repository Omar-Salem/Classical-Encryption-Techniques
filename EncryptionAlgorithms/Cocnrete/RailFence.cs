namespace EncryptionAlgorithms
{
    using System;
    using System.ComponentModel.Composition;

    public class RailFence : SecurityAlgorithm
    {
        readonly int key;

        public RailFence(int key)
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
            int rows = key;
            int columns = (int)Math.Ceiling((double)message.Length / (double)rows);
            char[,] result = FillArray(message, rows, columns, mode);
            string strReturn = "";

            foreach (char c in result)
            {
                strReturn += c;
            }

            return strReturn;
        }

        private char[,] FillArray(string message, int nRows, int nColumns, Mode mode)
        {
            int charPosition = 0;
            int length = 0, width = 0;
            char[,] arrReturn = new char[nRows, nColumns];
            switch (mode)
            {
                case Mode.Encrypt:
                    length = nRows;
                    width = nColumns;
                    break;
                case Mode.Decrypt:
                    arrReturn = new char[nColumns, nRows];
                    width = nRows;
                    length = nColumns;
                    break;
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (charPosition < message.Length)
                    {
                        arrReturn[j, i] = message[charPosition];
                    }
                    else
                    {
                        arrReturn[j, i] = '*';
                    }

                    charPosition++;
                }
            }

            return arrReturn;
        }

        #endregion
    }
}