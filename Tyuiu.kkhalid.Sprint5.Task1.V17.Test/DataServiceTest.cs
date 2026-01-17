using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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

            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            string[] lines = File.ReadAllLines(path);

            // Должно быть 11 значений (от -5 до 5 включительно)
            Assert.AreEqual(11, lines.Length);

            // Проверяем несколько значений
            // F(-5) = 2*(-5) - 4 + (2*(-5)-1)/(sin(-5)+1)
            Assert.AreEqual("-19.62", lines[0]);
            Assert.AreEqual("-17.12", lines[1]);
            Assert.AreEqual("-18.15", lines[2]);
            Assert.AreEqual("-63.13", lines[3]);
            Assert.AreEqual("-24.92", lines[4]);
            Assert.AreEqual("-5.00", lines[5]);
            Assert.AreEqual("-1.46", lines[6]);
            Assert.AreEqual("1.57", lines[7]);
            Assert.AreEqual("6.38", lines[8]);
            Assert.AreEqual("32.78", lines[9]);
            Assert.AreEqual("225.11", lines[10]);
        }
    }
}