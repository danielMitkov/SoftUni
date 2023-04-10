using System;
 
namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
 
            string outputCurrentDestination = "";
            string outputAllDestination = "";
            double minBudget = 0;
            double currentSaveAmount = 0;
 
            while (destination != "End")
            {
                minBudget = double.Parse(Console.ReadLine());
 
                while (minBudget > 0)
                {
                    string command = Console.ReadLine();
                    if (command == "End")
                    {
                        Console.WriteLine(outputAllDestination);
                        return;
                    }
                    currentSaveAmount = double.Parse(command);
                    minBudget -= currentSaveAmount;
                }
                outputCurrentDestination = "Going to " + destination + "!" + "\n";
                outputAllDestination += outputCurrentDestination;
                destination = Console.ReadLine();
            }
            if (destination == "End")
            {
                Console.WriteLine(outputAllDestination);
            }
        }
    }
}