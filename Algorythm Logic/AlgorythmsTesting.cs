namespace Algorythm_Logic;

using Algorythm_Logic.Algorythms;
using Algorythms_Logic.Algorythms;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;

public class AlgorythmsTesting
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
    public static int[][,] GenerateMatixSet(MatrixOperation matrixOp, int maxRank, int limits) //Генерирует массив из матриц размером maxRank * NumberOfOperands. Причём для каждого размера подряд идёт NumberOfOperands матриц одного размера 
    {
        int[][,] set = new int[maxRank * matrixOp.NumberOfOperands][,];
        int curentRank = 0;
        for (int i = 0;i < maxRank * matrixOp.NumberOfOperands; i += matrixOp.NumberOfOperands)
        {
            for (int j = 0;j < matrixOp.NumberOfOperands; j++)
            {
                int[,] matrix = GenerateMatix(curentRank, limits);
                set[i + j] = matrix;
            }
            curentRank++;
        }
        return set;
    }
    public static double[] TestExecutionTime(Algorythm algorythm, int[] data, int[] marking) // Принимает алгоритм, данные и массив разметки (иксов). Возвращает массив времени выполнения алгоритма для каждой метки
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
            result[i] = (double)stopwatch.ElapsedTicks / 10000;
            
        }
        return result;
    }
    public static double[] TestExecutionTime(MatrixOperation matrixOp, int[][,] data) // Принимает алгоритм, данные и массив разметки (иксов). Возвращает массив времени выполнения алгоритма для каждой метки
    {
        int numberOfOperands = matrixOp.NumberOfOperands;
        int curentMartixGroup = 0;
        double[] result = new double[data.Length / numberOfOperands]; ;
        for (int i = 0; i < data.Length / numberOfOperands; i ++)
        {
            int[][,] testData = new int[numberOfOperands][,];
            Array.Copy(data, curentMartixGroup, testData, 0, numberOfOperands);
            Stopwatch stopwatch = Stopwatch.StartNew();
            matrixOp.Execute(testData);
            stopwatch.Stop();
            result[i] = (double)stopwatch.ElapsedTicks / 10000;
            curentMartixGroup += numberOfOperands;
        }
        return result;
    }
    public static List<Algorythm> FindAvilibleAlgorythms()
    {
        var parent = typeof(Algorythm);                                                                     //Получение типа базового класса Algorythm
        var assamblies = AppDomain.CurrentDomain.GetAssemblies();                                           //Получение списка всех сборок в приложении
        var allTypes = assamblies.SelectMany(a => a.GetTypes());                                            // Получение списка всех типов, существующих в приложении
        var algorythmTypes = allTypes.Where(t => parent.IsAssignableFrom(t) && !t.IsAbstract).ToList();     // Получение списка всех типов, наследуемых от Algorythm
        var algorthms = algorythmTypes.Select(type => (Algorythm)Activator.CreateInstance(type)).ToList();  // Получение списка из экземпляров классов, наследуемых от Algorythm

        return algorthms;
    }
}