using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Decimal[] values = new Decimal[] { 22.1M, 33.2M, 175.4M, 43.7M, 98.8M, 14.9M };
            String path = @"C:\Users\Public\SBin.dat";

            if (File.Exists(path) == true)
            {
                File.Delete(path);
                Console.WriteLine("Se elimina archivo existente");
            }

            Serialize(values, path);
            Console.WriteLine("La serialización se realizó correctamente");

            Decimal[] result = Deserialize<Decimal[]>(path);

            foreach (Decimal item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("La deserialización se realizó correctamente");

            Animal animal = new Animal()
            {
                Habitat = "Selva",
                Nombre = "Jaguar",
                Tipo = "Felino"
            };

            Serialize(animal, path);
            Console.WriteLine("La serialización se realizó correctamente");

            Animal animalResult = Deserialize<Animal>(path);
            Console.WriteLine(animalResult.ToString());
            Console.WriteLine("La deserialización se realizó correctamente");

            Console.Clear();
            List<Animal> animales = new List<Animal>()
            {
                new Animal()
                {
                    Habitat = "Selva",
                    Nombre = "Jaguar",
                    Tipo = "Felino"
                },
                new Animal()
                {
                    Habitat = "Selva",
                    Nombre = "Tigre",
                    Tipo = "Felino"
                }
            };

            Serialize(animales, path);
            Console.WriteLine("La serialización se realizó correctamente");

            foreach (Animal item in Deserialize<List<Animal>>(path))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        private static void Serialize(Object obj, String path)
        {
            using (FileStream fs = File.Create(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        private static T Deserialize<T>(String path)
        {
            T result;

            using (FileStream fs = File.OpenRead(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = (T)bf.Deserialize(fs);
            }

            return result;

        }
    }

    [Serializable]
    public class Animal
    {
        public String Nombre { get; set; }
        public String Tipo { get; set; }
        public String Habitat { get; set; }

        public override string ToString()
        {
            return $"Soy un {this.Nombre} soy de tipo {this.Tipo} y vivo en {this.Habitat}";
        }
    }
}