using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task1.V17.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task1.V17
{
    class Program
    {
        static void Main(string[] args)
        {
            int startValue = -5;
            int stopValue = 5;

            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("startValue = " + startValue);
            Console.WriteLine("stopValue = " + stopValue);
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string res = ds.SaveToFileTextData(startValue, stopValue);

            // Чтение содержимого файла
            string fileContent = File.ReadAllText(res);
            string[] values = fileContent.Split('\n');

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Успешно создан!");
            Console.WriteLine();

            // Вывод таблицы на консоль
            Console.WriteLine("Таблица значений функции:");
            Console.WriteLine("-------------------");
            Console.WriteLine("|    x   |   F(x)   |");
            Console.WriteLine("-------------------");

            for (int i = 0; i < values.Length; i++)
            {
                int x = startValue + i;
                Console.WriteLine($"| {x,6} | {values[i],8} |");
            }
            Console.WriteLine("-------------------");

            // Также выводим в формате для проверки
            Console.WriteLine("\nЗначения для проверки:");
            Console.WriteLine(fileContent.Replace("\n", "\\n"));

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ВЫПОЛНЕНИЕ ЗАВЕРШЕНО                                                     *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}