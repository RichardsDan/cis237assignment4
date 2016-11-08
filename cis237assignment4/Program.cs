using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            MakeList(droidCollection);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 3, continue to do work with the program
            while (choice != 4)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;
                    // Choose to sort the list of droids
                    case 2:
                        userInterface.SortDroids();
                        break;
                    //Choose to Print the droids
                    case 3:
                        userInterface.PrintDroidList();
                        break;
                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }
        }

        static void MakeList(IDroidCollection droids)
        {
            droids.Add("Carbonite", "Janitorial", "Bronze", true, false, false, true, true);
            droids.Add("Quadranium", "Astromech", "Gold", true, true, true, true, 20);
            droids.Add("Carbonite", "Utility", "Bronze", false, false, false);
            droids.Add("Vanadium", "Astromech", "Silver", true, false, true, false, 10);
            droids.Add("Quadranium", "Protocol", "Gold", 25);
            droids.Add("Quadranium", "Utility", "Gold", true, true, true);
            droids.Add("Quadranium", "Janitorial", "Silver", false, false, true, false, true);
            droids.Add("Carbonite", "Protocol", "Bronze", 13);
            droids.Add("Carbonite", "Astromech", "Bronze", false, false, false, false, 1);
            droids.Add("Vanadium", "Janitorial", "Gold", false, false, true, true, false);
            droids.Add("Vanadium", "Utility", "Silver", true, false, true);
            droids.Add("Vandium", "Protocol", "Silver", 4);
        }
    }
}
