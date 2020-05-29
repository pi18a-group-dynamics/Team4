using GroupTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroupTaskTests
{
    [TestClass]
    public class Tests
    {
       [TestMethod]
        public void TestMultiplication()
        {
            var a = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };
            var b = new double[,]
            {
                {5, 1},
                {3, 4}
            };
            double[,] expected = new double[,]
            {
                {43, 29},
                {29, 16},
                {3, 4}
            };

            var res = Operations.Multiplication(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }
        [TestMethod]
        public void TestMultiplicationNumber()
        {
            var a = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };

            var b = new double[,]
            {
                {5 }
            };

            double[,] expected = new double[,]
            {
                {25, 30},
                {20, 15},
                {0, 5}
            };

            var res = Operations.MultiplicationNumber(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestNormalizeFrobenius()
        {
            var a = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };

            double[,] expected = new double[,]
            {
                {0.1, 0.02},
                {0.82, 0.56},
                {0, 0.09}
            };

            var res = Operations.NormalizeFrobenius(a);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestLowerTriangular()
        {
            var a = new double[,] {
                { 5.5, 1, 8},
                { 44, 30,9},
                { 0, 5,15.6}
            };

            double[,] expected = new double[,]
            {                
                {1, 0, 0},
                {8, 1, 0},
                {0, 0.23, 1}
            };

            var res = Operations.LowerTriangular(a);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }
[TestMethod]
        public void TestAddition()
        {
            var a = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };

            var b = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };

            double[,] expected = new double[,]
            {
                {10.5, 7},
                {48, 33},
                {0, 6}
            };

            var res = Operations.Addition(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }
        [TestMethod]
        public void TestAddition2()
        {
            var a = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };

            var b = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };

            double[,] expected = new double[,]
            {
                {10.5, 5},
                {48, 33},
                {0, 6}
            };

            var res = Operations.Addition(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreNotEqual(res, expected);
        }
		[TestMethod]
        public void TestSubtraction()
        {
            var a = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };
            var b = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };

            double[,] expected = new double[,]
            {
                {0.5, -5},
                {40, 27},
                {0, 4}

            };

            var res = Operations.Subtraction(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }

        [TestMethod]
        public void TestSubtraction2()
        {
            var a = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };
            var b = new double[,] {
                { 5, 6},
                { 4, 3},
                { 0, 1}
            };

            double[,] expected = new double[,]
            {
                {0.5, 5},
                {40, 27},
                {0, 4}

            };

            var res = Operations.Subtraction(a, b);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreNotEqual(res, expected);
        }
		        [TestMethod]
        public void TestTranspose()
        {
            var a = new double[,] {
                { 5.5, 1},
                { 44, 30},
                { 0, 5}
            };

            double[,] expected = new double[,]
            {
                {5.5, 44, 0},
                {1, 30, 5},

            };

            var res = Operations.Transpose(a);
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = Math.Round(res[i, j], 2);

            CollectionAssert.AreEqual(res, expected);
        }
    }
}
