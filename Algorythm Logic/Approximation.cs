using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic
{
    public class Approximation
    {
        public static double[] MakeApproximation(int[] intX, double[] dataY,int degree)
        {
            int arraysLength = intX.Length;
            double[] dataX = new double[arraysLength];
            Array.Copy(intX, dataX, arraysLength);
            
            double[] temp;
            double[] aproxY = LinearRegression(dataX, dataY);
            double minError = GoodnessOfFit.CoefficientOfDetermination(aproxY, dataY);
            for (int i = 0; i < degree; i++)
            {
                temp = PolinomialRgression(dataX, dataY, i);
                double error = GoodnessOfFit.PopulationStandardError(temp, dataY);
                if (Math.Abs(error) <Math.Abs(minError))
                {
                    minError = error;
                    aproxY = temp;
                }
            }
            return aproxY;
        }
        public static double[] MakeApproximation(int[] intX, double[] dataY, int degree, List<double> errorList)
        {
            errorList.Clear();
            int arraysLength = intX.Length;
            double[] dataX = new double[arraysLength];
            Array.Copy(intX, dataX, arraysLength);

            double[] temp;
            double[] aproxY = LinearRegression(dataX, dataY);
            double minError;
            minError = GoodnessOfFit.PopulationStandardError(aproxY, dataY);
            errorList.Add(minError);
            for (int i = 0; i < degree; i++)
            {
                temp = PolinomialRgression(dataX, dataY, i);
                double error = GoodnessOfFit.PopulationStandardError(temp, dataY);
                errorList.Add(error);
                if (Math.Abs(error) < Math.Abs(minError))
                {
                    minError = error;
                    aproxY = temp;
                }
            }
            return aproxY;
        }
        public static double[] PolinomialRgression(double[] dataX, double[] dataY,int degree)
        {
            double[] regressY = new double[dataY.Length];
            double[] p = Fit.Polynomial(dataX, dataY, degree);
            for (int i = 0; i < dataX.Length; i++)
            {
                int x = (int)dataX[i];
                double element = 0;
                {
                    for (int j = 0; j < degree; j++)
                    {
                        element += p[j] * Math.Pow(x, j);
                    }
                }
                regressY[i] = element;
            }
            double error = GoodnessOfFit.PopulationStandardError(regressY, dataY);
            return regressY;
        }
        public static double[] LinearRegression(double[] dataX, double[] dataY)
        {
            double[] regressY = new double[dataY.Length];
            (double, double) l = Fit.Line(dataX, dataY);
            for (int i = 0;i < dataX.Length;i++)
            {
                regressY[i] = l.Item2 * dataX[i] + l.Item1;
            }    
            return regressY;
        }

    }
}
