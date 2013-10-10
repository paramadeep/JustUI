using System;
using System.Diagnostics;

namespace JustUI
{
    public class Wait
    {
        private readonly Stopwatch stopwatch = new Stopwatch();

        public Wait(int waitInMilliSeconds)
        {
            WaitInMilliSeconds = waitInMilliSeconds;
        }

        private int WaitInMilliSeconds { get; set; }

        public void UntillTrue(Func<bool> expression)
        {
            stopwatch.Start();
            while (!expression() && stopwatch.ElapsedMilliseconds < WaitInMilliSeconds)
            {
            }
            stopwatch.Stop();
        }

        public T UntillNotNull<T>(Func<T> expression)
        {
            T expected;
            stopwatch.Start();
            do
            {
                expected = expression();
            } while (stopwatch.ElapsedMilliseconds < WaitInMilliSeconds && expected == null);
            stopwatch.Stop();
            return expected;
        }

        public T Untill<T>(Func<T> expression, Func<T, bool> isTrue)
        {
            T expected;
            stopwatch.Start();
            do
            {
                expected = expression();
            } while (stopwatch.ElapsedMilliseconds < WaitInMilliSeconds && !isTrue(expected));
            stopwatch.Stop();
            return expected;
        }
    }
}
