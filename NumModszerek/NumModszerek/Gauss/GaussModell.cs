using System;
using System.Collections.Generic;
using System.Text;

namespace NumModszerek.Gauss
{
    class GaussModell
    {
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
                resultVector[i] = new Rational(vel.Next(15));
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = new Rational(vel.Next(10));
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
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    rowSubstraction(j,i,matrix[i,j] / matrix[i,i]);
                }
            }
        }
        private void rowSubstraction(int a, int b, Rational gaussHanyados)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[a, i] = matrix[a, i] - matrix[b, i] * gaussHanyados;
            }
            bVector[a] = bVector[a] - bVector[b] * gaussHanyados;
        }
    }
}
