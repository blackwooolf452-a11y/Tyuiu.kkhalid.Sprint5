using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.kkhalid.Sprint5.Task3.V12.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task3.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);
            bool fileExists = File.Exists(path);
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);
            Assert.IsTrue(File.Exists(path));
        }
    }
}