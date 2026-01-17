using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task2.V19.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task2.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[3, 3] {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            string path = ds.SaveToFileTextData(matrix);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[3, 3] {
                { 9, 2, 5 },
                { 8, 8, 2 },
                { 7, 4, 8 }
            };

            string path = ds.SaveToFileTextData(matrix);

            string[] lines = File.ReadAllLines(path);

            // Должно быть 3 строки (3x3 массив)
            Assert.AreEqual(3, lines.Length);

            // Проверяем содержимое
            // Первая строка: 9,2,5 -> 0,2,0 (CSV: "0;2;0")
            // Вторая строка: 8,8,2 -> 8,8,2 (CSV: "8;8;2")
            // Третья строка: 7,4,8 -> 0,4,8 (CSV: "0;4;8")
            Assert.AreEqual("0;2;0", lines[0]);
            Assert.AreEqual("8;8;2", lines[1]);
            Assert.AreEqual("0;4;8", lines[2]);
        }

        [TestMethod]
        public void ValidSaveToFileWithOtherMatrix()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[3, 3] {
                { 0, 1, 0 },
                { 10, 10, 1 },
                { 0, 1, 1 }
            };

            string path = ds.SaveToFileTextData(matrix);

            string[] lines = File.ReadAllLines(path);

            // Проверяем содержимое
            // 0,1,0 -> 0,0,0
            // 10,10,1 -> 10,10,0
            // 0,1,1 -> 0,0,0
            Assert.AreEqual("0;0;0", lines[0]);
            Assert.AreEqual("10;10;0", lines[1]);
            Assert.AreEqual("0;0;0", lines[2]);
        }
    }
}