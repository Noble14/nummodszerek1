using System;
using System.Collections.Generic;
using System.Text;
using NumModszerek.Tasks.Gauss.Model;

namespace NumModszerek.Tasks.MachineNumbers.Model
{
    class MachineNumbersModel
    {
        #region Fields
        private Int16 _mantissza;
        private Int16 _kStart;
        private Int16 _kEnd;
        #endregion

        #region Properties
        public Int16 Mantissa
        {
            get { return _mantissza; }
            set { _mantissza = value; }
        }
        public Int16 CharacteristicEnd
        {
            get { return _kEnd; }
            set { _kEnd = value; }
        }
        public Int16 CharacteristicStart
        {
            get { return _kStart; }
            set { _kStart = value; }
        }
        #endregion

        #region Constructors

        #endregion

        #region Public methods
        public MachineNumberSolution<int> Count()
        {
            int k;
            if (_kStart <= 0)
                k = _kEnd - _kStart + 1;
            else
                k = _kEnd - _kStart;
            string sol = $"{2} * ({2}^({_mantissza}-{1})) * {k} + 1";
            int actual = 2 * (2 ^ (_mantissza - 1)) * k + 1;
            return new MachineNumberSolution<int>() { TextOfSolution = sol, Solution = actual };
        }
        public MachineNumberSolution<float> MaxNumber()
        {
            float sum = (1 - 1 / (2 ^ _mantissza)) * (2 ^ _kEnd);
            StringBuilder str = new StringBuilder();
            str.Append("[");
            for (int i = 0; i < _mantissza; i++)
            {
                str.Append("1");
            }
            str.Append($"| {_kEnd}]\n");
            str.Append($"(1 - 1 / (2 ^ {_mantissza})) * (2^{_kEnd})");
            return new MachineNumberSolution<float>() { TextOfSolution = str.ToString(), Solution = sum };
        }
        /// <summary>
        /// Kiszámolja a legkisebb pozitív ábrázolható gépi számot, az adott halmazon
        /// </summary>
        /// <returns>A megoldás menete és a legkisebb pozitív gépiszám értéke</returns>
        public MachineNumberSolution<Rational> MinNumber()
        {
            Rational half = new Rational(1, 2);
            Rational mink, sum;
            string text;
            if (_kStart < 0)
            {
                mink = new Rational(1, 2 ^ _kStart);
                sum = half * mink;
                text = half.ToString() + $"* 1/ 2^{_kStart}";
            }
            else
            {
                mink = new Rational(2 ^ _kStart);
                sum = half * mink;
                text = half.ToString() + "*" + mink.ToString();
            }
            return new MachineNumberSolution<Rational>() { TextOfSolution = text, Solution = sum };
        }
        #endregion
    }
}
