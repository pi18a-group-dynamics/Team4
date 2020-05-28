using GroupTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroupTaskTests
{
    [TestClass]
    public class Tests
    {
       

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

    }
}
