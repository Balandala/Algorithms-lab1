using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class HornerMethod: Algorythm
    {
        public override string Description => "Метод Горнора";
        public override int MaxArraySize => 100000000;

        public override void Execute(int[] array)
        {
            double x = 1.5;
            HornerMethod_(array, x);
        }
        private static double HornerMethod_(int[] coefficients, double x)
        {
            double result = 0;

            // Проходим по коэффициентам полинома в прямом порядке
            for (int i = 0; i < coefficients.Length; i++)
            {
                result = result * x + coefficients[i];
            }

            return result;
        }
    }
}
