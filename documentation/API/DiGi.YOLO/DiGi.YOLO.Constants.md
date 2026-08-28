#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Constants Namespace
### Classes

<a name='DiGi.YOLO.Constants.Count'></a>

## Count Class

Provides constant counts used to bound the data collected while running the YOLO scripts\.

```csharp
public static class Count
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Count
### Fields

<a name='DiGi.YOLO.Constants.Count.OutputLines'></a>

## Count\.OutputLines Field

The number of trailing lines kept from each of the prediction process output streams\.

predict.py prints a line for every image it processes and ultralytics prints more on top of that, so a county sized run writes megabytes to its output streams. Only the tail is kept, because that is the part carrying the reason a run ended the way it did.

```csharp
public const int OutputLines = 200;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Constants.DirectoryName'></a>

## DirectoryName Class

Provides constant values for standard directory names used in YOLO dataset structures\.

```csharp
public static class DirectoryName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DirectoryName
### Fields

<a name='DiGi.YOLO.Constants.DirectoryName.Images'></a>

## DirectoryName\.Images Field

The name of the directory containing image files\.

```csharp
public const string Images = "images";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.Labels'></a>

## DirectoryName\.Labels Field

The name of the directory containing label files\.

```csharp
public const string Labels = "labels";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.YOLO'></a>

## DirectoryName\.YOLO Field

The name of the directory containing YOLO deployment scripts and configuration files\.

```csharp
public const string YOLO = "YOLO";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileExtension'></a>

## FileExtension Class

Provides constant values for file extensions used across the application\.

```csharp
public static class FileExtension
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileExtension
### Fields

<a name='DiGi.YOLO.Constants.FileExtension.BoundingBoxResultFile'></a>

## FileExtension\.BoundingBoxResultFile Field

The file extension associated with bounding box result files\.

```csharp
public const string BoundingBoxResultFile = "bbrf";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName'></a>

## FileName Class

Provides constant values for file names used in YOLO runner scripts and configuration files\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.YOLO.Constants.FileName.Check'></a>

## FileName\.Check Field

The file name of the preflight check script\.

```csharp
public const string Check = "check.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Conf'></a>

## FileName\.Conf Field

The file name of the dataset configuration YAML file\.

```csharp
public const string Conf = "conf.yaml";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Predict'></a>

## FileName\.Predict Field

The file name of the prediction runner script\.

```csharp
public const string Predict = "predict.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Requirements'></a>

## FileName\.Requirements Field

The file name of the Python dependencies requirements file\.

```csharp
public const string Requirements = "requirements.txt";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Train'></a>

## FileName\.Train Field

The file name of the training runner script\.

```csharp
public const string Train = "train.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Utils'></a>

## FileName\.Utils Field

The file name of the utility script\.

```csharp
public const string Utils = "utils.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')