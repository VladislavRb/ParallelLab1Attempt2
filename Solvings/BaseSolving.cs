using System;
using System.Diagnostics;

namespace ParallelLab1Attempt2.Solvings
{
    public abstract class BaseSolving
    {
        private const double Eps = 5E-05;

        protected readonly SolvingParameters Sp;
        protected readonly Stopwatch Stopwatch = new Stopwatch();

        protected BaseSolving(SolvingParameters sp) => Sp = sp;

        public abstract long Run();

        protected void SolveMany(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                var (a, b, c) = (Sp.Generate(), Sp.Generate(), Sp.Generate());
                var (root1, root2) = Equation.Roots(a, b, c);

                if (!(a == 0 || RootIsCorrect(a, b, c, root1) && RootIsCorrect(a, b, c, root2)))
                {
                    throw new Exception("Root is found incorrectly");
                }
            }
        }

        protected void StartTimer() => Stopwatch.Start();

        protected long StopAndResetTimer()
        {
            Stopwatch.Stop();
            var elapsedMilliseconds = Stopwatch.ElapsedMilliseconds;
            Stopwatch.Reset();

            return elapsedMilliseconds;
        }

        private bool RootIsCorrect(int a, int b, int c, Complex root) => (root * root * a + root * b + c).Len <= Eps;
    }
}
