namespace VendingMachine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxItems = new ListBox();
            buttonVend = new Button();
            buttonCancel = new Button();
            labelInserted = new Label();
            labelSelected = new Label();
            labelRemaining = new Label();
            flowLayoutPanelMoney = new FlowLayoutPanel();
            
            // 
            // listBoxItems
            // 
            listBoxItems.FormattingEnabled = true;
            listBoxItems.ItemHeight = 15;
            listBoxItems.Location = new Point(12, 12);
            listBoxItems.Name = "listBoxItems";
            listBoxItems.Size = new Size(200, 244);
            listBoxItems.TabIndex = 0;
            listBoxItems.SelectedIndexChanged += listBoxItems_SelectedIndexChanged;
            // 
            // buttonVend
            // 
            buttonVend.Location = new Point(218, 183);
            buttonVend.Name = "buttonVend";
            buttonVend.Size = new Size(170, 35);
            buttonVend.TabIndex = 1;
            buttonVend.Text = "Vend";
            buttonVend.Click += buttonVend_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(218, 224);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(170, 32);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelInserted
            // 
            labelInserted.AutoSize = true;
            labelInserted.Location = new Point(218, 12);
            labelInserted.Name = "labelInserted";
            labelInserted.Size = new Size(89, 15);
            labelInserted.TabIndex = 3;
            labelInserted.Text = "Money Inserted: $0.00";
            // 
            // labelSelected
            // 
            labelSelected.AutoSize = true;
            labelSelected.Location = new Point(218, 37);
            labelSelected.Name = "labelSelected";
            labelSelected.Size = new Size(82, 15);
            labelSelected.TabIndex = 4;
            labelSelected.Text = "Selected: None";
            // 
            // labelRemaining
            // 
            labelRemaining.AutoSize = true;
            labelRemaining.Location = new Point(218, 62);
            labelRemaining.Name = "labelRemaining";
            labelRemaining.Size = new Size(113, 15);
            labelRemaining.TabIndex = 5;
            labelRemaining.Text = "Please make a selection";
            // 
            // flowLayoutPanelMoney
            // 
            flowLayoutPanelMoney.Location = new Point(218, 90);
            flowLayoutPanelMoney.Name = "flowLayoutPanelMoney";
            flowLayoutPanelMoney.Size = new Size(170, 87);
            flowLayoutPanelMoney.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 268);
            Controls.Add(flowLayoutPanelMoney);
            Controls.Add(labelRemaining);
            Controls.Add(labelSelected);
            Controls.Add(labelInserted);
            Controls.Add(buttonCancel);
            Controls.Add(buttonVend);
            Controls.Add(listBoxItems);
            Name = "Form1";
            Text = "Vending Machine";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxItems;
        private Button buttonVend;
        private Button buttonCancel;
        private Label labelInserted;
        private Label labelSelected;
        private Label labelRemaining;
        private FlowLayoutPanel flowLayoutPanelMoney;
    }
}
