using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task4.V21.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task4.V21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСПОЛНЕНИЕ ЗАДАНИЯ 4 | СПРИНТ 5 | ВАРИАНТ 21                           *");
            Console.WriteLine("*-------------------------------------------------------------------------*");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть вещественное значение.                          *");
            Console.WriteLine("* Прочитать значение из файла и подставить вместо Х в формуле.            *");
            Console.WriteLine("* y = x^3 * cos(x) + 2x                                                   *");
            Console.WriteLine("* Вычислить значение по формуле                                           *");
            Console.WriteLine("* (Полученное значение округлить до трёх знаков после запятой)            *");
            Console.WriteLine("* и вернуть полученный результат на консоль.                              *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Создаем путь к файлу
            string path = @"C:\DataSprint5\InPutDataFileTask4V21.txt";

            // Проверяем существует ли папка, если нет - создаем
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Если файла нет, создаем с тестовым значением
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "3.5");
                Console.WriteLine("Файл создан с тестовым значением: 3.5");
            }

            Console.WriteLine("Данные находятся в файле: " + path);
            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                double res = ds.LoadFromDataFile(path);

                // Читаем значение x для вывода
                double x = Convert.ToDouble(File.ReadAllText(path));

                Console.WriteLine($"Значение x из файла: {x}");
                Console.WriteLine($"Формула: y = x^3 * cos(x) + 2x");
                Console.WriteLine($"Результат: {res}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Убедитесь, что файл существует и содержит корректное вещественное число.");
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ОПЕРАЦИЯ УСПЕШНО ЗАВЕРШЕНА                                             *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}