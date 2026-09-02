#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Classes Namespace
### Classes

<a name='DiGi.YOLO.Classes.BoundingBox'></a>

## BoundingBox Class

Represents a rectangular bounding box used to define the location and size of an object within an image\.

```csharp
public class BoundingBox : DiGi.YOLO.Interfaces.IBoundingBox
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BoundingBox

Derived  
↳ [BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')

Implements [IBoundingBox](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox 'DiGi\.YOLO\.Interfaces\.IBoundingBox')
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double)'></a>

## BoundingBox\(double, double, double, double\) Constructor

Initializes a new instance of the [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') class\.

```csharp
public BoundingBox(double x, double y, double width, double height);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The x\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The y\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.
### Properties

<a name='DiGi.YOLO.Classes.BoundingBox.Height'></a>

## BoundingBox\.Height Property

Gets the height of the bounding box\.

```csharp
public double Height { get; }
```

Implements [Height](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Height 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Height')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.Width'></a>

## BoundingBox\.Width Property

Gets the width of the bounding box\.

```csharp
public double Width { get; }
```

Implements [Width](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Width 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Width')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.X'></a>

## BoundingBox\.X Property

Gets the x\-coordinate of the top\-left corner of the bounding box\.

```csharp
public double X { get; }
```

Implements [X](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.X 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.X')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.Y'></a>

## BoundingBox\.Y Property

Gets the y\-coordinate of the top\-left corner of the bounding box\.

```csharp
public double Y { get; }
```

Implements [Y](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Y 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Y')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')
### Methods

<a name='DiGi.YOLO.Classes.BoundingBox.Equals(object)'></a>

## BoundingBox\.Equals\(object\) Method

Determines whether the specified object is equal to the current bounding box based on its coordinates and dimensions\.

```csharp
public override bool Equals(object? @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBox.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current bounding box\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the objects are equal; otherwise, false\.

<a name='DiGi.YOLO.Classes.BoundingBox.GetHashCode()'></a>

## BoundingBox\.GetHashCode\(\) Method

Returns a hash code for the current bounding box based on its coordinates and dimensions\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A hash code for the current object\.

<a name='DiGi.YOLO.Classes.BoundingBox.ToString()'></a>

## BoundingBox\.ToString\(\) Method

Returns a string that represents the current bounding box in the format "x y width height"\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string representation of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult'></a>

## BoundingBoxResult Class

Represents the result of a bounding box detection, containing spatial coordinates, label information, and confidence score\.

```csharp
public class BoundingBoxResult : DiGi.YOLO.Classes.BoundingBox
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') → BoundingBoxResult
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double)'></a>

## BoundingBoxResult\(string, int, double, double, double, double, double\) Constructor

Initializes a new instance of the [BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult') class\.

```csharp
public BoundingBoxResult(string? name, int labelIndex, double x, double y, double width, double height, double confidence);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the detected object\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label associated with the detection\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X coordinate of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y coordinate of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence score of the detection\.
### Properties

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Confidence'></a>

## BoundingBoxResult\.Confidence Property

Gets the confidence score of the detected object\.

```csharp
public double Confidence { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBoxResult.LabelIndex'></a>

## BoundingBoxResult\.LabelIndex Property

Gets the index of the label for the detected object\.

```csharp
public int LabelIndex { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Name'></a>

## BoundingBoxResult\.Name Property

Gets the name of the detected object\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Equals(object)'></a>

## BoundingBoxResult\.Equals\(object\) Method

Determines whether the specified object is equal to the current bounding box result based on its properties\.

```csharp
public override bool Equals(object? @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current object\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the objects are equal; otherwise, `false`\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.GetHashCode()'></a>

## BoundingBoxResult\.GetHashCode\(\) Method

Gets the hash code for the current bounding box result\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer hash code\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.ToString()'></a>

## BoundingBoxResult\.ToString\(\) Method

Returns a string representation of the bounding box result, including name, label index, coordinates, dimensions, and confidence\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A tab\-separated string containing the detection details\.

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile'></a>

## BoundingBoxResultFile Class

Represents a collection of bounding box results typically associated with a result file\.

```csharp
public class BoundingBoxResultFile : System.Collections.Generic.List<DiGi.YOLO.Classes.BoundingBoxResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1') → BoundingBoxResultFile
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile.BoundingBoxResultFile()'></a>

## BoundingBoxResultFile\(\) Constructor

Initializes a new instance of the [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') class\.

```csharp
public BoundingBoxResultFile();
```
### Methods

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile.ToString()'></a>

## BoundingBoxResultFile\.ToString\(\) Method

Returns a string representation of the bounding box results contained in the file, 
with each result on a new line\.

```csharp
public override string? ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the concatenated string representations of all valid bounding box results\.

<a name='DiGi.YOLO.Classes.ConfigurationFile'></a>

## ConfigurationFile Class

Represents the configuration settings for a YOLO project, including directory paths and labels\.

```csharp
public class ConfigurationFile
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ConfigurationFile
### Constructors

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile()'></a>

## ConfigurationFile\(\) Constructor

Initializes a new instance of the [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') class\.

```csharp
public ConfigurationFile();
```

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_)'></a>

## ConfigurationFile\(string, string, string, string, IEnumerable\<Label\>\) Constructor

Initializes a new instance of the [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') class with specified directory paths and labels\.

```csharp
public ConfigurationFile(string? directory, string? trainDirectoryName, string? validateDirectoryName, string? testDirectoryName, System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label>? labels);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base root directory path\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).trainDirectoryName'></a>

`trainDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the training directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).validateDirectoryName'></a>

`validateDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the validation directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).testDirectoryName'></a>

`testDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the test directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).labels'></a>

`labels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of labels to be associated with this configuration\.
### Properties

<a name='DiGi.YOLO.Classes.ConfigurationFile.Directory'></a>

## ConfigurationFile\.Directory Property

Gets the base root directory path\.

```csharp
public string? Directory { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.ConfigurationFile.Labels'></a>

## ConfigurationFile\.Labels Property

Gets the collection of labels associated with this configuration\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label> Labels { get; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')
### Methods

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetCategories()'></a>

## ConfigurationFile\.GetCategories\(\) Method

Retrieves all categories defined within the configuration\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category> GetCategories();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') values\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectory(DiGi.YOLO.Enums.Category)'></a>

## ConfigurationFile\.GetDirectory\(Category\) Method

Gets the full combined path for a specific category\.

```csharp
public string? GetDirectory(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectory(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the full directory path\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute path combining the base directory and the category folder, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if not found or empty\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectoryNames(DiGi.YOLO.Enums.Category)'></a>

## ConfigurationFile\.GetDirectoryNames\(Category\) Method

Gets the relative directory name for a specific category\.

```csharp
public string? GetDirectoryNames(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectoryNames(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the folder name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The relative directory name, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if not found or empty\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ToString()'></a>

## ConfigurationFile\.ToString\(\) Method

Returns a string representation of the configuration file, formatted for output or storage\.

```csharp
public override string? ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A formatted string containing the base path, category paths, and label names\.

<a name='DiGi.YOLO.Classes.Image'></a>

## Image Class

Represents an image associated with a collection of [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') instances\.

```csharp
public class Image : DiGi.YOLO.Classes.Image<DiGi.YOLO.Classes.BoundingBox>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.YOLO\.Classes\.Image&lt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>') → Image
### Constructors

<a name='DiGi.YOLO.Classes.Image.Image(string)'></a>

## Image\(string\) Constructor

Initializes a new instance of the [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') class\.

```csharp
public Image(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image.Image(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path to the image\.
### Methods

<a name='DiGi.YOLO.Classes.Image.GetLabelFile()'></a>

## Image\.GetLabelFile\(\) Method

Creates and populates a [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') containing all bounding boxes associated with this image\.

```csharp
public DiGi.YOLO.Classes.LabelFile GetLabelFile();
```

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
A [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') instance populated with the image's bounding box data\.

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_'></a>

## Image\<TBoundingBox\> Class

Represents an image associated with a collection of bounding boxes categorized by label indices\.

```csharp
public class Image<TBoundingBox>
    where TBoundingBox : DiGi.YOLO.Interfaces.IBoundingBox
```
#### Type parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox'></a>

`TBoundingBox`

The type of the bounding box, which must implement [IBoundingBox](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox 'DiGi\.YOLO\.Interfaces\.IBoundingBox')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Image\<TBoundingBox\>

Derived  
↳ [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')
### Constructors

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Image(string)'></a>

## Image\(string\) Constructor

Initializes a new instance of the [Image&lt;TBoundingBox&gt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>') class\.

```csharp
public Image(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Image(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path to the image\.
### Fields

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.boundingBoxes'></a>

## Image\<TBoundingBox\>\.boundingBoxes Field

The dictionary containing bounding boxes grouped by label indices\.

```csharp
protected Dictionary<int,HashSet<TBoundingBox>> boundingBoxes;
```

#### Field Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.path'></a>

## Image\<TBoundingBox\>\.path Field

The file path to the image\.

```csharp
protected string? path;
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Properties

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.LabelIndexes'></a>

## Image\<TBoundingBox\>\.LabelIndexes Property

Gets the collection of label indices that have associated bounding boxes in this image\.

```csharp
public System.Collections.Generic.IEnumerable<int> LabelIndexes { get; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Path'></a>

## Image\<TBoundingBox\>\.Path Property

Gets the file path of the image\.

```csharp
public string? Path { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.this[int]'></a>

## Image\<TBoundingBox\>\.this\[int\] Property

Gets the set of bounding boxes associated with the specified label index\.

```csharp
public System.Collections.Generic.IEnumerable<TBoundingBox>? this[int labelIndex] { get; }
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.this[int].labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label to retrieve bounding boxes for\.

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')
### Methods

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox)'></a>

## Image\<TBoundingBox\>\.Add\(int, TBoundingBox\) Method

Adds a bounding box to the image for the specified label index\.

```csharp
public bool Add(int labelIndex, TBoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label\.

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox).boundingBox'></a>

`boundingBox` [TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')

The bounding box instance to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the bounding box was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.Label'></a>

## Label Class

Represents a label associated with an object detection class in YOLO\.

```csharp
public class Label
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Label
### Constructors

<a name='DiGi.YOLO.Classes.Label.Label(int,string)'></a>

## Label\(int, string\) Constructor

Initializes a new instance of the [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') class\.

```csharp
public Label(int index, string? name);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Label.Label(int,string).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The numerical index for the label\.

<a name='DiGi.YOLO.Classes.Label.Label(int,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The descriptive name for the label\.
### Fields

<a name='DiGi.YOLO.Classes.Label.index'></a>

## Label\.index Field

The numerical index of the label\.

```csharp
public int index;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.Label.name'></a>

## Label\.name Field

The descriptive name of the label\.

```csharp
public string? name;
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Properties

<a name='DiGi.YOLO.Classes.Label.Index'></a>

## Label\.Index Property

Gets the numerical index of the label\.

```csharp
public int Index { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.Label.Name'></a>

## Label\.Name Property

Gets the descriptive name of the label\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.YOLO.Classes.Label.Equals(object)'></a>

## Label\.Equals\(object\) Method

Determines whether the specified object is equal to the current label based on its string representation\.

```csharp
public override bool Equals(object @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Label.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current label\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the objects are equal; otherwise, false\.

<a name='DiGi.YOLO.Classes.Label.GetHashCode()'></a>

## Label\.GetHashCode\(\) Method

Returns a hash code for the current label based on its string representation\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer hash code\.

<a name='DiGi.YOLO.Classes.Label.ToString()'></a>

## Label\.ToString\(\) Method

Returns a string that represents the current label\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the index and name of the label\.

<a name='DiGi.YOLO.Classes.LabelFile'></a>

## LabelFile Class

Represents a label file containing associations between class indices and bounding boxes for an image\.

```csharp
public class LabelFile
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LabelFile
### Constructors

<a name='DiGi.YOLO.Classes.LabelFile.LabelFile()'></a>

## LabelFile\(\) Constructor

Initializes a new instance of the [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') class\.

```csharp
public LabelFile();
```
### Fields

<a name='DiGi.YOLO.Classes.LabelFile.tuples'></a>

## LabelFile\.tuples Field

The collection of tuples pairing label indices with their corresponding bounding boxes\.

```csharp
public List<Tuple<int,BoundingBox>> tuples;
```

#### Field Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Tuple&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')
### Properties

<a name='DiGi.YOLO.Classes.LabelFile.Count'></a>

## LabelFile\.Count Property

Gets the total number of entries in the label file\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox)'></a>

## LabelFile\.Add\(int, BoundingBox\) Method

Adds a label index and its associated bounding box to the collection\.

```csharp
public bool Add(int labelIndex, DiGi.YOLO.Classes.BoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer index of the label\.

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox).boundingBox'></a>

`boundingBox` [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')

The bounding box associated with the label\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the pair was successfully added; otherwise, false if the bounding box is null or the index is negative\.

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBox(int)'></a>

## LabelFile\.GetBoundingBox\(int\) Method

Retrieves the bounding box at the specified position\.

```csharp
public DiGi.YOLO.Classes.BoundingBox GetBoundingBox(int index);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBox(int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based index of the entry to retrieve\.

#### Returns
[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')  
The [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') associated with the given position\.

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBoxes(int)'></a>

## LabelFile\.GetBoundingBoxes\(int\) Method

Retrieves all bounding boxes associated with a specific label index\.

```csharp
public System.Collections.Generic.List<DiGi.YOLO.Classes.BoundingBox> GetBoundingBoxes(int labelIndex);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBoxes(int).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The label index to filter by\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') objects matching the specified label index\.

<a name='DiGi.YOLO.Classes.LabelFile.GetLabelIndex(int)'></a>

## LabelFile\.GetLabelIndex\(int\) Method

Retrieves the label index at the specified position\.

```csharp
public int GetLabelIndex(int index);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetLabelIndex(int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based index of the entry to retrieve\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The label index associated with the given position\.

<a name='DiGi.YOLO.Classes.LabelFile.GetTagIndexes()'></a>

## LabelFile\.GetTagIndexes\(\) Method

Retrieves a set of all unique tag indices present in the label file\.

```csharp
public System.Collections.Generic.HashSet<int> GetTagIndexes();
```

#### Returns
[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')  
A [System\.Collections\.Generic\.HashSet&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1') containing the unique label indices\.

<a name='DiGi.YOLO.Classes.LabelFile.ToString()'></a>

## LabelFile\.ToString\(\) Method

Returns a string representation of the label file, formatted as space\-separated values per line\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the labels and bounding boxes separated by new lines\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult'></a>

## YOLOEnvironmentResult Class

Represents the preflight check result of probing the CPython environment and YOLO dependencies on a machine\.

Reports whether the interpreter can run YOLO, its version, installed dependency versions, CUDA availability, model compatibility, and any diagnostic messages explaining why the environment is not runnable.

```csharp
public class YOLOEnvironmentResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOEnvironmentResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_)'></a>

## YOLOEnvironmentResult\(bool, string, string, string, string, Nullable\<bool\>, string, string, IEnumerable\<string\>, Nullable\<DateTimeOffset\>\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class\.

```csharp
public YOLOEnvironmentResult(bool runnable, string? pythonPath, string? pythonVersion, string? ultralyticsVersion, string? torchVersion, System.Nullable<bool> cudaAvailable, string? modelPath, string? modelUltralyticsVersion, System.Collections.Generic.IEnumerable<string>? messages, System.Nullable<System.DateTimeOffset> checkedTime);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the probed Python interpreter can execute YOLO prediction workloads\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the Python interpreter that was probed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).pythonVersion'></a>

`pythonVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The Python version reported by the interpreter\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).ultralyticsVersion'></a>

`ultralyticsVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The installed version of the ultralytics package, or `null` when import failed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).torchVersion'></a>

`torchVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The installed version of PyTorch, or `null` when import failed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).cudaAvailable'></a>

`cudaAvailable` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

A value indicating whether PyTorch reports CUDA acceleration available\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the model checkpoint probed, or `null` when none was provided\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).modelUltralyticsVersion'></a>

`modelUltralyticsVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ultralytics version recorded inside the model checkpoint, or `null` when unreadable\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostic messages detailing why the environment is not runnable or warnings encountered\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).checkedTime'></a>

`checkedTime` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the preflight probe completed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult)'></a>

## YOLOEnvironmentResult\(YOLOEnvironmentResult\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class by copying an existing result\.

```csharp
public YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult? yOLOEnvironmentResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult).yOLOEnvironmentResult'></a>

`yOLOEnvironmentResult` [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')

The source result instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOEnvironmentResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class using a JSON object\.

```csharp
public YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Checked'></a>

## YOLOEnvironmentResult\.Checked Property

Gets the moment the preflight probe completed\.

```csharp
public System.Nullable<System.DateTimeOffset> Checked { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.CudaAvailable'></a>

## YOLOEnvironmentResult\.CudaAvailable Property

Gets a value indicating whether PyTorch reports CUDA GPU hardware acceleration available\.

```csharp
public System.Nullable<bool> CudaAvailable { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Messages'></a>

## YOLOEnvironmentResult\.Messages Property

Gets the diagnostic messages detailing why the environment is not runnable or warnings encountered during probing\.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.ModelPath'></a>

## YOLOEnvironmentResult\.ModelPath Property

Gets the path of the model checkpoint probed, or `null` when no model path was supplied\.

```csharp
public string? ModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.ModelUltralyticsVersion'></a>

## YOLOEnvironmentResult\.ModelUltralyticsVersion Property

Gets the ultralytics version recorded inside the model checkpoint file, or `null` when unreadable\.

```csharp
public string? ModelUltralyticsVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.PythonPath'></a>

## YOLOEnvironmentResult\.PythonPath Property

Gets the full path of the CPython interpreter that was probed\.

```csharp
public string? PythonPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.PythonVersion'></a>

## YOLOEnvironmentResult\.PythonVersion Property

Gets the Python version string reported by the interpreter\.

```csharp
public string? PythonVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable'></a>

## YOLOEnvironmentResult\.Runnable Property

Gets a value indicating whether the probed Python interpreter can execute YOLO prediction workloads\.

```csharp
public bool Runnable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.TorchVersion'></a>

## YOLOEnvironmentResult\.TorchVersion Property

Gets the installed version of PyTorch, or `null` when import failed\.

```csharp
public string? TorchVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.UltralyticsVersion'></a>

## YOLOEnvironmentResult\.UltralyticsVersion Property

Gets the installed version of the ultralytics package, or `null` when import failed\.

```csharp
public string? UltralyticsVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOModel'></a>

## YOLOModel Class

Represents a YOLO model structure that manages images, labels, and their associated categories and bounding boxes\.

```csharp
public class YOLOModel
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YOLOModel
### Constructors

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel()'></a>

## YOLOModel\(\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class and sets up default directory paths for train, validate, and test categories\.

```csharp
public YOLOModel();
```

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(DiGi.YOLO.Classes.ConfigurationFile)'></a>

## YOLOModel\(ConfigurationFile\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class using the provided configuration file\.

```csharp
public YOLOModel(DiGi.YOLO.Classes.ConfigurationFile? configurationFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(DiGi.YOLO.Classes.ConfigurationFile).configurationFile'></a>

`configurationFile` [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')

The configuration file to initialize the model with\.

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(string)'></a>

## YOLOModel\(string\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class with a specified root directory and sets up default category paths\.

```csharp
public YOLOModel(string? directory);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(string).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base directory path for the model\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOModel.Directory'></a>

## YOLOModel\.Directory Property

Gets or sets the base directory path for the model data\.

```csharp
public string? Directory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.ConfigurationFile)'></a>

## YOLOModel\.Add\(ConfigurationFile\) Method

Adds the specified configuration file settings to the YOLO model\.

```csharp
public bool Add(DiGi.YOLO.Classes.ConfigurationFile? configurationFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.ConfigurationFile).configurationFile'></a>

`configurationFile` [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')

The configuration file containing directory and label information\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the configuration was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.Label)'></a>

## YOLOModel\.Add\(Label\) Method

Adds a specific [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') object to the model's labels collection\.

```csharp
public bool Add(DiGi.YOLO.Classes.Label? label);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.Label).label'></a>

`label` [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')

The label object to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the label was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string)'></a>

## YOLOModel\.Add\(string\) Method

Adds a new label name to the model's labels collection if it does not already exist\.

```csharp
public bool Add(string? labelName);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the label was added; false if the label already exists or is invalid\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile)'></a>

## YOLOModel\.Add\(string, LabelFile\) Method

Adds all labels and bounding boxes contained within a label file to an image at the given path\.

```csharp
public bool Add(string? path, DiGi.YOLO.Classes.LabelFile? labelFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile).labelFile'></a>

`labelFile` [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')

The label file containing annotation data\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if at least one bounding box was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[])'></a>

## YOLOModel\.Add\(string, Category\[\]\) Method

Associates an image at the specified path with one or more categories\.

```csharp
public bool Add(string? path, params DiGi.YOLO.Enums.Category[]? categories);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[]).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[]).categories'></a>

`categories` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of categories to assign to the image\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the image and categories were successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox)'></a>

## YOLOModel\.Add\(string, string, BoundingBox\) Method

Adds a bounding box for a specific label to an image at the given path\.

```csharp
public bool Add(string? path, string? labelName, DiGi.YOLO.Classes.BoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label associated with the bounding box\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).boundingBox'></a>

`boundingBox` [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')

The bounding box coordinates and dimensions\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the bounding box was successfully added to the image; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories()'></a>

## YOLOModel\.GetCategories\(\) Method

Retrieves a collection of all unique categories currently stored in the model\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category>? GetCategories();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable containing all registered [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') values\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories(string)'></a>

## YOLOModel\.GetCategories\(string\) Method

Retrieves the collection of categories associated with the specified path\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category>? GetCategories(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path to look up categories for\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable of [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') if found; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetConfigurationFile()'></a>

## YOLOModel\.GetConfigurationFile\(\) Method

Creates and returns a [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') instance based on the current model configuration\.

```csharp
public DiGi.YOLO.Classes.ConfigurationFile? GetConfigurationFile();
```

#### Returns
[ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')  
A [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') object representing the current settings\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images()'></a>

## YOLOModel\.GetDirectory\_Images\(\) Method

Retrieves the full path to the base images directory\.

```csharp
public string? GetDirectory_Images();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if the base directory is set; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Images\(Category\) Method

Retrieves the full path to the images directory for the specified category using the model's current base directory\.

```csharp
public string? GetDirectory_Images(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category \(e\.g\., Train, Validate, Test\) to locate\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if successful; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Images\(string, Category\) Method

Retrieves the full path to the images directory for a specific category within a provided root directory\.

```csharp
public string? GetDirectory_Images(string? directory, DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The root directory path\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category \(e\.g\., Train, Validate, Test\) to locate\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if the root directory is valid; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels()'></a>

## YOLOModel\.GetDirectory\_Labels\(\) Method

Retrieves the full path to the labels directory by deriving it from the images directory path\.

```csharp
public string? GetDirectory_Labels();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string for labels if successful; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Labels\(Category\) Method

Retrieves the labels directory path for a specific category using the model's internal directory state\.

```csharp
public string? GetDirectory_Labels(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category associated with the directories\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The calculated path to the labels directory, or `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Labels\(string, Category\) Method

Retrieves the labels directory path based on a provided image directory and category\.

```csharp
public string? GetDirectory_Labels(string? directory, DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base directory path to evaluate\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category associated with the directories\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The calculated path to the labels directory, or `null` if the provided directory is null or whitespace\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetImage(string)'></a>

## YOLOModel\.GetImage\(string\) Method

Retrieves an image object associated with the specified file path\.

```csharp
public DiGi.YOLO.Classes.Image? GetImage(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetImage(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')  
The [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') object if found in the model; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetImages(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetImages\(Category\) Method

Retrieves all images that belong to a specific category\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Image> GetImages(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetImages(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category used to filter the images\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') objects belonging to the specified category\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabel(int)'></a>

## YOLOModel\.GetLabel\(int\) Method

Retrieves a label based on its unique integer index\.

```csharp
public DiGi.YOLO.Classes.Label? GetLabel(int labelIndex);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabel(int).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label to retrieve\.

#### Returns
[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')  
The [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') object if found; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabelFile(string)'></a>

## YOLOModel\.GetLabelFile\(string\) Method

Retrieves the label file associated with the image at the specified path\.

```csharp
public DiGi.YOLO.Classes.LabelFile? GetLabelFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabelFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
The [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') object if found; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels()'></a>

## YOLOModel\.GetLabels\(\) Method

Retrieves all labels defined within the model\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label> GetLabels();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of all available [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') objects\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels(string)'></a>

## YOLOModel\.GetLabels\(string\) Method

Retrieves all labels associated with the image at the specified path\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label>? GetLabels(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') objects associated with the image, or `null` if no labels are found\.

<a name='DiGi.YOLO.Classes.YOLOModel.LabelIndex(string)'></a>

## YOLOModel\.LabelIndex\(string\) Method

Retrieves the index of a label based on its name\.

```csharp
public int LabelIndex(string? labelName);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.LabelIndex(string).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label to search for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The integer index of the label if found; otherwise, \-1\.

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions'></a>

## YOLOPredictionOptions Class

Provides the settings one run of the YOLO prediction script needs: which interpreter runs it, which weights it scores with, which images it reads, and where it writes its results\.

The constructors only assign. Use [YOLOPredictionOptions\(string, string, string, string, string, double, int\)](DiGi.YOLO.md#DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int) 'DiGi\.YOLO\.Create\.YOLOPredictionOptions\(string, string, string, string, string, double, int\)') to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.

```csharp
public class YOLOPredictionOptions : DiGi.Core.Classes.SerializableOptions, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → YOLOPredictionOptions

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions()'></a>

## YOLOPredictionOptions\(\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class with default values\.

```csharp
public YOLOPredictionOptions();
```

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions)'></a>

## YOLOPredictionOptions\(YOLOPredictionOptions\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class by copying an existing options instance\.

```csharp
public YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions? yOLOPredictionOptions);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions).yOLOPredictionOptions'></a>

`yOLOPredictionOptions` [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')

The source options instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOPredictionOptions\(JsonObject\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class using a JSON object\.

```csharp
public YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration settings\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.BatchSize'></a>

## YOLOPredictionOptions\.BatchSize Property

Gets or sets the number of images passed to the prediction model in a single inference batch, passed to predict\.py as \-\-batch\.

Batching amortizes Python call overhead and GPU kernel launches over multiple images. The default is 32. Turning it down reduces GPU memory usage.

```csharp
public int BatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.Confidence'></a>

## YOLOPredictionOptions\.Confidence Property

Gets or sets the confidence threshold a detection has to reach to be reported, passed to predict\.py as \-\-conf\.

The default matches the script's own default. Lowering it returns more boxes and more false positives; the weights are frozen, so this is the only knob over how much the detector reports.

```csharp
public double Confidence { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.ModelPath'></a>

## YOLOPredictionOptions\.ModelPath Property

Gets or sets the path of the trained weights file the prediction scores with, passed to predict\.py as \-\-model\.

Left null the script falls back to its own search, which picks whichever training run is newest on disk. Name the file, so a run is reproducible.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.OutputPath'></a>

## YOLOPredictionOptions\.OutputPath Property

Gets or sets the path of the bounding box result file the prediction writes, passed to predict\.py as \-\-output\.

The script opens it for writing rather than appending, so re-running a source directory replaces the previous answer instead of doubling it.

```csharp
public string? OutputPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.PythonPath'></a>

## YOLOPredictionOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter that runs the prediction script, or the name of one on PATH\.

This has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.SourceDirectory'></a>

## YOLOPredictionOptions\.SourceDirectory Property

Gets or sets the directory holding the images to score, passed to predict\.py as \-\-source\.

The script reads the .jpg, .jpeg and .png files directly in the directory and does not descend into it.

```csharp
public string? SourceDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.WorkingDirectory'></a>

## YOLOPredictionOptions\.WorkingDirectory Property

Gets or sets the directory the prediction process runs in, which is also where the runner keeps the Python scripts\.

predict.py imports utils.py, and Python resolves that import against the directory the script itself sits in, so the two files have to stay together. The runner puts them there with [WriteScripts\(string\)](DiGi.YOLO.md#DiGi.YOLO.Modify.WriteScripts(string) 'DiGi\.YOLO\.Modify\.WriteScripts\(string\)') when they are missing. Ultralytics also writes its own caches here.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult'></a>

## YOLOPredictionResult Class

Represents what one run of the YOLO prediction script did: how it ended, what it said, and the result lines it produced\.

The detections are kept as the raw lines of the bounding box result file rather than as parsed objects, so that a result read back from JSON is the same result that was written. Parse them with [BoundingBoxResultFile\(this YOLOPredictionResult\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult) 'DiGi\.YOLO\.Create\.BoundingBoxResultFile\(this DiGi\.YOLO\.Classes\.YOLOPredictionResult\)').

```csharp
public class YOLOPredictionResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOPredictionResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult)'></a>

## YOLOPredictionResult\(YOLOPredictionResult\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class by copying an existing result\.

```csharp
public YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult? yOLOPredictionResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult).yOLOPredictionResult'></a>

`yOLOPredictionResult` [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')

The source result to copy from\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_)'></a>

## YOLOPredictionResult\(int, int, string, IEnumerable\<string\>, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class\.

```csharp
public YOLOPredictionResult(int exitCode, int imageCount, string? outputPath, System.Collections.Generic.IEnumerable<string>? values, System.Collections.Generic.IEnumerable<string>? standardOutput, System.Collections.Generic.IEnumerable<string>? standardError, System.Nullable<System.DateTimeOffset> start, System.Nullable<System.DateTimeOffset> end);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The code the prediction process ended with, or \-1 when the runner never got one\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).imageCount'></a>

`imageCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images found in the source directory\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file the run was told to write\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).values'></a>

`values` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines of the bounding box result file the run produced\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The trailing lines the process wrote to its standard output stream\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardError'></a>

`standardError` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The trailing lines the process wrote to its standard error stream\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).start'></a>

`start` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the run began\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).end'></a>

`end` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the run ended\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOPredictionResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class using a JSON object\.

```csharp
public YOLOPredictionResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Duration'></a>

## YOLOPredictionResult\.Duration Property

Gets how long the run took, or `null` when either end of it is unknown\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.End'></a>

## YOLOPredictionResult\.End Property

Gets the moment the run ended\.

```csharp
public System.Nullable<System.DateTimeOffset> End { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.ExitCode'></a>

## YOLOPredictionResult\.ExitCode Property

Gets the code the prediction process ended with\. Zero means it ran to completion\.

-1 is the runner's own code for a run it never handed to the interpreter or took back from it - the process could not be started, the source directory was gone, or the run was cancelled. [StandardError](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult.StandardError 'DiGi\.YOLO\.Classes\.YOLOPredictionResult\.StandardError') carries the reason in the first two cases; a caller that cancelled already knows about the third.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.ImageCount'></a>

## YOLOPredictionResult\.ImageCount Property

Gets the number of images found in the source directory\.

Zero here with an exit code of zero is a run that had nothing to do, which is worth telling apart from a run that scored images and found nothing on them.

```csharp
public int ImageCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.OutputPath'></a>

## YOLOPredictionResult\.OutputPath Property

Gets the path of the bounding box result file the run was told to write\.

```csharp
public string? OutputPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.StandardError'></a>

## YOLOPredictionResult\.StandardError Property

Gets the trailing lines the process wrote to its standard error stream, at most [OutputLines](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Count.OutputLines 'DiGi\.YOLO\.Constants\.Count\.OutputLines') of them\.

```csharp
public System.Collections.Generic.List<string>? StandardError { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.StandardOutput'></a>

## YOLOPredictionResult\.StandardOutput Property

Gets the trailing lines the process wrote to its standard output stream, at most [OutputLines](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Count.OutputLines 'DiGi\.YOLO\.Constants\.Count\.OutputLines') of them\.

```csharp
public System.Collections.Generic.List<string>? StandardOutput { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Start'></a>

## YOLOPredictionResult\.Start Property

Gets the moment the run began\.

```csharp
public System.Nullable<System.DateTimeOffset> Start { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Succeeded'></a>

## YOLOPredictionResult\.Succeeded Property

Gets a value indicating whether the run completed and produced its result file\.

```csharp
public bool Succeeded { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Values'></a>

## YOLOPredictionResult\.Values Property

Gets the lines of the bounding box result file the run produced, or `null` when it produced none\.

An empty list is a run that scored images and detected nothing; `null` is a run that wrote no file at all.

```csharp
public System.Collections.Generic.List<string>? Values { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')