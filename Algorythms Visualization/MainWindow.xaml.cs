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
            double sum = 0;
            int size = experements[0].Length; //Размер внутренних массивов (количество X)
            double[] dataY = new double[size];
            for (int i = 0; i < size; i++)  // проход по всем элементам внутренних массивов
            {
                for (int j = 0;j < experements.Length; j++) // проход по всем элементам внешнего массива
                {
                    sum += experements[j][i]; //суммирование i-ых элементов внутренних массивов
                }
                dataY[i] = Math.Round(sum / experements.Length, 6);
            }
            return dataY;
        }
        private void Graph_Build()
        {
            MyPlot.Reset();
            int stp = (int)Math.Round(step.Value);
            int size = (int)(Math.Round(arraySize.Value) / stp);
            int[] dataX = new int[size];
            for (int i = 0;i < size;i++)
            {
                dataX[i] = i * stp;
            }
            double[] dataY = ToAvarageData(MakeExperiments(dataX));
            // Пример данных для второй линии
            var testDataGraph = MyPlot.Plot.Add.Scatter(dataX, dataY);
            testDataGraph.Label = "Эксперементальные результаты";
            //толщина
            testDataGraph.LineWidth = 2; 

            //var scatter2 = WpfPlot1.Plot.Add.Scatter(dataX, dataY2);
            //scatter2.Label = "Аппроксимация на основе теоретических ошибок";
            //scatter2.LineWidth = 2;

            // Подписи левой нижней и верхней оси
            MyPlot.Plot.ShowLegend();
            MyPlot.Plot.Axes.Left.Label.Text = "Время(милисекунды)";
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
            MyPlot.Plot.Axes.Title.Label.Text = "График зависимости";
            MyPlot.Plot.Axes.Title.Label.Bold = false;
            MyPlot.Plot.Axes.Title.Label.ForeColor = ScottPlot.Colors.Black;
            MyPlot.Plot.Axes.Title.Label.FontName = ScottPlot.Fonts.Monospace;
            MyPlot.Plot.Axes.Title.Label.FontSize = 25;

           
            MyPlot.Refresh();
           
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
        
           //Graph_Build();

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

            _selectedAlgorythm = _avilibleAlgorytmhs.FirstOrDefault(a => a.Description == Combox.SelectedItem); // устанавливает _avilibleAlgorythm в соответсвии с выбранным элементом комбобокса
            arraySize.Maximum = _selectedAlgorythm.MaxArraySize;
            step.Maximum = arraySize.Maximum / 100;
            step.Minimum = arraySize.Maximum / 1000;
            arrayBlock.Visibility = Visibility.Visible;
            stepBlock.Visibility = Visibility.Visible;
        }
    }
   
}
