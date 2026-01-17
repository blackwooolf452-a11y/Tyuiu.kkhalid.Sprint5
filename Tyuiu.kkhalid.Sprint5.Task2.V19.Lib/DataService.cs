using System;
using System.IO;
using System.Text;
using Tyuiu.kkhalid.Sprint5.Task2.V19.Lib;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task2.V19.Lib
{
    public class DataService : ISprint5Task2V19
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask2.csv");

            // Удаляем файл если существует
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            StringBuilder csvContent = new StringBuilder();

            // Создаем копию матрицы и заменяем нечетные элементы на 0
            int[,] modifiedMatrix = (int[,])matrix.Clone();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (modifiedMatrix[i, j] % 2 != 0) // если элемент нечетный
                    {
                        modifiedMatrix[i, j] = 0;
                    }
                }
            }

            // Формируем CSV строки
            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = new string[columns];
                for (int j = 0; j < columns; j++)
                {
                    rowValues[j] = modifiedMatrix[i, j].ToString();
                }
                csvContent.AppendLine(string.Join(";", rowValues));
            }

            // Записываем в файл
            File.WriteAllText(path, csvContent.ToString());

            return path;
        }
    }
}