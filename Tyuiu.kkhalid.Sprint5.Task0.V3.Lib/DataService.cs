using System;
using tyuiu.cources.programming.interfaces.Sprint5;


namespace Tyuiu.kkhalid.Sprint5.Task0.V3.Lib
{
    public class DataService : ISprint5Task0V3
    {
        public string SaveToFileTextData(int x)
        {

            {
                // محاسبه مقدار تابع y = -1/4*(x^3 - 3x^2 + 4)
                double y = -(1.0 / 4.0) * (Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + 4);

                // گرد کردن به سه رقم اعشار
                y = Math.Round(y, 3);

                // ایجاد مسیر فایل
                string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask0.txt");

                // ذخیره در فایل
                File.WriteAllText(path, y.ToString());

                return path;
            }
        }
    }


}
