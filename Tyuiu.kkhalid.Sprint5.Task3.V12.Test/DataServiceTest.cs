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
            // Arrange
            DataService ds = new DataService();
            int x = 3;
            double expected = 0.211; // x³/(2*(x+5)²) при x=3 = 27/(2*64) = 27/128 = 0.2109375 ≈ 0.211

            // Act
            string path = ds.SaveToFileTextData(x);
            bool fileExists = File.Exists(path);

            // Assert
            Assert.IsTrue(fileExists, "Файл должен существовать");
        }

        [TestMethod]
        public void ValidCalculate()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 3;
            double expected = 0.211; // 27/(2*64) = 27/128 = 0.2109375

            // Act
            double result = ds.Calculate(x);

            // Assert
            Assert.AreEqual(expected, result, 0.001, "Результат вычислений должен быть правильным");
        }

        [TestMethod]
        public void CheckedExistsFile()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 3;

            // Act
            string path = ds.SaveToFileTextData(x);
            bool fileExists = File.Exists(path);

            // Assert
            Assert.IsTrue(fileExists, "Файл должен существовать после сохранения");

            // Дополнительная проверка содержимого файла
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                double savedValue = reader.ReadDouble();
                double expected = 0.211;
                Assert.AreEqual(expected, savedValue, 0.001, "Значение в файле должно быть правильным");
            }
        }
    }
}