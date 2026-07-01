#### [DiGi\.YOLO](index.md 'index')

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