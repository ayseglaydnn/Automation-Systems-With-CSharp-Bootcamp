using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_MarketApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Cashier cashier = new Cashier();
            Market market = new Market();

            while (true)
            {
                Console.WriteLine("1. Cashier");
                Console.WriteLine("2. Market");
                Console.WriteLine("3. View Data for the Boss");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        cashier.Shop();
                        break;
                    case "2":
                        market.BuyProduct();
                        break;
                    case "3":
                        Boss.ViewData();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}
