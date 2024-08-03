using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class StoreForm : Form
    {
        private int wallet;
        private User user;
        private List<Itemstore> items;
        private FlowLayoutPanel flowLayoutPanel;
        //private Label walletLabel;
        private Database DB;
        private TextBox nameTextBox;
        private TextBox priceTextBox;
        private TextBox imagePathTextBox;
        private Button addButton;

        public StoreForm(User user, Database DB)
        {
            this.DB = DB;
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
            InitializeCustomComponents();
            this.Resize += new EventHandler(StoreForm_Resize);
            this.user = user;
            wallet = DB.GetBalance(int.Parse(user.ID)); // Initialize wallet with a default value
            items = new List<Itemstore>();
            LoadItems();
            UpdateWalletLabel();

            // Set the background image for the form
            //var fileInfo = new FileInfo(@"..\..\..\pics\background.jpg");
            //MessageBox.Show($"File path: {fileInfo.FullName}");
            //string imagePath = Path.Combine(fileInfo.ToString()); // Adjust path

            // Set up the scrollable panel for items
            var scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Set up the FlowLayoutPanel properties
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.AutoScroll = true;

            // Add the FlowLayoutPanel to the scrollablePanel
            scrollablePanel.Controls.Add(flowLayoutPanel);

            // Add the scrollablePanel to the form
            this.Controls.Add(scrollablePanel);

            // Optionally, adjust item size on form resize
            this.Resize += (s, e) => AdjustItemSize();
        }

        private void AdjustItemSize()
        {
            int panelWidth = flowLayoutPanel.ClientSize.Width;
            int minItemWidth = 200; // Minimum width for an item
            int itemMargin = 10; // Adjust this value to control the spacing between items
            int maxItemsPerRow = Math.Max(1, (panelWidth + itemMargin) / (minItemWidth + itemMargin));
            int itemWidth = (panelWidth - (maxItemsPerRow - 1) * itemMargin) / maxItemsPerRow;

            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is Panel itemPanel)
                {
                    itemPanel.Width = itemWidth;
                    itemPanel.Height = 180; // Set a fixed height for each item panel, or calculate dynamically if needed
                }
            }

            flowLayoutPanel.PerformLayout(); // Force the FlowLayoutPanel to re-arrange its contents
        }

        private void StoreForm_Resize(object sender, EventArgs e)
        {
            AdjustItemSize();
        }

        private void InitializeCustomComponents()
        {
            this.flowLayoutPanel = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(12, 12),
                Name = "flowLayoutPanel1",
                Size = new System.Drawing.Size(900, 550),
                AutoScroll = true // Enable scrolling if needed
            };
            this.Controls.Add(this.flowLayoutPanel);
            ////
            ///
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            if (!int.TryParse(priceTextBox.Text, out int price))
            {
                MessageBox.Show("Invalid price");
                return;
            }
            string imagePath = imagePathTextBox.Text;

            var newItem = new Itemstore(name, price, imagePath);
            items.Add(newItem);
            AddItemToUI(newItem);
        }
        private void AddItemToUI(Itemstore item)
        {
            var panel = new Panel
            {
                Width = 200,
                Height = 280, // Increased height to accommodate all elements
                Margin = new Padding(10)
            };

            var pictureBox = new PictureBox
            {
                ImageLocation = item.ImagePath,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 85,
                Height = 100,
                Top = 5,
                Left = (panel.Width - 80) / 2
            };

            var nameLabel = new Label
            {
                Text = item.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = panel.Width,
                Height = 25,
                Top = pictureBox.Bottom + 5,
                Left = 0,
                Font = new Font("Gill Sans MT", 12, FontStyle.Regular)
            };

            var priceLabel = new Label
            {
                Text = $"${item.Price}",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = panel.Width,
                Height = 30,
                Top = nameLabel.Bottom + 5,
                Left = 0,
                Font = new Font("Gill Sans MT", 12, FontStyle.Regular)
            };

            var buyButton = new Button
            {
                Text = "Buy",
                Width = 70,
                Height = 30,
                Top = priceLabel.Bottom + 10,
                Left = (panel.Width - 80) / 2,
                Font = new Font("Gill Sans MT", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat


            };

            // Configure the FlatAppearance properties
            buyButton.FlatAppearance.BorderSize = 2;
            buyButton.FlatAppearance.BorderColor = Color.Black;
            buyButton.TextAlign = ContentAlignment.TopCenter;
            buyButton.Click += (sender, e) => BuyItem(item);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(buyButton);
            Console.WriteLine($"adding an item");

            flowLayoutPanel.Controls.Add(panel);
        }

        private void LoadItems()
        {
            try
            {
                var filePath = @"../../storeitems.xlsx";
                string fullPath = Path.GetFullPath(filePath);
                Console.WriteLine($"Attempting to load file from: {fullPath}");


                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("items"); // Name of the worksheet
                    var rows = worksheet.RangeUsed().RowsUsed();

                    foreach (var row in rows)
                    {
                        var name = row.Cell(1).GetValue<string>();
                        var price = row.Cell(2).GetValue<int>();
                        var imagePath = row.Cell(3).GetValue<string>();

                        string fullImagePath = Path.Combine(Application.StartupPath, @"..\..\..\" + imagePath);
                        Itemstore item = new Itemstore(name, price, fullImagePath);
                        items.Add(item);
                    }
                }

                foreach (var item in items)
                {
                    AddItemToUI(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void Add_To_excel(Itemstore item)
        {
            try
            {
                var filePath = @"../../../storeitems.xlsx";
                bool fileExists = File.Exists(filePath);

                using (var workbook = fileExists ? new XLWorkbook(filePath) : new XLWorkbook())
                {
                    var worksheet = fileExists ? workbook.Worksheet("store") : workbook.Worksheets.Add("store");

                    var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 0;
                    var newRow = worksheet.Row(lastRow + 1);

                    newRow.Cell(1).Value = item.Name;
                    newRow.Cell(2).Value = item.Price;
                    newRow.Cell(3).Value = DateTime.Now.ToString();
                    newRow.Cell(4).Value = user.ID;

                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }
    private void BuyItem(Itemstore item)
        {
            if (wallet >= item.Price)
            {
                wallet -= item.Price;
                UpdateWalletLabel();
                Add_To_excel(item);
                DB.SetBalance(int.Parse(user.ID), wallet);
                MessageBox.Show($"You bought {item.Name}!");
            }
            else
            {
                //user doesn't have enough money
                MessageBox.Show("You dont enough money!!");
            }
        }
        private void UpdateWalletLabel()
        {
            //walletlabel2.Text = $"${wallet:F2}";
            
        }
        

    }
}
