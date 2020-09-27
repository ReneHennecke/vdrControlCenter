namespace vdrControlServiceExtension
{
    using System.Xml.Serialization;

    public static class XmlSerializerRaX
    {
        public static string Serialize(object o)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(o.GetType());
                serializer.Serialize(stringwriter, o);
                return stringwriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml) where T : class
        {
            using (var stringReader = new System.IO.StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stringReader) as T;
            }
        }
    }
}
