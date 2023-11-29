# VintaSoft WinForms Icon Editor Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to edit multipage icon (.ico) file:
* Create, load, add page and save ICO and CUR file.
* Navigate images in ICO file: first, previous, next, last.
* Edit image's pixels color by clicking right or left mouse buttons.
* Specify hotspot for CUR images.
* Edit palette of 4-bit and 8-bit images.
* Zoom-in and zoom-out images.


## Screenshot
<img src="vintasoft-icon-editor-demo.jpg" title="VintaSoft Icon Editor Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("IconEditorDemo.Net8.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build IconEditorDemo.Net8.csproj
   ```

4. Run compiled application and try to edit multipage icon (.ico) file.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
