namespace DiGi.YOLO.Interfaces
{
    /// <summary>
    /// Marker interface implemented by every DiGi.YOLO object that can be serialized to and from JSON.
    /// </summary>
    public interface IYOLOSerializableObject : IYOLOObject, Core.Interfaces.ISerializableObject
    {
    }
}