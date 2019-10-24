using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BidMyMechanic.Services.Services
{
    public class UtilSerializer
    {
        public T XMLDeserialize<T>(string input) where T: class
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            
            using (StringReader file = new StringReader(input))
            {
                return (T)xml.Deserialize(file);
            }
        }

        public string XMLSerialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }

        public IEnumerable<T> CSVDeserialize<T>(string input) where T : class
        {
            // this is partially working, when encounter big amounts of data it does not work.
            using (var reader = new StreamReader(input))
            using (var csv = new CsvReader(reader))
            {
                var returnData = csv.GetRecords<T>();
                return returnData;
            }
            
        }
        
        public IEnumerable<T> JSONDeserialize<T>(string path) where T: class, new ()
        {
            // Implementation for Json parsing and mapping to object.
            if (File.Exists(path))
            {
                var jsonFile = File.ReadAllText(path);
                var convertToObject = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonFile);
                return convertToObject;
            }
            return new List<T>();
        }
    }
}
