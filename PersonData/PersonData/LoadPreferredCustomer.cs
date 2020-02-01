/**********************************************
 Date Completed: 6/30/2014
 Purpose: To queried Database and return either
          a single customer or a list of all 
          customers.
 **********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PersonDataProg
{
    class LoadPreferredCustomer
    {
        private static List<PreferredCustomer> customers = new List<PreferredCustomer>();


        public static List<PreferredCustomer> Loader()
        {
            int count = 0;// Holds List Collection element count.

            string source = "Data Source=COMPUTER\\ACEMAN;Integrated Security=True";// Establishes connection.
            string getAcustomer = "select * from some4";                            // Holds sql query.
            SqlConnection connect = new SqlConnection(source);

            try 
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(getAcustomer, connect);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())// Reads entire database and stores all values into customers List.
                {
                    customers.Add(new PreferredCustomer());

                    customers[count].CustomerNumber = (string)reader[0];
                    customers[count].setFirstName((string)reader[1]);
                    customers[count].setLastName((string)reader[2]);
                    customers[count].setAddress((string)reader[3]);
                    customers[count].setCity((string)reader[4]);
                    customers[count].setState((string)reader[5]);
                    customers[count].setZip((string)reader[6]);
                    customers[count].setPhoneNumber((string)reader[7]);
                    count++;
                }
            }
            catch(SqlException sql)// Catches Sql exception.
            {
                Console.WriteLine("A problem ocurred with the database....");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unknown error has ocurred....");
                Console.WriteLine("The error that ocurred was..." + ex.Message);
            }
            finally // Closes connection.
            {
                connect.Close();
            }

            return customers; // Returns List.
        }

        /**************************
          Overload of above method,
          only returns a single 
          customer from database.
         **************************/
        public static PreferredCustomer Loader(string find)
        {
            PreferredCustomer p = new PreferredCustomer();

            string source = "Data Source=COMPUTER\\ACEMAN;Integrated Security=True";
            string getAcustomer = "select * from some4 where CustomerId = " + find;
            SqlConnection connect = new SqlConnection(source);

            try
            { 
                connect.Open();
                SqlCommand cmd = new SqlCommand(getAcustomer, connect);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                
                p.CustomerNumber = (string)reader[0];
                p.setFirstName((string)reader[1]);
                p.setLastName((string)reader[2]);
                p.setAddress((string)reader[3]);
                p.setCity((string)reader[4]);
                p.setState((string)reader[5]);
                p.setZip((string)reader[6]);
                p.setPhoneNumber((string)reader[7]);
               

            }
            catch(SqlException sql)
            {
                Console.WriteLine("An error has ocurred with the database...");
                Console.WriteLine("The error that ocurred is..." + sql.Message);
            }
            catch(InvalidOperationException notValid)
            {
                Console.WriteLine("An error has ocurred with the database...");
                Console.WriteLine("The error that ocurred is..." + notValid.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unknown error has ocurred...");
                Console.WriteLine("The error that ocurred was.." + ex.Message);
            }
            finally
            {
               connect.Close();
            }

            return p;
        }
    }
}
