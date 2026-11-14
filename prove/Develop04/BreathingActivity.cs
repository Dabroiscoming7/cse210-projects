class BreathingActivity : BaseActivity
{
    public void RunActivity()
    {
        StartActivity(
            "Breathing Activity",
            "This activity will help you focus on breathing in and breathing out.");

        StartTimer();
        while (!HasTimerExpired())
        {
            RunCountdownForActivity("Breathe in...", 5);
            if (!HasTimerExpired())
            {
                RunCountdownForActivity("Breathe out...", 5);
            }
        }

        EndActivity("Breathing Activity Completed!");
    }
}
