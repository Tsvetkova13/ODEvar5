using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.OdeSolvers;

namespace ODE_var5
{
    public class Calculation:Iode
    {
        /*public double[,] CalcODE()
        {
            Vector<double> y0 = Vector<double>.Build.Dense(2);
            y0[0] = 2.0;
            y0[1] = 0.0;

            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            double [,] res=new double[N,2];



            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });

            Vector<double>[] tmpRes = RungeKutta.FourthOrder(y0, t0, tmax, N, f);
         
            tmpRes.ToArray();

            for (int i = 0; i < tmpRes.Length - 1; i++)
            {

                res[i, 0] = tmpRes[i][0];
                res[i, 1] = tmpRes[i][1];
            }
            return res;
        }*/
        public double[,] CalcODE(double[] y, double t0, double tmax, Func<double, Vector<double>, Vector<double>> f)
        {
            Vector<double> y0 = Vector<double>.Build.Dense(3);
            y0[0] = y[0];
            y0[1] = y[1];
            y0[2] = y[2];
            
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            double[,] res = new double[N, 3];

            Vector<double>[] tmpRes = RungeKutta.FourthOrder(y0, t0, tmax, N, f);


            tmpRes.ToArray();

            for (int i = 0; i < tmpRes.Length - 1; i++)
            {

                res[i, 0] = tmpRes[i][0];
                res[i, 1] = tmpRes[i][1];
                res[i, 2] = tmpRes[i][2];
            }
            return res;

        }

    }
}
