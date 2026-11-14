class BaseActivity
{
    private int _duration;
    private DateTime _endTime;
    private bool _timerStarted;

    protected void StartActivity(string name, string description)
    {
        Console.WriteLine($"\n{name}");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
        _duration = ObtainDuration();
        Console.WriteLine("\nGet ready...");
        RunSpinnerMessage("Prepare", 3);
        Console.WriteLine();
    }

    private static int ObtainDuration()
    {
        while (true)
        {
            Console.Write("Enter the duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter another number.");
        }
    }

    protected void StartTimer()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
        _timerStarted = true;
    }

    protected bool HasTimerExpired()
    {
        if (!_timerStarted)
        {
            throw new InvalidOperationException("The activity timer has not started.");
        }

        return DateTime.Now >= _endTime;
    }

    protected static void RunCountdownMessage(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{message} {i}...");
            Thread.Sleep(1000);
        }
    }

    protected void RunCountdownForActivity(string message, int seconds)
    {
        DateTime phaseEnd = DateTime.Now.AddSeconds(seconds);
        Console.WriteLine(message);
        while (!HasTimerExpired())
        {
            DateTime now = DateTime.Now;
            TimeSpan delay = phaseEnd - now;
            TimeSpan activityRemaining = _endTime - now;
            if (activityRemaining < delay)
            {
                delay = activityRemaining;
            }

            if (delay <= TimeSpan.Zero)
            {
                break;
            }

            int remaining = (int)Math.Ceiling(delay.TotalSeconds);
            Console.WriteLine($"{remaining}...");
            if (delay > TimeSpan.FromSeconds(1))
            {
                delay = TimeSpan.FromSeconds(1);
            }

            Thread.Sleep(delay);
        }
    }

    protected void RunSpinnerUntilActivityEnds(string message, int maxSeconds)
    {
        int remainingSeconds = Math.Max(0, (int)(_endTime - DateTime.Now).TotalSeconds);
        int pauseSeconds = Math.Min(maxSeconds, remainingSeconds);
        Console.Write($"{message} ");
        if (pauseSeconds > 0 && !HasTimerExpired())
        {
            RunSpinnerMessage(message, pauseSeconds);
        }

        Console.WriteLine();
    }

    protected void EndActivity(string name)
    {
        Console.WriteLine("\nYou did a good job!");
        Console.WriteLine($"\nYou have completed the {name} for {_duration} seconds.");
        Console.WriteLine();
        _timerStarted = false;
    }

    public void RunSpinnerMessage(string message, int seconds)
    {
        Console.CursorVisible = false;
        DateTime now = DateTime.Now;
        DateTime endTime = now.AddSeconds(seconds);
        //for(int i = 0; i < seconds; i++)
        while (DateTime.Now < endTime)
        {
            Console.Write("+");
            Thread.Sleep(200);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b");
            Console.Write("*");
            Thread.Sleep(200);
        }
        Console.CursorVisible = true;
    }

}
