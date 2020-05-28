using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GroupTask
{
    public static class Operations
    {
        public static double[,] MultiplicationNumber(double[,] a, double[,] v)
        {
            if (v.Length != 1)
            {
                MessageBox.Show("Матрица должна быть размера 1х1");
                return null;
            }
            int rows = a.GetLength(0);
            int columns = a.GetLength(1);
            double[,] arr = new double[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    arr[i,j] = a[i,j] * v[0,0];

            return arr;
        }

        public static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
            {
                MessageBox.Show("Матрицы нельзя перемножить, т.к. кол-во столбцов первой матрицы не равна кол-ву строк второй");
                return null;
            }

            double[,] result = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        result[i, j] += a[i, k] * b[k, j];

            return result;
        }

        public static bool IsSquare(double[,] a)
        {
            if (a.GetLength(0) == a.GetLength(1))
                return true;
            return false;
        }

        

        public static double[,] Addition(double[,] a, double[,] b)
        {
            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                int rows = a.GetLength(0);
                int columns = a.GetLength(1);
                double[,] arr = new double[rows, columns];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        arr[i, j] = a[i, j] + b[i, j];
                return arr;
            }
            MessageBox.Show("Матрицы должны быть одного размера.");
            return null;
        }

        public static double[,] Subtraction(double[,] a, double[,] b)
        {
            if (a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                int rows = a.GetLength(0);
                int columns = a.GetLength(1);
                double[,] arr = new double[rows, columns];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        arr[i, j] = a[i, j] - b[i, j];
                return arr;
            }
            MessageBox.Show("Матрицы должны быть одного размера.");
            return null;
        }

       
    }
}
