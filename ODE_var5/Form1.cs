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
using DigitalRune.Mathematics.Analysis;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.OdeSolvers;




namespace ODE_var5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1";
            textBox2.Text = "1";
            textBox3.Text = "1";
            X.Text = "1";
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

                //решение уравнения
                var Ae = 0.0143;
                //1 метод
                ImprovedNewtonRaphsonMethodD rootFinder = new ImprovedNewtonRaphsonMethodD(Foo, FooDerived);
                double x0 =0;
                double x1 = 1;
                rootFinder.ExpandBracket(ref x0, ref x1, Ae);
                var wsr = rootFinder.FindRoot(x0, x1, Ae);
                //2 метод
                BisectionMethodD bisectionMethodD = new BisectionMethodD(Foo);
                bisectionMethodD.ExpandBracket(ref x0, ref x1, Ae);
                var wsr2 = bisectionMethodD.FindRoot(x0, x1, Ae);
                //3 метод
                RegulaFalsiMethodD regulaFalsiMethodD = new RegulaFalsiMethodD(Foo);
                regulaFalsiMethodD.ExpandBracket(ref x0, ref x1, Ae);
                var wsr3 = bisectionMethodD.FindRoot(x0, x1, Ae);

                //w среза
                float mywsr = (float)wsr;
                float truewsr = 0.92f;

                //Complex32 omega = Complex32.Zero;
                Complex32 omega = new Complex32(mywsr, 0.0f);
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
        private static double Foo(double x)
        {
            var da = 1.43 / (19.8 * x * x * x + 114.6 * x * x + 43.9 * x + 1.0)/* - 0.0143*/;
            //var fa = (float)da;
            //var a = 1.43f / (19.8f * x * x * x + 114.6f * x * x + 43.9f * x + 1.0f) - 0.0143f;
            return da;
        }

        private static double FooDerived(double x)
        {
            var da =(- 0.160129 - 0.836027 * x - 0.216667 *x*x)/((0.0505051 + 2.21717 *x + 5.78788*x*x + x*x*x)* (0.0505051 + 2.21717 * x + 5.78788 * x * x + x * x * x));
            //var fa = (float)da;
            //var a = (-0.216667f * x - 0.836027f * x - 0.160129f) / ((x * x * x + 5.78788f * x * x + 2.21717f * x + 0.0505051f) * (x * x * x + 5.78788f * x * x + 2.21717f * x + 0.0505051f));
            return da;
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
