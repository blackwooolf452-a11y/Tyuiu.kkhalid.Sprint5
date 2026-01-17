using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task4.V21.Lib
{
    public class DataService : ISprint5Task4V21
    {
        public double LoadFromDataFile(string path)
        {
            // Чтение значения x из файла
            string strX = File.ReadAllText(path);
            double x = Convert.ToDouble(strX);

            // Вычисление по формуле y = x^3 * cos(x) + 2x
            double y = Math.Pow(x, 3) * Math.Cos(x) + 2 * x;

            // Округление до 3 знаков после запятой
            y = Math.Round(y, 3);

            return y;
        }
    }

}