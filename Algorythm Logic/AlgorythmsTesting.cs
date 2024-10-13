namespace Algorythms_Logic;

using Algorythms_Logic.BinaryOperations;
using Algorythms_Logic.MatrixOperations;
using Algorythms_Logic.Algorythms;
using MathNet.Numerics;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Drawing;

public class AlgorythmsTesting
{
    public static int[] GenerateData(int size)
    {
        Random rand = new Random();
        int[] ar = new int[size];
        for (int i = 0; i < ar.Length; i++)
        {
            ar[i] = rand.Next();
        }
        return ar;
    }

    public static int[,] GenerateMatix(int size)
    {
        var mx = new int[size, size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                mx[i, j] = random.Next();
            }
        }
        return mx;
    }
    public static int[][,] GenerateMatixSet(MatrixOperation matrixOp, int maxRank) //Генерирует массив из матриц размером maxRank * NumberOfOperands. Причём для каждого размера подряд идёт NumberOfOperands матриц одного размера 
    {
        int[][,] set = new int[maxRank * matrixOp.NumberOfOperands][,];
        int curentRank = 0;
        for (int i = 0; i < maxRank * matrixOp.NumberOfOperands; i += matrixOp.NumberOfOperands)
        {
            for (int j = 0; j < matrixOp.NumberOfOperands; j++)
            {
                int[,] matrix = GenerateMatix(curentRank);
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
            result[i] = (double)stopwatch.ElapsedTicks / 10000; // Время в милисекундах
        }
        return result;
    }
    public static double[] TestExecutionTime(MatrixOperation matrixOp, int[][,] data, int[] marking) // Перегрузка для матриц
    {
        int numberOfOperands = matrixOp.NumberOfOperands;
        double[] result = new double[marking.Length]; ;
        for (int i = 0; i < marking.Length; i++)
        {
            int[][,] testData = new int[numberOfOperands][,];
            Array.Copy(data, marking[i], testData, 0, numberOfOperands);
            Stopwatch stopwatch = Stopwatch.StartNew();
            matrixOp.Execute(testData);
            stopwatch.Stop();
            result[i] = (double)stopwatch.ElapsedTicks / 10000;
        }
        return result;
    }
    public static double[] TestExecutionTime(BinaryOperation op, int basis, int[] marking) // Принимает алгоритм, данные и массив разметки (иксов). Возвращает массив времени выполнения алгоритма для каждой метки
    {
        double[] result = new double[marking.Length];
        for (int i = 0; i < marking.Length; i++)
        {
            op.Execute(basis, marking[i]);
            result[i] = op.StepCount; // Время в милисекундах

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