using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic.Model;
using System.Threading;

namespace Genetic.Data
{
    class Algorithm
    {
        public static Population Perform(Population startPopulation)
        {
            GeneticOperations genetic = new GeneticOperations(Parameters.MutationProb, Parameters.CrossingProb);
            Population population = startPopulation;
            List<double> avarageFittnesForGeneration = new List<double>();
            for (int k = 0; k < Parameters.Generations; k++)
            {
                Rulet rulet = new Rulet(population.Individuals);
                //rulet.ShowProportions(population.Individuals);
                Population newOffspring = new Population();
                int j = 0;
                do
                {
                    List<Individual> newInds = genetic.Perform(population, rulet);
                    newOffspring.Add(newInds, j);
                    j = j + 1;
                } while (newOffspring.GetSize() < population.GetSize());
                newOffspring.RemoveLast();
                var avarageFittnes = newOffspring.ShowAvarageFittnes(k + 1);
                avarageFittnesForGeneration.Add(avarageFittnes);
                population = newOffspring.Copy();
            }

            Reader.WriteAvarageFitnes(avarageFittnesForGeneration);
            return population;
        }
    }
}
