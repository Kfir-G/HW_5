using System;
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
            float totalBill = 0, tipToPay = 0, tip;
            int idxShak = 0, idxFal = 0, i;
            bool check = true;

            while(check)
            {
                order = Menu();
                Console.WriteLine("--------------------------------------------------\n");
                switch (order)
                {
                    //Shakshuka
                    case 'S': case 's':
                        if(idxShak==50)
                        {
                            Console.WriteLine("You reach to the limit of shakshuka orders");
                            break;
                        }
                        Console.WriteLine("Enter your name");
                        shakshukaOrderTemp = new ShakshukaOrder (Console.ReadLine(), 22.5f, 1, false);
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
                    
                    //Falafel
                    case 'F': case 'f':
                        if (idxFal == 50)
                        {
                            Console.WriteLine("You reach to the limit of falafel orders");
                            break;
                        }
                        Console.WriteLine("Enter your name");
                        falafelOrderTemp = new FalafelOrder(Console.ReadLine(), 19.95f, 3, false);
                        falafelOrdersArr[idxFal] = falafelOrderTemp;
                        Console.WriteLine("Enter to add 0/3/6/9 eggs of falafel");
                        falafelOrdersArr[idxFal].AddFalafelBalls(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Do you want to add tahini? (Y- for Yes\tN-for NO)");
                        tempVal = char.Parse(Console.ReadLine());
                        if (tempVal == 'Y' || tempVal == 'y')
                            falafelOrdersArr[idxFal].SetHasTahini(true);
                        idxFal++;
                            break;
                    
                    //Exit
                    case 'Q': case 'q':
                        if(idxFal==0 && idxShak==0)
                        {
                            Console.WriteLine("You did not oreder");
                            check = false; //exit menu
                            break;
                        }
                        if (idxFal > 0)
                        {
                            for (i = 0; i < idxFal; i++)
                            {
                                totalBill += falafelOrdersArr[i].GetPrice();
                                Console.Write("{0}.", i+1);
                                Console.WriteLine("{0}" ,falafelOrdersArr[i].Describe());
                            }
                        }
                        if (idxShak > 0)
                        {
                            for (i = 0; i < idxShak; i++)
                            {
                                totalBill += shakshukaOrdersArr[i].GetPrice();
                                Console.Write("{0}.", i+1+idxFal);
                                Console.WriteLine("{0}" ,shakshukaOrdersArr[i].Describe());
                            }
                        }
                        Console.WriteLine("Total number of dishes:{0}", idxShak+idxShak); 
                        Console.WriteLine("You need to pay:{0}", totalBill);
                        Console.WriteLine("Type precent of tip");
                        tip = float.Parse(Console.ReadLine());
                        for (i = 0; i < idxFal; i++)
                            tipToPay += falafelOrdersArr[i].CalculateTip(tip);
                        for (i = 0; i < idxShak; i++)
                            tipToPay += shakshukaOrdersArr[i].CalculateTip(tip);
                        Console.WriteLine("You need to pay tip:{0} NIS", tipToPay);
                        check = false; //exit menu
                        break;

                    default:
                        Console.WriteLine("Incorrect Input");
                        break;
                }
            }
            Console.WriteLine("Bye Bye...");
        }
        public static char Menu()
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Enter a letter:");
            Console.WriteLine("Put a - S\tfor oredring a Shakshuka");
            Console.WriteLine("Put a - F\tfor ordering a Falafel");
            Console.WriteLine("Put a - Q\tfor END order and start eating");
            return char.Parse(Console.ReadLine());
        }
    }
}
