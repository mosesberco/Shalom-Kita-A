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
            //string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string[] files = Directory.GetFiles(exeDirectory);

            // Print each file name to the console
            //Console.WriteLine("Files in directory: " + Path.GetFullPath(exeDirectory));
            //foreach (string file in files)
            //{
            //    Console.WriteLine(Path.GetFileName(file));
            //}
            //WriteItemsToTextFile(@"../storeitems.xlsx", @"../ItemsData.txt");
            //WriteTextFileToExcel(@"../ItemsData.txt", @"../storeitems.xlsx");
            //WriteUsersExcelToTextFile(@"../Users.xlsx", @"../UsersData.txt");
            //CreateUsersExcelFromTextFile(@"../UsersData.txt", @"../Users.xlsx");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var appLogin = new Login();
            Application.Run(appLogin);         
        }
        private static void WriteItemsToTextFile(string excelFilePath, string textFilePath)
        {
            if (!File.Exists(excelFilePath))
            {
                Console.WriteLine("excel file didnt exist");
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook(excelFilePath))
                {
                    Console.WriteLine("found workbook, before finding items sheet");
                    IXLWorksheet worksheet = null;
                    try
                    {
                        worksheet = workbook.Worksheet("items");
                    }catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;

                    }
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
                Console.WriteLine("write items to text ");
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
                Console.WriteLine(Path.GetFullPath(textFilePath));
                Console.WriteLine("didnt find the items text file");
                return;
            }
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    Console.WriteLine("adding items sheet to the storeitems.xlsx");
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

                            Console.WriteLine(worksheet.Cell(currentRow, 1).Value);
                            Console.WriteLine(worksheet.Cell(currentRow, 2).Value);
                            Console.WriteLine(worksheet.Cell(currentRow, 3).Value);
                        }
                    }

                    workbook.SaveAs(excelFilePath);
                    Console.WriteLine("write items to excel ");
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
                Console.WriteLine("--------------------------------");
                Console.WriteLine(Path.GetFullPath(excelFilePath));
                Console.WriteLine("--------------------------------");
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
                Console.WriteLine("write users to text ");

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
                                Console.WriteLine(worksheet.Cell(currentRow, 1).Value);
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
                    Console.WriteLine("write users to excel ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Excel file: {ex.Message}");
            }
        }
    }
}
