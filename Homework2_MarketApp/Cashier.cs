using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_MarketApp
{
    public class Cashier
    {
        private List<Shopping> shoppingList = new List<Shopping>();

        public void Shop()
        {
            Console.Write("Shopping Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Shopping shopping = new Shopping(amount);
            shoppingList.Add(shopping);

            ExcelDatabase.AddCashierData(amount);
            Console.WriteLine("Shopping recorded successfully.");
        }

        public static void ViewCashierData()
        {
            ExcelDatabase.ViewCashierData();
        }
    }
}
