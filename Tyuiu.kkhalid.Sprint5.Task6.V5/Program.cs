using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task6.V5.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task6.V5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Используем временную директорию и создаем тестовый файл
            string path = Path.Combine(Path.GetTempPath(), "InputFileTask6V5.txt");

            // Если файла нет, создаем его с тестовыми данными
            if (!File.Exists(path))
            {
                string testData = "Hello WORLD! ABC 123 XYZ\nAnother LINE with CAPITAL Letters";
                File.WriteAllText(path, testData);
            }

            Console.WriteLine("Данные находятся в файле: " + path);
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                int res = ds.LoadFromDataFile(path);
                Console.WriteLine("Количество заглавных латинских букв = " + res);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}