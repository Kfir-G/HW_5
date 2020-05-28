using System;

namespace HW_5
{
    class Restaurant
    {
        static void Main(string[] args)
        {
            int sizeArr = 50;       //size of arrays
            FalafelOrder[] falafelOrdersArr = new FalafelOrder[sizeArr];
            ShakshukaOrder[] shakshukaOrdersArr = new ShakshukaOrder[sizeArr];
            ShakshukaOrder shakshukaOrderTemp = null;
            FalafelOrder falafelOrderTemp = null;
            char order, tempVal;
            float totalBill = 0, tipToPay = 0, tip;
            int idxShak = 0, idxFal = 0, i;
            bool check = true;

            while (check)
            {
                order = Menu();
                Console.WriteLine("--------------------------------------------------\n");
                switch (order)
                {
                    //Shakshuka
                    case 'S': case 's':
                        if (idxShak == 50)
                        {
                            Console.WriteLine("You reach to the limit of shakshuka orders");
                            break;
                        }
                        try
                        {
                            Console.WriteLine("Enter your name");
                            shakshukaOrderTemp = new ShakshukaOrder(Console.ReadLine(), 22.5f, 1, false);
                        }
                        catch(ArgumentNullException e) // user did not put a name
                        {
                            Console.WriteLine(e.Message);
                            shakshukaOrderTemp = new ShakshukaOrder(AddName(), 22.5f, 1, false);
                        }
                        catch (ArgumentException e1) // user puts digits in the name
                        {
                            Console.WriteLine(e1.Message);
                            shakshukaOrderTemp = new ShakshukaOrder( AddName(), 22.5f, 1, false);
                        }
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
                        try
                        {
                            Console.WriteLine("Enter your name");
                            falafelOrderTemp = new FalafelOrder(Console.ReadLine(), 19.95f, 3, false);
                        }
                        catch (ArgumentNullException e2) //not put a name
                        {
                            Console.WriteLine(e2.Message);
                            falafelOrderTemp = new FalafelOrder(AddName(), 19.95f, 3, false);
                        }
                        catch (ArgumentException e3) //put a number in the name 
                        {
                            Console.WriteLine(e3.Message);
                            falafelOrderTemp = new FalafelOrder(AddName(), 19.95f, 3, false);
                        }
                        falafelOrdersArr[idxFal] = falafelOrderTemp;
                        try
                        {
                            Console.WriteLine("Enter to add 0/3/6/9 eggs of falafel");
                            falafelOrdersArr[idxFal].AddFalafelBalls(int.Parse(Console.ReadLine()));
                        }
                        catch(ArgumentException e4) // NOT  0/3/6/9
                        {
                            Console.WriteLine(e4.Message);
                            falafelOrdersArr[idxFal].AddFalafelBalls(AddingFalafelsBalls());
                        }
                        Console.WriteLine("Do you want to add tahini? (Y- for Yes\tN-for NO)");
                        tempVal = char.Parse(Console.ReadLine());
                        if (tempVal == 'Y' || tempVal == 'y')
                            falafelOrdersArr[idxFal].SetHasTahini(true);
                        idxFal++;
                        break;

                    //Exit
                    case 'Q': case 'q':
                        if (idxFal == 0 && idxShak == 0)
                        {
                            Console.WriteLine("You did not oreder");
                            check = false; //exit menu
                            break;
                        }
                        for (i = 0; i < idxFal; i++)
                        {
                            totalBill += falafelOrdersArr[i].GetPrice();
                            Console.Write("{0}.", i + 1);
                            Console.WriteLine("{0}", falafelOrdersArr[i].Describe());
                        }
                        for (i = 0; i < idxShak; i++)
                        {
                            totalBill += shakshukaOrdersArr[i].GetPrice();
                            Console.Write("{0}.", i + 1 + idxFal);
                            Console.WriteLine("{0}", shakshukaOrdersArr[i].Describe());
                        }
                        Console.WriteLine("Total number of dishes:{0}", idxShak + idxShak);
                        Console.WriteLine("You need to pay:{0}", totalBill);
                        Console.WriteLine("Type precent of tip");
                        tip = float.Parse(Console.ReadLine());
                        for (i = 0; i < idxFal; i++)
                            tipToPay += falafelOrdersArr[i].CalculateTip(tip);
                        for (i = 0; i < idxShak; i++)
                            tipToPay += shakshukaOrdersArr[i].CalculateTip(tip);
                        Console.WriteLine("You need to pay tip:{0} NIS", tipToPay);
                        check = false; //----exit menu----
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
        public static string AddName()
        {
            string name = null;
            bool check = false;
            while(!check)
            {
                Console.WriteLine("Please put again the name");
                name = Console.ReadLine();
                if (name != String.Empty)
                {
                    check = true;
                    foreach (char c in name)
                    {
                        if (c >= '0' && c <= '9')
                            check = false;
                    }
                }
            }
            return name;
        }
        public static int AddingFalafelsBalls()
        {
            bool check = false;
            int num = -1;
            while (!check)
            {
                Console.WriteLine("Enter again falafel balls (ONLY!:0/3/6/9)");
                num = int.Parse(Console.ReadLine());
                if (num == 0 || num == 3 || num == 6 || num == 9)
                    check = true;
            }
            return num;
        }
    }
}
