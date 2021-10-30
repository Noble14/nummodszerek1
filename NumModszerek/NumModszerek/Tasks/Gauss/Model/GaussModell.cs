using System;
using System.Collections.Generic;
using System.Text;

namespace NumModszerek.Tasks.Gauss.Model
{
    class GaussModell
    {
        #region Properties
        public Rational[,] matrix { get; private set; }
        public Rational[] bVector { get; private set; }
        public Rational[] resultVector { get; private set; }
        #endregion

        #region Fields
        private int step = 0;
        private int n;
        private Random vel = new Random();
        #endregion

        #region Constructors
        public GaussModell(int n)
        {
            this.n = n;
            matrix = new Rational[n, n];
            bVector = new Rational[n];
            resultVector = new Rational[n];
            generateRandomMatrix();

        }
        #endregion

        #region private methods
        private void generateRandomMatrix()
        {
            for (int i = 0; i < resultVector.Length; i++)
            {
                resultVector[i] = new Rational(vel.Next(1, 15));
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = new Rational(vel.Next(1, 10));
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
        
        /// <summary>
        /// Kivon két megfelelő sort egymásból
        /// </summary>
        /// <param name="a">Ebből vonok ki</param>
        /// <param name="b">Ezt a sort vonom ki</param>
        /// <param name="gaussHanyados"></param>        
        private void rowSubstraction(int a, int b, Rational gaussHanyados)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[a, i] = matrix[a, i] - matrix[b, i] * gaussHanyados;
            }
            bVector[a] = bVector[a] - bVector[b] * gaussHanyados;
        }
        #endregion

        #region Public methods
        public void solve()
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = j + 1; i < n; i++)
                {
                    rowSubstraction(i, j, matrix[i, j] / matrix[j, j]);
                }
            }
        }
        public void next()
        {
            for (int i = step + 1; i < n; i++)
            {
                rowSubstraction(i, step, matrix[i, step] / matrix[step, step]);
            }
            step++;
            ModelHasChanged?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Events
        public event EventHandler<EventArgs> ModelHasChanged;
        #endregion
    }
}
