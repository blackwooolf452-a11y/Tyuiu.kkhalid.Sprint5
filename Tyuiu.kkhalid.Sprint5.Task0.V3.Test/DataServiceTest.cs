using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.kkhalid.Sprint5.Task0.V3.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task0.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            int x = 3;

            // اجرای متد
            string path = ds.SaveToFileTextData(x);

            // بررسی وجود فایل
            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            // مقدار مورد انتظار
            bool wait = true;

            // تست
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckFileContent()
        {
            DataService ds = new DataService();
            int x = 3;

            // اجرای متد
            string path = ds.SaveToFileTextData(x);

            // خواندن محتوای فایل
            string content = File.ReadAllText(path);
            double result = double.Parse(content);

            // محاسبه مقدار مورد انتظار
            double expected = -(1.0 / 4.0) * (Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + 4);
            expected = Math.Round(expected, 3);

            // تست
            Assert.AreEqual(expected, result);
        }
    }
}