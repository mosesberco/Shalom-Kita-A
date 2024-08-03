using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace final_project
{
    public class Database : IDisposable
    {
        private string pathToExcel = @"..\..\Users.xlsx";

        public Database()
        {
            Console.WriteLine($"Excel file path: {pathToExcel}");
            if (File.Exists(pathToExcel))
            {
                Console.WriteLine("Excel file exists.");
            }
            else
            {
                Console.WriteLine("File does not exist.");
                CreateExcelFile();
            }
        }

        private void OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange)
        {
            xlApp = new Excel.Application();
            Console.WriteLine(Path.GetFullPath(pathToExcel));
            xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(pathToExcel));
            xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets["Users"];
            xlRange = xlWorksheet.UsedRange;
        }

        private void CreateExcelFile()
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];

                xlWorksheet.Name = "Users";
                xlWorksheet.Cells[1, 1] = "Username";
                xlWorksheet.Cells[1, 2] = "Password";
                xlWorksheet.Cells[1, 3] = "ID";
                xlWorksheet.Cells[1, 4] = "Email";
                xlWorksheet.Cells[1, 5] = "Gender";
                xlWorksheet.Cells[1, 6] = "Balance";

                xlWorkbook.SaveAs(Path.GetFullPath(pathToExcel));
                Console.WriteLine("Excel file created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Excel file: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, null);
            }
        }

        public int ValidateUser(string username, string password)
        {
            int isValidIndex = -1;

            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 1].Value2?.ToString() == username &&
                        xlRange.Cells[i, 2].Value2?.ToString() == password)
                    {
                        isValidIndex = i;
                        break;
                    }
                }
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }

            return isValidIndex;
        }

        public bool RegisterUser(string username, string password, string id, string email, string gender)
        {
            bool isRegistered = false;

            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                int row = xlRange.Rows.Count + 1;
                xlWorksheet.Cells[row, 1] = username;
                xlWorksheet.Cells[row, 2] = password;
                xlWorksheet.Cells[row, 3] = id;
                xlWorksheet.Cells[row, 4] = email;
                xlWorksheet.Cells[row, 5] = gender;
                xlWorksheet.Cells[row, 6] = 0;

                xlWorkbook.Save();
                isRegistered = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }

            return isRegistered;
        }

        public void SetBalance(int id, int wallet)
        {
            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 3].Value2.ToString() == id.ToString())
                    {
                        xlRange.Cells[i, 6].Value = wallet;
                        xlWorkbook.Save();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting balance: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
        }

        public Excel.Workbook GetXlWorkbook()
        {
            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);
            CleanUp(xlApp, null, xlWorksheet, xlRange);
            return xlWorkbook;
        }

        public int GetBalance(int id)
        {
            int balance = -1;

            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 3].Value2.ToString() == id.ToString())
                    {
                        balance = (int)(xlRange.Cells[i, 6].Value);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting balance: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }

            return balance;
        }
        public void SetUsername(int id, string newUsername)
        {
            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 3].Value2.ToString() == id.ToString())
                    {
                        xlRange.Cells[i, 1].Value = newUsername;
                        xlWorkbook.Save();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting username: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
        }

        public void SetPassword(int id, string newPassword)
        {
            OpenExcelFile(out Excel.Application xlApp, out Excel.Workbook xlWorkbook, out Excel._Worksheet xlWorksheet, out Excel.Range xlRange);

            try
            {
                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 3].Value2.ToString() == id.ToString())
                    {
                        xlRange.Cells[i, 2].Value = newPassword;
                        xlWorkbook.Save();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting password: {ex.Message}");
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
        }


        private void CleanUp(Excel.Application xlApp, Excel.Workbook xlWorkbook, Excel._Worksheet xlWorksheet, Excel.Range xlRange)
        {
            if (xlRange != null) Marshal.ReleaseComObject(xlRange);
            if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
            if (xlWorkbook != null)
            {
                xlWorkbook.Close(false);
                Marshal.ReleaseComObject(xlWorkbook);
            }
            if (xlApp != null)
            {
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void Dispose()
        {
            // No action needed here, as each method handles its own cleanup
        }

        public User LoadUserData(int index)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                OpenExcelFile(out xlApp, out xlWorkbook, out xlWorksheet, out xlRange);

                if (index < 2 || index > xlRange.Rows.Count)
                {
                    throw new ArgumentException("Invalid index");
                }

                User user = new User(
                 username: xlRange.Cells[index, 1].Value2?.ToString(),
                 password: xlRange.Cells[index, 2].Value2?.ToString(),
                 id: xlRange.Cells[index, 3].Value2?.ToString(),
                 email: xlRange.Cells[index, 4].Value2?.ToString(),
                 gender: xlRange.Cells[index, 5].Value2?.ToString(),
                 balance: Convert.ToInt32(xlRange.Cells[index, 6].Value2)
             );;

                if (string.IsNullOrEmpty(user.ID))
                {
                    throw new InvalidOperationException("User data not found");
                }

                return user;
            }
            finally
            {
                CleanUp(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
        }
    }
}
