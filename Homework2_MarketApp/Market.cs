using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_MarketApp
{
    public class Market
    {
        private List<Product> productList = new List<Product>();

        public Market()
        {
            productList.Add(new Product("Water", 10.0));
            productList.Add(new Product("Chocolate", 15.0));
            productList.Add(new Product("Coffee", 8.0));
            productList.Add(new Product("Cips", 12.0));
        }

        public void BuyProduct()
        {
            Console.WriteLine("Products:");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i}. {productList[i].Name} - {productList[i].Price} TL");
            }

            Console.Write("Enter the product index: ");
            int productIndex = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the quantity: ");
            double quantity = Convert.ToDouble(Console.ReadLine());

            double totalAmount = productList[productIndex].Price * quantity;
            ExcelDatabase.AddMarketData(productList[productIndex].Name, quantity, totalAmount);

            Console.WriteLine("Purchase recorded successfully.");
        }

        public static void ViewMarketData()
        {
            ExcelDatabase.ViewMarketData();
        }

    }

}
