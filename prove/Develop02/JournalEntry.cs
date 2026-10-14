class JournalEntry
{
    public string _date;

    public string _prompt;

    public string _response;

    public void DisplayJournalEntry()
    {
        Console.WriteLine($"{_date}, {_prompt}");
        Console.WriteLine($"{_response}");
    }
    public void CreateJournalEntry()
    {
        string [] prompts =
        {
            "How was your day?",
            "Did you meet someone new today?",
            "Who did you interact with today?",
            "Did you get all of your tasks done today?",
            "Was there something that had went wrong today?"
        };

        //Picks a random prompt
        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        _prompt = prompts[randomIndex];

        //Current date
        _date = DateTime.Now.ToShortDateString();

        Console.WriteLine($"{_prompt}: ");
        _response = Console.ReadLine();
    }
}