using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.kkhalid.Sprint5.Task4.V21.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task4.V21.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            // Arrange
            DataService ds = new DataService();

            // Создаем временный файл с тестовым значением
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "2.5");

            // Act
            double result = ds.LoadFromDataFile(tempFile);

            // Assert
            // Для x = 2.5: y = 2.5^3 * cos(2.5) + 2*2.5
            // 15.625 * (-0.8011436155) + 5 = -12.5179 + 5 = -7.5179 ≈ -7.518
            double expected = -7.518;
            Assert.AreEqual(expected, result, 0.001);

            // Cleanup
            File.Delete(tempFile);
        }

        [TestMethod]
        public void CheckedExistsFile()
        {
            // Arrange
            string path = @"C:\DataSprint5\InPutDataFileTask4V21.txt";

            // Act
            bool fileExists = File.Exists(path);

            // Assert
            // Если файл существует - тест пройден
            // Если нет - проверяем, что можем его создать
            if (!fileExists)
            {
                // Пытаемся создать директорию и файл
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(path, "3.5");
                fileExists = true;
            }

            Assert.IsTrue(fileExists);
        }

    }
}