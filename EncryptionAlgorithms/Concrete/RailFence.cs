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
            char[,] matrix = FillArray(message, rows, columns, mode);
            string result = "";

            foreach (char c in matrix)
            {
                result += c;
            }

            return result;
        }

        private char[,] FillArray(string message, int rowsCount, int columnsCount, Mode mode)
        {
            int charPosition = 0;
            int length = 0, width = 0;
            char[,] matrix = new char[rowsCount, columnsCount];

            switch (mode)
            {
                case Mode.Encrypt:
                    length = rowsCount;
                    width = columnsCount;
                    break;
                case Mode.Decrypt:
                    matrix = new char[columnsCount, rowsCount];
                    width = rowsCount;
                    length = columnsCount;
                    break;
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (charPosition < message.Length)
                    {
                        matrix[j, i] = message[charPosition];
                    }
                    else
                    {
                        matrix[j, i] = '*';
                    }

                    charPosition++;
                }
            }

            return matrix;
        }

        #endregion
    }
}