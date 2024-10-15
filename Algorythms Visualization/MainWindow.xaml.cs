using Algorythm_Logic;
using Algorythms_Logic;
using Algorythms_Logic.Algorythms;
using Algorythms_Logic.BinaryOperations;
using Algorythms_Logic.MatrixOperations;
using OpenTK.Graphics.OpenGL;
using ScottPlot;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Algorythms_Visualization
{
    public partial class MainWindow : Window
    {
        private List<Algorythm> _avilibleAlgorytmhs;
        private Algorythm? _selectedAlgorythm;
        private List<double> _aproxErrorData = new List<double>();

        private double[][] MakeExperiments(int[] marking)
        {
            int testAmount = (int)Math.Round(numberOfTests.Value);
            int maxSize = (int)Math.Round(arraySize.Value);
            double[][] experiments = new double[testAmount][];
            for (int i = 0; i < testAmount; i++)
            {
                double[] result = new double[marking.Length];
                if (_selectedAlgorythm is MatrixOperation)
                {
                    MatrixOperation matrixOP = (MatrixOperation)_selectedAlgorythm;
                    var data = AlgorythmsTesting.GenerateMatixSet(matrixOP, maxSize);
                    experiments[i] = AlgorythmsTesting.TestExecutionTime(matrixOP, data, marking);

                }
                else if (_selectedAlgorythm is BinaryOperation)
                {
                    BinaryOperation binOp = (BinaryOperation)_selectedAlgorythm;
                    experiments[i] = AlgorythmsTesting.TestExecutionTime(binOp, (int)Math.Round(basis.Value), marking);

                }
                else
                {
                    var data = AlgorythmsTesting.GenerateData(maxSize);
                    experiments[i] = AlgorythmsTesting.TestExecutionTime(_selectedAlgorythm, data, marking);
                }
                
            }
            return experiments;

        }

        private double[] ToAvarageData(double[][] experements)
        {
            int size = experements[0].Length; //Размер внутренних массивов (количество X)
            double[] dataY = new double[size];
            for (int i = 0; i < size; i++)  // проход по всем элементам внутренних массивов
            {
                double sum = 0;
                for (int j = 0;j < experements.Length; j++) // проход по всем элементам внешнего массива
                {
                    sum += experements[j][i]; //суммирование i-ых элементов внутренних массивов
                }
                dataY[i] = Math.Round(sum / experements.Length, 8);
            }
            return dataY;
        }
        private void Graph_Build()
        {
            MyPlot.Reset();
            // График тестовых данных
            int stp = (int)Math.Round(step.Value);
            int size = (int)(Math.Round(arraySize.Value) / stp);
            int[] dataX = new int[size];
            
            for (int i = 0;i < size;i++)
            {
                dataX[i] = i * stp;
            }
            double[] dataY = ToAvarageData(MakeExperiments(dataX));
            var testDataGraph = MyPlot.Plot.Add.Scatter(dataX, dataY);
            testDataGraph.Label = "Эксперементальные результаты";
            testDataGraph.LineWidth = 1;

            // График аппроксимации

            int degree = (int)Math.Min(20, Math.Round(arraySize.Value / step.Value));// Максимальная степень полинома (нужно, что бы избежать краша при некторых значениях arraySize)
            double[] aproxData = Approximation.MakeApproximation(dataX, dataY, degree, _aproxErrorData);
                var aproxGraph = MyPlot.Plot.Add.Scatter(dataX, aproxData);
            aproxGraph.Label = "Аппроксимация на основе полученных данных";
            aproxGraph.LineWidth = 2;

            // Подписи левой нижней и верхней оси
            MyPlot.Plot.ShowLegend();
            if (_selectedAlgorythm is BinaryOperation)
                MyPlot.Plot.Axes.Left.Label.Text = "Количество шагов";
            else
                MyPlot.Plot.Axes.Left.Label.Text = "Время (миллисекунды)";
            MyPlot.Plot.Axes.Left.Label.ForeColor = ScottPlot.Colors.Black;
            MyPlot.Plot.Axes.Left.Label.FontName = ScottPlot.Fonts.Monospace;
            MyPlot.Plot.Axes.Left.Label.Bold = false;
            MyPlot.Plot.Axes.Left.Label.FontSize = 20;
            //нижняя
            MyPlot.Plot.Axes.Bottom.Label.Text = "Количество эелементов в массиве";
            MyPlot.Plot.Axes.Bottom.Label.Bold = false;
            MyPlot.Plot.Axes.Bottom.Label.ForeColor = ScottPlot.Colors.Black;
            MyPlot.Plot.Axes.Bottom.Label.FontName = ScottPlot.Fonts.Monospace;
            MyPlot.Plot.Axes.Bottom.Label.FontSize = 20;
            //верхняя
            MyPlot.Plot.Axes.Title.Label.Text = _selectedAlgorythm.Description;
            MyPlot.Plot.Axes.Title.Label.Bold = false;
            MyPlot.Plot.Axes.Title.Label.ForeColor = ScottPlot.Colors.Black;
            MyPlot.Plot.Axes.Title.Label.FontName = ScottPlot.Fonts.Monospace;
            MyPlot.Plot.Axes.Title.Label.FontSize = 25;
            MyPlot.Refresh();
           
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(2 * step.Value <= arraySize.Value))
            {
                MessageBox.Show("Размер массива должен быть как минимум в 2 раза больше велечины шага");
                return;
            }
            if (_selectedAlgorythm is null)
            {
                MessageBox.Show("Выберите алгоритм");
                return;
            }
            else if (_selectedAlgorythm is BinaryOperation)
            {
                BinaryOperation binOp = (BinaryOperation) _selectedAlgorythm;
                if (!int.TryParse(baseText.Text, out int value))
                {
                    return;
                }
            }
            Graph_Build();
            ErrorButton.Visibility = Visibility.Visible;
        }
        public MainWindow()
        {

            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Combox.SelectionChanged += Combox_SelectedValueChanged;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (_avilibleAlgorytmhs == null)
            {
                arrayBlock.Visibility = Visibility.Hidden;
                stepBlock.Visibility = Visibility.Hidden;
                basisBlock.Visibility = Visibility.Hidden;
                ErrorButton.Visibility = Visibility.Hidden;
                _avilibleAlgorytmhs = AlgorythmsTesting.FindAvilibleAlgorythms();
                Combox.ItemsSource = _avilibleAlgorytmhs.Select(t => t.Description);
            }
        }
        private void Combox_SelectedValueChanged(object sender, EventArgs e)
        {

            _selectedAlgorythm = _avilibleAlgorytmhs.FirstOrDefault(a => a.Description == Combox.SelectedItem); // устанавливает _avilibleAlgorythm в соответсвии с выбранным элементом комбобокса
            // Пределы для слайдеров:
            arraySize.Minimum = (_selectedAlgorythm.MaxArraySize / 500) < 2 ? 2 : _selectedAlgorythm.MaxArraySize / 500;
            arraySize.Maximum = _selectedAlgorythm.MaxArraySize;
            step.Maximum = arraySize.Maximum / 100;
            step.Minimum = Math.Floor(arraySize.Maximum / 1000);
            step.Minimum = step.Minimum.Equals(0) ? 1 : step.Minimum; 

            if (_selectedAlgorythm is BinaryOperation)
            {
                BinaryOperation binOp = (BinaryOperation) _selectedAlgorythm;
                basis.Maximum = binOp.MaxBasisNumber;
                basisBlock.Visibility = Visibility.Visible;
            }
            else
            {
              basisBlock.Visibility = Visibility.Hidden;
            }
            arrayBlock.Visibility = Visibility.Visible;
            stepBlock.Visibility = Visibility.Visible;
        }

        private void ErrorButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            for (int i = 0; i < _aproxErrorData.Count; i++)
            {
                if (i == 0)
                    errorMessage += $"Линейная регрессия:\t{_aproxErrorData[i]}";
                else
                    errorMessage += $"\n Полином {i}-ой степени:\t{_aproxErrorData[i]}";
                if (_aproxErrorData[i] == _aproxErrorData.Min())
                    errorMessage += "✔";
            }
            MessageBox.Show(errorMessage, "Ошибка в разных функциях аппроксимации");
        }
    }
   
}
