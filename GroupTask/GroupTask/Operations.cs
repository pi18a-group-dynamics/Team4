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

        public static void LU(double[,] a, out double[,] U, out double[,] L)
        {
            int n = a.GetLength(0);
            U = new double[n, n];
            L = new double[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    U[i, j] = a[i, j];

            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    L[j, i] = U[j, i] / U[i, i];

            for (int k = 1; k < n; k++)
            {
                for (int i = k - 1; i < n; i++)
                    for (int j = i; j < n; j++)
                        L[j, i] = U[j, i] / U[i, i];

                for (int i = k; i < n; i++)
                    for (int j = k - 1; j < n; j++)
                        U[i, j] = U[i, j] - L[i, k - 1] * U[k - 1, j];
            }
        }

        public static double[,] UpperTriangular(double[,] a)
        {
            if (!IsSquare(a))
            {
                MessageBox.Show("Матрица должна быть квадратной.");
                return null;
            }
            LU(a, out double[,] U, out _);
            foreach (var item in U)
                if (double.IsNaN(item))
                {
                    MessageBox.Show("Невозможно вычислить верхнюю треугольную матрицу для невырожденной");
                    return null;
                }
            return U;
        }

        public static double[,] LowerTriangular(double[,] a)
        {
            if (!IsSquare(a))
            {
                MessageBox.Show("Матрица должна быть квадратной.");
                return null;
            }
            LU(a, out _, out double[,] L);
            foreach (var item in L)
                if(double.IsNaN(item))
                {
                    MessageBox.Show("Невозможно вычислить нижнюю треугольную матрицу для невырожденной");
                    return null;
                }
            return L;
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

        public static double[,] Transpose(double[,] a)
        {
            int rows = a.GetLength(0);
            int columns = a.GetLength(1);
            double[,] arr = new double[columns,rows];
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    arr[i,j] = a[j,i];
                
            return arr;
        }
        public static double[,] NormalizeFrobenius(double[,] a)
        {
            double norm = 0;
            int columns = a.GetLength(0);
            int rows = a.GetLength(1);
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    norm += a[i,j] * a[i,j];

            norm = Math.Sqrt(norm);
            double[,] arr = new double[columns, rows];
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)               
                    arr[i,j] = a[i,j] / norm;

            return arr;
        }

        public static bool IsIdentity(double[,] a)
        {
            int c = 0;
            int rows = a.GetLength(0);
            int columns = a.GetLength(1);
            for (int i = 0; i < rows; i++, c++)
            {
                int j = 0;
                for (; j < c; j++)
                    if (a[i,j] != 0) 
                        return false;
                if (a[i,j++] != 1) 
                    return false;
                for (; j < columns; j++)
                    if (a[i,j] != 0) 
                        return false;
            }
            return true;
        }

        public static double[,] AreInverses(double[,] a, double[,] b)
        {
            if (!IsSquare(a) || !IsSquare(b))
            {
                MessageBox.Show("Неквадратная матрица не имеет обратной.");
                return null;
            }
            else
            {
                if (IsIdentity(Multiplication(a, b)))
                {
                    MessageBox.Show("Матрицы являются взаимно обратными");
                    return null;
                }
                MessageBox.Show("Матрицы не являются взаимно обратными");
                return null;
            }
        }
    }
}
