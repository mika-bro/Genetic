using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Model;
using Genetic.Data;

namespace Genetic
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Reader.DefineFilePath("config.txt");
            var config = Reader.ReadConfigFile(path);

            Parameters.Random = new Random();
            Parameters.PopulationSize = config["population"];
            Parameters.Generations = config["generations"];
            Parameters.MutationProb = config["mutation-prob"];
            Parameters.CrossingProb = config["crossing-prob"];
            Parameters.MoveUp = 0;
            Parameters.Xmin = 500;
            Parameters.Xmax = 2500;

            Population population = new Population(Parameters.PopulationSize);
            Population overRase = Algorithm.Perform(population);
            Console.WriteLine(" ");
            overRase.Show();
            Console.WriteLine(" ");
            overRase.ShowBest();
            Console.ReadKey();
        }
    }
}
