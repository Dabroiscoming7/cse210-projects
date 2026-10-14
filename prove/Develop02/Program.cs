// Exceeding requirements I have added a feauture for when the user clicks 5, 
// the program will count how many entries there are.
class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();
        Journal myJournal = new Journal();

        int response = 0;
        while(response != 6)
        {
            response = myMenu.ProcessMenu();
            switch(response)
            {
                case 1:
                    myJournal.CreateEntry();
                    break;
                case 2:
                    myJournal.DisplayJournal();
                    break;
                case 3:
                    myJournal.SaveToFile();
                    break;
                case 4: 
                    myJournal.LoadFromFile();
                    break;
                case 5:
                    myJournal.CountEntries();
                    break;
            }
        }
        
    }
}