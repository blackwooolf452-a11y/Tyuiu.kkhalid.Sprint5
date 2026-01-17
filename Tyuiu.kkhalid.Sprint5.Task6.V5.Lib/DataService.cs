using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task6.V5.Lib
{
    public class DataService : ISprint5Task6V5
    {
        public int LoadFromDataFile(string path)
        {
            int count = 0;

            try
            {
                // Проверяем существование файла
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Файл не найден: {path}");
                }

                // Читаем файл и подсчитываем заглавные латинские буквы
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        foreach (char c in line)
                        {
                            // Проверяем, является ли символ заглавной латинской буквой
                            // Диапазон ASCII: A-Z (65-90)
                            if (c >= 'A' && c <= 'Z')
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении файла: " + ex.Message);
            }

            return count;
        }
    }
}