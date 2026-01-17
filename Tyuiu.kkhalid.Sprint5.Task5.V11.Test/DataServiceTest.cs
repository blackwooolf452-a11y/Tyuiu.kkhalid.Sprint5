using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestWithExpectedResult()
        {
            // ایجاد فایل تست موقت
            string testFile = Path.GetTempFileName();

            // داده‌هایی که باید 12005 تولید کنند
            // 5 * 7 * 49 * 7 = 12005
            File.WriteAllLines(testFile, new string[]
            {
                "5",
                "7.0",
                "2",
                "49",
                "7.5",
                "7",
                "10"
            });

            var ds = new DataService();
            double result = ds.LoadFromDataFile(testFile);

            // پاک کردن فایل موقت
            File.Delete(testFile);

            Assert.AreEqual(12005.0, result, 0.001,
                $"Ожидалось 12005.0, получено {result}");
        }

        [TestMethod]
        public void TestRealFile()
        {
            string realPath = @"C:\DataSprint5\InPutDataFileTask5V11.txt";

            if (!File.Exists(realPath))
            {
                Assert.Inconclusive("Файл не найден: " + realPath);
                return;
            }

            var ds = new DataService();
            double result = ds.LoadFromDataFile(realPath);

            // لاگ برای دیباگ
            System.Diagnostics.Debug.WriteLine($"Результат из реального файла: {result}");

            // مقدار انتظاری بر اساس پیام خطا
            Assert.AreEqual(12005.0, result, 0.001,
                $"Ожидалось 12005.0, получено {result}. Проверьте содержимое файла.");
        }
    }
}