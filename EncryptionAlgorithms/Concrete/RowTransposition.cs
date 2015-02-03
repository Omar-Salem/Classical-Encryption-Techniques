namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class RowTransposition : SecurityAlgorithm
    {
        readonly int[] key;

        public RowTransposition(int[] key)
        {
            this.key = key;
        }

        #region Public Methods

        public override string Encrypt(string plainText)
        {
            int columns = 0, rows = 0;
            Dictionary<int, int> rowsPositions = FillPositionsDictionary(plainText, ref columns, ref rows);
            char[,] matrix2 = new char[rows, columns];

            //Fill Matrix
            int charPosition = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (charPosition < plainText.Length)
                    {
                        matrix2[i, j] = plainText[charPosition];
                    }
                    else
                    {
                        matrix2[i, j] = '*';
                    }

                    charPosition++;
                }
            }

            string result = "";

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result += matrix2[j, rowsPositions[i + 1]];
                }

                result += " ";
            }

            return result;
        }

        public override string Decrypt(string cipherText)
        {
            int columns = 0, rows = 0;
            Dictionary<int, int> rowsPositions = FillPositionsDictionary(cipherText, ref columns, ref rows);
            char[,] matrix = new char[rows, columns];

            //Fill Matrix
            int charPosition = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[j, rowsPositions[i + 1]] = cipherText[charPosition];
                    charPosition++;
                }
            }

            string result = "";

            foreach (char c in matrix)
            {
                if (c != '*' && c != ' ')
                {
                    result += c;
                }
            }

            return result;
        }

        #endregion

        #region Private Methods

        private Dictionary<int, int> FillPositionsDictionary(string token, ref int columns, ref int rows)
        {
            var result = new Dictionary<int, int>();
            columns = key.Length;
            rows = (int)Math.Ceiling((double)token.Length / (double)columns);
            /*  we need something to tell where to start
             *        4  3  1  2  5  6  7               Key
             *        
             *        0  1  2  3  4  5  6               Value
             */
            //attack postponed until two am xyz
            for (int i = 0; i < columns; i++)
            {
                result.Add(key[i], i);
            }

            return result;
        }

        #endregion
    }
}