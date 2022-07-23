using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_SaiAnudeep
{
    public class Program
    {
        enum Products
        {
            Cola = 1,
            Chips = 2,
            Candy = 3
        }
        
        public static void Main(string[] args)
        {
            
            DisplayProducts();
            
        }

        public static void DisplayProducts()
        {
            bool loopBreak = false;
            double colaPrice = 1;
            double chipsPrice = 0.5;
            double candyPrice = 0.65;
            double selectedItemPrice = 0;
            try
            {
                while (!loopBreak)
                {
                    Console.WriteLine("Welcome! Choose any one of the below product");
                    int iterator = 1;
                    foreach (Products product in Enum.GetValues(typeof(Products)))
                    {
                        Console.WriteLine("Enter " + iterator + " for " + product);
                        iterator++;
                    }
                    short val = Convert.ToInt16(Console.ReadLine());
                    loopBreak = true;
                    switch (val)
                    {
                        case (short)Products.Cola:
                            Console.WriteLine("The Price of Cola is " + colaPrice + "$");
                            selectedItemPrice = colaPrice;
                            break;
                        case (short)Products.Chips:
                            Console.WriteLine("The Price of Chips is " + chipsPrice + "$");
                            selectedItemPrice = chipsPrice;
                            break;
                        case (short)Products.Candy:
                            Console.WriteLine("The Price of Candy is " + candyPrice + "$");
                            selectedItemPrice = candyPrice;
                            break;
                        default:
                            loopBreak = false;
                            //DisplayProducts();
                            break;
                    }
                    if (loopBreak) // If Entered product value is correct, we process furthur steps
                    {
                        Console.WriteLine("We accept nickels, dimes and quarters.");
                        loopBreak = ProcessItem(val, selectedItemPrice, 0);
                    }
                        
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Enter correct value.");
                Console.WriteLine();
                DisplayProducts();
            }
        }

        public static bool ProcessItem(short selectedItem, double selectedItemPrice,double totalAmountInserted)
        {            
            bool success = false;
            bool isLoopBreak = false;          

            
            while (!isLoopBreak)
            {
                Console.WriteLine("Press N for Nickel, D for Dime & Q for Quarter.");
                string coin = Convert.ToString(Console.ReadLine()).ToUpper();
                switch (coin)
                {
                    case "N":
                        Console.WriteLine("Enter the no of coins you wish to enter");
                        break;
                    case "D":
                        Console.WriteLine("Enter the no of coins you wish to enter");
                        break;
                    case "Q":
                        Console.WriteLine("Enter the no of coins you wish to enter");
                        break;
                    default:
                        Console.WriteLine("Enter Correct value of coin you wish to insert");
                        ProcessItem(selectedItem,selectedItemPrice,totalAmountInserted);
                        success = false;
                        return success;
                }
                
                int noOfCoins=Convert.ToInt32(Console.ReadLine());
                
                if (coin == "N")
                {
                    totalAmountInserted += noOfCoins * 0.05;                                     
                    
                }
                if (coin == "D")
                {
                    totalAmountInserted += noOfCoins * 0.1;             

                }
                else if (coin == "Q")
                {
                    totalAmountInserted += noOfCoins * 0.25;                    
                }
                Console.WriteLine("Total Amount inserted - " + totalAmountInserted);
                if (totalAmountInserted >= selectedItemPrice)
                {
                    Console.WriteLine("Thank you for choosing our product " + Enum.GetName(typeof(Products), selectedItem));
                    if (totalAmountInserted > selectedItemPrice)
                    {
                        Console.WriteLine("Please accept the return change of " + (totalAmountInserted - selectedItemPrice) + "$");
                        success = true;
                        Console.WriteLine();
                        Console.WriteLine("If you wish to Exit press Y else press any other key to display Menu.");
                        string isExit = Convert.ToString(Console.ReadLine()).ToUpper();
                        if (isExit == "Y")
                            Environment.Exit(0);
                        else
                            DisplayProducts();

                    }
                    isLoopBreak = true;
                }
                else
                {
                    Console.WriteLine("Insert more coins as your Inserted Coins are less than the select product price " + selectedItemPrice);                    
                }

            }
            return success;
        }
    }
}
