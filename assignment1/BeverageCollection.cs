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
    class BeverageCollection : IBeverageCollection
    {
        //Private Variables
        Beverage[] Beverages;
        int beveragesLength;
        
        //Constuctor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            Beverages = new Beverage[size];
            beveragesLength = 0;
        }

        //Get The Print String Array For All Items
        public Beverage[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            Beverage[] allItemStrings = new Beverage[beveragesLength];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (beveragesLength > 0)
            {
                //For each item in the collection
                foreach (Beverage beverage in Beverages)
                {
                    //if the current item is not null.
                    if (beverage != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = beverage;
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

    }
}