using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task7.V12.Lib
{
    public class DataService : ISprint5Task7V12
    {
        public string LoadDataAndSave(string path)
        {
            // Проверка входных параметров
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}", path);

            // Создаем путь для выходного файла
            string outputPath = Path.Combine(
                Path.GetDirectoryName(path) ?? Path.GetTempPath(),
                "OutPutDataFileTask7V12.txt"
            );

            try
            {
                // Читаем входной файл, преобразуем и записываем в выходной
                using (StreamReader reader = new StreamReader(path, Encoding.Default))
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Преобразуем строчные русские буквы в заглавные
                        string transformedLine = ConvertToUpperRussian(line);
                        writer.WriteLine(transformedLine);
                    }
                }

                return outputPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке файла: {ex.Message}", ex);
            }
        }

        private string ConvertToUpperRussian(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder(input.Length);

            foreach (char c in input)
            {
                // Проверяем, является ли символ строчной русской буквой
                // Диапазоны Unicode для русских букв: 
                // строчные: а-я (1072-1103), ё (1105)
                // заглавные: А-Я (1040-1071), Ё (1025)
                if ((c >= 'а' && c <= 'я') || c == 'ё')
                {
                    // Преобразуем строчную русскую букву в заглавную
                    if (c == 'ё')
                        result.Append('Ё');
                    else
                        result.Append((char)(c - 32)); // Разница в кодировке
                }
                else
                {
                    // Оставляем другие символы без изменений
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // Альтернативная реализация с использованием стандартных методов
        public string LoadDataAndSaveAlternative(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}", path);

            string outputPath = Path.Combine(
                Path.GetDirectoryName(path) ?? Path.GetTempPath(),
                "OutPutDataFileTask7V12.txt"
            );

            string content = File.ReadAllText(path, Encoding.Default);
            string transformedContent = ConvertToUpperRussianAlternative(content);

            File.WriteAllText(outputPath, transformedContent, Encoding.Default);

            return outputPath;
        }

        private string ConvertToUpperRussianAlternative(string input)
        {
            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                // Преобразуем только строчные русские буквы
                if ((c >= 'а' && c <= 'я'))
                {
                    chars[i] = char.ToUpper(c);
                }
                else if (c == 'ё')
                {
                    chars[i] = 'Ё';
                }
            }

            return new string(chars);
        }
    }
}