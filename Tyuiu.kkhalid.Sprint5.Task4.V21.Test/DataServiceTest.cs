using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task3.V12.Lib;


namespace Tyuiu.kkhalid.Sprint5.Task3.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileBinaryData()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 1.5; // 3/2 = 1.5

            // Act
            string path = ds.SaveToFileBinaryData(x);

            // Assert
            Assert.IsTrue(File.Exists(path), "Файл не создан");

            // Читаем из файла
            double yFromFile;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                yFromFile = reader.ReadDouble();
            }

            // Ожидаемое значение
            double expected = Math.Pow(x, 3) / (2 * Math.Pow(x + 5, 2));
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, yFromFile, 0.001, "Значения не совпадают");

            // Очистка тестового файла
            File.Delete(path);
        }
    }
}