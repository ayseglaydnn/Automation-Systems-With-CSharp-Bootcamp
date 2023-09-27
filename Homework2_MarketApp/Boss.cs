using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_MarketApp
{
    public static class Boss
    {
        private static string bossPassword = "1234";
        public static void ViewData()
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if(password == bossPassword)
            {
                Console.WriteLine("Which data would you like to view?");
                Console.WriteLine("1. Cashier");
                Console.WriteLine("2. Market");
                Console.Write("Choose an Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Cashier.ViewCashierData();
                        break;
                    case "2":
                        Market.ViewMarketData();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid password.");
            }

        }
    }
}
