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
        protected int numOfFalafelDishes;
        protected int falafelBalls; // ONLY 0,3,6,9
        protected bool hasTahini; // if there's tahini aside
    }
}
