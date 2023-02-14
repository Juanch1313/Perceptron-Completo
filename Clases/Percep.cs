using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Perceptron.Clases
{
    public class Percep
    {
       private static readonly Random random = new Random();
        private float w0 = (float)random.NextDouble();
        private float w1 = (float)random.NextDouble();
        private float w2 = (float)random.NextDouble();

        private List<float> x1 = new List<float>() 
        { 
            1, 1, -1, -1
        };

        private List<float> x2 = new List<float>()
        {
            1, -1, 1, -1
        };

        private List<float> and = new List<float>()
        {
            1, -1, -1, -1
        };

        private float factorAprendizaje = 0.4f;
        private const int epocas = 500;


        public void Entrenamiento()
        {
            for (int i = 0; i < epocas; i++)
            {
                for (int j = 0; j < x1.Count; j++)
                {
                    float y = (w0 * 1) + (w1 * x1[j]) + (w2 * x2[j]);
                    y = y >= 0 ? 1 : -1;
                    var error = and[j] - (y);
                    if(error != 0)
                    {
                        w0 += (factorAprendizaje * (error) * 1);
                        w1 += (factorAprendizaje * (error) * x1[j]);
                        w2 += (factorAprendizaje * (error) * x2[j]);
                        break;
                    }
                    continue;
                }
            }
        }

        public int Ver(float coordX, float coordY)
        {
            float y = (w0 * 1) + (w1 * coordX) + (w2 * coordY);
            y = y >= 0 ? 1 : 0;

            return (int)y;
        }
    }
}
