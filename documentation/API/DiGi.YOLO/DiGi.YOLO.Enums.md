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