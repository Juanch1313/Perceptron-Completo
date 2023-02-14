using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Perceptron
{
    public partial class Perceptron : Form
    {
        private static readonly Random random = new Random();
        private double w0 = (double)random.NextDouble();
        private double w1 = (double)random.NextDouble();
        private double w2 = (double)random.NextDouble();

        private readonly double factorAprendizaje = 0.4;
        private readonly int epocas = 500;


        private List<double> puntosX = new List<double>();
        private List<double> puntosY = new List<double>();
        private List<double> salidasDeseadas = new List<double>();


        public Perceptron()
        {
            InitializeComponent();

            //Maximos, minimos y linea cruzada
            chart2.ChartAreas[0].AxisX.Minimum = -10;
            chart2.ChartAreas[0].AxisY.Minimum = -10;
            chart2.ChartAreas[0].AxisX.Maximum = 10;
            chart2.ChartAreas[0].AxisY.Maximum = 10;
            chart2.ChartAreas[0].AxisX.Crossing = 0;
            chart2.ChartAreas[0].AxisY.Crossing = 0;

            //Configuraciones extras de diseño
            chart2.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Triangle;
            chart2.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Triangle;
            chart2.ChartAreas[0].AxisX.LineWidth = 2;
            chart2.ChartAreas[0].AxisY.LineWidth = 2;
            chart2.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 14;
            chart2.ChartAreas[0].AxisY.LabelAutoFitMinFontSize = 14;

            //Colores
            chart2.Series[0].Color = Color.Green;
            chart2.Series[1].Color = Color.Red;
            chart2.Series[2].Color = Color.Black;
            chart2.Series[3].Color = Color.Blue;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Entrenamiento();
            return;
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            puntosX.Add(chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
            puntosY.Add(chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
            if (cbxCero.Checked)
            {
                salidasDeseadas.Add(0);
            }
            else
            {
                salidasDeseadas.Add(1);
            }

            chart2.Series[3].Points.AddXY(puntosX.Last(), puntosY.Last());
        }

        private void cbxCero_MouseClick(object sender, MouseEventArgs e)
        {
            cbxUno.Checked = false;
            cbxCero.Checked = true;
        }

        private void cbxUno_MouseClick(object sender, MouseEventArgs e)
        {
            cbxUno.Checked = true;
            cbxCero.Checked = false;
        }
        #region Perceptron
        private void Entrenamiento()
        {
            ;
            for (int i = 0; i < epocas; i++)
            {
                for (int j = 0; j < puntosX.Count; j++)
                {
                    var y = (w0 * 1) + (w1 * puntosX[j]) + (w2 * puntosY[j]);
                    y = y >= 0 ? 1 : -1;
                    var error = salidasDeseadas[j] - (y);
                    if (error != 0)
                    {
                        w0 += (factorAprendizaje * (error) * 1);
                        w1 += (factorAprendizaje * (error) * puntosX[j]);
                        w2 += (factorAprendizaje * (error) * puntosY[j]);
                        break;
                    }
                    continue;
                }
            }
        }

        #endregion
    }
}
