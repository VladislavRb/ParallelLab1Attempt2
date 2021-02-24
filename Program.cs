using System;
using ParallelLab1Attempt2.Solvings;

namespace ParallelLab1Attempt2
{
    public class Program
    {
        private static readonly SolvingParameters Sp = new SolvingParameters(1_000, 10_000_000);

        public static void Main(string[] args)
        {
            var nonConcurrent = new NonConcurrentSolving(Sp);
            var threadPool = new ThreadPoolSolving(Sp);

            for (int i = 0; i < 10; i++)
            {
                var nonConcurrentMillis = nonConcurrent.Run();
                Console.WriteLine($"Non-concurrent: {nonConcurrentMillis}ms");

                var threadPoolMillis = threadPool.Run();
                Console.WriteLine($"Thread pool: {threadPoolMillis}ms");

                var difference = (double)nonConcurrentMillis / threadPoolMillis;
                Console.WriteLine($"Thread pool is {difference} times faster");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
