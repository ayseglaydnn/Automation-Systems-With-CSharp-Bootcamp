using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_MarketApp
{           
    public static class ExcelDatabase
    {
        private static string filePath = "Database.xlsx";

        public static void AddCashierData(double amount)
        {
            if (!File.Exists(filePath))
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Cashier");
                    worksheet.Cell(1, 1).Value = "Date";
                    worksheet.Cell(1, 2).Value = "Amount";
                    workbook.SaveAs(filePath);
                }
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault(s => s.Name == "Cashier");
                if (worksheet == null)
                {
                    worksheet = workbook.Worksheets.Add("Cashier");
                    worksheet.Cell(1, 1).Value = "Date";
                    worksheet.Cell(1, 2).Value = "Amount";
                }

                int rowCount = worksheet.RowsUsed().Count();
                worksheet.Cell(rowCount + 1, 1).Value = DateTime.Now;
                worksheet.Cell(rowCount + 1, 2).Value = amount;

                workbook.SaveAs(filePath);
            }
        }

        public static void ViewCashierData()
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault(s => s.Name == "Cashier");
                if (worksheet != null)
                {
                    var rows = worksheet.RowsUsed().Skip(1);
                    foreach (var row in rows)
                    {
                        Console.WriteLine($"Date: {row.Cell(1).Value}, Amount: {row.Cell(2).Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Cashier data not found.");
                }
            }
        }

        public static void AddMarketData(string productName, double quantity, double totalAmount)
        {
            if (!File.Exists(filePath))
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Market");
                    worksheet.Cell(1, 1).Value = "Product Name";
                    worksheet.Cell(1, 2).Value = "Quantity";
                    worksheet.Cell(1, 3).Value = "Total Amount";
                    workbook.SaveAs(filePath);
                }
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault(s => s.Name == "Market");
                if (worksheet == null)
                {
                    worksheet = workbook.Worksheets.Add("Market");
                    worksheet.Cell(1, 1).Value = "Product Name";
                    worksheet.Cell(1, 2).Value = "Quantity";
                    worksheet.Cell(1, 3).Value = "Total Amount";
                }

                int rowCount = worksheet.RowsUsed().Count();
                worksheet.Cell(rowCount + 1, 1).Value = productName;
                worksheet.Cell(rowCount + 1, 2).Value = quantity;
                worksheet.Cell(rowCount + 1, 3).Value = totalAmount;

                workbook.SaveAs(filePath);
            }
        }

        public static void ViewMarketData()
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault(s => s.Name == "Market");
                if (worksheet != null)
                {
                    var rows = worksheet.RowsUsed().Skip(1);
                    foreach (var row in rows)
                    {
                        Console.WriteLine($"Product Name: {row.Cell(1).Value}, Quantity: {row.Cell(2).Value}, Total Amount: {row.Cell(3).Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Market data not found.");
                }
            }
        }
    }
}
