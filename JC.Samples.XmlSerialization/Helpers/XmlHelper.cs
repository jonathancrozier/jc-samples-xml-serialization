using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace JC.Samples.XmlSerialization.Helpers
{
    /// <summary>
    /// Provides methods to help with XML serialization.
    /// </summary>
    public class XmlHelper
    {
        #region Methods

        /// <summary>
        /// Deserializes an XML file to the specified type of object.
        /// </summary>
        /// <typeparam name="T">The Type of object to deserialize</typeparam>
        /// <param name="xmlFilePath">The path to the XML file to deserialize</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromFile<T>(string xmlFilePath) where T : class
        {
            using (var reader = XmlReader.Create(xmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Deserializes an XML string to a specified object.
        /// </summary>
        /// <typeparam name="T">The Type to deserialize</typeparam>
        /// <param name="xmlString">The XML string to deserialize</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromString<T>(string xmlString) where T : class
        {
            using (var reader = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }
        
        /// <summary>
        /// Serializes an object of the specified Type to a file.
        /// </summary>
        /// <typeparam name="T">The Type of the object to serialize</typeparam>
        /// <param name="xmlFilePath">The path to save the XML file to</param>
        /// <param name="objectToSerialize">The object instance to serialize</param>
        public static void SerializeToFile<T>(string xmlFilePath, T objectToSerialize) where T : class
        {
            using (var writer = new StreamWriter(xmlFilePath))
            {
                // Do this to avoid the serializer inserting default XML namespaces.
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(objectToSerialize.GetType());
                serializer.Serialize(writer, objectToSerialize, namespaces);
            }
        }

        /// <summary>
        /// Serializes an object of a specified Type to a string.
        /// </summary>
        /// <typeparam name="T">The Type of the object to serialize</typeparam>
        /// <param name="objectToSerialize">The object instance to serialize</param>
        /// <returns>The XML string representation of the object</returns>
        public static string SerializeToString<T>(T objectToSerialize) where T : class
        {
            using (var writer = new StringWriter())
            {
                // Do this to avoid the serializer inserting default XML namespaces.
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(objectToSerialize.GetType());
                serializer.Serialize(writer, objectToSerialize, namespaces);

                return writer.ToString();
            }
        }

        #endregion
    }
}