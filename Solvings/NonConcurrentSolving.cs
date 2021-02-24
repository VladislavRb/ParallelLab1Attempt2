namespace ParallelLab1Attempt2.Solvings
{
    public class NonConcurrentSolving : BaseSolving
    {
        public NonConcurrentSolving(SolvingParameters sp) : base(sp) { }

        public override long Run()
        {
            StartTimer();
            SolveMany(Sp.Iterations);

            return StopAndResetTimer();
        }
    }
}
