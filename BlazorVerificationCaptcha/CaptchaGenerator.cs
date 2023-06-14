using SkiaSharp;

namespace BlazorVerificationCaptcha
{
    public static class CaptchaGenerator
    {
        /// <summary>
        /// The generator is subject to change, I want to make it more difficult to read the captcha-content
        /// </summary>
        /// <returns>Image as base64</returns>
        public static (string imagevalue, string textvalue) GenerateCaptcha(bool IncludeNumbers, string TypefaceFamilyName)
        {
            const int width = 200;
            const int height = 50;

            string captchaText = Tools.GenerateRandomText(IncludeNumbers);

            using SKBitmap bitmap = new(width, height);
            using SKCanvas canvas = new(bitmap);

            using SKPaint paint = new();
            canvas.Clear(RandomColor(false));

            paint.TextSize = RandomFloatValue(19, 25);
            paint.Color = SKColors.Black;

            using (SKTypeface typeface = SKTypeface.FromFamilyName(TypefaceFamilyName))
            using (SKFont font = new(typeface, paint.TextSize))
            {
                paint.ImageFilter = SKImageFilter.CreateBlur(1, 1);
                paint.FilterQuality = SKFilterQuality.Low;

                paint.TextSkewX = 1;
                canvas.DrawText(captchaText, RandomFloatValue(44, 62), RandomFloatValue(26, 35), paint);

                RandomNumbersAndText(canvas, paint);
            }

            using SKImage image = SKImage.FromBitmap(bitmap);
            using SKData data = image.Encode(SKEncodedImageFormat.Jpeg, 100);

            return (ConvStreamToBase64(data), captchaText);
        }

        private static void RandomNumbersAndText(SKCanvas canvas, SKPaint paint)
        {
            paint.TextSize = 12;
            paint.Color = RandomColor();

            canvas.DrawText(Convert.ToString(RandomFloatValue(0, 99)), 20, 20, paint);
            paint.Color = RandomColor();

            paint.TextSize = 10;
            canvas.DrawText(Convert.ToString(RandomFloatValue(99, 199)), 20, 40, paint);

            paint.TextSize = 11;
            paint.Color = RandomColor();

            canvas.DrawText(Convert.ToString(RandomFloatValue(199, 299)), 175, 20, paint);
            paint.Color = RandomColor();

            canvas.DrawText(Convert.ToString(RandomFloatValue(299, 399)), 175, 33, paint);
            paint.TextSize = 13;

            paint.Color = RandomColor();
            canvas.DrawText(Tools.GenerateRandomText(false), 80, RandomFloatValue(48, 54), paint);
        }

        private static string ConvStreamToBase64(SKData data)
        {
            MemoryStream ms = new();
            data.SaveTo(ms);

            byte[] byteArray = ms.ToArray();
            string b64String = Convert.ToBase64String(byteArray);

            return $"data:image/jpg;base64,{b64String}";
        }

        private static float RandomFloatValue(int min, int max)
        {
            return Random.Shared.Next(min, max);
        }

        private static SKColor RandomColor(bool IsForegroundColorNeeded = true)
        {
            if (IsForegroundColorNeeded)
            {
                SKColor[] ForegroundColors = new SKColor[] { SKColors.Black, SKColors.DarkBlue, SKColors.DarkGreen, SKColors.DarkViolet };
                return ForegroundColors[Random.Shared.Next(ForegroundColors.Length)];
            }

            SKColor[] BackgroundColors = new SKColor[] { SKColors.White, SKColors.Yellow, SKColors.LightBlue, SKColors.OrangeRed };
            return BackgroundColors[Random.Shared.Next(BackgroundColors.Length)];
        }
    }
}