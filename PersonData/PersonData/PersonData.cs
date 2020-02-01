/****************************************
Date Completed: 6/29/2014
Purpose: To hold person related strings.
*****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataProg
{
    abstract class PersonData
    {
        private string lastName;
        private string firstName;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private string phoneNumber;

        /*************************
           All Setter Methods
         *************************/

        public bool setFirstName(string firstName)
        {
            if(isAlphaString(firstName))
            {
                this.firstName = firstName;
                return true;
            }
            return false;
        }

        public bool setLastName(string lastName)
        {
            if(isAlphaString(lastName))
            {
                this.lastName = lastName;
                return true;
            }
            return false;
        }

        public void setAddress(string address)
        { this.address = address; }

        public bool setCity(string city)
        {
            if(isAlphaString(city))
            {
                this.city = city;
                return true;
            }
            return false;
        }

        public bool setState(string state)
        {
            if(isAlphaString(state))
            {
                this.state = state;
                return true;
            }
            return false;
        }

        public bool setZip(string zipCode)
        {
            if(isNumberString(zipCode))
            {
                this.zipCode = zipCode;
                return true;
            }
            return false;
        }

        public bool setPhoneNumber(string phoneNumber)
        {
            phoneNumber = isValidPhoneNumber(phoneNumber);

            if(phoneNumber != null)
            {
                this.phoneNumber = phoneNumber;
                return true;
            }
            return false;
        }

        /**********************
          All Getter Methods
         **********************/

        public string getFirstName() { return firstName; }

        public string getLastName() { return lastName; }

        public string getAddress() { return address; }

        public string getCity() { return city;  }

        public string getState() { return state; }

        public string getZipCode() { return zipCode; }

        public string getPhoneNumber() { return phoneNumber; }

        /*******************************************
           Methods test for Invalid string data
         *******************************************/
        protected bool isAlphaString(string checkIt)
        {
            char A;
            bool test;

            foreach (var letter in checkIt)
            {
                A = letter;
                test = char.IsLetter(A);

                if (test == false)
                    return false;
            }
            return true;
        }

        protected bool isNumberString(string checkIt)
        {
            char A;
            bool test;

            foreach(var letter in checkIt)
            {
                A = letter;
                test = char.IsNumber(A);

                if (test == false)
                    return false;
            }
            return true;
        }

        protected string isValidPhoneNumber(string phNumber)//Error checks phoneNumber string.
        {
            string temp, test = null;//temp holds passed string test holds striing without dashes.
            int count = 0;//Counts the number of characters in phone number string.

            temp = phNumber;

            foreach (var letter in temp)//Checks every char in temp string appends
            {                          //all characters except '-' char to test string.
                if (letter != '-')
                    test += letter;
                count++;
            }

            if (isNumberString(test) == true && count == 12)//Tests the test string returns 
                return phNumber;                           //a boolean value.

            return null;//If string still invalid returns null.
        }
    }
}
