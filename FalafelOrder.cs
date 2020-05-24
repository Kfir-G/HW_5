using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5
{
    class FalafelOrder : DishOrder
    {
        //----data fields----
        //string name from->DishOrder
        //float price from->DishOrder
        // static numOfDishes from->DishOrder
        protected static int  numOfFalafelDishes;
        protected int falafelBalls; // ONLY 0,3,6,9
        protected bool hasTahini; // if there's tahini aside

        //----properties-----
            //gets:
        public new int GetNumOfDishes()
        {
            return numOfDishes;
        }
        public int GetNumOfFalafelDishes()
        {
            return numOfFalafelDishes;
        }
            //sets:
        public new void SetName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("You did not put a name");
            foreach (char c in name)
            {
                if (c >= '0' && c <= '9')
                    throw new ArgumentException("You put a digit in the name");
            }
            this.name = name;
        }
        public new void SetPrice(int price)
        {
            if (price < 10)
                throw new ArgumentException("You put the price less then 10");
            else
                this.price = price;
        }
        public void SetFalafelBalls(int falafelBalls)
        {
            if (falafelBalls == 0 || falafelBalls == 3 || falafelBalls == 6 || falafelBalls == 9)
                this.falafelBalls = falafelBalls;
            else
                throw new ArgumentException("The falafel balls are NOT 0/3/6/9");
        }
        public void SetHasTahini(bool hasTahini)
        {
            this.hasTahini = hasTahini;
        }

        //-----methods-----
            //constructors:
        public FalafelOrder():base()
        {
            // ++numOfDish
            // name = "Someone is Hungry"
            SetFalafelBalls(0); //default
            SetHasTahini(false); //default
            numOfFalafelDishes++;

        }
        public FalafelOrder(string name, int price, int falafelBalls, bool hasTahini): base(string name, int price)
        {
            SetFalafelBalls(falafelBalls);
            SetHasTahini(hasTahini);
            AddNumOfDishes();
        }
    }
}
