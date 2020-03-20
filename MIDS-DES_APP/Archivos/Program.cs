using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Archivos
{
    class Program
    {
        private static Int32 counter = 0;
        private static List<String> files = new List<string>();
        private static List<String> moveFiles = new List<string>();
        private static List<String> deleteFiles = new List<string>();

        static void Main(string[] args)
        {
            String path = @"C:\Users\Public\DirectoryTest";

            //WriteFile();
            //ReadFile();
            //ValidateDirectoryExist(path);
            //AppendText();
            //GetInfo();
            
            ExploreDirectories(@"C:\Users\Public\DirectoryTest");
            Console.WriteLine($"Archivos encontrados: {counter}");

            CopyFiles();

            MoveFiles();

            DeleteFiles();

            Console.WriteLine("Transacción finalizada");
            Console.ReadKey();
        }

        private static void DeleteFiles()
        {
            try
            {
                foreach (String item in deleteFiles)
                {
                    File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MoveFiles()
        {
            try
            {
                String path = @"C:\Users\Public\MovedFiles\";

                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }

                foreach (String item in moveFiles)
                {
                    FileInfo fi = new FileInfo(item);
                    File.Move(item, $"{path}{fi.Name}");
                    deleteFiles.Add($"{path}{fi.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CopyFiles()
        {
            try
            {
                String path = @"C:\Users\Public\CopiedFiles\";

                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }

                foreach (String item in files)
                {
                    FileInfo fi = new FileInfo(item);
                    String fileName = $"{path}{fi.Name}";
                    if (File.Exists(fileName) == true)
                    {
                        fileName = $"{path}{Guid.NewGuid().ToString()}-{fi.Name}";
                    }
                    moveFiles.Add(fileName);
                    File.Copy(item, fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ExploreDirectories(String path)
        {
            IEnumerable<String> direcories = Directory.EnumerateDirectories(path);

            if (direcories.ToList().Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Directorio: {path}");
                foreach (String item in Directory.EnumerateFiles(path))
                {
                    files.Add(item);
                    FileInfo fi = new FileInfo(item);
                    Console.WriteLine($"{fi.Name} - {fi.Length} bytes");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Directorio: {path}");
                foreach (String item in Directory.EnumerateFiles(path))
                {
                    files.Add(item);
                    FileInfo fi = new FileInfo(item);
                    Console.WriteLine($"{fi.Name} - {fi.Length} bytes");
                    counter++;
                }

                foreach (String item in direcories)
                {
                    ExploreDirectories(item);
                }
            }

        }

        private static void GetInfo()
        {
            try
            {
                String path = @"C:\Users\Public\TestFile.txt";

                Console.WriteLine($"El último acceso al archivo fue: {File.GetLastAccessTime(path)}");
                Console.WriteLine($"La última escritura al archivo fue: {File.GetLastWriteTime(path)}");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ValidateDirectoryExist(String path)
        {
            if (Directory.Exists(path) == true)
            {
                Console.WriteLine($"El directorio {path} si existe");
            }
            else
            {
                Console.WriteLine($"El directorio {path} NO existe");
                Directory.CreateDirectory(path);
                Console.WriteLine($"El directorio {path} se creó correctamente");
            }
        }

        private static async void ReadFile()
        {
            try
            {
                String path = @"C:\Users\Public\TestFile.txt";

                if (File.Exists(path) == true)
                {
                    using (StreamReader sw = new StreamReader(path))
                    {
                        String content = await sw.ReadToEndAsync();
                        Console.WriteLine($"El contenido del archivo es: {content}");
                    }
                }
                else
                {
                    Console.WriteLine("El archivo que intentas abrir no existe.");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void WriteFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\TestFile.txt"))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        await sw.WriteLineAsync($"Esta es la línea del índice {i}");
                        Console.WriteLine("Se escribió: " + $"Esta es la línea del índice {i}");
                    }

                    Console.WriteLine("Operación finalizada correctamente");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AppendText()
        {
            try
            {
                String path = @"C:\Users\Public\TestFile.txt";
                List<String> lines = new List<string>();

                for (int i = 0; i < 100; i++)
                {
                    lines.Add($"Se agrega la línea con índice {i}");
                }

                File.AppendAllLines(path, lines);

                Console.WriteLine("Operación finalizada correctamente");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}