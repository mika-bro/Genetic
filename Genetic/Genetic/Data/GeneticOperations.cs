using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Model;
using System.Threading;

namespace Genetic.Data
{
    class GeneticOperations
    {
        public int ReproductionProb { get; set; }
        public int CrossingProb { get; set; }
        public int MutationProb { get; set; }

        public GeneticOperations(int mutationProb, int crossinProb)
        {
            ReproductionProb = 100 - crossinProb - mutationProb;
            CrossingProb = crossinProb;
            MutationProb = mutationProb;
        }

        public List<Individual> Perform(Population population, Rulet rulet)
        {
            int r = Parameters.Random.Next(1, 101);
            if(r <= ReproductionProb)
            {
                RuletIndividual ind = rulet.Try();
                Individual pickedIndividual = population.Get(ind.IndividualID);
                return new List<Individual>
                {
                    new Individual(pickedIndividual.Chromosome)
                };
            }
            if((r > ReproductionProb) & (r <= CrossingProb))
            {
                RuletIndividual ind = rulet.Try();
                Individual father = population.Get(ind.IndividualID);
                RuletIndividual _ind = rulet.Try();
                Individual mather = population.Get(_ind.IndividualID);
                var inds = Cross(father, mather);
                return inds;
            }
            else
            {
                RuletIndividual ind = rulet.Try();
                Individual pickedIndividual = population.Get(ind.IndividualID);
                Individual mutatedIndividual = Mutate(pickedIndividual);
                return new List<Individual> { mutatedIndividual };
            }
        }

        public List<Individual> Cross(Individual father, Individual mother)
        {
            int crossingSide = Parameters.Random.Next(1, father.Chromosome.Length);
            string newChromosome1 = CrossChromosome(father, mother, crossingSide);
            string newChromosome2 = CrossChromosome(mother, father, crossingSide);
            Individual Children1 = new Individual(newChromosome1);
            Individual Children2 = new Individual(newChromosome2);
            return new List<Individual>{Children1, Children2};
        }

        public Individual Mutate(Individual ind)
        {
            int mutationSide = Parameters.Random.Next(1, ind.Chromosome.Length);
            string mutatedChromosome = "";
            int i = 1;
            foreach(var item in ind.Chromosome)
            {
                if(i == mutationSide)
                {
                    if (item.Equals('0'))
                    {
                        mutatedChromosome = mutatedChromosome + 1;
                    }
                    if (item.Equals('1'))
                    {
                        mutatedChromosome = mutatedChromosome + 0;
                    }
                }
                else
                {
                    mutatedChromosome = mutatedChromosome + item;
                }
                i = i + 1;
            }
            return new Individual(mutatedChromosome);
        }

        private string CrossChromosome(Individual parent1, Individual parent2, int cross_place)
        {
            var L = parent1.Chromosome.Length;

            string part_one = "";
            for (int i = 0; i < cross_place; i++)
            {
                var x = parent1.Chromosome[i];
                part_one = part_one + x;
            }

            string part_two = "";
            for (int i = cross_place; i < L; i++)
            {
                var x = parent2.Chromosome[i];
                part_two = part_two + x;
            }

            return part_one + part_two;
        }
    }
}
