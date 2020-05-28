using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

namespace GroupTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Func<double[,], double[,], double[,]>> MethodsForMatrix { get; set; }

        public double[,] FirstMatrix { get; set; } = new double[,] 
        {
            { 0 }
        };
        public double[,] SecondMatrix { get; set; } = new double[,]
        {
            { 0 }
        };

        public double[,] Result { get; set; }

        public static MainWindow CurWindow { get; set; }

        public bool VisibleFirstMatrix { get; set; } = true;

        public MainWindow()
        {

        }

        public static DataTable ToDataTable(double[,] matrix)
        {

        }

        private static void Res_RowChanged(object sender, DataRowChangeEventArgs e)
        {

        }

        private void ToArray(DataGrid grid, double[,] matrix)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbMethods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonFirstMatrix_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSecondMatrix_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        public static string CheckNumeric(string input, char[] extendAccessedChars = null)
        {

        }

        private void bChangeSizeOfMatrix_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUseOperation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbCountOfRows_TextChanged(object sender, TextChangedEventArgs e)
		{}

        private void tbCountOfColumns_TextChanged(object sender, TextChangedEventArgs e)
		{}
    }
}
