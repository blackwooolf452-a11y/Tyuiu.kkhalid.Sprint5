using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task3.V12.Lib
{
    public class DataService : ISprint5Task3V12
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение функции
            // y = x³ / (2 * (x + 5)²)
            double numerator = Math.Pow(x, 3);
            double denominator = 2 * Math.Pow(x + 5, 2);
            double y = numerator / denominator;

            // Округляем до 3 знаков после запятой
            y = Math.Round(y, 3);

            // Создаем путь к файлу в папке пользователя
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\source\\repos\\Tyuiu.kkhalid.Sprint5\\Tyuiu.kkhalid.Sprint5.Task3.V12\\bin\\Debug\\OutPutFileTask3.bin";

            // Записываем результат в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(y);
            }

            return path;
        }

        public double Calculate(int x)
        {
            // Вычисляем значение функции для вывода в консоль
            double numerator = Math.Pow(x, 3);
            double denominator = 2 * Math.Pow(x + 5, 2);
            double result = numerator / denominator;
            return Math.Round(result, 3);
        }
    }

}