using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Genetic.Data
{
    class Reader
    {
        public static Dictionary<string, int> ReadConfigFile(string path)
        {
            Dictionary<string, int> config = new Dictionary<string, int>();
            var file = File.ReadLines(path);
            foreach (var item in file)
            {
                string[] splitedLine = item.Split(':');
                config.Add(
                    splitedLine[0],
                    Int32.Parse(splitedLine[1]));

            }
            return config;
        }

        static public string DefineFilePath(string fileName)
        {
            var path1 = Directory.GetCurrentDirectory();
            var path2 = Directory.GetParent(path1).ToString();
            var path3 = Directory.GetParent(path2).ToString();
            var root = Directory.GetParent(path3).ToString();
            return root + @"\files\" + fileName;
        }

        static public void WriteAvarageFitnes(List<double> avFittnes)
        {
            StringBuilder file = new StringBuilder();
            int i = 1;
            foreach(var item in avFittnes)
            {
                file.AppendLine(i.ToString() + ";" + item.ToString());
            }
            File.WriteAllText("C:\\F\\genetic.csv", file.ToString());
        }
    }
}
