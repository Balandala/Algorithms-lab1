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
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                double[] dataX = { 1, 2, 3, 4, 5 };
                double[] dataY = { 1, 4, 9, 16, 25 };
                WpfPlot1.Plot.Add.Scatter(dataX, dataY);
                WpfPlot1.Refresh();
            };
           
        }
        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Логика для динамического изменения размера шрифта
            double newFontSize = Math.Min(this.ActualWidth / 25, this.ActualHeight / 10);
            mySlider.FontSize = newFontSize;
        }
        

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fasa.Content = "Первый алгоритм1";
            double testvalue = Math.Round(mySlider.Value);
            Fasa.Content = testvalue.ToString();
        }
    }
}
