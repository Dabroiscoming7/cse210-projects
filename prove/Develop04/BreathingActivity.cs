class BreathingActivity : BaseActivity
{
    public BreathingActivity(): base()
    {
        
    }
    public void RunActivity()
    {
        //call StartActivity() method
        //DateTime endTime = DateTime.Now.AddSeconds(20); // delete later 
        RunCountDownMessage("Get Ready", 5);
        StartTimer();
        //while (DateTime.Now < endTime)
        while(! HasTimerExpired()) // Add when code is ready 
        {
            RunCountDownMessage("Breath in", 4);
            RunCountDownMessage("Breath out", 6);
        }


        //Call EndActivity()
    }
}