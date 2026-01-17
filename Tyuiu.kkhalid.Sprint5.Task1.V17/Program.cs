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

            // Чтение и вывод содержимого файла
            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Успешно создан!");
            Console.WriteLine();

            // Вывод таблицы на консоль
            Console.WriteLine("Таблица значений функции:");
            Console.WriteLine("x\t\tF(x)");
            Console.WriteLine("-------------------");

            for (int x = startValue; x <= stopValue; x++)
            {
                try
                {
                    double denominator = Math.Sin(x) + 1;

                    if (Math.Abs(denominator) < 0.000001)
                    {
                        Console.WriteLine($"{x}\t\t0.00");
                    }
                    else
                    {
                        double numerator = 2 * x - 1;
                        double value = 2 * x - 4 + numerator / denominator;
                        Console.WriteLine($"{x}\t\t{Math.Round(value, 2):F2}");
                    }
                }
                catch
                {
                    Console.WriteLine($"{x}\t\t0.00");
                }
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ВЫПОЛНЕНИЕ ЗАВЕРШЕНО                                                     *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}