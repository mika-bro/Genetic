using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic.Data
{
    class Function
    {
        public static double Count(double x)
        {
            return CountSinusoidFunction(x);
        }

        public static double Count(string chromosome)
        {
            int _x = Convert.ToInt32(chromosome, 2);
            double x = (double)_x / (double)1000;
            double result = Count(x);
            return result;
        }

        public static double ToPhenotype(string chromosome)
        {
            int _x = Convert.ToInt32(chromosome, 2);
            double x = (double)_x / (double)1000;
            return x;
        }

        private static double CountSinusoidFunction(double x)
        {
            if (x < 0.5)
            {
                return 0;
            }
            if (x > 2.5)
            {
                return 0;
            }
            else
            {
                return ((Math.Pow(Math.E, x) * Math.Sin(10 * Math.PI * x) + 1) / x) + Parameters.MoveUp;
            }
            
        }

        private static double CountTestFunction(double x)
        {
            if (x < (Parameters.Xmin / 1000))
            {
                return 0;
            }
            if (x > ((Parameters.Xmax - 1) / 1000))
            {
                return 0;
            }
            else
            {
                double result = -Math.Pow((x - 5), 2) + 10;
                return result;
            }
        }
    }
}
