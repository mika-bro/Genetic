using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Data;

namespace Genetic.Model
{
    class Individual
    {
        public int ID { get; set; }
        public string Chromosome{ get; set; }
        public double Phenotype { get; set; }
        public double Fitness { get; set; }
        public int Frequence { get; set; }

        public Individual()
        {

        }

        public Individual(string chromosome)
        {
            Chromosome = chromosome;
            Phenotype = Function.ToPhenotype(chromosome);
            Fitness = Function.Count(chromosome);
        }
    }
}
