using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace ODE_var5
{
    public interface Iode
    {
        Complex32 CalcWp(Complex32 p);
        double[,] CalcODE(double[] y, double t0, double tmax, Func<double, Vector<double>, Vector<double>> f);
    }
}
