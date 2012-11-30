namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;

    public class Hill : SecurityAlgorithm
    {
        readonly int[,] key;

        public Hill(int[,] matrix)
        {
            key = matrix;
        }

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
            MatrixClass matrix = new MatrixClass(key);

            if (mode == Mode.Decrypt)
            {
                matrix = matrix.Inverse();
            }

            int pos = 0, charPosition;
            string substring, result = "";
            int matrixSize = key.GetLength(0);

            while (pos < message.Length)
            {
                substring = message.Substring(pos, matrixSize);
                pos += matrixSize;

                for (int i = 0; i < matrixSize; i++)
                {
                    charPosition = 0;

                    for (int j = 0; j < matrixSize; j++)
                    {
                        charPosition += (int)matrix[j, i].Numerator * alphabet[substring[j]];
                    }

                    result += alphabet.Keys.ElementAt(charPosition % 26);
                }
            }

            return result;
        }

        #endregion
    }
}