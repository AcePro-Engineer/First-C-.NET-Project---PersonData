/*****************************************************
 Date Created: 6/29/2014
 Purpose: To extend CustomerData class functionality.
 *****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataProg
{
    class PreferredCustomer : CustomerData
    {
        private double purchaseAmount;
        private double discountLevel;

        /******************
          All Constructors
         ******************/
        public PreferredCustomer() { } // Default Constructor.

        public PreferredCustomer(double pAmount) { setDiscount(pAmount);  }

        public PreferredCustomer(double purchaseAmount,double discountLevel)
        {
            if(purchaseAmount > 0 && discountLevel > 0)
            {
                this.purchaseAmount = purchaseAmount;
                this.discountLevel = discountLevel;
            }
        }

        /********************
         All Setters Methods
         ********************/
        public bool setPurchaseAmount(double purchaseAmount)
        {
            if(purchaseAmount > 0)
            {
                this.purchaseAmount = purchaseAmount;
                return true;
            }
            return false;
        }

        public bool setDiscountLevel(double discountLevel)
        {
            if(discountLevel > 0)
            {
                this.discountLevel = discountLevel;
                return true;
            }
            return false;
        }

        /**********************************
         Method sets PurchaseAmount and
         discountLevel to appropiate amount
         based on passed in amount.
         **********************************/
        public bool setDiscount(double pAmount) 
        {
            if (pAmount > 0)
            {
                if (pAmount >= 1000.00 && pAmount <= 1499.99)
                {
                    setPurchaseAmount(pAmount);
                    discountLevel = 6.0;
                    return true;
                }
                else if (pAmount >= 1500.00 && pAmount <= 1999.99)
                {
                    setPurchaseAmount(pAmount);
                    discountLevel = 7.0;
                    return true;
                }
                else if (pAmount >= 2000.000)
                {
                    setPurchaseAmount(pAmount);
                    discountLevel = 10.0;
                    return true;
                }
            }
            else
                setPurchaseAmount(pAmount);
            return false;
        }

        /********************
         All Getter Methods
         ********************/
        public double getPurchaseAmount() { return purchaseAmount; }

        public double getDiscountLevel() { return discountLevel; }
    }
}
