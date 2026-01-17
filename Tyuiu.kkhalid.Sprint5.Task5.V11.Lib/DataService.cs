using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

using System.IO;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib
{
    public class DataService : ISprint5Task5V11
    {
        public double LoadFromDataFile(string path)
        {
            // بررسی وجود فایل
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден по пути: {path}");
            }

            double product = 1;
            bool hasOddInt = false;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    line = line.Trim();

                    // رد کردن خطوط خالی
                    if (string.IsNullOrEmpty(line))
                        continue;

                    try
                    {
                        // جایگزینی کاما با نقطه
                        string normalizedLine = line.Replace(',', '.');

                        if (double.TryParse(normalizedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                        {
                            // بررسی صحیح بودن (بدون جزء اعشاری)
                            bool isInteger = Math.Abs(number - Math.Truncate(number)) < 0.000001;

                            if (isInteger)
                            {
                                int intValue = (int)number;

                                // بررسی فرد بودن (هم برای مثبت هم منفی)
                                if (Math.Abs(intValue) % 2 == 1)
                                {
                                    product *= intValue;
                                    hasOddInt = true;

                                    // پیوند برای دیباگ (اختیاری)
                                    // Console.WriteLine($"Найдено нечетное целое: {intValue}");
                                }
                            }
                        }
                        else
                        {
                            // اگر عدد معتبر نیست، می‌توانیم خطا بدهیم یا نادیده بگیریم
                            // Console.WriteLine($"Предупреждение: строка {lineNumber} содержит нечисловое значение: '{line}'");
                        }
                    }
                    catch (FormatException)
                    {
                        // نادیده گرفتن خطوط با فرمت نامعتبر
                        continue;
                    }
                }
            }

            if (!hasOddInt)
            {
                // اگر هیچ عدد صحیح فردی پیدا نشد
                return 0;
            }

            // گرد کردن به سه رقم اعشار
            return Math.Round(product, 3);
        }
    }
}