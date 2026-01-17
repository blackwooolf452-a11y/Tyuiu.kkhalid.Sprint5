using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.kkhalid.Sprint5.Task3.V12.Lib
{
    public class DataService : ISprint5Task3V12
    {
        public string SaveToFileBinaryData(double x)
        {
            double x = 1.5; // 3/2 = 1.5
            double y = Math.Pow(x, 3) / (2 * Math.Pow(x + 5, 2));
            y = Math.Round(y, 3);

            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(y);
            }

            return path;
        }

        public string SaveToFileTextData(int x)
        {
            throw new NotImplementedException();
        }
    }
}