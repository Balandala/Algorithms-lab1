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
       
       /* public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Логика для динамического изменения размера шрифта
            double newFontSize = Math.Min(this.ActualWidth / 250, this.ActualHeight / 100);
            mySlider.FontSize = newFontSize;
        }*/


        private void Graph_Build()
        {
            
            double testvalue = Math.Round(mySlider.Value);
            double[] dataX = { 0, 1, 2, 3, 4, 5 };
            double[] dataY = { 0, testvalue, 4, 9, 16, 25 };

            // Пример данных для второй линии
            double[] dataY2 = { testvalue * 0.5, testvalue * 1.5, testvalue * 2.5, testvalue * 3.5, testvalue * 4.5 };
            var scatter1 = WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            scatter1.Label = "Эксперементальные результаты";
            //толщина
            scatter1.LineWidth = 2; 

            var scatter2 = WpfPlot1.Plot.Add.Scatter(dataX, dataY2);
            scatter2.Label = "Аппроксимация на основе теоретических ошибок";
            scatter2.LineWidth = 2;

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
           
            double testvalue = Math.Round(mySlider.Value);
            //Const.Content = testvalue.ToString();
       
                var selectedAlgorithm = (ComboBoxItem)Combox.SelectedItem;
                string algorithmName = selectedAlgorithm.Content.ToString();

                switch (algorithmName)
                {
                    case "F(n)=1":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();

                        break;

                    case "Сумма всех элементов массива":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();

                        break;

                    case "Произведение всех элементов массива":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "P(x)=sum(i=1...n) ƎVᵢ*x^(i-1),для x=1,5":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Сортировка пузырьком":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "БЫсьрая сортировка":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Алгоритм возведения в степень":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Умножение двух матриц размером m*n":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Алгоритм полного перебора(Brute force)":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Поразрядная сортировка(Radix sort)":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    case "Нахождение всех троек в массиве(3-Sum Problem)":
                        WpfPlot1.Plot.Clear();
                        Graph_Build();
                        break;

                    default:
                        MessageBox.Show("Выберите алгоритм!");
                        break;
                }           
        }
        public MainWindow()
        {

            InitializeComponent();
           
        
           // Graph_Build();

        }
    }
   
}
