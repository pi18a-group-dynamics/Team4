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
            var res = new DataTable();
            res.Columns.Add("n", typeof(double));
            for (int i = 0; i < matrix.GetLength(1); i++)
                res.Columns.Add("" + (1 + i), typeof(double));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();
                row[0] = i+ 1;
                for (int j = 1; j < matrix.GetLength(1) + 1; j++)
                    row[j] = Math.Round(matrix[i, j - 1], 2);

                res.Rows.Add(row);
            }
            res.Columns[0].ReadOnly = true;
            res.RowChanged += Res_RowChanged;
            return res;
        }

        private static void Res_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            CurWindow.ToArray(CurWindow.dgFirstMatrix, CurWindow.FirstMatrix);
            CurWindow.ToArray(CurWindow.dgSecondMatrix, CurWindow.SecondMatrix);
        }

        private void ToArray(DataGrid grid, double[,] matrix)
        {
            var table = ((DataView)grid.ItemsSource).ToTable();
            for (int i = 0; i < table.Rows.Count; i++)
                for (int j = 1; j < table.Columns.Count; j++)
                    matrix[i, j - 1] = (double)table.Rows[i].ItemArray[j];
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileNames.Length != 1)
                return;
            if (!string.IsNullOrWhiteSpace(ofd.FileName))
            {
                StreamWriter writer = new StreamWriter(ofd.FileName);
                WriteMatrix(FirstMatrix, writer);
                WriteMatrix(SecondMatrix, writer);
                if(Result!=null)
                    WriteMatrix(Result, writer);
                writer.Close();
            }
            static void WriteMatrix(double[,] arr, StreamWriter writer)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    var s = new StringBuilder();
                    for (int j = 0; j < arr.GetLength(1); j++)
                        s.Append(arr[i, j] + " ");
                    writer.Write(s.ToString() + "\n");
                }
                writer.Write("\n");
            }
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileNames.Length != 1)
                return;
            if (!string.IsNullOrWhiteSpace(ofd.FileName))
            {
                var counter = 0;
                var mas = new List<string>();
                var rows = File.ReadAllText(ofd.FileName).Split('\n');
                double[,] arr = null;
                for (int l = 0; l < rows.Length; l++)
                {
                    if (string.IsNullOrWhiteSpace(rows[l]))
                    {
                        for (int i = 0; i < mas.Count(); i++)
                        {
                            string[] s = (from k in mas[i].Split() where !k.Equals("") && !k.Equals(" ") select k).ToArray();
                            if(arr == null)
                                arr = new double[mas.Count(), s.Length];
                            if (s.Length != arr.GetLength(1))
                                return;
                            for (int j = 0; j < s.Length; j++)
                                if (!double.TryParse(s[j], out arr[i, j]))
                                    return;
                        }
                        mas = new List<string>();
                        if (counter == 0)
                        {
                            if (arr == null)
                                break;
                            FirstMatrix = new double[arr.GetLength(0), arr.GetLength(1)];
                            for (int i = 0; i < arr.GetLength(0); i++)
                                for (int j = 0; j < arr.GetLength(1); j++)
                                    FirstMatrix[i, j] = arr[i, j];
                        }
                        else if (counter == 1)
                        {
                            if (arr == null)
                                break;
                            SecondMatrix = new double[arr.GetLength(0), arr.GetLength(1)];
                            for (int i = 0; i < arr.GetLength(0); i++)
                                for (int j = 0; j < arr.GetLength(1); j++)
                                    SecondMatrix[i, j] = arr[i, j];
                        }
                        else if (counter == 2)
                        {
                            if (arr == null)
                            {
                                Result = null;
                                break;
                            }
                            Result = new double[arr.GetLength(0), arr.GetLength(1)];
                            for (int i = 0; i < arr.GetLength(0); i++)
                                for (int j = 0; j < arr.GetLength(1); j++)
                                    Result[i, j] = arr[i, j];
                        }
                        else
                            break;
                        counter++;
                        arr = null;
                    }
                    else
                        mas.Add(rows[l]);
                    
                }
                ButtonSecondMatrix_Click(null, null);
                ButtonFirstMatrix_Click(null, null);
                if (Result != null)
                    dgResultMatrix.ItemsSource = ToDataTable(Result).DefaultView;
                else
                    dgResultMatrix.ItemsSource = null;
            }
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
