using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1":
                    new BreathingActivity().RunActivity();
                    break;
                case "2":
                    new ReflectionActivity().RunActivity();
                    break;
                case "3":
                    new ListingActivity().RunActivity();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please select a diffrent option.\n");
                    break;
            }
        }

        Console.WriteLine("Thank you for particpating in these activities!.");
    }
}