namespace DiGi.YOLO.Enums
{
    /// <summary>
    /// Specifies what kind of file a training run starts from.
    /// </summary>
    public enum ModelKind
    {
        /// <summary>
        /// The file is neither a checkpoint nor a definition, or is not known.
        /// </summary>
        Undefined,

        /// <summary>
        /// A trained weights file (.pt), continued from or used as pretrained start weights.
        /// </summary>
        Checkpoint,

        /// <summary>
        /// An architecture definition (.yaml), trained from random initialisation.
        /// </summary>
        Definition
    }
}
