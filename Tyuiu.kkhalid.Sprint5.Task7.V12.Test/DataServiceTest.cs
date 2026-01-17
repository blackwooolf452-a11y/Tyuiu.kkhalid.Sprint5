using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.kkhalid.Sprint5.Task7.V12.Lib;

namespace Tyuiu.kkhalid.Sprint5.Task7.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {
        private string _testInputPath;
        private DataService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new DataService();
            _testInputPath = Path.Combine(Path.GetTempPath(), "InPutDataFileTask7V12.txt");

            // Очищаем файлы перед тестом
            if (File.Exists(_testInputPath))
                File.Delete(_testInputPath);

            string outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V12.txt");
            if (File.Exists(outputPath))
                File.Delete(outputPath);
        }

        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            // Подготовка тестовых данных
            string testData = "Привет, мир! Это тестовый текст.\n" +
                             "Строчные русские буквы: а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я\n" +
                             "Заглавные русские буквы: А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я\n" +
                             "Английские буквы: abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ\n" +
                             "Цифры: 1234567890\n" +
                             "Символы: !@#$%^&*()_+-=[]{}|;:'\",.<>?/";

            File.WriteAllText(_testInputPath, testData, System.Text.Encoding.Default);

            // Выполнение метода
            string outputPath = _service.LoadDataAndSave(_testInputPath);

            // Проверки
            Assert.IsTrue(File.Exists(outputPath), "Выходной файл должен быть создан");

            string outputContent = File.ReadAllText(outputPath, System.Text.Encoding.Default);

            // Проверяем преобразование строчных русских букв
            Assert.IsTrue(outputContent.Contains("ПРИВЕТ, МИР!"), "Строчные русские буквы должны быть преобразованы в заглавные");
            Assert.IsTrue(outputContent.Contains("СТРОЧНЫЕ РУССКИЕ БУКВЫ:"), "Заголовок должен быть в верхнем регистре");
            Assert.IsTrue(outputContent.Contains("ЗАГЛАВНЫЕ РУССКИЕ БУКВЫ:"), "Заглавные русские буквы должны остаться без изменений");

            // Проверяем, что английские буквы не изменились
            Assert.IsTrue(outputContent.Contains("abcdefghijklmnopqrstuvwxyz"), "Английские строчные буквы не должны меняться");
            Assert.IsTrue(outputContent.Contains("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), "Английские заглавные буквы не должны меняться");

            // Проверяем, что цифры и символы не изменились
            Assert.IsTrue(outputContent.Contains("1234567890"), "Цифры не должны меняться");
            Assert.IsTrue(outputContent.Contains("!@#$%^&*()_+-=[]{}|;:'\",.<>?/"), "Символы не должны меняться");
        }

        [TestMethod]
        public void CheckedExistsOutputFile()
        {
            // Создаем тестовый файл
            string testData = "тестовый текст с русскими буквами";
            File.WriteAllText(_testInputPath, testData, System.Text.Encoding.Default);

            // Выполняем метод
            string outputPath = _service.LoadDataAndSave(_testInputPath);

            // Проверяем существование файла
            FileInfo fileInfo = new FileInfo(outputPath);
            bool fileExists = fileInfo.Exists;

            Assert.IsTrue(fileExists, "Выходной файл должен существовать");
        }
    }
}