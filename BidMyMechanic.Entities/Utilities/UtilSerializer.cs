using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BidMyMechanic.Services.Services
{
    public class UtilSerializer
    {
        public T Deserialize<T>(string input) where T: class
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            
            using (StringReader file = new StringReader(input))
            {
                return (T)xml.Deserialize(file);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
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
            TextReader reader = new StreamReader(input);
            var csvReader = new CsvReader(reader);
            var records = csvReader.GetRecords<T>();
            //using (CsvReader csvfile = new CsvReader(new StreamReader(input)))
            //{
            //    csvfile.Read();
            //    csvfile.ReadHeader();
            //    records =  csvfile.GetRecords<T>();
            //}
            return records;
        }
    }
}
