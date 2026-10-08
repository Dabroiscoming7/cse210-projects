class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();
        JournalEntry myEntry = new JournalEntry();

        int response = 0;
        while(response != 5)
        {
            response = myMenu.ProcessMenu();
            switch(response)
            {
                case 1:
                    myEntry.CreateJournalEntry();
                    break;
                case 2:
                    myEntry.DisplayJournalEntry();
                    break;
                case 3:
                    Console.WriteLine("Save");
                    // Call ReadFromFile()
                    break;
                case 4: 
                    Console.WriteLine("Write");
                    // Call WriteToFile()
                    break;
            }
        }
        
    }
}