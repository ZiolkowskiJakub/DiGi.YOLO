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

<a name='DiGi.YOLO.Constants.DirectoryName.Models'></a>

## DirectoryName\.Models Field

The name of the directory, directly inside a [YOLO](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.DirectoryName.YOLO 'DiGi\.YOLO\.Constants\.DirectoryName\.YOLO') folder, holding the frozen weights \(model\.pt and the pretrained base checkpoints\)\.

No training run may write into it; see [IsInsideModelsDirectory\(string\)](DiGi.YOLO.md#DiGi.YOLO.Query.IsInsideModelsDirectory(string) 'DiGi\.YOLO\.Query\.IsInsideModelsDirectory\(string\)').

```csharp
public const string Models = "models";
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

<a name='DiGi.YOLO.Constants.DirectoryName.YoloConfig'></a>

## DirectoryName\.YoloConfig Field

The name of the directory holding the ultralytics settings isolated to the working directory a run executes in\.

Each run points the YOLO_CONFIG_DIR environment variable at this folder, so the settings file an ultralytics version reads and writes lives in the working directory instead of the shared machine-wide one. Without it, switching ultralytics versions between runs rewrites the other's settings, prints a settings notice on stdout and loses custom values such as runs_dir.

```csharp
public const string YoloConfig = ".yolo-config";
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

<a name='DiGi.YOLO.Constants.FileName.Export'></a>

## FileName\.Export Field

The file name of the ONNX export script\.

```csharp
public const string Export = "export.py";
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

<a name='DiGi.YOLO.Constants.FileName.Validate'></a>

## FileName\.Validate Field

The file name of the validation runner script\.

```csharp
public const string Validate = "val.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker'></a>

## Marker Class

Provides constant values for the stdout contract of the preflight check script\.

```csharp
public static class Marker
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Marker
### Fields

<a name='DiGi.YOLO.Constants.Marker.CheckJsonBegin'></a>

## Marker\.CheckJsonBegin Field

The line check\.py prints immediately before its JSON payload\.

The payload is the first non-empty line between this marker and [CheckJsonEnd](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonEnd 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonEnd'), so a caller finds it without depending on what the interpreter or ultralytics print first - a settings notice included. The markers and their use are stated in check.py in files/YOLO.

```csharp
public const string CheckJsonBegin = "YOLO_CHECK_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker.CheckJsonEnd'></a>

## Marker\.CheckJsonEnd Field

The line check\.py prints immediately after its JSON payload\.

Paired with [CheckJsonBegin](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonBegin 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonBegin'); see check.py in files/YOLO.

```csharp
public const string CheckJsonEnd = "YOLO_CHECK_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix'></a>

## OutputPrefix Class

Provides the line prefixes the training and validation scripts print their results under, shared by the scripts' output contract and the parsers that read it back\.

```csharp
public static class OutputPrefix
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OutputPrefix
### Fields

<a name='DiGi.YOLO.Constants.OutputPrefix.AMP'></a>

## OutputPrefix\.AMP Field

The prefix of the line train\.py prints the automatic mixed precision actually used under, True or False\.

```csharp
public const string AMP = "AMP:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.Bytes'></a>

## OutputPrefix\.Bytes Field

The prefix of the line train\.py and export\.py print the size of the written file under, in bytes\.

```csharp
public const string Bytes = "Bytes:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.MAP50'></a>

## OutputPrefix\.MAP50 Field

The prefix of the line val\.py prints the box mAP at IoU 0\.5 under\.

```csharp
public const string MAP50 = "mAP50:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.MAP50_95'></a>

## OutputPrefix\.MAP50\_95 Field

The prefix of the line val\.py prints the box mAP averaged over IoU 0\.5 to 0\.95 under\.

```csharp
public const string MAP50_95 = "mAP50-95:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.SHA256'></a>

## OutputPrefix\.SHA256 Field

The prefix of the line train\.py and export\.py print the lowercase hexadecimal SHA\-256 digest of the written file under\.

```csharp
public const string SHA256 = "SHA256:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.Weights'></a>

## OutputPrefix\.Weights Field

The prefix of the line train\.py prints the path of the best weights file under\.

```csharp
public const string Weights = "Weights:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')