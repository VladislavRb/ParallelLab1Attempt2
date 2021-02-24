using System;

namespace ParallelLab1Attempt2
{
    public readonly struct SolvingParameters
    {
        private static readonly Random Rand = new Random();

        public int ValueBound { get;}
        public int Iterations { get; }

        public SolvingParameters(int valueBound, int iterations)
        {
            ValueBound = valueBound;
            Iterations = iterations;
        }

        public int Generate() => Rand.Next(-ValueBound, ValueBound);
    }
}
