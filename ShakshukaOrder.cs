using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5
{
    class ShakshukaOrder:DishOrder
    {
        //----data fields----
        //string name from->DishOrder
        //int price from->DishOrder
        //static int numOfDishes from->DishOrder
        public static int numOfShakshukaDishes;
        protected int eggs;
        protected bool isSpicy;

        //----properties-----
            //gets:
        public new int GetNumOfDishes()
        {
            return base.GetNumOfDishes();
        }
        public int GetNumOfShakshukaDishes()
        {
            return numOfShakshukaDishes;
        }
            //sets:
        public new void SetPrice (int price)
        {
            base.SetPrice(price);
        }
        public new void SetName (string name)
        {
            base.SetName(name);
        }
        public void SetEggs(int eggs)
        {
            this.eggs = eggs;
        }
        public void SetIsSpicy (bool isSpicy)
        {
            this.isSpicy = isSpicy;
        }

        //-----methods-----
            //constructors:
        public ShakshukaOrder() :base ()
        {
            //numOfDishes++;
            //name = "Someone is Hungry"; //default
            price = 0;                //default

            AddNumOfShakshukaDishes();
            eggs = 0;                  //default
            isSpicy= false;           //default

        }
        public ShakshukaOrder(string name, int price , int eggs, bool isSpicy):base(name,price)
        {
            SetEggs(eggs);
            SetIsSpicy(isSpicy);
        }
            //
        public void AddNumOfShakshukaDishes()
        {
            numOfShakshukaDishes++;
        }
        public void AddEgg()
        {
            price += 10;
            ++eggs; 
        }
        public override float CalculateTip(int percent)
        {
            return base.CalculateTip(percent);
        }
        public override string Describe()
        {
            return base.Describe() + "number of eggs:" + eggs + "is it spicy:" + isSpicy;
        }
    }
}
