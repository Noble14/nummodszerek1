using System;
using System.Collections.Generic;
using System.Text;

namespace NumModszerek.Gauss
{
    public class Rational
    {
        public int denominator { get; set; }
        public int nominator { get; set; }

        public Rational(int a, int b)
        {
            if( a == 0)
            {
                this.denominator = 1;
                this.nominator = 0;
            }
            else
            {
                int m = lnko(a, b);
                this.denominator = b / m;
                this.nominator = a / m;
            }
        }

        public Rational(int a)
        {
            this.denominator = 1;
            this.nominator = a;
        }

        public Rational()
        {
            denominator = 1;
            nominator = 0;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int nevezo = lkkt(a.denominator, b.denominator);
            int aszorzo = nevezo / a.denominator;
            int bszorzo = nevezo / b.denominator;
            return new Rational(a.nominator * aszorzo + b.nominator * bszorzo, nevezo);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int nevezo = lkkt(a.denominator, b.denominator);
            int aszorzo = nevezo / a.denominator;
            int bszorzo = nevezo / b.denominator;
            return new Rational(a.nominator * aszorzo - b.nominator * bszorzo, nevezo);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.nominator * b.nominator, a.denominator * b.denominator);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            if (b.nominator == 0)
            {
                Exception e = new Exception("Cannot divide with null");
                throw e;
            }
            return new Rational(a.nominator * b.denominator, a.denominator * b.nominator);
        }

        public override string ToString()
        {
            if (denominator == 1)
            {
                return nominator.ToString();
            }
            return $"{nominator}/{denominator}";
        }

        public static int lkkt(int a, int b)
        {
            return a * b / lnko(a, b);
        }

        public static int lnko(int a, int b)
        {
            if (a < b)
            {
                int c = b;
                b = a;
                a = c;
            }
            int m;
            while (b != 0)
            {
                m = a % b;
                a = b;
                b = m;
            }
            return a;
        }
    }
}
