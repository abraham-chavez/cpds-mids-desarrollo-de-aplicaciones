using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al módulo 1.3.11 - Colecciones");
            Console.WriteLine("Este programa realiza la suma de números enteros. Por favor ingresa varios números enteros a sumar, presiona enter por cada número.");
            Console.WriteLine("Cuando finalices la captura de números, ingresa fin");
            Console.WriteLine("Captura los números");

            Boolean continuar = true;
            //Int32[] valores = new Int32[10];
            List<Int32> valores = new List<Int32>();
            //Int32 indice = 0;

            do
            {
                String respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "fin")
                {
                    continuar = false;
                }
                else
                {
                    Int32 valor = 0;
                    Boolean conversion = Int32.TryParse(respuesta, out valor);
                    if (conversion == true)
                    {
                        valores.Add(valor);

                        //valores[indice] = valor;
                        //indice++;

                        //if (indice == valores.Length)
                        //{
                        //    Int32[] temp = valores;
                        //    valores = new Int32[indice + 10];
                        //    for (int i = 0; i < temp.Length; i++)
                        //    {
                        //        valores[i] = temp[i];
                        //    }
                        //}
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es un número entero");
                    }
                }

            } while (continuar);

            Console.WriteLine($"Usted ingresó {valores.Count} números enteros y la suma de todos ellos es: {Sumar(valores.ToArray())}");

            Dictionary<String, String> diccionarioContrasenias = new Dictionary<String, String>();
            diccionarioContrasenias.Add("Facebook", "Admin123");
            diccionarioContrasenias.Add("Twitter", "Admin321");
            diccionarioContrasenias.Add("Outlook", "Admin1234");

            Console.WriteLine($"La contraseña de Facebook es: {diccionarioContrasenias["Facebook"]}");

            foreach (KeyValuePair<String, String> item in diccionarioContrasenias)
            {
                Console.WriteLine($"La contraseña de {item.Key} es: {item.Value}");
            }

            if (diccionarioContrasenias.ContainsKey("Facebook") == true)
            {
                diccionarioContrasenias["Facebook"] = "contrasenia123";
            }
            else
            {
                diccionarioContrasenias.Add("Facebook", "contrasenia123");
            }

            foreach (KeyValuePair<String, String> item in diccionarioContrasenias)
            {
                Console.WriteLine($"La contraseña de {item.Key} es: {item.Value}");
            }

            Console.ReadKey();
        }

        private static Int32 Sumar(Int32[] valores)
        {
            Int32 total = 0;

            foreach (Int32 item in valores)
            {
                total += item;
            }

            return total;
        }
    }
}