using System.Text;

namespace BlazorVerificationCaptcha
{
    internal static class Tools
    {
        /// <summary>
        /// Also subject to change, I want to allow more or less than six characters of captcha but for this I need to redo the image generation because of the dimensions
        /// </summary>
        /// <param name="AddSpaces"></param>
        /// <returns>Random characters as string</returns>
        internal static string GenerateRandomText(bool UseNumbers, bool AddSpaces = true)
        {
            StringBuilder sb = new();
            int outputLength = 6;

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            if (UseNumbers)
            {
                chars += "0123456789";
            }

            if (!AddSpaces)
            {
                outputLength = 8;
            }

            for (int i = 0; i < outputLength; i++)
            {
                sb.Append(chars[Random.Shared.Next(chars.Length)]);
                if (i < outputLength && AddSpaces)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}