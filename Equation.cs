using System;

namespace ParallelLab1Attempt2
{
    public static class Equation
    {
        public static (Complex, Complex) Roots(int a, int b, int c)
        {
            if (a == 0)
            {
                return (null, null);
            }

            Complex discSqrt = DiscSqrt(b * b - 4 * a * c);
            return ((discSqrt - b) / (2 * a), (-discSqrt - b) / (2 * a));
        }

        private static Complex DiscSqrt(int discriminant)
        {
            double discSqrt = Math.Sqrt(Math.Abs(discriminant));
            return discriminant >= 0 ? new Complex(discSqrt, 0) : new Complex(0, discSqrt);
        }
    }
}
