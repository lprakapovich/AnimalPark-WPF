using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializerUtility
{
    /// <summary>
    /// Class handling serialization and deserialization processes
    /// </summary>
    public static class SerializationUtils
    {
        public static void SerializeDataToBinary<T>(string filename, T obj)
        {
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
        }

        public static T DeserializeFromBinary<T>(string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T) binaryFormatter.Deserialize(fileStream);
            }
        }

        public static void SerializeToXml<T>(string filepath, T obj)
        {
            using (TextWriter writter = new StreamWriter(filepath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writter, obj);
            }
        }

        public static T DeserializeFromXml<T>(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StreamReader(filepath))
            {
                return (T) serializer.Deserialize(reader);
            }
        }
    }
}

