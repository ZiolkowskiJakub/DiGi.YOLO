#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Enums Namespace
### Enums

<a name='DiGi.YOLO.Enums.Category'></a>

## Category Enum

Specifies the category of a dataset split used in YOLO model training and evaluation\.

```csharp
public enum Category
```
### Fields

<a name='DiGi.YOLO.Enums.Category.Train'></a>

`Train` 0

The subset of data used to train the model weights\.

<a name='DiGi.YOLO.Enums.Category.Validate'></a>

`Validate` 1

The subset of data used for hyperparameter tuning and preventing overfitting during training\.

<a name='DiGi.YOLO.Enums.Category.Test'></a>

`Test` 2

The subset of data used to provide an unbiased evaluation of the final model performance\.

<a name='DiGi.YOLO.Enums.ModelKind'></a>

## ModelKind Enum

Specifies what kind of file a training run starts from\.

```csharp
public enum ModelKind
```
### Fields

<a name='DiGi.YOLO.Enums.ModelKind.Undefined'></a>

`Undefined` 0

The file is neither a checkpoint nor a definition, or is not known\.

<a name='DiGi.YOLO.Enums.ModelKind.Checkpoint'></a>

`Checkpoint` 1

A trained weights file \(\.pt\), continued from or used as pretrained start weights\.

<a name='DiGi.YOLO.Enums.ModelKind.Definition'></a>

`Definition` 2

An architecture definition \(\.yaml\), trained from random initialisation\.