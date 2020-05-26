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
        //static numOfDishes from->DishOrder
        protected static int  numOfFalafelDishes;
        protected int falafelBalls; // ONLY 0,3,6,9
        protected bool hasTahini; // if there's tahini aside

        //----properties-----
            //gets:
        public new int GetNumOfDishes()
        {
            return base.GetNumOfDishes();
        }
        public int GetNumOfFalafelDishes()
        {
            return numOfFalafelDishes;
        }
            //sets:
        public new void SetName(string name)
        {
            base.SetName(name);
        }
        public new void SetPrice(float price)
        {
            base.SetPrice(price);
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
            SetPrice(0);
            
            SetFalafelBalls(0); //default
            SetHasTahini(false); //default
            numOfFalafelDishes++;

        }
        public FalafelOrder(string name, int price, int falafelBalls, bool hasTahini): base(name, price)
        {
            SetFalafelBalls(falafelBalls);
            SetHasTahini(hasTahini);
            AddNumOfDishes();
        }
            //
        public void AddFalafelBalls (int num)
        {
            if (falafelBalls != 0 || falafelBalls != 3 || falafelBalls != 6 || falafelBalls != 9)
                throw new ArgumentException("The falafel balls are NOT 0/3/6/9");
            else
            {
                falafelBalls += num;
                price += (2 * num);
            }
        }
        public override float CalculateTip (int percent)
        {
            return base.CalculateTip(percent);
        }
        public override string  Describe()
        {
            return base.Describe() + "falafel balls:" + falafelBalls + "Has Tahini:" + hasTahini;
        }
    }
}
