
namespace AnimalPark.Model.Interfaces
{
    public interface ISerializable<T>
    {
        void SerializeBinary(string filename);

        void DeserializeBinary(string filename);

        void SerializeXml(string filename);

        void DeserializeXml(string filename);
    }
}
