namespace BlazorVerificationCaptcha
{
    partial class VerificationCaptcha
    {
        public static string CaptchaBackup
        {
            get
            {
                return RenewCaptchaContent();
            }
        }

        private static string imageURL = string.Empty;

        private static string RenewCaptchaContent()
        {
            (string image, string text) ImageText = CaptchaGenerator.GenerateCaptcha();
            imageURL = ImageText.image;

            return ImageText.text.Replace(" ", string.Empty);
        }
    }
}