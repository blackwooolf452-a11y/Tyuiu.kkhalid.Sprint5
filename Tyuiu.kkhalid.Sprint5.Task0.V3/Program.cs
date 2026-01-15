using System;
using Tyuiu.kkhalid.Sprint5.Task0.V3.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task0.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            // نمایش هدر مانند تصویر
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* y = -1/4*(x^3 - 3x^2 + 4)                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // مقداردهی x
            int x = 3;

            // ایجاد نمونه از DataService
            DataService ds = new DataService();

            // ذخیره در فایل و دریافت مسیر
            string path = ds.SaveToFileTextData(x);

            // محاسبه مجدد برای نمایش
            double y = -(1.0 / 4.0) * (Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + 4);
            y = Math.Round(y, 3);

            // نمایش نتیجه
            Console.WriteLine($"Значение выражения при x = {x}: {y}");
            Console.WriteLine($"Файл сохранен по пути: {path}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ФАЙЛ СОХРАНЕН УСПЕШНО!                                                   *");
            Console.WriteLine("***************************************************************************");

            Console.ReadKey();
        }
    }
}