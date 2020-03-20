using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal(2)
            {
                Habitat = "Selva",
                Nombre = "Jaguar",
                Tipo = "Felino"
            };

            String result = Serialize<Animal>(animal);
            Console.WriteLine(result);

            Animal animalDes = Deserialize<Animal>(result);
            Console.WriteLine(animalDes.ToString());

            result = JsonConvert.SerializeObject(animal);
            Console.WriteLine(result);

            animalDes = JsonConvert.DeserializeObject<Animal>(result);
            Console.WriteLine(animalDes.ToString());

            Console.ReadKey();
        }

        private static T Deserialize<T>(String data)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(data)))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                T result = (T)js.ReadObject(ms);

                return result;
            }
        }

        private static String Serialize<T>(T obj)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                js.WriteObject(ms, obj);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    String value = sr.ReadToEnd();
                    return value;
                }
            }
        }
    }

    [DataContract]
    public class Animal
    {
        [DataMember(IsRequired = true, Name = "Nombre del animal", Order = 1)]
        public String Nombre { get; set; }
        [DataMember(IsRequired = true, Order = 2)]
        public String Tipo { get; set; }
        [DataMember(IsRequired = true, Order = 3)]
        public String Habitat { get; set; }
        [DataMember(IsRequired = true, Order = 4)]
        private Int32 Edad { get; set; }

        public Animal(Int32 edad)
        {
            this.Edad = edad;
        }

        public override string ToString()
        {
            return $"Soy un {this.Nombre} soy de tipo {this.Tipo} y vivo en {this.Habitat}";
        }
    }
}