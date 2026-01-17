using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;
using Tyuiu.kkhalid.Sprint5.Task1.V17.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task1.V17.Lib
{
    public class DataService : ISprint5Task1V17
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            // Удаляем файл если существует
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Табулирование функции F(x) = 2x - 4 + (2x - 1)/(sin(x) + 1)");
                writer.WriteLine("Диапазон: [" + startValue + "; " + stopValue + "]");
                writer.WriteLine("Шаг: 1");
                writer.WriteLine();
                writer.WriteLine("x\t\tF(x)");
                writer.WriteLine("-------------------");

                for (int x = startValue; x <= stopValue; x++)
                {
                    try
                    {
                        // Проверка деления на ноль
                        double denominator = Math.Sin(x) + 1;

                        if (Math.Abs(denominator) < 0.000001) // если sin(x) ≈ -1
                        {
                            writer.WriteLine($"{x}\t\t0.00");
                        }
                        else
                        {
                            double numerator = 2 * x - 1;
                            double value = 2 * x - 4 + numerator / denominator;
                            writer.WriteLine($"{x}\t\t{Math.Round(value, 2):F2}");
                        }
                    }
                    catch
                    {
                        writer.WriteLine($"{x}\t\t0.00");
                    }
                }
            }

            return path;
        }
    }
}