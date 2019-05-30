using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Model;
using System.Threading;

namespace Genetic.Data
{
    class RuletIndividual
    {
        public int ID { get; set; }
        public int IndividualID { get; set; }
    }

    class Rulet
    {
        public List<RuletIndividual> Individuals { get; set; }

        public Rulet(List<Individual> individuals)
        {
            List<RuletIndividual> inds = new List<RuletIndividual>();
            foreach (var item in individuals)
            {
                int ruletArea = FindProportion(item, individuals.Sum(x => x.Fitness));
                for (int i = 0; i < ruletArea; i++)
                {
                    int n;
                    if (inds == null) n = 0;
                    else n = inds.Count();
                    inds.Add(
                        new RuletIndividual
                        {
                            ID = n + 1,
                            IndividualID = item.ID
                        });
                };
            }
            Individuals = inds;
        }

        public int FindProportion(Individual ind, double sumFitness)
        {
            double _proportion = ind.Fitness / sumFitness;
            int proportion = (int)(_proportion * 1000);
            return proportion;
        }

        public RuletIndividual Try()
        {
            int randomIndex = Parameters. Random.Next(0, Individuals.Count());
            return Individuals[randomIndex];
        }

        public void ShowProportions(List<Individual> inds)
        {
            Dictionary<int, int> ruletProportions = new Dictionary<int, int>();
            for(int i = 1; i <= Parameters.PopulationSize; i++)
            {
                int ruletArea = Individuals.FindAll(x => x.IndividualID == i).Count();
                ruletProportions.Add(i, ruletArea);
            }
            foreach(var item in ruletProportions)
            {
                Individual ind = inds.Single(x => x.ID == item.Key);
                Console.WriteLine(item.Key + "  " + item.Value + "  " + ind.Fitness);
                
            }
            Console.WriteLine(" ");
        }
    }
}
