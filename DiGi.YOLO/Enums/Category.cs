namespace DiGi.YOLO.Enums
{
    /// <summary>
    /// Specifies the category of a dataset split used in YOLO model training and evaluation.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// The subset of data used to train the model weights.
        /// </summary>
        Train,

        /// <summary>
        /// The subset of data used for hyperparameter tuning and preventing overfitting during training.
        /// </summary>
        Validate,

        /// <summary>
        /// The subset of data used to provide an unbiased evaluation of the final model performance.
        /// </summary>
        Test
    }
}