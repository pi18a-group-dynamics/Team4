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
            InitializeComponent();
            CurWindow = this;
            MethodsForMatrix = new Dictionary<string, Func<double[,], double[,], double[,]>>()
            {
                ["Сложение"] = (a, b) => Operations.Addition(a, b),
                ["Вычитание"] = (a, b) => Operations.Subtraction(a, b),
                ["Умножение"] = (a, b) => Operations.Multiplication(a, b),
                ["Умножение на вектор"] = (a, b) => Operations.Multiplication(a, b),
                ["Умножение на число"] = (a, b) => Operations.MultiplicationNumber(a, b),
                ["Транспонирование"] = (a, b) => Operations.Transpose(VisibleFirstMatrix ? a : b),
                ["Нормирование"] = (a, b) => Operations.NormalizeFrobenius(VisibleFirstMatrix ? a : b),
                ["Верхняя треугольная"] = (a, b) => Operations.UpperTriangular(VisibleFirstMatrix ? a : b),
                ["Нижняя треугольная"] = (a, b) => Operations.LowerTriangular(VisibleFirstMatrix ? a : b),
                ["Матрицы являются обратными?"] = (a, b) => Operations.AreInverses(a, b),
            };

            cbMethods.ItemsSource = MethodsForMatrix.Keys;

            ButtonSecondMatrix_Click(null, null);
            ButtonFirstMatrix_Click(null, null);
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
            dgFirstMatrix.Visibility = Visibility.Visible;
            dgSecondMatrix.Visibility = Visibility.Hidden;
            dgFirstMatrix.ItemsSource = ToDataTable(FirstMatrix).DefaultView;
            bFirstMatrix.Background = Brushes.Gray;
            bSecondMatrix.Background = Brushes.LightGray;
            VisibleFirstMatrix = true;
        }

        private void ButtonSecondMatrix_Click(object sender, RoutedEventArgs e)
        {
            dgSecondMatrix.Visibility = Visibility.Visible;
            dgFirstMatrix.Visibility = Visibility.Hidden;
            dgSecondMatrix.ItemsSource = ToDataTable(SecondMatrix).DefaultView;
            bSecondMatrix.Background = Brushes.Gray;
            bFirstMatrix.Background = Brushes.LightGray;
            VisibleFirstMatrix = false;
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        public static string CheckNumeric(string input, char[] extendAccessedChars = null)
        {
			var accessed = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var rightInput = "";
            if (extendAccessedChars != null)
                accessed = accessed.Union(extendAccessedChars).ToArray();
            if (input.Length != 0)
            {
                for (int i = 0; i < input.Length; i++)
                    if (accessed.Contains(input[i]))
                        rightInput += input[i];

            }
            return rightInput;
        }

        private void bChangeSizeOfMatrix_Click(object sender, RoutedEventArgs e)
        {
            double[,] matrix = SecondMatrix;
            if (VisibleFirstMatrix)
                matrix = FirstMatrix;
            if (string.IsNullOrWhiteSpace(tbCountOfColumns.Text) ||
                string.IsNullOrWhiteSpace(tbCountOfRows.Text) ||
                !int.TryParse(tbCountOfColumns.Text, out _) ||
                !int.TryParse(tbCountOfRows.Text, out _))
                return;

            double[,] arr = new double[int.Parse(tbCountOfRows.Text), int.Parse(tbCountOfColumns.Text)];
            for (int i = 0; i < Math.Min(arr.GetLength(0), matrix.GetLength(0)); i++)
                for (int j = 0; j < Math.Min(arr.GetLength(1), matrix.GetLength(1)); j++)
                    arr[i, j] = matrix[i, j];

            if (VisibleFirstMatrix)
            {
                FirstMatrix = arr;
                ButtonFirstMatrix_Click(null, null);
            }
            else
            {
                SecondMatrix = arr;
                ButtonSecondMatrix_Click(null, null);
            }
        }

        private void ButtonUseOperation_Click(object sender, RoutedEventArgs e)
        {
            if ((string)cbMethods.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать операцию");
                return;
            }
            Result = MethodsForMatrix[(string)cbMethods.SelectedItem](FirstMatrix, SecondMatrix);
            if (Result == null)
                return;
            dgResultMatrix.ItemsSource = ToDataTable(Result).DefaultView;
        }

        private void tbCountOfRows_TextChanged(object sender, TextChangedEventArgs e)
            => tbCountOfRows.Text = CheckNumeric(tbCountOfRows.Text);

        private void tbCountOfColumns_TextChanged(object sender, TextChangedEventArgs e)
            => tbCountOfColumns.Text = CheckNumeric(tbCountOfColumns.Text);
    }
}
