using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3_ToDoFormApp
{
    public class TodoManager
    {
        private const string ExcelFilePath = "todos.xlsx"; 

        // Check if the Excel file exists, if not, create a new one
        private static void EnsureExcelFileExists()
        {
            if (!File.Exists(ExcelFilePath))
            {
                var workbook = new XLWorkbook();
                workbook.AddWorksheet("Todos");
                workbook.SaveAs(ExcelFilePath);
            }
        }

        // Add a new todo to the Excel file
        public static void AddTodoToExcel(string todoName, bool isFinished)
        {
            EnsureExcelFileExists();

            using (var workbook = new XLWorkbook(ExcelFilePath))
            {
                var worksheet = workbook.Worksheets.First();

                var lastUsedRow = worksheet.LastRowUsed();

                int lastRow = lastUsedRow != null ? lastUsedRow.RowNumber() : 0;

                worksheet.Cell(lastRow + 1, 1).Value = todoName;
                worksheet.Cell(lastRow + 1, 2).Value = isFinished ? "Finished" : "Unfinished";

                workbook.SaveAs(ExcelFilePath);
            }
        }

        public static Dictionary<string, bool> LoadTodosFromExcel()
        {
            EnsureExcelFileExists();

            Dictionary<string, bool> todos = new Dictionary<string, bool>();

            using (var workbook = new XLWorkbook(ExcelFilePath))
            {
                var worksheet = workbook.Worksheets.First();

                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    string todoName = row.Cell(1).Value.ToString();
                    bool isFinished = row.Cell(2).Value.ToString().Equals("Finished", StringComparison.OrdinalIgnoreCase);

                    // Check if the todoName already exists in the dictionary before adding
                    if (!todos.ContainsKey(todoName))
                    {
                        todos.Add(todoName, isFinished);
                    }
                }
            }

            return todos;
        }

        public static void UpdateTodoStatusInExcel(string todoName, bool isFinished, DateTime? finishingTime)
        {
            EnsureExcelFileExists();

            using (var workbook = new XLWorkbook(ExcelFilePath))
            {
                var worksheet = workbook.Worksheets.First();

                var cell = worksheet
                    .RowsUsed()
                    .Where(row => row.Cell(1).Value.ToString() == todoName)
                    .Select(row => row.Cell(2))
                    .FirstOrDefault();

                if (cell != null)
                {
                    cell.Value = isFinished ? "Finished" : "Unfinished";

                    if (isFinished && finishingTime.HasValue)
                    {
                        worksheet.Cell(cell.Address.RowNumber, 3).Value = finishingTime.Value;
                    }
                    else
                    {
                        worksheet.Cell(cell.Address.RowNumber, 3).Value = string.Empty; // Clear finishing time
                    }
                }

                workbook.SaveAs(ExcelFilePath);
            }
        }
    }
}
