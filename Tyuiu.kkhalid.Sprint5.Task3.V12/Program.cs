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

            // Значение x = 3 по условию задачи
            int x = 3;

            Console.WriteLine("x = " + x);
            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // Создаем экземпляр сервиса
            DataService ds = new DataService();

            // Вычисляем результат
            double result = ds.Calculate(x);

            // Сохраняем в файл
            string path = ds.SaveToFileTextData(x);

            // Выводим информацию
            Console.WriteLine("Функция: y = x^3 / (2 * (x + 5)^2)");
            Console.WriteLine("При x = 3:");
            Console.WriteLine("y = " + result);
            Console.WriteLine();
            Console.WriteLine("Файл: " + path);
            Console.WriteLine("Создан!");

            // Чтение и проверка сохраненных данных
            Console.WriteLine();
            Console.WriteLine("Проверка сохраненных данных:");
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                double savedValue = reader.ReadDouble();
                Console.WriteLine("Прочитано из файла: " + savedValue);
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ОПЕРАЦИЯ УСПЕШНО ЗАВЕРШЕНА                                             *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}