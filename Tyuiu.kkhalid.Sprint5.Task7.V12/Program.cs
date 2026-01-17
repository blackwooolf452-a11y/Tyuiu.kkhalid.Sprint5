using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task7.V12.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task7.V12
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Определяем путь к файлу
            string inputPath;

            // Проверяем наличие исходного файла по заданному пути
            string originalPath = @"C:\DataSprint5\InPutDataFileTask7V12.txt";

            if (File.Exists(originalPath))
            {
                inputPath = originalPath;
            }
            else
            {
                // Если файла нет, используем временную директорию и создаем тестовый файл
                inputPath = Path.Combine(Path.GetTempPath(), "InPutDataFileTask7V12.txt");

                // Создаем тестовые данные
                string testData = "Привет! Это тестовый файл для задания 7.\n" +
                                 "Строчные русские буквы должны быть преобразованы в заглавные.\n" +
                                 "Пример: информатика → ИНФОРМАТИКА\n" +
                                 "Английские буквы остаются без изменений: hello world\n" +
                                 "Цифры: 123, символы: !@#$%";

                File.WriteAllText(inputPath, testData, System.Text.Encoding.Default);
                Console.WriteLine("* ВНИМАНИЕ: Исходный файл не найден, создан тестовый файл в            *");
                Console.WriteLine("*          временной директории.                                      *");
            }

            Console.WriteLine("Данные находятся в файле: " + inputPath);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                string outputPath = ds.LoadDataAndSave(inputPath);

                Console.WriteLine("Преобразованные данные находятся в файле:");
                Console.WriteLine(outputPath);

                // Дополнительно: показываем первые несколько строк результата
                Console.WriteLine("\nПервые строки результата:");
                Console.WriteLine("----------------------------------------");

                if (File.Exists(outputPath))
                {
                    using (StreamReader reader = new StreamReader(outputPath, System.Text.Encoding.Default))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            string line = reader.ReadLine();
                            if (line != null)
                            {
                                Console.WriteLine(line);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке файла: " + ex.Message);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Нажмите любую клавишу для выхода...                                     *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}