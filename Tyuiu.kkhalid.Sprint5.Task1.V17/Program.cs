using System;
using Tyuiu.kkhalid.Sprint5.Task1.V17.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task1.V17
{
    class Program
    {
        static void Main(string[] args)
        {
            // Интерфейс по шаблону
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* F(x) = 2x - 4 + (2x - 1)/(sin(x) + 1)                                   *");
            Console.WriteLine("* Табулирование на диапазоне [-5; 5] с шагом 1                           *");
            Console.WriteLine("* При делении на ноль вернуть 0                                           *");
            Console.WriteLine("* Округлить до двух знаков после запятой                                  *");
            Console.WriteLine("* Результат сохранить в файл OutPutFileTask1.txt                          *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            int startValue = -5;
            int stopValue = 5;

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(startValue, stopValue);

            // Вывод таблицы на консоль
            Console.WriteLine("+----------+----------+");
            Console.WriteLine("|    x     |   f(x)   |");
            Console.WriteLine("+----------+----------+");

            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = Math.Sin(x) + 1;

                if (Math.Abs(denominator) < 0.000001)
                {
                    Console.WriteLine($"|{x,10:F2}|{0,10:F2}|");
                }
                else
                {
                    double f = 2 * x - 4 + (2 * x - 1) / denominator;
                    f = Math.Round(f, 2);
                    Console.WriteLine($"|{x,10:F2}|{f,10:F2}|");
                }
            }

            Console.WriteLine("+----------+----------+");
            Console.WriteLine($"Файл: {path}");
            Console.WriteLine("Создан!");

            Console.ReadKey();
        }
    }
}