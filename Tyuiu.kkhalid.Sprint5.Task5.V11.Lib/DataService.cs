using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib
{
    public class DataService : ISprint5Task5V11
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            double product = 1;
            bool foundOddInteger = false;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    // رد کردن خطوط خالی
                    if (string.IsNullOrEmpty(line))
                        continue;

                    // حذف فضای خالی اضافی
                    line = line.Replace(" ", "");

                    // اگر خط حاوی چند عدد است (با جداکننده)
                    string[] numbers = line.Split(new char[] { ' ', '\t', ';', ',' },
                                                StringSplitOptions.RemoveEmptyEntries);

                    foreach (string numStr in numbers)
                    {
                        if (TryParseNumber(numStr, out double number))
                        {
                            // بررسی آیا عدد صحیح است
                            if (IsInteger(number))
                            {
                                long intValue = (long)Math.Truncate(number);

                                // بررسی فرد بودن (برای اعداد مثبت و منفی)
                                if (intValue % 2 != 0)
                                {
                                    product *= intValue;
                                    foundOddInteger = true;
                                }
                            }
                        }
                    }
                }
            }

            // اگر عددی پیدا نشد، 0 برگردان
            if (!foundOddInteger)
                return 0;

            // گرد کردن به 3 رقم اعشار
            return Math.Round(product, 3);
        }

        private bool TryParseNumber(string str, out double result)
        {
            // جایگزینی کاما با نقطه
            str = str.Replace(',', '.');

            // اگر عدد با نقطه شروع می‌شود، صفر اضافه کن
            if (str.StartsWith(".") || str.StartsWith(","))
                str = "0" + str;

            return double.TryParse(str, NumberStyles.Any,
                                 CultureInfo.InvariantCulture, out result);
        }

        private bool IsInteger(double number)
        {
            // بررسی با دقت بیشتر
            double epsilon = 1e-10;
            return Math.Abs(number - Math.Truncate(number)) < epsilon;
        }
    }
}