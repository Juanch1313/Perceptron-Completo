using MathNet.Numerics.LinearAlgebra;
using Perceptron.Clases;
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
        private static List<double> puntosX = new List<double>();
        private static List<double> puntosY = new List<double>();
        private static List<double> puntosXN = new List<double>();
        private static List<double> puntosYN = new List<double>();

        private readonly static Percep perceptron = new Percep();

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
            perceptron.Entrenamiento();

            return;
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            puntosX.Add(chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
            puntosY.Add(chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));

            chart2.Series[3].Points.AddXY(puntosX.Last(), puntosY.Last());
        }
    }
}
