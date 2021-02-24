using System.Threading;

namespace ParallelLab1Attempt2.Solvings
{
    public class ThreadPoolSolving : BaseSolving
    {
        private readonly int _threadPoolQueueSize;
        private readonly int _callsPerQueueItem;
        private int _operations;

        public ThreadPoolSolving(SolvingParameters sp, int threadPoolQueueSize = 10) : base(sp)
        {
            _threadPoolQueueSize = threadPoolQueueSize;
            _callsPerQueueItem = Sp.Iterations / threadPoolQueueSize;
        }

        public override long Run()
        {
            var resetEvent = new AutoResetEvent(false);
            ThreadPool.SetMinThreads(_threadPoolQueueSize, _threadPoolQueueSize);

            StartTimer();
            for (int i = 0; i < _threadPoolQueueSize; i++)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    SolveMany(_callsPerQueueItem);

                    Interlocked.Increment(ref _operations);
                    if (_operations == _threadPoolQueueSize)
                    {
                        resetEvent.Set();
                    }
                }, null);
            }
            resetEvent.WaitOne();
            _operations = 0;

            return StopAndResetTimer();
        }
    }
}
