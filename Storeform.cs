using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace final_project
{
    public partial class StoreForm : Form
    {
        private int wallet;
        private Database DB;
        private User user;
        private List<Itemstore> items;
        private FlowLayoutPanel flowLayoutPanel;
        //private Panel westPanel;
        private Panel centerPanel;
        private const int ItemWidth = 200;
        private const int ItemHeight = 250;

        public StoreForm(User user)
        {
            InitializeComponent();
            SetupLayout();
            this.user = user;
            this.DB = new Database();
            wallet = DB.GetBalance(int.Parse(user.ID));
            items = new List<Itemstore>();
            LoadItems();
            //UpdateWalletLabel(0);
            userData.Text = $"שם משתמש : {user.Username}";
            user_balance.Text = $"מטבעות : {wallet}";
            Resize += new EventHandler(StoreForm_Resize);
        }
        private void updateData(int dis)
        {

            user_balance.Text = $"Balance {wallet - dis}";
            wallet = wallet - dis;
            DB.SetBalance(int.Parse(user.ID), wallet);
        }

        //private void SetupLayout()
        //{
        //    // West Panel
        //    westPanel = new Panel
        //    {
        //        Dock = DockStyle.Left,
        //        Width = 200 // Adjust as needed
        //    };
        //    this.Controls.Add(westPanel);

        //    // Center Panel
        //    centerPanel = new Panel
        //    {
        //        //Dock = DockStyle.Fill
        //        Dock = DockStyle.Fill
        //    };
        //    this.Controls.Add(centerPanel);

        //    // FlowLayoutPanel (inside centerPanel)
        //    this.flowLayoutPanel = new FlowLayoutPanel
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoScroll = true,
        //        FlowDirection = FlowDirection.LeftToRight,
        //        WrapContents = true,
        //        ////
        //        //AutoSize = false,
        //        //Location = new Point(100, 0)
        //        ////
        //    };
        //    centerPanel.Controls.Add(this.flowLayoutPanel);
        //    //
        //    Point p = flowLayoutPanel.Location;
        //    Console.WriteLine(p.ToString());
        //    //
        //    // Move the scroll to the right side
        //    flowLayoutPanel.VerticalScroll.Visible = true;
        //    flowLayoutPanel.HorizontalScroll.Visible = false;
        //    flowLayoutPanel.WrapContents = true;
        //}
        private void SetupLayout()
        {
            // West Panel                           useless
            //westPanel = new Panel
            //{
            //    Dock = DockStyle.Left,
            //    Width = 100 // Adjust as needed
            //};
            //this.Controls.Add(westPanel);

            ///// Center Panel
            centerPanel = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(centerPanel);

            //// FlowLayoutPanel (inside centerPanel)
            //this.flowLayoutPanel = new FlowLayoutPanel
            //{
            //    Dock = DockStyle.Fill,
            //    AutoScroll = true,
            //    FlowDirection = FlowDirection.LeftToRight,
            //    WrapContents = true,
            //    BackgroundImage = Properties.Resources.udi_game_background
            //};
            //centerPanel.Controls.Add(this.flowLayoutPanel);
            this.flowLayoutPanel1 = flowLayoutPanel1;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanel1.WrapContents = true;
            this.flowLayoutPanel1.BackgroundImage = Properties.Resources.udi_game_background;

            // Adjust the flowLayoutPanel size and position
            AdjustItemSize();
        }


        private void StoreForm_Resize(object sender, EventArgs e)
        {
            AdjustItemSize();
        }

        private void AdjustItemSize()
        {
            if (this.flowLayoutPanel1 != null)
            {
                int availableWidth = this.flowLayoutPanel1.ClientSize.Width - this.flowLayoutPanel1.Padding.Horizontal;
                int itemsPerRow = Math.Max(1, availableWidth / ItemWidth);
                int itemWidth = (availableWidth - (itemsPerRow - 1) * 10) / itemsPerRow; // 10 is the horizontal margin

                foreach (Control control in this.flowLayoutPanel1.Controls)
                {
                    if (control is Panel itemPanel)
                    {
                        itemPanel.Width = itemWidth;
                        itemPanel.Height = ItemHeight;
                    }
                }

                this.flowLayoutPanel1.PerformLayout();
            }
        }

        private void AddItemToUI(Itemstore item)
        {
            var panel = new Panel
            {
                Width = ItemWidth,
                Height = ItemHeight,
                Margin = new Padding(5)
            };

            var pictureBox = new PictureBox
            {
                ImageLocation = item.ImagePath,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = ItemWidth - 20,
                Height = 120,
                Top = 10,
                Left = 10
            };

            var nameLabel = new Label
            {
                Text = item.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = ItemWidth - 20,
                Height = 30,
                Top = pictureBox.Bottom + 5,
                Left = 10,
                Font = new Font("Gill Sans MT", 12, FontStyle.Regular)
            };

            var priceLabel = new Label
            {
                Text = $"${item.Price}",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = ItemWidth - 20,
                Height = 30,
                Top = nameLabel.Bottom + 5,
                Left = 10,
                Font = new Font("Gill Sans MT", 12, FontStyle.Regular)
            };

            var buyButton = new Button
            {
                Text = "Buy",
                Width = ItemWidth - 40,
                Height = 30,
                Top = priceLabel.Bottom + 10,
                Left = 20,
                Font = new Font("Gill Sans MT", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat
            };

            buyButton.FlatAppearance.BorderSize = 2;
            buyButton.FlatAppearance.BorderColor = Color.Black;
            buyButton.Click += (sender, e) => BuyItem(item);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(buyButton);

            this.flowLayoutPanel1.Controls.Add(panel);
        }

        private void LoadItems()
        {
            try
            {
                var filePath = @"../../storeitems.xlsx";
                string fullPath = Path.GetFullPath(filePath);
                //Console.WriteLine(fullPath);

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("items");
                    var rows = worksheet.RangeUsed().RowsUsed();

                    foreach (var row in rows) // Skip header row
                    {
                        
                        var name = row.Cell(1).GetValue<string>();
                        var price = row.Cell(2).GetValue<int>();
                        var imagePath = row.Cell(3).GetValue<string>();

                        string fullImagePath = Path.Combine(Application.StartupPath, @"..\..\" + imagePath);
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

        private void BuyItem(Itemstore item)
        {
            if (wallet >= item.Price)
            {
                //wallet -= item.Price;
                //UpdateWalletLabel();
                Add_To_excel(item);
                DB.SetBalance(int.Parse(user.ID), wallet);
                MessageBox.Show($"You bought {item.Name}!");
                this.updateData(item.Price);
            }
            else
            {
                MessageBox.Show("You don't have enough money!");
            }
        }

        private void Add_To_excel(Itemstore item)
        {
            try
            {
                var filePath = @"../../storeitems.xlsx";
                bool fileExists = File.Exists(filePath);
                string fullPath = Path.GetFullPath(filePath);
                Console.WriteLine(fullPath);
                string itempath = item.ImagePath;
                int lastIndex = itempath.LastIndexOf(@"pics");
                string secondPart = "";
                if (lastIndex >= 0)
                {
                    // Extract the second part
                    secondPart = itempath.Substring(lastIndex);
                }

                    using (var workbook = fileExists ? new XLWorkbook(filePath) : new XLWorkbook())
                {
                    
                    IXLWorksheet worksheet = null;
                    //Console.WriteLine(workbook.Worksheets);
                    if (fileExists)
                    {
                        // Check if "store" worksheet exists
                        if (workbook.Worksheets.TryGetWorksheet("store", out worksheet))
                        {
                            Console.WriteLine("Found 'store' worksheet.");
                        }
                        else
                        {
                            Console.WriteLine("'store' worksheet not found. Creating new 'store' worksheet.");
                            worksheet = workbook.Worksheets.Add("store");
                        }
                    }
                    var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 0;
                    var newRow = worksheet.Row(lastRow + 1);

                    newRow.Cell(1).Value = item.Name;
                    newRow.Cell(2).Value = item.Price;
                    newRow.Cell(3).Value = DateTime.Now.ToString();
                    newRow.Cell(4).Value = user.ID;
                    newRow.Cell(5).Value = secondPart;

                    workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}