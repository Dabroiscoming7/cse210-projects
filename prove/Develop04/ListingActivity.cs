class ListingActivity : BaseActivity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you like to hangout with?",
        "What personal strengths do you have?",
        "Who are people you met this week?",
        "When have you felt the Holy Ghost?",
        "Who are people you look up too?"
    };

    public void RunActivity()
    {
        StartActivity(
            "Listing Activity",
            "This activity will ask questions and will listen to your response.");

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {Prompts[Random.Shared.Next(Prompts.Length)]} ---");
        RunCountdownMessage("You may begin in", 5);

        StartTimer();
        Console.WriteLine("Begin listing items. Press Enter after each item.");
        int itemCount = CollectItems();
        Console.WriteLine($"\nYou listed {itemCount} item(s).");

        EndActivity("Listing Activity");
    }

    private int CollectItems()
    {
        int itemCount = 0;
        string currentItem = "";
        while (!HasTimerExpired())
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                if (!string.IsNullOrWhiteSpace(currentItem))
                {
                    itemCount++;
                }

                currentItem = "";
            }
            else if (key.Key == ConsoleKey.Backspace && currentItem.Length > 0)
            {
                currentItem = currentItem[..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                currentItem += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        return itemCount;
    }
}
