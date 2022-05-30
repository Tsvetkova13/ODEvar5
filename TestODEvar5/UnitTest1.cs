using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ODE_var5;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.OdeSolvers;


namespace TestODEvar5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalcODE1()
        {
            //assert 
            double[] y0 = new double[2];
            y0[0] = 2.0;
            y0[1] = 0.0;
            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });
            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            double[,] resExpected = new double[,] {{ 2.0000, 0.0000 },
                                         { 1.9999, -0.0219  },
                                         { 1.9995, -0.0430 },
                                         { 1.9989, -0.0634 },
                                         { 1.9981, -0.0832 },
                                         { 1.9971, -0.1023 },
                                         { 1.9958, -0.1208 },
                                         { 1.9944, -0.1387 },
                                         { 1.9928, -0.1559 },
                                         { 0.0000, 0.0000 },
                                         };

            

            //act
            Iode math = new Calculation();
            double[,] res = new double[10,2];
            res = math.CalcODE(y0, t0, tmax, f);
            for (int i = 0; i <= N-1; i++)
            {
                res[i, 0] = Math.Round(res[i, 0], 4);
                res[i, 1] = Math.Round(res[i, 1], 4);
                
            }

            CollectionAssert.AreEqual(resExpected, res);
        }
        [TestMethod]
        public void TestCalcODE_tmax2()
        {
            //assert 
            double[] y0 = new double[2];
            y0[0] = 2.0;
            y0[1] = 0.0;
            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });
            double t0 = 0;
            double tmax = 0.2;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            double[,] resExpected = new double[,] {{ 2.0000, 0.0000 },
                                         { 1.9999, -0.0207  },
                                         { 1.9996, -0.0408 },
                                         { 1.9990, -0.0603 },
                                         { 1.9983, -0.0791 },
                                         { 1.9974, -0.0973 },
                                         { 1.9963, -0.1150 },
                                         { 1.9950, -0.1321 },
                                         { 1.9935, -0.1487 },
                                         { 1.9918, -0.1648 },
                                         { 1.9900, -0.1804 },
                                         { 1.9880, -0.1955 },
                                         { 1.9859, -0.2101 },
                                         { 1.9836, -0.2243 },
                                         { 1.9812, -0.2380 },
                                         { 1.9786, -0.2513 },
                                         { 1.9759, -0.2642 },
                                         { 1.9730, -0.2768 },
                                         { 1.9701, -0.2889 },
                                         { 0.0000, 0.0000 },
                                         };



            //act
            Iode math = new Calculation();
            double[,] res = new double[10, 2];
            res = math.CalcODE(y0, t0, tmax, f);
            for (int i = 0; i <= N - 1; i++)
            {
                res[i, 0] = Math.Round(res[i, 0], 4);
                res[i, 1] = Math.Round(res[i, 1], 4);

            }

            CollectionAssert.AreEqual(resExpected, res);
        }
        [TestMethod]
        public void TestCalcODE_tmax3()
        {
            //assert 
            double[] y0 = new double[2];
            y0[0] = 2.0;
            y0[1] = 0.0;
            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });
            double t0 = 0;
            double tmax = 0.3;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            double[,] resExpected = new double[,] {{ 2.0000, 0.0000 },
                                         { 1.9999, -0.0204  },
                                         { 1.9996, -0.0401 },
                                         { 1.9991, -0.0593 },
                                         { 1.9984, -0.0778 },
                                         { 1.9975, -0.0958 },
                                         { 1.9964, -0.1132 },
                                         { 1.9951, -0.1301 },
                                         { 1.9937, -0.1465 },
                                         { 1.9921, -0.1623 },
                                         { 1.9903, -0.1777 },
                                         { 1.9884, -0.1926 },
                                         { 1.9863, -0.2071 },
                                         { 1.9841, -0.2211 },
                                         { 1.9818, -0.2347 },
                                         { 1.9793, -0.2479 },
                                         { 1.9766, -0.2607 },
                                         { 1.9739, -0.2731 },
                                         { 1.9710, -0.2852 },
                                         { 1.9680, -0.2969 },
                                         { 1.9649, -0.3083 },
                                         { 1.9616, -0.3193 },
                                         { 1.9582, -0.3300 },
                                         { 1.9548, -0.3405 },
                                         { 1.9512, -0.3506 },
                                         { 1.9475, -0.3605 },
                                         { 1.9437, -0.3701 },
                                         { 1.9399, -0.3794 },
                                         { 1.9359, -0.3885 },
                                         { 0.0000, 0.0000 },
                                         };



            //act
            Iode math = new Calculation();
            double[,] res = new double[10, 2];
            res = math.CalcODE(y0, t0, tmax, f);
            for (int i = 0; i <= N - 1; i++)
            {
                res[i, 0] = Math.Round(res[i, 0], 4);
                res[i, 1] = Math.Round(res[i, 1], 4);

            }

            CollectionAssert.AreEqual(resExpected, res);
        }
    }
}
