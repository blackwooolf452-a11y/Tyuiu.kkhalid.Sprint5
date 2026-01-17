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

            string result = "";

            for (int x = startValue; x <= stopValue; x++)
            {
                try
                {
                    // Проверка деления на ноль
                    double denominator = Math.Sin(x) + 1;

                    if (Math.Abs(denominator) < 0.000001) // если sin(x) ≈ -1
                    {
                        result += "0";
                    }
                    else
                    {
                        double numerator = 2 * x - 1;
                        double value = 2 * x - 4 + (numerator / denominator);
                        result += Math.Round(value, 2).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                catch
                {
                    result += "0";
                }

                // Добавляем перевод строки, кроме последней итерации
                if (x != stopValue)
                {
                    result += "\n";
                }
            }

            // Записываем результат в файл
            File.WriteAllText(path, result);

            return path;
        }
    }
}