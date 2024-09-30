using Algorythms_Logic;
using Algorythms_Logic.Algorythms;
using Algorythms_Logic.BinaryOperations;
using Algorythms_Logic.MatrixOperations;
using ScottPlot;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Algorythm> _avilibleAlgorytmhs;
        private Algorythm? _selectedAlgorythm;

        /* public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
         {
             // Логика для динамического изменения размера шрифта
             double newFontSize = Math.Min(this.ActualWidth / 250, this.ActualHeight / 100);
             mySlider.FontSize = newFontSize;
         }*/


        private double[][] MakeExperiments(int[] marking)
        {
            int maxSize = (int)Math.Floor(arraySize.Value);
            double[][] experiments = new double[maxSize][];
            for (int i = 0; i < maxSize; i++)
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
                    experiments[i] = AlgorythmsTesting.TestExecutionTime(binOp, maxSize, marking);

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
            int size = experements.GetLength(0);
            double[] dataY = new double[experements.GetLength(0)];
            for (int i = 0; i < size; i++)
            {
                double average = 0;
                for (int j = 0;j < experements.Length; j++)
                {
                    average += experements[j][i]; // Надо пофиксить
                }
                dataY[i] = Math.Round(average / size, 10);
            }
            return dataY;
        }
        private void Graph_Build()
        {
            int stp = (int)Math.Round(step.Value);
            int size = (int)(Math.Round(arraySize.Value) / stp);
            int[] dataX = new int[size];
            for (int i = 0;i < size;i++)
            {
                dataX[i] = i * stp;
            }
            double[] dataY = ToAvarageData(MakeExperiments(dataX));
            // Пример данных для второй линии
            var testDataGraph = WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            testDataGraph.Label = "Эксперементальные результаты";
            //толщина
            testDataGraph.LineWidth = 2; 

            //var scatter2 = WpfPlot1.Plot.Add.Scatter(dataX, dataY2);
            //scatter2.Label = "Аппроксимация на основе теоретических ошибок";
            //scatter2.LineWidth = 2;

            // Подписи левой нижней и верхней оси
            WpfPlot1.Plot.ShowLegend();
            WpfPlot1.Plot.Axes.Left.Label.Text = "Время(секунды)";
            WpfPlot1.Plot.Axes.Left.Label.ForeColor = ScottPlot.Colors.Black;
            WpfPlot1.Plot.Axes.Left.Label.FontName = ScottPlot.Fonts.Monospace;
            WpfPlot1.Plot.Axes.Left.Label.Bold = false;
            WpfPlot1.Plot.Axes.Left.Label.FontSize = 20;
            //нижняя
            WpfPlot1.Plot.Axes.Bottom.Label.Text = "Количество эелементов в массиве";
            WpfPlot1.Plot.Axes.Bottom.Label.Bold = false;
            WpfPlot1.Plot.Axes.Bottom.Label.ForeColor = ScottPlot.Colors.Black;
            WpfPlot1.Plot.Axes.Bottom.Label.FontName = ScottPlot.Fonts.Monospace;
            WpfPlot1.Plot.Axes.Bottom.Label.FontSize = 20;
            //верхняя
            WpfPlot1.Plot.Axes.Title.Label.Text = "График зависимости";
            WpfPlot1.Plot.Axes.Title.Label.Bold = false;
            WpfPlot1.Plot.Axes.Title.Label.ForeColor = ScottPlot.Colors.Black;
            WpfPlot1.Plot.Axes.Title.Label.FontName = ScottPlot.Fonts.Monospace;
            WpfPlot1.Plot.Axes.Title.Label.FontSize = 25;

           
            WpfPlot1.Refresh();
           
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Graph_Build();      
        }
        public MainWindow()
        {

            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Combox.SelectionChanged += Combox_SelectedValueChanged;
        
           // Graph_Build();

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (_avilibleAlgorytmhs == null)
            {
                arrayBlock.Visibility = Visibility.Hidden;
                stepBlock.Visibility = Visibility.Hidden;
                _avilibleAlgorytmhs = AlgorythmsTesting.FindAvilibleAlgorythms();
                Combox.ItemsSource = _avilibleAlgorytmhs.Select(t => t.Description);
            }
        }
        private void Combox_SelectedValueChanged(object sender, EventArgs e)
        {

            _selectedAlgorythm = _avilibleAlgorytmhs.FirstOrDefault(a => a.Description == Combox.SelectedItem);
            arraySize.Maximum = _selectedAlgorythm.MaxArraySize;
            step.Maximum = arraySize.Maximum / 2;
            if (_selectedAlgorythm is MatrixOperation)
            {
                MatrixOperation matrixop = (MatrixOperation)_selectedAlgorythm;
                step.TickFrequency = matrixop.NumberOfOperands;
                step.Minimum = matrixop.NumberOfOperands;
            }
            else
            {
                step.TickFrequency = 1;
                step.Minimum = 1;
            }
            arrayBlock.Visibility = Visibility.Visible;
            stepBlock.Visibility = Visibility.Visible;
        }
    }
   
}
