#### [DiGi\.YOLO](index.md 'index')

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

Reads a file from the specified path and parses its contents into a [BoundingBoxResultFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResultFile(string) 'DiGi\.YOLO\.Create\.BoundingBoxResultFile\(string\)') collection\.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the bounding box result file\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResultFile(string) 'DiGi\.YOLO\.Create\.BoundingBoxResultFile\(string\)') instance containing the parsed results if the file exists and is valid; otherwise, `null`\.

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