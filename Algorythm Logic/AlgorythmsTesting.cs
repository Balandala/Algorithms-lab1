namespace Algorythm_Logic;
using Algorythms_Logic.Algorythms;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;

public class AlgorythmTesting
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
    public static long[] TestExecutionTime(Algorythm algorythm, int[] data, int[] marking) // Принимает алгоритм, данные и массив разметки (иксов). Возвращает массив времени выполнения алгоритма для каждой метки
    {
        long[] result = new long[marking.Length];
        for (int i = 0; i < marking.Length; i++)
        { 
            int mark = marking[i];
            int[] testData = new int[mark];
            Array.Copy(data, testData, mark); 
            Stopwatch stopwatch = Stopwatch.StartNew();
            algorythm.Execute(testData);
            stopwatch.Stop();
            result[i] = stopwatch.ElapsedMilliseconds;
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