namespace Algorythm_Logic;
using Algorythms_Logic.Algorythms;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;

public class Testing
{
    public static int[] GenerateData(int size, int limits) 
    {
        Random rand = new Random();
        int[] ar = new int[size];
        for(int i = 0; i < ar.Length; i++)
        {
            ar[i] = rand.Next(-limits, limits);
        }
        return ar;
    }

    public static int[,] GenerateMatix(int size, int limits)
    {
        var mx = new int[size,size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++) 
            {
                mx[i,j] = random.Next(-limits, limits);
            }
        }
        return mx;
    } 
}

public class Tester
{
    public static double[] TestExecutionTime(Algorythm algorythm, int[] data, int[] marking)
    {
        double[] result = new double[marking.Length];
        for (int i = 0; i < marking.Length; i++)
        { 
            int mark = marking[i];
            int[] testData = new int[mark];
            Array.Copy(data, testData, mark); 
            Stopwatch stopwatch = Stopwatch.StartNew();
            algorythm.Execute(testData);
            stopwatch.Stop();
            result[i] = (double)stopwatch.ElapsedTicks;
        }
        return result;
    }
}