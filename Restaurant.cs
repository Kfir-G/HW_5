﻿using System;
using System.Threading;

namespace HW_5
{
    class Restaurant
    {
        static void Main(string[] args)
        {
            int sizeArr = 50;       //size of arrays
            FalafelOrder [] falafelOrdersArr = new FalafelOrder[sizeArr];
            ShakshukaOrder[] shakshukaOrdersArr = new ShakshukaOrder[sizeArr];
            ShakshukaOrder shakshukaOrderTemp;
            FalafelOrder falafelOrderTemp;
            char order, tempVal;
            float totalBill = 0, tipToPay = 0;
            int idxShak = 0, idxFal = 0, i, tip;
            bool check = true;

            order = Menu();
            while(check)
            {
                switch (order)
                {
                    case 'S': case 's':
                        Console.WriteLine("Enter your name");
                        shakshukaOrderTemp = new ShakshukaOrder (Console.ReadLine(), (float)22.5, 1, false);
                        shakshukaOrdersArr[idxShak] = shakshukaOrderTemp;
                        Console.WriteLine("Do you want to add an egg? (Y- for Yes\tN-for NO)");
                        tempVal = char.Parse(Console.ReadLine());
                        if (tempVal == 'Y' || tempVal == 'y')
                            shakshukaOrdersArr[idxShak].AddEgg();
                        Console.WriteLine("Do you want your Shankshuka to be a spicy? (Y- for Yes\tN-for NO)");
                        tempVal = char.Parse(Console.ReadLine());
                        if (tempVal == 'Y' || tempVal == 'y')
                            shakshukaOrdersArr[idxShak].SetIsSpicy(true);
                        idxShak++;
                        break;

                    case 'F': case 'f':
                        Console.WriteLine("Enter your name");
                        falafelOrderTemp = new FalafelOrder(Console.ReadLine(), (float)19.95, 3, false);
                        falafelOrdersArr[idxFal] = falafelOrderTemp;
                        Console.WriteLine("Enter to add 0/3/6/9 eggs of falafel");
                        falafelOrdersArr[idxFal].AddFalafelBalls(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Do you want to add tahini? (Y- for Yes\tN-for NO)");
                        tempVal = char.Parse(Console.ReadLine());
                        if (tempVal == 'Y' || tempVal == 'y')
                            falafelOrdersArr[idxFal].SetHasTahini(true);
                        idxFal++;
                            break;

                    case 'Q': case 'q':
                        for (i = 0; i <= idxFal; i++)
                        {
                            totalBill += falafelOrdersArr[i].GetPrice();
                            Console.Write("{0}", i);
                            falafelOrdersArr[i].Describe();
                        }
                        for(i =0; i<=idxShak; i++)
                        {
                            totalBill += shakshukaOrdersArr[i].GetPrice();
                            Console.Write("{0}", i);
                            shakshukaOrdersArr[i].Describe();
                        }
                        Console.WriteLine("Total number of dishes:{0}", shakshukaOrdersArr[0].GetNumOfDishes()); //Genrally
                        Console.WriteLine("You need to pay:{0}", totalBill);
                        Console.WriteLine("Type precent of tip");
                        tip = int.Parse(Console.ReadLine());
                        for (i = 0; i <= idxFal; i++)
                            tipToPay += falafelOrdersArr[i].CalculateTip(tip);
                        for (i = 0; i <= idxShak; i++)
                            tipToPay += shakshukaOrdersArr[i].CalculateTip(tip);
                        Console.WriteLine("You need to pay tip:{0} NIS", tipToPay);
                        check = false; //exit menu
                        break;

                    default:
                        Console.WriteLine("Incorrect Input");
                        break;
                }
                order = Menu();
            }
        }
        public static char Menu()
        {
            Console.WriteLine("Enter a letter:");
            Console.WriteLine("Put a - S\tfor oredring a Shakshuka");
            Console.WriteLine("Put a - F\tfor ordering a Falafel");
            Console.WriteLine("Put a - Q\tfor END order and start eating");
            return char.Parse(Console.ReadLine());
        }
    }
}
