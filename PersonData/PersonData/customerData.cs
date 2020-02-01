/**************************************************
 Date Completed: 6/29/2014
 Purpose: To extend PersonData class functionality.
 **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataProg
{
    class CustomerData : PersonData
    {
        private string customerNumber;
        private bool mailingList;

        /***********************************
         Sets/Gets customerNumber Property.
         ***********************************/
        public string CustomerNumber
        {
            get { return customerNumber; }
            set
            {
                try
                {
                    customerNumber = value;//Catches any improper data being set
                }                         //to cusomerNumber property.
                catch(Exception e)
                { throw new Exception("Invalid input" + e.Message); }
                
            }
        }
        /*******************************
         Sets/Gets mailingList property.
         *******************************/
        public bool MailingList
        {
            get { return mailingList; }
            set { mailingList = value; }
        }
    }
}
