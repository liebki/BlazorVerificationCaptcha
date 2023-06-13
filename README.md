# BlazorVerificationCaptcha

A simple solution to verify users using a simple captcha with a current limit of six characters (changed in next update).

## Technologies

### Created using
- .NET Core 6.0

### NuGet/Dependencies used
- [SkiaSharp](https://www.nuget.org/packages/SkiaSharp/)

## Features

### Nuget
- BlazorVerificationCaptcha package is available on NuGet: [BlazorVerificationCaptcha](https://www.nuget.org/packages/BlazorVerificationCaptcha)

### General
- Provides a simple and easy-to-use solution for implementing captcha verification in Blazor applications.
- The current version supports a captcha length of up to six characters.

## Usage (For more, see examples)

To use BlazorVerificationCaptcha in your Blazor application, follow these steps:

1. Install the BlazorVerificationCaptcha package from NuGet.
2. Add ```@using BlazorVerificationCaptcha``` inside the _Imports.razor
3. Implement the captcha component in your desired location, by adding ```<VerificationCaptcha />```
4. Add ```ExampleVariable = VerificationCaptcha.CaptchaBackup;``` inside ```OnInitializedAsync()```, as this code generates the image

## Example (Component)

Here is an example of how you can use BlazorVerificationCaptcha in your Blazor component:

```
<VerificationCaptcha />

@code {

    private string ExampleVariable;

    protected override Task OnInitializedAsync()
    {
        ExampleVariable = VerificationCaptcha.CaptchaBackup;
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

#### What do I have to be aware of?

The image is displayed using base64, which adds some overhead. You should test if this method meets your requirements. In future updates, an alternative way of displaying the captcha image will be implemented.

## License

**Software:** BlazorVerificationCaptcha

License: [GNU General Public License v3.0](https://choosealicense.com/licenses/gpl-3.0/)

## Roadmap

- Implement an alternative way to display the captcha image, besides base64
- Allow customization of the captcha length, dimension etc.
- Maybe implement features for barrier free things like text2speech etc.