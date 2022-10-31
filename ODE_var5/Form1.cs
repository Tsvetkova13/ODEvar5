using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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
            double[] y0 = new double[3];
            y0[0] = Convert.ToDouble(textBox1.Text);
            y0[1] = Convert.ToDouble(textBox2.Text);
            y0[2] = Convert.ToDouble(textBox3.Text);
            int x = Convert.ToInt32(X.Text);

            Iode c = new Calculation();

            //Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { y[1], ((1 - y[0] * y[0]) * y[1] - y[0]) });
            Func<double, Vector<double>, Vector<double>> f = (t, y) => Vector<double>.Build.Dense(new[] { ((1.43 * x - 114.6 * y[0] - 43.9 * y[1] - y[2]) / 19.8), y[0], y[1] });

            double t0 = 0;
            double tmax = 0.1;
            double tau = 0.01;
            int N = Convert.ToInt32((tmax - t0) / tau);

            double[,] res = new double[N, 3];
            //while (true)
            {
                res = c.CalcODE(y0, t0, tmax, f);
                dgvRes.ColumnCount = 3;
                for (int i = 0; i < N - 1; i++)
                {

                    dgvRes.Rows.Add();
                    dgvRes[0, i].Value = res[i, 0];
                    dgvRes[1, i].Value = res[i, 1];
                    dgvRes[2, i].Value = res[i, 2];
                }



                var Ae = 0.0143;
                //решение уравнения
                //....

                //w среза
                double wsr = 0.92;

                Complex32 omega = Complex32.Zero;
                //Complex32 omega = new Complex32(10.0f, 0.0f);
                //вызов функции для получения значения W(p) в виде комплексного числа
                var Wp = c.CalcWp(omega);
                //Квадрат
                var Wpsquare = Wp.Square();

                Complex32 Aw = Complex32.Sqrt(Wpsquare.Real + Wpsquare.Imaginary);


                //время квантования
                var tkv = 3.1415 / wsr;
                //задержка перед новым расчетом
                var tkvXms = (int)tkv * 1000;
                //Thread.Sleep(tkvXms);
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
