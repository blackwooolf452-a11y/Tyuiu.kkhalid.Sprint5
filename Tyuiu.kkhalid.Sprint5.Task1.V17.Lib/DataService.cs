using System;

using tyuiu.cources.programming.interfaces.Sprint5;


namespace Tyuiu.kkhalid.Sprint5.Task1.V17.Lib
{
    public class DataService : ISprint5Task1V17
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {

            {
                string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("Табулирование функции F(x) = 2x - 4 + (2x-1)/(sin(x)+1)");
                    writer.WriteLine("на диапазоне [" + startValue + "; " + stopValue + "] с шагом 1");
                    writer.WriteLine();
                    writer.WriteLine("+----------+----------+");
                    writer.WriteLine("|    x     |   f(x)   |");
                    writer.WriteLine("+----------+----------+");

                    for (int x = startValue; x <= stopValue; x++)
                    {
                        double denominator = Math.Sin(x) + 1;

                        // Проверка деления на ноль
                        if (Math.Abs(denominator) < 0.000001)
                        {
                            writer.WriteLine($"|{x,10:F2}|{0,10:F2}|");
                        }
                        else
                        {
                            double f = 2 * x - 4 + (2 * x - 1) / denominator;
                            f = Math.Round(f, 2);
                            writer.WriteLine($"|{x,10:F2}|{f,10:F2}|");
                        }
                    }

                    writer.WriteLine("+----------+----------+");
                }

                return path;
            }
        }
    }
}