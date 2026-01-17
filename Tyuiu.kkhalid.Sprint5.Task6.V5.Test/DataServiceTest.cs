using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task6.V5.Lib;


namespace Tyuiu.KkhalidIS.Sprint5.Task6.V5.Test
{
    [TestClass]
    public class DataServiceTest
    {
        private string _testFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            // Создаем тестовый файл перед каждым тестом
            _testFilePath = Path.Combine(Path.GetTempPath(), "InputFileTask6V5.txt");

            // Очищаем файл если он существует
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void CheckedExistsFile()
        {
            // Создаем тестовый файл
            string testData = "Hello WORLD! ABC 123 XYZ";
            File.WriteAllText(_testFilePath, testData);

            // Проверяем существование
            FileInfo fileInfo = new FileInfo(_testFilePath);
            bool fileExists = fileInfo.Exists;

            Assert.IsTrue(fileExists, "Файл должен существовать");
        }

        [TestMethod]
        public void ValidCalc()
        {
            // Подготовка данных
            DataService ds = new DataService();

            // Создаем тестовый файл с известным содержанием
            string testData = "Hello WORLD! ABC 123 XYZ";
            File.WriteAllText(_testFilePath, testData);

            // Вызов метода
            int result = ds.LoadFromDataFile(_testFilePath);

            // Ожидаемый результат: H(1) + WORLD(5) + ABC(3) + XYZ(3) = 12
            int expected = 12;

            // Проверка
            Assert.AreEqual(expected, result,
                "Количество заглавных латинских букв подсчитано неверно");
        }

        [TestMethod]
        public void ValidCalc_EmptyFile()
        {
            // Тест с пустым файлом
            DataService ds = new DataService();

            File.WriteAllText(_testFilePath, "");

            int result = ds.LoadFromDataFile(_testFilePath);
            int expected = 0;

            Assert.AreEqual(expected, result,
                "Для пустого файла должен возвращаться 0");
        }

        [TestMethod]
        public void ValidCalc_OnlyLowercase()
        {
            // Тест только со строчными буквами
            DataService ds = new DataService();

            File.WriteAllText(_testFilePath, "hello world abc xyz");

            int result = ds.LoadFromDataFile(_testFilePath);
            int expected = 0;

            Assert.AreEqual(expected, result,
                "Для строчных букв должен возвращаться 0");
        }

        [TestMethod]
        public void ValidCalc_OnlyUppercase()
        {
            // Тест только с заглавными буквами
            DataService ds = new DataService();

            File.WriteAllText(_testFilePath, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            int result = ds.LoadFromDataFile(_testFilePath);
            int expected = 26; // Все буквы алфавита

            Assert.AreEqual(expected, result,
                "Для полного алфавита заглавных букв должно быть 26");
        }

    }
}