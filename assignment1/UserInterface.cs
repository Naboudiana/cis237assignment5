//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 7;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the beverage program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What beverage would you like to search for? (SEARCH BY ID)");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public Beverage GetNewItemInformation()
        {
            Beverage beverage = new Beverage();
            Console.WriteLine();
            Console.WriteLine("What is the new beverage's Id?");
            Console.Write("> ");
            beverage.id = Console.ReadLine();
            Console.WriteLine("What is the new beverage's Name?");
            Console.Write("> ");
            beverage.name = Console.ReadLine();
            Console.WriteLine("What is the new beverage's Pack?");
            Console.Write("> ");
            beverage.pack = Console.ReadLine();
            Console.WriteLine("What is the new beverage's Price?");
            Console.Write("> ");
            beverage.price = decimal.Parse(Console.ReadLine());

            return beverage;
        }

        public Beverage GetUpdates(Beverage beverageToUpdate)
        {            
            Beverage beverage = new Beverage();
            Console.WriteLine(" IDs cannot be updated, however you can choose to update name, pack, and/or size");
            Console.WriteLine("Would You Like To Update The Name? (yes = 1/no = 2)");
            int answer1 = Int32.Parse(Console.ReadLine());
            switch (answer1)
            {
                case 1:
                    Console.WriteLine("What is the new beverage's Name?");
                    Console.Write("> ");
                    beverageToUpdate.name = Console.ReadLine();
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            Console.WriteLine("Would You Like To Update The Pack? (yes = 1/no = 2)");
            int answer2 = Int32.Parse(Console.ReadLine());
            switch (answer2)
            {
                case 1:
                    Console.WriteLine("What is the new beverage's Pack?");
                    Console.Write("> ");
                    beverageToUpdate.pack = Console.ReadLine();
                    break;

                case 2:
                    
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            Console.WriteLine("Would You Like To Update The Price? (yes = 1/no = 2)");
            int answer3 = Int32.Parse(Console.ReadLine());
            switch (answer3)
            {
                case 1:
                    Console.WriteLine("What is the new beverage's Price?");
                    Console.Write("> ");
                    beverageToUpdate.price = decimal.Parse(Console.ReadLine());
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            return beverageToUpdate;
        }

        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Beverage List Has Been Imported Successfully");
        }

        //Display All Items
        public void DisplayAllBeverages(Beverage[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (Beverage beverage in allItemsOutput)
            {
                if (beverage != null)
                    Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price);
            }
        }

        //Display All Items Error
        public void DisplayAllBeveragesError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no beverages in the list to print");
        }

        //Display Item Found Success
        public void DisplayBeverageFound(Beverage FoundInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Found!");
           
        }

        //Display Item Found Error
        public void DisplayBeverageFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddBeverageSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Beverage was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayBeverageAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("A Beverage With That Id Already Exists");
        }

        public void DisplayBeverageUpdateChoice()
        {
            Console.WriteLine();
            Console.WriteLine("You chose to update a beverage which you will need to, first, search for");
        }

        public void DisplayBeverageUpdateSucces()
        {
            Console.WriteLine();
            Console.WriteLine("The beverage was successfully updated");
        }

        public void DisplayBeverageUpdateError()
        {
            Console.WriteLine();
            Console.WriteLine("The beverage was not found, thus it cannot be updated");
        }

        public void DisplayBeverageDeleteChoice()
        {
            Console.WriteLine();
            Console.WriteLine("You chose to delete a beverage which you will need to, first, search for");
        }

        public void DisplayBeverageDeleteSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The beverage was successfully deleted");
        }

        public void DisplayBeverageDeleteError()
        {
            Console.WriteLine();
            Console.WriteLine("The beverage was not found, thus it cannot be deleted");
        }

        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Load Wine List From CSV");
            Console.WriteLine("2. Print The Entire List Of Beverages");
            Console.WriteLine("3. Search For An Beverage");
            Console.WriteLine("4. Add New Beverage To The List");
            Console.WriteLine("5. Update An Existing Beverage");
            Console.WriteLine("6. Delete An Beverage From The List");
            Console.WriteLine("7. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
