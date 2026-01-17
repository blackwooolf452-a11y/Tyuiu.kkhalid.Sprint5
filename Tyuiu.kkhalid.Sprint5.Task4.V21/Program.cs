using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task3.V12.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task3.V12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Халид К.В. | ИИПБ-23-3";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Потоковый метод записи данных в бинарный файл                    *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #12                                                             *");
            Console.WriteLine("* Выполнил: Халид К.В. | ИИПБ-23-3                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение. Вычислить его значение при x = 3/2, результат сохранить*");
            Console.WriteLine("* в бинарный файл OutPutFileTask3.bin и вывести на консоль.              *");
            Console.WriteLine("* Округлить до трёх знаков после запятой.                                 *");
            Console.WriteLine("* y = x^3 / (2*(x+5)^2)                                                   *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Задаем x
            double x = 3.0 / 2.0;
            Console.WriteLine($"x = {x}");

            // Вычисляем y
            double y = Math.Pow(x, 3) / (2 * Math.Pow(x + 5, 2));
            y = Math.Round(y, 3);

            Console.WriteLine($"Значение выражения y = {y}");

            // Сохраняем в бинарный файл
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(y);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Результат сохранен в файл: {path}");
            Console.WriteLine($"y = {y}");
            Console.ReadKey();
        }
    }
}