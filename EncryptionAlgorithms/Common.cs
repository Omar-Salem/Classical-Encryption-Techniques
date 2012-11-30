namespace EncryptionAlgorithms
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Common
    {
        internal static int GetAlphabetPosition(int textPosition, int keyPosition, Mode mode)
        {
            int result = 0;

            switch (mode)
            {
                case Mode.Encrypt:
                    result = (textPosition + keyPosition) % 26;
                    break;
                case Mode.Decrypt:
                    result = textPosition - keyPosition;

                    if (result < 0)
                    {
                        result += 26;
                    }

                    break;
            }

            return result;
        }


        internal static string Shift(string token, string Key, Mode mode, Dictionary<char, int> alphabetSorted)
        {
            string result = "";
            int textPosition, keyPosition, resPosition = 0;
            for (int i = 0; i < token.Length; i++)
            {
                textPosition = alphabetSorted[token[i]];
                keyPosition = alphabetSorted[Key[i]];
                resPosition = GetAlphabetPosition(textPosition, keyPosition, mode);
                result += alphabetSorted.Keys.ElementAt(resPosition);
            }
            return result;
        }
    }
}
