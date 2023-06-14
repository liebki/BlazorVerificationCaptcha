namespace BlazorVerificationCaptcha
{
    partial class VerificationCaptcha
    {
        private static string imageURL = string.Empty;

        public static string GenerateCaptchaContent(bool IncludeNumbers = true, string TypefaceFamilyName = "Arial")
        {
            (string image, string text) = CaptchaGenerator.GenerateCaptcha(IncludeNumbers, TypefaceFamilyName);
            imageURL = image;

            return text.Replace(" ", string.Empty);
        }
    }
}