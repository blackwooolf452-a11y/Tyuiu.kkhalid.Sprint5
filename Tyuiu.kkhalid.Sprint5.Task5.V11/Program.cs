using System;
using System.IO;
using Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // ساخت مسیر فایل در Temp
            string tempPath = Path.GetTempPath();
            string dataDir = Path.Combine(tempPath, "DataSprint5");

            // ایجاد پوشه اگر وجود ندارد
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // مسیر کامل فایل
            string path = Path.Combine(dataDir, "InPutDataFileTask5V11.txt");

            Console.WriteLine($"Данные находятся в файле: {path}");
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                // بررسی وجود فایل
                if (!File.Exists(path))
                {
                    Console.WriteLine("Файл не найден! Создайте файл по указанному пути.");
                    Console.WriteLine($"Путь: {path}");
                }
                else
                {
                    double res = ds.LoadFromDataFile(path);
                    Console.WriteLine($"Произведение всех нечетных целых чисел = {res:F3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Для продолжения нажмите любую клавишу...                                *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}