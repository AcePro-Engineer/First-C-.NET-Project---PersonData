/*****************************************************
 Date Completed: 7/6/2014
 Name:Person/Item Data Program
 Purpose: To queried a database and perform operations
 on queried data.
 *****************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersonDataProg
{
    class Program
    {
        static void Main(string[] args)
        {
            float total = 0;          // Holds total cost of ordered items.
            float originalTotal = 0; //  Holds original total cost of ordered items.
            string choice;          //   Holds user choice string. 
            string test;           //    Holds test string value.


            PreferredCustomer customer = new PreferredCustomer(); // PreferredCustomer object.(derives from PersonData)
            ItemSet queriedItems = new ItemSet();                //  Pulls a List of item data from the database.
            List<Item> itemList = new List<Item>();             //   Holds pulled item List data.
            List<Item> tally = new List<Item>();               //    Keeps a tally of all ordered items.
            Item aItem = new Item();

            Console.WriteLine("THIS PROGRAM WILL ALLOW THE USER TO ORDER ITEMS FROM A LIST " + // Program description banner.
                               "AND RETURN A TOTAL  VALUE PLUS ANY DISCOUNTS ASSOCIATED WITH " +
                               "THAT VALUE.\n");
            Console.WriteLine("PLEASE ENTER A CUSTOMER ID BETWEEN 1001 AND 1014.\n");

            itemList = queriedItems.getItems();

            Console.Write("Please enter a customer Number: ");
            string cusNo = Console.ReadLine();
            customer = LoadPreferredCustomer.Loader(cusNo);

            do // Do-while loop controls main flow of the driver program.
            {
                Console.WriteLine();
                Console.WriteLine("This is the order guide for " + customer.getFirstName()
                                    + " " + customer.getLastName());
                Console.WriteLine("Please enter the cooresponding number for each item to add it to your " +
                                   "currently existing order.");
                Console.WriteLine();
                do // Controls the orderGuide method call.
                {
                    tally.Add(orderGuide(customer.getFirstName(), customer.getLastName(), itemList));
                    Console.Write("\nDoes " + customer.getFirstName() + " wish to order another item? Yes or No(To finish ordering items please spell NO completely): ");
                    choice = Console.ReadLine();

                    test = null;
                    foreach (var letter in choice)
                        test += char.ToUpper(letter);

                } while (!(test.Equals("NO")));

                Console.WriteLine("\nThe Items " + customer.getFirstName() + " selected were:\n");
                foreach (var item in tally) // Writes out a list of all ordered items.
                {
                    Console.WriteLine(item.ItemType + " Cost: " + item.ItemCost);
                    total += item.ItemCost;
                    originalTotal = total;

                    total = caculateCost(customer, total);
                }
                Console.WriteLine();
                Console.WriteLine("The total cost of all " + customer.getFirstName() + "'s items is {0:0.00}", total);

                if (originalTotal >= 1000.00) // If value greater than a 1000.00 prints original total before deduction to screen.
                    Console.WriteLine(customer.getFirstName() + "'s original total was {0:0.00}", originalTotal);

                Console.WriteLine(customer.getFirstName() + " saved a total of {0:0.00} dollars", originalTotal - total);

                tally.Clear(); // Clears tally Item List collection of all elements.
                total = 0;    //  Assigns 0 to total float variable for new amount accumulation.
                Console.Write("\nDoes " + customer.getFirstName() + " wish to start a new order? Yes or No(To end program  please spell NO completely): ");
                choice = Console.ReadLine();

                test = null;
                foreach (var letter in choice)
                    test += char.ToUpper(letter);

            } while (!(test.Equals("NO"))); //If test value is false re-iterates entire main driver.

            Console.WriteLine("\nPress enter to close program..");
            Console.ReadLine();

        }

        /********************************
         Prints a List of items to screen
         and returns a single item chosen
         by user.
         ********************************/
        static Item orderGuide(string firstName, string lastName, List<Item> itemList)
        {
            int choice = 0;          // Holds a numeric choice, specified by user.
            int count = 1;          //  Generates a numeric sentinal value to be used by user.
            Item pick = new Item();//   Item object to be returned when chosen by user.

           try
           {
                Console.WriteLine();
                foreach (var item in itemList) // Prints a List of items to be ordered by user.
                {
                    Console.WriteLine(count + ". " + item.ToString());
                    count++;
                }
                Console.Write("\nWhich item would " + firstName + " like to order? : ");
                choice = int.Parse(Console.ReadLine());
                pick = itemList[choice - 1];
            }
           catch (FormatException fm) { Console.WriteLine("Invalid input..please try again."); } // Error handling code.
           catch (ArgumentOutOfRangeException arg) { Console.WriteLine("No Item was selected."); }
           catch (Exception e) { Console.WriteLine("A unknown error has ocurred."); }

           return pick;
        }

        /***********************************
         Caculates and returns a new total
         value with discounts applied to new
         total value, if any apply.
         ***********************************/
        static float caculateCost(PreferredCustomer customer, float total)
        {
            float newTotal = total; // newTotal varible used to caculate discount of total value.

            if(customer.setDiscount(newTotal))
                return total = newTotal - ((newTotal / 100) * (float)customer.getDiscountLevel());

            return total;
        }
    }
}
