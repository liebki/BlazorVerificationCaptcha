# BlazorVerificationCaptcha

The BlazorVerificationCaptcha project offers a seamless solution for integrating CAPTCHA verification into Blazor applications. Utilizing this package allows developers to quickly and effortlessly enhance their application's security by verifying users and safeguarding against automated bots.

###### Check it out on GitHub: https://github.com/liebki/BlazorVerificationCaptcha


## Technologies

### Created using
- .NET Core 6.0


### NuGet/Dependencies used
- [SkiaSharp](https://www.nuget.org/packages/SkiaSharp/)
- [SkiaSharp.NativeAssets.Linux.NoDependencies](https://www.nuget.org/packages/SkiaSharp.NativeAssets.Linux.NoDependencies/) - This is only needed for deployment on Linux machines (FAQ down below)


## Features

### Nuget
- BlazorVerificationCaptcha package is available on NuGet: [BlazorVerificationCaptcha](https://www.nuget.org/packages/BlazorVerificationCaptcha)


### General
- Provides a simple and easy-to-use solution for implementing captcha verification in Blazor applications.
- You can change the image quality, length of the captcha text, what should be displayed, make it easier or harder to read etc.


## Screenshots

A GIF, to see the image and variable content change on page reload

![Animated](https://i.imgur.com/t5VveOb.gif)

A image, to get the original quality that the image is displayed in

![Static](https://i.imgur.com/VYvvyhv.png)


## Usage (For more, see examples)

To seamlessly integrate BlazorVerificationCaptcha into your Blazor application, follow these simple steps:

1. **Install the Package**: Begin by installing the BlazorVerificationCaptcha package from NuGet. This can be done using your preferred package manager.

2. **Import the Namespace**: In your Blazor project, add `@using BlazorVerificationCaptcha` to the `_Imports.razor` file. This enables you to use the package's features throughout your application.

3. **Implement the Captcha Component**: Integrate the CAPTCHA component by placing the `<VerificationCaptcha />` tag in the desired location within your Blazor components. This tag will render the CAPTCHA image.

4. **Generate CAPTCHA Content**: Inside the `OnInitializedAsync()` method or another suitable lifecycle method, include the code snippet `ExampleVariable = VerificationCaptcha.GenerateCaptchaContent();`. This line of code generates the CAPTCHA image and text content, which can be used as needed in your application.

By following these steps, you'll effectively incorporate BlazorVerificationCaptcha to enhance security and user interaction in your Blazor application.

For more comprehensive examples and usage scenarios, refer to the examples section below.


## Example (Component)

### Parameters

The `GenerateCaptchaContent` method inside the `VerificationCaptcha` class, allows you to generate CAPTCHA content, which includes both an image and the corresponding text. The method provides several customizable options to tailor the generated CAPTCHA according to your needs:

- `IncludeNumbers` (Optional, default: `true`):
  Set this parameter to `true` if you want to include numbers in the CAPTCHA text. If set to `false`, only alphabetic characters will be used in the text.

- `TypefaceFamilyName` (Optional, default: "Arial"):
  Specify the font family name for the CAPTCHA text. You can set this parameter to the desired font family name that suits your application's visual style.

- `CaptchaLength` (Optional, default: `6`):
  This parameter determines the desired length of the CAPTCHA text. You can set it to any positive integer value to control the length of the generated text.

- `JpegQualityLevel` (Optional, default: `100`):
  The JPEG quality level for image encoding defines the level of compression applied to the generated CAPTCHA image. Higher values result in higher image quality and larger file sizes, while lower values decrease image quality and file size.

- `ReduceRandomCharacters` (Optional, default: `false`):
  When this parameter is set to `true`, certain characters in the generated image will have reduced randomness. This can make the CAPTCHA text slightly more readable and easier to solve for users.

Example call using all parameters: `VerificationCaptcha.GenerateCaptchaContent(IncludeNumbers: false, TypefaceFamilyName: "Verdana", CaptchaLength: 10, JpegQualityLevel: 80, ReduceRandomCharacters: true);`

Here is an example of how you can use BlazorVerificationCaptcha in your Blazor component:

```
<VerificationCaptcha />

@code {

    private string ExampleVariable;

    protected override Task OnInitializedAsync()
    {
        ExampleVariable = VerificationCaptcha.GenerateCaptchaContent();
        return base.OnInitializedAsync();
    }
}
```


## Example (Generator)

Here is an example of how you can use the generator without the component, to get the values and display it by yourself

```
<p>@ExampleVariable.Text</p>
<p>@ExampleVariable.Image</p>

@code {

    private (string Image, string Text) ExampleVariable;

    protected override Task OnInitializedAsync()
    {
        ExampleVariable = CaptchaGenerator.GenerateCaptcha();
        return base.OnInitializedAsync();
    }
}
```

This example doesn't show how to handle checking if the captcha is correct but you have the ExampleVariable, so 
you can easily just do ```if(ExampleVariable.Equals(ExampleInputVariable, StringComparison.InvariantCulture))```.


## FAQ

#### Notes on Linux

Should the captcha only show colored backgrounds without any content, this can be resolved by installing the aforementioned dependencies.

This application is intended to be able to run on a Linux environment (for ASP-Hosting etc.). Please take note of the following important considerations:

1. **Dependencies**: In order to ensure smooth functionality, it is essential to install the following dependencies on your Linux system:
   - fontconfig
   - freetype
   - freetype-devel
   - fontconfig-devel
   - libstdc++

2. **Installation**: On CentOS I installed the required packages by executing the following command in your terminal: ```yum install fontconfig freetype freetype-devel fontconfig-devel libstdc++```


#### What do I have to be aware of?

The image is displayed as base64, I'm working on another way propably JavaScript.


## License

**Software:** BlazorVerificationCaptcha

License: [GNU General Public License v3.0](https://choosealicense.com/licenses/gpl-3.0/)


## Roadmap

- Implement an alternative way to display the captcha image, besides base64 (even tho I don't think there is an better way).
- Allow customization of the captcha length, dimension etc.
- Maybe implement features for barrier free things like text2speech etc.