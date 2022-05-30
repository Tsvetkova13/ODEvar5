using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.OdeSolvers;

namespace ODE_var5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CalcRK4()
        {
            double[] y0 = new double[2];
            y0[0] = Convert.ToDouble(textBox1.Text);
            y0[1] = Convert.ToDouble(textBox2.Text);

            Iode c = new Calculation();

            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });

            
            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);

            double[,] res = new double[N, 2];
            res = c.CalcODE(y0,t0,tmax,f);
            dgvRes.ColumnCount = 2;
            for (int i = 0; i < N - 1; i++)
            {

                dgvRes.Rows.Add();
                dgvRes[0, i].Value = res[i, 0];
                dgvRes[1, i].Value = res[i, 1];
            }



            /*Vector<double> y0 = Vector<double>.Build.Dense(2);
            y0[0] = 2.0;
            y0[1] = 0.0;

            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);

            

            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });

            Vector<double>[] res = RungeKutta.FourthOrder(y0, t0, tmax, N, f);
            Iode c = new Calculation();
            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);
            /*Vector<double>[] result;
            result = c.CalcODE();


            dgvRes.ColumnCount = N;
            for (int i = 0; i < result.Length-1; i++)
            {

                dgvRes.Rows.Add();
                dgvRes[0, i].Value = result[i][0];
                dgvRes[1,i].Value = result[i][1];
            }*/





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcRK4();
            
        }
    }
}
