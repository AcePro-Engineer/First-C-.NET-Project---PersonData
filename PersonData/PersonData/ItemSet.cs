/******************************************
 Date created: 9/29/2014
 Purpose: To create a Collection of Items. 
 *******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PersonDataProg
{
    class ItemSet
    {
        private List<Item> items = new List<Item>();

        /*******************************
          ItemSet default constructor
          Calls FillItemSet method to 
          fill items List Collection.
         *******************************/

        public ItemSet() { FillItemSet(); }

        /****************************
         Adds a new item to the Item
         List Collection.
         ****************************/
        public void addItem(Item newItem) { items.Add(newItem); }

        /*****************************
         Returns a Single Item object
         from items List Collection
         *****************************/
        public Item getItems(int singleItem) { return items[singleItem]; }

        public List<Item> getItems() { return items; } // Returns entire item List Collection.

        /**********************************
         Method queries internal database
         and fills ItemSet List Collection 
         with queried information.
         **********************************/

        private void FillItemSet()
        {
            string source = "Data Source=COMPUTER\\ACEMAN;Integrated Security=True";
            string getItems = "select * from ItemTable4";
            SqlConnection connect = new SqlConnection(source);
            int count = 0;// ItemSet List element indexer value.

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(getItems, connect);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    items.Add(new Item());// Creates a new Item instance for every row read from database.

                    items[count].ItemType = (string)read[0];// Reads all ItemType strings from database.
                    items[count].ItemCost = (float)read[1];// Reads all ItemCost floats from database.
                    count++;
                }
            }
            catch(SqlException sql)// Throws sqlexception from class.
            {
                Console.WriteLine("A problem occured with the database...");
                Console.WriteLine("The error was: " + sql.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unknown error has occured...");
                Console.WriteLine("The error that occured was..." + ex.Message);
            }
            finally// Closes connection under all circumstances.
            {
                connect.Close();
            }
        }
    }
}
