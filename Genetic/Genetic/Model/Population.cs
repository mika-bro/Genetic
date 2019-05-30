using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Data;
using System.Threading;

namespace Genetic.Model
{
    class Population
    {
        public List<Individual> Individuals { get; set; }
        public int Size { get; set; }

        public Population()
        {
            Individuals = new List<Individual>();
        }

        public Population(List<Individual> inds)
        {
            this.Individuals = inds;
        }

        public Population(int n)
        {
            List<Individual> individuals = new List<Individual>();
            for (int i = 0; i < n; i++)
            {                
                int _randomValue = Parameters.Random.Next(Parameters.Xmin, 2501);
                double randomValue = (double)_randomValue / (double)1000;
                string chromosome = Extend(
                    Convert.ToString(_randomValue, 2)
                    );
                Individual individual = new Individual()
                {
                    ID = i + 1,
                    Chromosome = chromosome,
                    Phenotype = randomValue,
                    Fitness = Function.Count(randomValue)
                };
                individuals.Add(individual);
            }
            Individuals = individuals;
            Size = n;
        }

        private string Extend(string binaryNumber)
        {
            string maxValue = Convert.ToString(Parameters.Xmax, 2);
            int maxLenght = maxValue.Count();
            int missingLenght = maxLenght - binaryNumber.Count();
            string addingPart = "";
            for(int i = 0; i < missingLenght; i++)
            {
                addingPart = addingPart + "0";
            }
            binaryNumber = addingPart + binaryNumber;
            return binaryNumber;
        }

        public Individual Get(int id)
        {
            return Individuals.Single(x => x.ID == id);
        }

        public void Add(List<Individual> inds, int i)
        {
            int id;
            if(Individuals == null)
            {
                id = 1;
            }
            else
            {
                id = Individuals.Count() + 1;
            }
            foreach(var item in inds)
            {
                item.ID = id;
                Individuals.Add(item);
                id = id + 1;
            }
            
        }

        public void Show()
        {
            foreach(var item in Individuals)
            {
                Console.WriteLine(item.Chromosome + "   " + item.Phenotype + "   " + (item.Fitness - Parameters.MoveUp));
            }
        }

        public int GetSize()
        {
            return Individuals.Count();
        }

        public Population Copy()
        {
            return new Population(Individuals);
        }

        public void RemoveLast()
        {
            if(Individuals.Count() > Parameters.PopulationSize)
            {
                Individual lastOne = Individuals.Last();
                Individuals.Remove(lastOne);
            }
        }

        public double ShowAvarageFittnes(int generation)
        {
            double fittnesSum = Individuals.Sum(x => x.Fitness);
            double result = fittnesSum / Individuals.Count();
            Console.WriteLine("generation " + generation + ":   " + (result - Parameters.MoveUp));
            return result;
        }

        public void ShowBest()
        {
            var maxFittnes = Individuals.Max(x => x.Fitness);
            Individual bestInd = Individuals.Where(x => x.Fitness == maxFittnes).First();
            Console.WriteLine(bestInd.Phenotype + "   " + (bestInd.Fitness - Parameters.MoveUp));
        }
    }
}
