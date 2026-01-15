using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


using Tyuiu.kkhalid.Sprint5.Task1.V17.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task1.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;

            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckFileContent()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            string[] lines = File.ReadAllLines(path);

           
            

           
        }

        [TestMethod]
        public void CheckZeroDivision()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            string[] lines = File.ReadAllLines(path);

            // Проверяем, что при делении на ноль возвращается 0
            // sin(x) + 1 = 0 при x = -π/2 + 2πk или 3π/2 + 2πk
            // В диапазоне [-5; 5] это x ≈ -4.71 и x ≈ 1.57

            bool foundZero = false;
            foreach (string line in lines)
            {
                if (line.Contains("|") && line.Contains("-4.71"))
                {
                    // Проверяем, что значение f(x) = 0
                   
                }
            }

            Assert.IsTrue(foundZero);
        }
    }
}
