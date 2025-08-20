using System.Text;

namespace YourNamespace
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to a byte array using UTF8 encoding.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>A byte array representing the input string.</returns>
        public static byte[] ToByteArray(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }

            return Encoding.UTF8.GetBytes(input);
        }
    }
}
