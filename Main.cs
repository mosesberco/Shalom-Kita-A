using ClosedXML.Excel;
using System;
using System.IO;
using System.Windows.Forms;

namespace final_project
{
    static class main
    {
        [STAThread]
        public static void Main() {
            //init the data
            WriteItemsToTextFile(@"../../storeitems.xlsx", @"../../ItemsData.txt");
            WriteTextFileToExcel(@"../../ItemsData.txt", @"../../storeitems.xlsx");
            WriteUsersExcelToTextFile(@"../../Users.xlsx", @"../../UsersData.txt");
            CreateUsersExcelFromTextFile(@"../../UsersData.txt", @"../../Users.xlsx");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var appLogin = new Login();
            Application.Run(appLogin);         
        }
        private static void WriteItemsToTextFile(string excelFilePath, string textFilePath)
        {
            if (!File.Exists(excelFilePath))
            {
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook(excelFilePath))
                {
                    var worksheet = workbook.Worksheet("items");
                    var rows = worksheet.RangeUsed().RowsUsed();

                    using (StreamWriter writer = new StreamWriter(textFilePath))
                    {
                        foreach (var row in rows)
                        {
                            if (row.RowNumber() == 1) continue; // Skip header row

                            var name = row.Cell(1).GetValue<string>();
                            var price = row.Cell(2).GetValue<int>();
                            var imagePath = row.Cell(3).GetValue<string>();

                            writer.WriteLine($"Name: {name}");
                            writer.WriteLine($"Price: {price}");
                            writer.WriteLine($"Image Path: {imagePath}");
                            writer.WriteLine(); // Add an empty line between items
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }
        private static void WriteTextFileToExcel(string textFilePath, string excelFilePath)
        {
            if (!File.Exists(textFilePath))
            {
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("items");

                    // Write headers
                    worksheet.Cell(1, 1).Value = "Name";
                    worksheet.Cell(1, 2).Value = "Price";
                    worksheet.Cell(1, 3).Value = "Image Path";

                    using (StreamReader reader = new StreamReader(textFilePath))
                    {
                        string line;
                        int currentRow = 2; // Start writing data from the second row

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("Name: "))
                            {
                                worksheet.Cell(currentRow, 1).Value = line.Substring("Name: ".Length);
                            }
                            else if (line.StartsWith("Price: "))
                            {
                                worksheet.Cell(currentRow, 2).Value = int.Parse(line.Substring("Price: ".Length));
                            }
                            else if (line.StartsWith("Image Path: "))
                            {
                                worksheet.Cell(currentRow, 3).Value = line.Substring("Image Path: ".Length);
                                currentRow++;
                            }
                        }
                    }

                    workbook.SaveAs(excelFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to Excel file: {ex.Message}\n{ex.StackTrace}");
            }
        }
        private static void WriteUsersExcelToTextFile(string excelFilePath, string textFilePath)
        {
            if (!File.Exists(excelFilePath))
            {
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook(excelFilePath))
                {
                    var worksheet = workbook.Worksheet("Users");
                    var rows = worksheet.RangeUsed().RowsUsed();

                    using (StreamWriter writer = new StreamWriter(textFilePath))
                    {
                        foreach (var row in rows)
                        {
                            if (row.RowNumber() == 1) continue; // Skip header row

                            var username = row.Cell(1).GetValue<string>();
                            var password = row.Cell(2).GetValue<string>();
                            var id = row.Cell(3).GetValue<string>();
                            var email = row.Cell(4).GetValue<string>();
                            var gender = row.Cell(5).GetValue<string>();
                            var balance = row.Cell(6).GetValue<int>();

                            writer.WriteLine($"Username: {username}");
                            writer.WriteLine($"Password: {password}");
                            writer.WriteLine($"ID: {id}");
                            writer.WriteLine($"Email: {email}");
                            writer.WriteLine($"Gender: {gender}");
                            writer.WriteLine($"Balance: {balance}");
                            writer.WriteLine(); // Add an empty line between records
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to text file: {ex.Message}");
            }
        }
        private static void CreateUsersExcelFromTextFile(string textFilePath, string excelFilePath)
        {
            if (!File.Exists(textFilePath))
            {
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Users");

                    // Write headers
                    worksheet.Cell(1, 1).Value = "Username";
                    worksheet.Cell(1, 2).Value = "Password";
                    worksheet.Cell(1, 3).Value = "ID";
                    worksheet.Cell(1, 4).Value = "Email";
                    worksheet.Cell(1, 5).Value = "Gender";
                    worksheet.Cell(1, 6).Value = "Balance";

                    using (StreamReader reader = new StreamReader(textFilePath))
                    {
                        string line;
                        int currentRow = 2; // Start writing data from the second row

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("Username: "))
                            {
                                worksheet.Cell(currentRow, 1).Value = line.Substring("Username: ".Length);
                            }
                            else if (line.StartsWith("Password: "))
                            {
                                worksheet.Cell(currentRow, 2).Value = line.Substring("Password: ".Length);
                            }
                            else if (line.StartsWith("ID: "))
                            {
                                worksheet.Cell(currentRow, 3).Value = line.Substring("ID: ".Length);
                            }
                            else if (line.StartsWith("Email: "))
                            {
                                worksheet.Cell(currentRow, 4).Value = line.Substring("Email: ".Length);
                            }
                            else if (line.StartsWith("Gender: "))
                            {
                                worksheet.Cell(currentRow, 5).Value = line.Substring("Gender: ".Length);
                            }
                            else if (line.StartsWith("Balance: "))
                            {
                                worksheet.Cell(currentRow, 6).Value = int.Parse(line.Substring("Balance: ".Length));
                                currentRow++;
                            }
                        }
                    }

                    workbook.SaveAs(excelFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Excel file: {ex.Message}");
            }
        }


    }
}
