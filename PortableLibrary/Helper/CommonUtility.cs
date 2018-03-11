using System;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class CommonUtility
    {
        /// <summary>
        /// Encryption key.
        /// </summary>
        public const string Key = "MvvmTest";

        /// <summary>
        /// Encryption byte size.
        /// </summary>
        public const int ByteSize = 16;

        /// <summary>
        /// HttpClient request format.
        /// </summary>
        public const string RequestFormat = "application/json";

        /// <summary>
        /// HttpClient encoding format.
        /// </summary>
        public const string EncodingFormat = "utf-8";

        /// <summary>
        /// The separator.
        /// </summary>
        public const char Separator = ':';

        #region Base Encoding
        /// <summary>
        /// Encodes the string to base64.
        /// </summary>
        /// <returns>base64 encoded string</returns>
        /// <param name="text">Text.</param>
        public static string EncodeToBase64(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{text}"));
        }

        #endregion

        #region String Manipulation
        /// <summary>
        /// Gets the combined text with separator.
        /// </summary>
        /// <returns>The combined text with separator.</returns>
        /// <param name="string1">String1.</param>
        /// <param name="string2">String2.</param>
        /// <param name="separator">Separator.</param>
        public static string GetCombinedTextWithSeparator(string string1, string string2, string separator)
        {
            var text = String.Join(separator, string1, string2);
            return text;
        }

        /// <summary>
        /// Gets the separated strings.
        /// </summary>
        /// <returns>The separated strings.</returns>
        /// <param name="combinedString">Combined string.</param>
        /// <param name="separator">Separator.</param>
        public static string[] GetSeparatedStrings(string combinedString, char separator)
        {
            var stringsArray = combinedString.Split(separator);
            return stringsArray;
        }
        #endregion
    }
}
