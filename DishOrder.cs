﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5
{
    class DishOrder
    {
        //----data fields----
        protected string name;
        protected float price;
        public static int numOfDishes; //total number of dishes

        //-----properties-----
            //gets:
        public int GetNumOfDishes()
        {
            return numOfDishes;
        }
        public string GetName()
        {
            return name;
        }
        public float GetPrice()
        {
            return price; 
        }
            //sets:
        public void SetName(string name)
        {
            if (name == String.Empty)
                throw new ArgumentNullException("You did not put a name");
            foreach(char c in name)
            {
                if (c >= '0' && c <= '9')
                    throw new ArgumentException("You put a digit in the name");
            }
            this.name = name;
        }
        public void SetPrice(float price)
        {
            if (price < 10)
                throw new ArgumentException("You put the price less then 10");
            else
                this.price = price;
        }

        //-----methods-----
            //constructors:
        public DishOrder()
        {
            numOfDishes++;
            name = "Someone is Hungry"; //default
            price = 10;                 //default
        }
        public DishOrder(string name, float price)
        {
            SetName(name);
            SetPrice(price);
            AddNumOfDishes();
        }
            //
        public void AddNumOfDishes()
        {
            numOfDishes++;
        }
        public float CalculateTip(float percent)
        {
            return (price *  (percent / 100));
        }
        public string Describe()
        {
            return "The name of the orderer:"+name + "\tcost of the dish: " + price;
        }
    }
}
