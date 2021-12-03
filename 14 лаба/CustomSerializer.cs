using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace _14_лаба
{
    internal class CustomSerializer
    {
        public static void Binary(string NameOfFile, object serObj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(NameOfFile, FileMode.Create))
            {
                bf.Serialize(fs, serObj);
            }

        }
        public static void XML(string NameOfFile, object obj)
        {
            XmlSerializer xml = new XmlSerializer(obj.GetType());
            using (var fs = new FileStream(NameOfFile, FileMode.Create))
            {
                xml.Serialize(fs, obj);
            }
        }
        public static void Json(string NameOfFile, object obj)
        {
            var json = new DataContractJsonSerializer(obj.GetType());
            using(var fs = new FileStream(NameOfFile, FileMode.Create))
            {
                json.WriteObject(fs, obj);
            }
        }

    }
    internal class CustomDeserializer
    {
        public static T Binary<T>(string NameOfFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(NameOfFile, FileMode.Open))
            {
                return (T)bf.Deserialize(fs);
            }
        }
        public static T XML<T>(string NameOfFile)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(NameOfFile, FileMode.Open))
            {
                return (T)xml.Deserialize(fs);
            }
        }
        public static T Json<T>(string NameOfFile)
        {
            var json = new DataContractJsonSerializer(typeof(T));
            using (var fs = new FileStream(NameOfFile, FileMode.Open))
            {
                return (T)json.ReadObject(fs);
            }
        }
    }

}
