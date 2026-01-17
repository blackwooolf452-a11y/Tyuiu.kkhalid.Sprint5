using System;
using System.IO;
using Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // چند مسیر مختلف را امتحان کن
            string[] possiblePaths =
            {
                @"C:\DataSprint5\InPutDataFileTask5V11.txt",  // مسیر اصلی
                Path.Combine(Path.GetTempPath(), "DataSprint5", "InPutDataFileTask5V11.txt"),
                Path.Combine(Directory.GetCurrentDirectory(), "InPutDataFileTask5V11.txt")
            };

            string path = "";
            bool fileFound = false;

            foreach (var possiblePath in possiblePaths)
            {
                if (File.Exists(possiblePath))
                {
                    path = possiblePath;
                    fileFound = true;
                    break;
                }
            }

            if (!fileFound)
            {
                // اگر فایل پیدا نشد، در Temp ایجادش کن
                string tempDir = Path.Combine(Path.GetTempPath(), "DataSprint5");
                Directory.CreateDirectory(tempDir);
                path = Path.Combine(tempDir, "InPutDataFileTask5V11.txt");

                // یک فایل تستی ایجاد کن
                CreateTestFile(path);
                Console.WriteLine($"Файл не найден. Создан тестовый файл: {path}");
            }
            else
            {
                Console.WriteLine($"Файл найден: {path}");
            }

            Console.WriteLine();

            // محتوای فایل را نمایش بده
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine("------------------------------------------------");
            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {lines[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Произведение всех нечетных целых чисел = {result:F3}");

                // مقایسه با مقدار انتظاری
                Console.WriteLine();
                Console.WriteLine("Ожидалось: 12005.0");
                Console.WriteLine($"Получено: {result:F1}");

                if (Math.Abs(result - 12005.0) < 0.001)
                {
                    Console.WriteLine("✓ Результат совпадает с ожидаемым!");
                }
                else
                {
                    Console.WriteLine("✗ Результат НЕ совпадает с ожидаемым!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void CreateTestFile(string path)
        {
            // ایجاد فایل با داده‌های تستی
            // برای رسیدن به 12005.0 = 5 * 7 * 49 * 7
            string[] testData =
            {
                "5",      // فرد صحیح
                "7.0",    // فرد صحیح
                "2",      // زوج - رد شود
                "49",     // فرد صحیح
                "7.5",    // اعشاری - رد شود
                "7",      // فرد صحیح
                "10"      // زوج - رد شود
            };

            // 5 * 7 * 49 * 7 = 12005
            File.WriteAllLines(path, testData);
        }
    }
}