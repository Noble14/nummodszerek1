using System;
using System.Collections.Generic;
using System.Text;

namespace NumModszerek.Gauss
{
    class GaussModell
    {
        private int step = 0;
        public Rational[,] matrix { get; private set; }
        public Rational[] bVector { get; private set; }
        public Rational[] resultVector { get; private set; }
        private int n;
        private Random vel = new Random();
        public GaussModell(int n)
        {
            this.n = n;
            matrix = new Rational[n, n];
            bVector = new Rational[n];
            resultVector = new Rational[n];
            generateRandomMatrix();
            
        }
        private void generateRandomMatrix()
        {
            for (int i = 0; i < resultVector.Length; i++)
            {
                resultVector[i] = new Rational(vel.Next(1,15));
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = new Rational(vel.Next(1,10));
                }
            }

            for (int i = 0; i < bVector.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < bVector.Length; j++)
                {
                    s = s + matrix[i, j].nominator * resultVector[j].nominator;
                }
                bVector[i] = new Rational(s);
            }
        }
        public void solve()
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = j+1; i < n; i++)
                {
                    rowSubstraction(i,j,matrix[i,j] / matrix[j,j]);
                }
            }
        }
        //summary
        /// <summary>
        /// Kivon két megfelelő sort egymásból
        /// </summary>
        /// <param name="a">Ebből vonok ki</param>
        /// <param name="b">Ezt a sort vonom ki</param>
        /// <param name="gaussHanyados"></param>
        //summary
        private void rowSubstraction(int a, int b, Rational gaussHanyados)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[a, i] = matrix[a, i] - matrix[b, i] * gaussHanyados;
            }
            bVector[a] = bVector[a] - bVector[b] * gaussHanyados;
        }
        public void next()
        {
            for (int i = step + 1; i < n; i++)
            {
                rowSubstraction(i, step, matrix[i, step] / matrix[step, step]);
            }
            step++;
        }

        public event EventHandler<EventArgs> ModelHasChanged;
    }
}
