using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    internal class EvaluatePolynomialcs : Algorythm
    {
        public override string Description => "Прямое (наивное) вычисление многочлена";
        public override int MaxArraySize => 10000000;

        public override void Execute(int[] coefficients)
        {
            double x = 1.5;
            double result = 0;
            int degree = coefficients.Length - 1;

            for (int i = 0; i <= degree; i++)
            {
                result += coefficients[i] * Math.Pow(x, degree - i);
            }

        }
    }
}
