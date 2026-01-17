using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task2.V19.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task2.V19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Данные из варианта 19
            int[,] mtx = new int[3, 3] {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            int rows = mtx.GetLength(0);
            int columns = mtx.GetLength(1);

            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            Console.WriteLine("Массив 3x3:");
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mtx[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string res = ds.SaveToFileTextData(mtx);

            // Чтение и вывод содержимого файла
            string fileContent = File.ReadAllText(res);
            string[] lines = fileContent.Trim().Split('\n');

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Успешно создан!");
            Console.WriteLine();

            Console.WriteLine("Модифицированный массив (нечетные заменены на 0):");
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = mtx[i, j];
                    if (value % 2 != 0)
                    {
                        Console.Write($"{0,4}");
                    }
                    else
                    {
                        Console.Write($"{value,4}");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Содержимое файла (CSV формат):");
            Console.WriteLine("-------------------------------");
            foreach (string line in lines)
            {
                Console.WriteLine(line.Trim());
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ВЫПОЛНЕНИЕ ЗАВЕРШЕНО                                                     *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}