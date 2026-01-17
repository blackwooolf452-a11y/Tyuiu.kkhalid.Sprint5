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
            bool wait = true;

            Assert.AreEqual(wait, fileExists);
        }


    }
}