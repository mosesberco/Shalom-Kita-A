using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace final_project
{
    class DatabaseOperations
    {
        private string pathToExcel = @"..\..\Users.xlsx";


        public DatabaseOperations()
        {
            Console.WriteLine($"Excel file path: {pathToExcel}");
            if (File.Exists(pathToExcel))
            {
                Console.WriteLine("File exists");
            }
            else
            {
                Console.WriteLine("File does not exist");
                CreateExcelFile();
            }
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

                xlWorksheet.Cells[1, 1] = "Username";
                xlWorksheet.Cells[1, 2] = "Password";
                xlWorksheet.Cells[1, 3] = "ID";
                xlWorksheet.Cells[1, 4] = "Email";
                xlWorksheet.Cells[1, 5] = "Gender";

                xlWorkbook.SaveAs(pathToExcel);
                Console.WriteLine("Excel file created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Excel file: {ex.Message}");
            }
            finally
            {
                CleanUp(null, xlWorksheet, xlWorkbook, xlApp);
            }
        }

        public bool ValidateUser(string username, string password)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(pathToExcel);
                xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    if (xlRange.Cells[i, 1].Value2?.ToString() == username &&
                        xlRange.Cells[i, 2].Value2?.ToString() == password)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating user: {ex.Message}");
                return false;
            }
            finally
            {
                CleanUp(xlRange, xlWorksheet, xlWorkbook, xlApp);
            }
        }

        public bool RegisterUser(string username, string password, string id, string email, string gender)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(pathToExcel);
                xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                int row = xlRange.Rows.Count + 1;
                xlWorksheet.Cells[row, 1] = username;
                xlWorksheet.Cells[row, 2] = password;
                xlWorksheet.Cells[row, 3] = id;
                xlWorksheet.Cells[row, 4] = email;
                xlWorksheet.Cells[row, 5] = gender;

                xlWorkbook.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}");
                return false;
            }
            finally
            {
                CleanUp(xlRange, xlWorksheet, xlWorkbook, xlApp);
            }
        }

        private void CleanUp(Excel.Range xlRange, Excel._Worksheet xlWorksheet, Excel.Workbook xlWorkbook, Excel.Application xlApp)
        {
            if (xlRange != null) Marshal.ReleaseComObject(xlRange);
            if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
            if (xlWorkbook != null)
            {
                xlWorkbook.Close(true);
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
    }
}