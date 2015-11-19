//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            const int wineItemCollectionSize = 4000;
            
            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            IBeverageCollection wineItemCollection = new BeverageCollection(wineItemCollectionSize);            
            
            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();
                       
            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.

            int choice = userInterface.DisplayMenuAndGetResponse();

            BeverageSDiagneEntities beverageEntities = new BeverageSDiagneEntities();
            
            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                                                
                        //Display Success Message
                        userInterface.DisplayImportSuccess();
                        break;

                    case 2:
                        //Print Entire List Of Items
                        int i = 0;
                        Beverage[] allItems = new Beverage[4000];
                        foreach (Beverage beverage in beverageEntities.Beverages)
                        {
                            if (beverage != null)
                            {
                                allItems[i] = beverage;
                                i++;
                            }
                        }            
                                                                                                
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllBeverages(allItems);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllBeveragesError();
                        }
                        break;

                    case 3:
                        //Search For An Item
                       
                        string searchQuery = userInterface.GetSearchQuery();
                        Beverage FoundInformation = beverageEntities.Beverages.Find(searchQuery);
                        if (FoundInformation != null)
                        {
                            userInterface.DisplayBeverageFound(FoundInformation);
                            Console.WriteLine(FoundInformation.id + " " + FoundInformation.name + " " + FoundInformation.pack + " " + FoundInformation.price);
                        }
                        else
                        {
                            userInterface.DisplayBeverageFoundError();
                        }
                       
                        break;

                    case 4:
                        //Add A New Item To The List
                      
                        Beverage newBeverageToAdd = userInterface.GetNewItemInformation();

                        if ((beverageEntities.Beverages.Find(newBeverageToAdd.id)) == null)
                        {
                            beverageEntities.Beverages.Add(newBeverageToAdd);
                            userInterface.DisplayAddBeverageSuccess();
                        }
                        else
                        {
                            userInterface.DisplayBeverageAlreadyExistsError();
                        }
                        beverageEntities.SaveChanges();
                        break;

                    case 5:

                        //Update an Item   
                        userInterface.DisplayBeverageUpdateChoice();
                        string searchQuery1 = userInterface.GetSearchQuery();
                        Beverage BeverageToUpdate = beverageEntities.Beverages.Find(searchQuery1);                        

                        if (BeverageToUpdate == null)
                        {
                            userInterface.DisplayBeverageUpdateError();
                            
                        }

                        else
                        {
                            BeverageToUpdate = userInterface.GetUpdates(BeverageToUpdate);                           
                            userInterface.DisplayBeverageUpdateSucces();
                        }

                        beverageEntities.SaveChanges();

                        break;

                    case 6:

                        //Delete an Item from the list
                        userInterface.DisplayBeverageDeleteChoice();
                        string searchQuery2 = userInterface.GetSearchQuery();
                        Beverage BeverageToDelete = beverageEntities.Beverages.Find(searchQuery2);                        

                        if (BeverageToDelete == null)
                        {
                            userInterface.DisplayBeverageDeleteError();
                        }
                        else
                        {
                            beverageEntities.Beverages.Remove(BeverageToDelete);                            
                            userInterface.DisplayBeverageDeleteSuccess();
                        }
                        beverageEntities.SaveChanges();

                        break;

                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
