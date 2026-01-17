using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task3.V12.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task3.V12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСПОЛНЕНИЕ ЗАДАНИЯ 3 | СПРИНТ 5 | ВАРИАНТ 12                           *");
            Console.WriteLine("*-------------------------------------------------------------------------*");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение y = x^3 / (2 * (x + 5)^2) вычислить его значение при     *");
            Console.WriteLine("* x = 3, результат сохранить в бинарный файл OutPutFileTask3.bin и        *");
            Console.WriteLine("* вывести на консоль. Округлить до трёх знаков после запятой.             *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int x = 3;
            Console.WriteLine("x = " + x);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string path = ds.SaveToFileTextData(x);

                // Вычисляем значение для вывода
                double result = Math.Pow(x, 3) / (2 * Math.Pow(x + 5, 2));
                result = Math.Round(result, 3);

                Console.WriteLine("Функция: y = x^3 / (2 * (x + 5)^2)");
                Console.WriteLine("При x = 3:");
                Console.WriteLine("y = " + result);
                Console.WriteLine();
                Console.WriteLine("Файл: " + path);
                Console.WriteLine("Создан!");

                // Проверяем содержимое файла
                if (File.Exists(path))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        double fileValue = reader.ReadDouble();
                        Console.WriteLine("Значение в файле: " + fileValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ОПЕРАЦИЯ УСПЕШНО ЗАВЕРШЕНА                                             *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}