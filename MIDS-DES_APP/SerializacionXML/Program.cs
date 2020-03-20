using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializacionXML
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeToFile<Animal>(new Animal()
            {
                Habitat = "Selva",
                Nombre = "Jaguar",
                Tipo = "Felino"
            });


            Console.WriteLine("El archivo se generó correctamente.");

            String result = SerializeToString<Animal>(new Animal()
            {
                Habitat = "Selva",
                Nombre = "Jaguar",
                Tipo = "Felino"
            });

            Console.WriteLine(result);

            Animal resultAnimal = Deserialize<Animal>(result);
            Console.WriteLine(resultAnimal.ToString());
            Console.ReadKey();
        }

        private static T Deserialize<T>(String value)
        {
            using (StringReader sw = new StringReader(value))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                T result = (T)xs.Deserialize(sw);

                return result;
            }
        }

        private static String SerializeToString<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, obj);

                return sw.ToString();
            }
        }

        private static void SerializeToFile<T>(T obj)
        {
            using (TextWriter tw = new StreamWriter(@"C:\Users\Public\Serialization.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(tw, obj);
            }
        }
    }

    [Serializable]
    public class Animal
    {
        [XmlElement("Name")]
        public String Nombre { get; set; }
        [XmlElement("Type")]
        public String Tipo { get; set; }
        [XmlElement("Environment")]
        public String Habitat { get; set; }
        [XmlElement("Age")]
        private Int32 Edad { get; set; }

        public Animal()
        {
            this.Edad = 2;
        }

        public override string ToString()
        {
            return $"Soy un {this.Nombre} soy de tipo {this.Tipo} y vivo en {this.Habitat}";
        }
    }
}