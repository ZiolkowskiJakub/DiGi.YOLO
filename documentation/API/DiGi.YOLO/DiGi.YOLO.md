#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO Namespace
### Classes

<a name='DiGi.YOLO.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double)'></a>

## Create\.BoundingBox\(double, double, double, double, double, double\) Method

Creates a normalized BoundingBox based on the provided image dimensions and bounding box coordinates\.

```csharp
public static DiGi.YOLO.Classes.BoundingBox? BoundingBox(double imageWidth, double imageHeight, double topLeftX, double topLeftY, double width, double height);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).imageWidth'></a>

`imageWidth` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The total width of the image\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).imageHeight'></a>

`imageHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The total height of the image\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).topLeftX'></a>

`topLeftX` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).topLeftY'></a>

`topLeftY` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.

#### Returns
[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')  
A normalized [BoundingBox\(double, double, double, double, double, double\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double) 'DiGi\.YOLO\.Create\.BoundingBox\(double, double, double, double, double, double\)') instance if all inputs are valid; otherwise, null\.

<a name='DiGi.YOLO.Create.BoundingBoxResult(string)'></a>

## Create\.BoundingBoxResult\(string\) Method

Parses a tab\-separated string into a [BoundingBoxResult\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResult(string) 'DiGi\.YOLO\.Create\.BoundingBoxResult\(string\)') object\.

Numbers are read with [System\.Globalization\.CultureInfo\.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture') because the file is written by predict.py and holds Python floats, which always use a decimal point. Reading them under the current culture rejects every line on a machine whose culture uses a comma, and the caller then sees an empty result rather than an error.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResult? BoundingBoxResult(string? text);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResult(string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The tab\-delimited string containing bounding box data \(name, label index, x, y, width, height, and confidence\)\.

#### Returns
[BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')  
A [BoundingBoxResult\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResult(string) 'DiGi\.YOLO\.Create\.BoundingBoxResult\(string\)') instance if the input is valid; otherwise, `null`\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(string)'></a>

## Create\.BoundingBoxResultFile\(string\) Method

Reads a file from the specified path and parses its contents into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the bounding box result file\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results if the file exists and is valid; otherwise, `null`\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(System.Collections.Generic.IEnumerable_string_)'></a>

## Create\.BoundingBoxResultFile\(IEnumerable\<string\>\) Method

Parses lines of a bounding box result file into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

Lines that do not hold a complete detection are skipped rather than rejecting the whole file. predict.py writes one such line, holding only the image name, for every image it scored and found nothing on.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(System.Collections.Generic.IEnumerable<string>? values);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(System.Collections.Generic.IEnumerable_string_).values'></a>

`values` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines to parse\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results, or `null` when there are no lines to parse\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult)'></a>

## Create\.BoundingBoxResultFile\(this YOLOPredictionResult\) Method

Parses the detections a prediction run produced into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(this DiGi.YOLO.Classes.YOLOPredictionResult? yOLOPredictionResult);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult).yOLOPredictionResult'></a>

`yOLOPredictionResult` [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')

The result of the prediction run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results, or `null` when the run did not complete or produced no result file\.

<a name='DiGi.YOLO.Create.ConfigurationFile(string)'></a>

## Create\.ConfigurationFile\(string\) Method

Parses a configuration file from the specified path and creates a [ConfigurationFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.ConfigurationFile(string) 'DiGi\.YOLO\.Create\.ConfigurationFile\(string\)') instance\.

```csharp
public static DiGi.YOLO.Classes.ConfigurationFile? ConfigurationFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.ConfigurationFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the configuration file\.

#### Returns
[ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')  
A [ConfigurationFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.ConfigurationFile(string) 'DiGi\.YOLO\.Create\.ConfigurationFile\(string\)') object if the file exists and is successfully parsed; otherwise, `null`\.

<a name='DiGi.YOLO.Create.LabelFile(string)'></a>

## Create\.LabelFile\(string\) Method

Parses a YOLO label file from the specified path and returns a LabelFile object containing the bounding boxes\.

```csharp
public static DiGi.YOLO.Classes.LabelFile? LabelFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.LabelFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the label file\.

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
A [LabelFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.LabelFile(string) 'DiGi\.YOLO\.Create\.LabelFile\(string\)') instance if the file exists and contains valid data; otherwise, null\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double)'></a>

## Create\.YOLOPredictionOptions\(string, string, string, string, string, double\) Method

Builds the options for one run of the YOLO prediction script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.

The working directory is not created here. It is created by [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)'), along with the scripts that have to sit in it.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory=null, double confidence=0.1);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the output file\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence threshold a detection has to reach to be reported\.

#### Returns
[YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
The options, or `null` when no interpreter was found, a required path is missing, or the confidence is not a value between zero and one\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int)'></a>

## Create\.YOLOPredictionOptions\(string, string, string, string, string, double, int\) Method

Builds the options for one run of the YOLO prediction script with a custom batch size, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.

The working directory is not created here. It is created by [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)'), along with the scripts that have to sit in it.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory, double confidence, int batchSize);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the output file\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence threshold a detection has to reach to be reported\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images passed to the model in a single inference batch\.

#### Returns
[YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
The options, or `null` when no interpreter was found, a required path is missing, the confidence is not a value between zero and one, or the batch size is less than one\.

<a name='DiGi.YOLO.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string)'></a>

## Modify\.Append\(this BoundingBoxResultFile, string\) Method

Appends the contents of a bounding box result file to a specified file path\.

```csharp
public static bool Append(this DiGi.YOLO.Classes.BoundingBoxResultFile? boundingBoxResultFile, string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).boundingBoxResultFile'></a>

`boundingBoxResultFile` [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')

The collection of bounding box results to append\.

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination file path where data will be appended\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the operation was successful; otherwise, false\.

<a name='DiGi.YOLO.Modify.ClearData(thisDiGi.YOLO.Classes.YOLOModel)'></a>

## Modify\.ClearData\(this YOLOModel\) Method

Clears the data associated with the specified YOLO model, including cache files and images/labels for various categories\.

```csharp
public static bool ClearData(this DiGi.YOLO.Classes.YOLOModel? yOLOModel);
```
#### Parameters

<a name='DiGi.YOLO.Modify.ClearData(thisDiGi.YOLO.Classes.YOLOModel).yOLOModel'></a>

`yOLOModel` [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')

The YOLO model instance whose data should be cleared\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if any files were successfully deleted; otherwise, false\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(string, string, string, string, int, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process with a custom batch size and returns the detections it found\.

A convenience over [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)') for callers that only want the detections. A run that did not complete gives `null`, with no account of why - take the other overload when that matters, which for an unattended run it does.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, int batchSize, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images passed to the model in a single inference batch\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
The detections, or `null` when the options could not be built or the run did not complete\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(string, string, string, string, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process and returns the detections it found\.

A convenience over [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)') for callers that only want the detections. A run that did not complete gives `null`, with no account of why - take the other overload when that matters, which for an unattended run it does.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
The detections, or `null` when the options could not be built or the run did not complete\.

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(this YOLOPredictionOptions, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process and reports how the run went\.

The scripts are laid down in the working directory when they are not already there, a stale result file is removed so a failed run cannot be mistaken for this one, and the process is then run with its output streams captured. A source directory holding no images is answered without starting a process at all, because predict.py writes no result file in that case and the missing file would otherwise be indistinguishable from a crash.

The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing. Only the interpreter is killed - this targets netstandard2.0, which has no overload for killing a whole process tree, so torch worker processes can outlive the cancellation.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionResult? Predict(this DiGi.YOLO.Classes.YOLOPredictionOptions? yOLOPredictionOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken).yOLOPredictionOptions'></a>

`yOLOPredictionOptions` [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')

The settings for the run\.

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')  
The result of the run, or `null` when the options are missing the interpreter, the weights, the source directory or the output path\.

<a name='DiGi.YOLO.Modify.Read(string)'></a>

## Modify\.Read\(string\) Method

Reads a YOLO model configuration and associated image and label files from the specified path\.

```csharp
public static DiGi.YOLO.Classes.YOLOModel? Read(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Read(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the configuration file\.

#### Returns
[YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')  
A [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') instance if the configuration is valid and found; otherwise, null\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string)'></a>

## Modify\.Write\(this BoundingBoxResultFile, string\) Method

Writes the contents of a bounding box result file to the specified file path\.

```csharp
public static bool Write(this DiGi.YOLO.Classes.BoundingBoxResultFile? boundingBoxResultFile, string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).boundingBoxResultFile'></a>

`boundingBoxResultFile` [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')

The collection of bounding box results to write\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination file path where the results will be saved\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the file was written successfully; otherwise, false\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.YOLOModel)'></a>

## Modify\.Write\(this YOLOModel\) Method

Writes the YOLO model data, including configuration files, images, and labels, to the filesystem\.

```csharp
public static bool Write(this DiGi.YOLO.Classes.YOLOModel? yOLOModel);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.YOLOModel).yOLOModel'></a>

`yOLOModel` [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')

The YOLO model instance containing the data to be written\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the writing process was successful; otherwise, false\.

<a name='DiGi.YOLO.Modify.WriteScripts(string)'></a>

## Modify\.WriteScripts\(string\) Method

Writes the YOLO Python runner scripts and configuration files into the specified directory\.

The scripts ship inside this assembly, so this works in any host that loads it. A YOLO folder sitting beside the assembly is used in preference, which lets a script be edited in a build output and tried without rebuilding.

predict.py imports utils.py, and Python resolves that against the directory the script sits in, so the files are only useful written together.

```csharp
public static bool WriteScripts(string? directory);
```
#### Parameters

<a name='DiGi.YOLO.Modify.WriteScripts(string).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target directory path where scripts will be written\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if every script file was written; otherwise, false\.

<a name='DiGi.YOLO.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.YOLO.Query.Decode(string)'></a>

## Query\.Decode\(string\) Method

Decodes a given path string by replacing URL\-encoded spaces with actual spaces and converting forward slashes to backslashes\.

```csharp
public static string? Decode(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.Decode(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The encoded path string to be decoded\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The decoded path string, or an empty string if the provided path is null or whitespace\.

<a name='DiGi.YOLO.Query.DirectoryName(thisDiGi.YOLO.Enums.Category)'></a>

## Query\.DirectoryName\(this Category\) Method

Returns the directory name associated with the specified category\.

```csharp
public static string? DirectoryName(this DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Query.DirectoryName(thisDiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the directory name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string representing the directory name \(e\.g\., "val", "train", "test"\), or `null` if no mapping is found\.

<a name='DiGi.YOLO.Query.Encode(string)'></a>

## Query\.Encode\(string\) Method

Encodes a given path string by replacing spaces with "%20" and backslashes with forward slashes\.

```csharp
public static string Encode(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.Encode(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path string to be encoded\. This value can be null\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
An encoded version of the path, or an empty string if the provided path is null or whitespace\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken)'></a>

## Query\.ExecuteProcess\(string, string, string, CancellationToken\) Method

Executes a process with captured standard output and standard error streams while supporting cancellation\.

Launches the process without creating a window, using UTF-8 encodings for both streams. Reading both streams asynchronously prevents deadlocks when process output buffers fill up.

```csharp
public static (int ExitCode,System.Collections.Generic.List<string> StandardOutput,System.Collections.Generic.List<string> StandardError) ExecuteProcess(string executablePath, string arguments, string workingDirectory, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).executablePath'></a>

`executablePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the executable process to run\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The command line arguments passed to the process\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory context for the process execution\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels process execution\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the process exit code, standard output lines, and standard error lines\.

<a name='DiGi.YOLO.Query.NormalizedPath(string)'></a>

## Query\.NormalizedPath\(string\) Method

Returns the full form of a path with any trailing directory separator removed\.

The separator matters because these paths are handed to a process on its command line. On Windows a backslash immediately before a closing quote escapes that quote, so a directory written as "C:\scratch\" swallows the argument that follows it and the process sees something entirely different from what was intended.

A root such as "C:\" keeps its separator, because removing it would leave a drive letter that names the current directory of that drive rather than its root.

```csharp
public static string? NormalizedPath(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.NormalizedPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to normalize\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The normalized path, or `null` when the path is null, empty, or cannot be resolved to a full path\.

<a name='DiGi.YOLO.Query.PythonPath(string)'></a>

## Query\.PythonPath\(string\) Method

Resolves the CPython interpreter that runs the YOLO scripts\.

A path that names an existing file is taken as given. Anything else, including `null`, is looked for on PATH, trying "python" and then "python3", in PATH order.

A Windows app execution alias is accepted like any other match even though it is a zero byte reparse point, because it is a working interpreter whenever its app is installed. When the app is not installed the alias opens the Microsoft Store instead and the run fails; that failure is reported through the result's standard error rather than avoided by guessing.

The interpreter has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them, so it is not an alternative to this.

```csharp
public static string? PythonPath(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.PythonPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of an interpreter, the name of one on PATH, or `null` to search for one\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The full path of the interpreter, or `null` when none was found\.

<a name='DiGi.YOLO.Query.PythonPaths(string)'></a>

## Query\.PythonPaths\(string\) Method

Resolves all potential CPython interpreter candidate paths on PATH\.

If [path](DiGi.YOLO.md#DiGi.YOLO.Query.PythonPaths(string).path 'DiGi\.YOLO\.Query\.PythonPaths\(string\)\.path') names an existing file, it is returned as the single candidate. Otherwise, PATH is searched for [path](DiGi.YOLO.md#DiGi.YOLO.Query.PythonPaths(string).path 'DiGi\.YOLO\.Query\.PythonPaths\(string\)\.path') (if provided), "python", and "python3" in order, returning all distinct existing candidates found.

```csharp
public static System.Collections.Generic.List<string> PythonPaths(string? path=null);
```
#### Parameters

<a name='DiGi.YOLO.Query.PythonPaths(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of an interpreter, the command name of one on PATH, or `null` to search PATH\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of distinct resolved interpreter paths in search order\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken)'></a>

## Query\.YOLOEnvironmentResult\(string, string, string, CancellationToken\) Method

Probes Python interpreter candidates in a specified working directory context to detect whether the machine can execute YOLO workloads\.

```csharp
public static DiGi.YOLO.Classes.YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, string? workingDirectory, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, a command name on PATH, or `null` to search PATH\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained model file to probe for compatibility, or `null`\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory where scripts are written and executed, or `null` to use temporary storage\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels probing\.

#### Returns
[YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')  
The result of the environment preflight check\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken)'></a>

## Query\.YOLOEnvironmentResult\(string, string, CancellationToken\) Method

Probes Python interpreter candidates to detect whether the machine can execute YOLO workloads, returning environment details and dependency versions\.

Checks candidate interpreters on PATH in order and reports the first interpreter that is runnable. Never throws an exception; probe failures or invalid interpreters are returned with [Runnable](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Runnable') set to `false` and diagnostic reasons in [Messages](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Messages 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Messages'). Non-fatal findings are returned in [Warnings](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Warnings 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Warnings') and do not affect [Runnable](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Runnable').

```csharp
public static DiGi.YOLO.Classes.YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, a command name on PATH, or `null` to search PATH\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained model file to probe for compatibility, or `null`\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels probing\.

#### Returns
[YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')  
The result of the environment preflight check\.