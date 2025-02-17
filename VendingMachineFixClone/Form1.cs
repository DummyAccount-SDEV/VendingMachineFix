using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, VendingItem> _items;
        private readonly Payment _payment;
        private VendingItem _selectedItem;

        public Form1()
        {
            InitializeComponent();
            _payment = new Payment();
            _items = new Dictionary<string, VendingItem>
            {
                { "A1", new VendingItem("Cola", 1.50m) },
                { "A2", new VendingItem("Sprite", 1.50m) },
                { "A3", new VendingItem("Water", 1.00m) },
                { "B1", new VendingItem("Chips", 0.75m) },
                { "B2", new VendingItem("Candy", 1.25m) },
                { "B3", new VendingItem("Gum", 0.50m) }
            };

            foreach (var kvp in _items)
            {
                listBoxItems.Items.Add($"{kvp.Key}: {kvp.Value}");
            }

            // Add money insertion buttons
            Button[] moneyButtons = {
                new Button { Text = "$5", Tag = 5.00m },
                new Button { Text = "$1", Tag = 1.00m },
                new Button { Text = "25¢", Tag = 0.25m },
                new Button { Text = "10¢", Tag = 0.10m },
                new Button { Text = "5¢", Tag = 0.05m }
            };

            foreach (var button in moneyButtons)
            {
                button.Width = 60;
                button.Click += MoneyButton_Click;
                flowLayoutPanelMoney.Controls.Add(button);
            }

            UpdateDisplay();
        }

        private void MoneyButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is decimal amount)
            {
                _payment.InsertMoney(amount);
                UpdateDisplay();
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem is string selectedText)
            {
                string code = selectedText.Split(':')[0].Trim();
                if (_items.TryGetValue(code, out VendingItem item))
                {
                    _selectedItem = item;
                    UpdateDisplay();
                }
            }
        }

        private void buttonVend_Click(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                MessageBox.Show("Please select an item first.", "Selection Required");
                return;
            }

            if (_selectedItem.Quantity <= 0)
            {
                MessageBox.Show("This item is out of stock.", "Out of Stock");
                return;
            }

            if (_payment.AmountInserted < _selectedItem.Price)
            {
                MessageBox.Show($"Please insert {Payment.FormatMoney(_selectedItem.Price - _payment.AmountInserted)} more.", "Insufficient Funds");
                return;
            }

            try
            {
                var change = _payment.CalculateChange(_selectedItem.Price);
                _selectedItem.Quantity--;
                
                string message = $"Vending {_selectedItem.Name}...\n\n";
                if (change.Count > 0)
                {
                    message += $"Your change:\n{_payment.FormatChange(change)}";
                }
                
                MessageBox.Show(message, "Success");
                
                _payment.Reset();
                _selectedItem = null;
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_payment.AmountInserted > 0)
            {
                MessageBox.Show($"Returning {Payment.FormatMoney(_payment.AmountInserted)}", "Transaction Cancelled");
                _payment.Reset();
                _selectedItem = null;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            labelInserted.Text = $"Money Inserted: {Payment.FormatMoney(_payment.AmountInserted)}";
            
            if (_selectedItem != null)
            {
                labelSelected.Text = $"Selected: {_selectedItem.Name} - {Payment.FormatMoney(_selectedItem.Price)}";
                decimal remaining = _selectedItem.Price - _payment.AmountInserted;
                labelRemaining.Text = remaining > 0 
                    ? $"Please Insert: {Payment.FormatMoney(remaining)}"
                    : "Ready to vend!";
            }
            else
            {
                labelSelected.Text = "Selected: None";
                labelRemaining.Text = "Please make a selection";
            }
        }
    }
}
