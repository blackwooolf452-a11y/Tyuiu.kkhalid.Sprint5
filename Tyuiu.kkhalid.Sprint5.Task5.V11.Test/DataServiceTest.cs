using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Kkhalid.Sprint5.Task5.V11.Lib;

namespace Tyuiu.Kkhalid.Sprint5.Task5.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            // ساخت مسیر در Temp
            string tempPath = Path.GetTempPath();
            string dataDir = Path.Combine(tempPath, "DataSprint5Test");

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string path = Path.Combine(dataDir, "TestFile.txt");

            // ایجاد فایل تست
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("3");
                writer.WriteLine("5.5");
                writer.WriteLine("7");
                writer.WriteLine("2");
                writer.WriteLine("-3");
                writer.WriteLine("9.0");
                writer.WriteLine("11");
            }

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path);

            // محاسبه دستی: 3 * 7 * (-3) * 9 * 11 = -6237
            double wait = -6237;

            Assert.AreEqual(wait, res);

            // تمیز کردن
            File.Delete(path);
            Directory.Delete(dataDir);
        }
    }
}