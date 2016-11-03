using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        GenericStackLinkedList<IDroid> protocolList = new GenericStackLinkedList<IDroid>();
        GenericStackLinkedList<IDroid> utilityList = new GenericStackLinkedList<IDroid>();
        GenericStackLinkedList<IDroid> janitorList = new GenericStackLinkedList<IDroid>();
        GenericStackLinkedList<IDroid> astromechList = new GenericStackLinkedList<IDroid>();
        GenericQueueLinkedList<IDroid> droidQueue = new GenericQueueLinkedList<IDroid>();

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SortDroids()
        {
            CreateDroidStacks();
            CreateQueue();
            EnterQueue();
        }

        private void CreateDroidStacks()
        {
            foreach (Droid droid in this.droidCollection)
            {
                if (droid != null)
                {
                    switch (droid.Model)
                    {
                        case "Protocol":
                            protocolList.AddToFront(droid);
                            break;
                        case "Utility":
                            utilityList.AddToFront(droid);
                            break;
                        case "Janitorial":
                            janitorList.AddToFront(droid);
                            break;
                        default:
                            astromechList.AddToFront(droid);
                            break;
                    }
                }
            }
        }

        private void CreateQueue()
        {
            while (!protocolList.IsEmpty)
            {
                droidQueue.AddToBack(protocolList.RemoveFromFront());
            }
            while (!utilityList.IsEmpty)
            {
                droidQueue.AddToBack(utilityList.RemoveFromFront());
            }
            while (!janitorList.IsEmpty)
            {
                droidQueue.AddToBack(janitorList.RemoveFromFront());
            }
            while (!astromechList.IsEmpty)
            {
                droidQueue.AddToBack(astromechList.RemoveFromFront());
            }
        }

        private void EnterQueue()
        {
            for (int i = 0; i < droidCollection.Length; i++)
            {
                if (droidCollection[i] != null)
                {
                    droidCollection[i] = droidQueue.RemoveFromFront();
                }
            }
        }

        public void SortCost()
        {
            foreach (IDroid droid in droidCollection)
            {
                if (droid != null)
                droid.CalculateTotalCost();
            }
            MergeSort.StartSort(droidCollection);
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }
    }
}
