#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Interfaces Namespace
### Interfaces

<a name='DiGi.YOLO.Interfaces.IBoundingBox'></a>

## IBoundingBox Interface

Defines a contract for a 2D bounding box used to specify the location and size of an object within an image\.

```csharp
public interface IBoundingBox
```

Derived  
↳ [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')
### Properties

<a name='DiGi.YOLO.Interfaces.IBoundingBox.Height'></a>

## IBoundingBox\.Height Property

Gets the height of the bounding box\.

```csharp
double Height { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Interfaces.IBoundingBox.Width'></a>

## IBoundingBox\.Width Property

Gets the width of the bounding box\.

```csharp
double Width { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Interfaces.IBoundingBox.X'></a>

## IBoundingBox\.X Property

Gets the x\-coordinate of the top\-left corner of the bounding box\.

```csharp
double X { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Interfaces.IBoundingBox.Y'></a>

## IBoundingBox\.Y Property

Gets the y\-coordinate of the top\-left corner of the bounding box\.

```csharp
double Y { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Interfaces.IYOLOObject'></a>

## IYOLOObject Interface

Marker interface implemented by every object belonging to the DiGi\.YOLO domain\.

```csharp
public interface IYOLOObject : DiGi.Core.Interfaces.IObject
```

Derived  
↳ [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
↳ [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')  
↳ [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject')

Implements [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.YOLO.Interfaces.IYOLOSerializableObject'></a>

## IYOLOSerializableObject Interface

Marker interface implemented by every DiGi\.YOLO object that can be serialized to and from JSON\.

```csharp
public interface IYOLOSerializableObject : DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
↳ [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')

Implements [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')