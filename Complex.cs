using System;

namespace ParallelLab1Attempt2
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public double Len => Math.Sqrt(Re * Re + Im * Im);

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public static Complex operator +(Complex c, double number) => new Complex(c.Re + number, c.Im);

        public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.Re + c2.Re, c1.Im + c2.Im);

        public static Complex operator -(Complex c, double number) => new Complex(c.Re - number, c.Im);

        public static Complex operator -(Complex c) => new Complex(-c.Re, -c.Im);

        public static Complex operator *(Complex c, double number) => new Complex(c.Re * number, c.Im * number);

        public static Complex operator *(Complex c1, Complex c2) =>
            new Complex(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);

        public static Complex operator /(Complex c, double number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException("Divisor can't be zero");
            }

            return new Complex(c.Re / number, c.Im / number);
        }

        public override string ToString() => Math.Sign(Im) switch
        {
            -1 => $"{Math.Round(Re, 3)} - {-Math.Round(Im, 3)} * i",
            1 => $"{Math.Round(Re, 3)} + {Math.Round(Im, 3)} * i",
            _ => $"{Math.Round(Re, 3)}"
        };
    }
}
