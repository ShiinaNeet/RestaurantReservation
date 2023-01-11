namespace RestaurantReservation
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Closebtn = new System.Windows.Forms.Button();
            this.OrderTotaltxtbox = new System.Windows.Forms.TextBox();
            this.PayBtn = new System.Windows.Forms.Button();
            this.txtboxTable = new System.Windows.Forms.TextBox();
            this.txtordernumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 24);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(904, 493);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.Controls.Add(this.Closebtn);
            this.panel1.Controls.Add(this.OrderTotaltxtbox);
            this.panel1.Controls.Add(this.PayBtn);
            this.panel1.Controls.Add(this.txtboxTable);
            this.panel1.Controls.Add(this.txtordernumber);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 257);
            this.panel1.TabIndex = 1;
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(160, 211);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(100, 32);
            this.Closebtn.TabIndex = 4;
            this.Closebtn.Text = "Delete";
            this.Closebtn.UseVisualStyleBackColor = true;
            // 
            // OrderTotaltxtbox
            // 
            this.OrderTotaltxtbox.Location = new System.Drawing.Point(0, 94);
            this.OrderTotaltxtbox.Multiline = true;
            this.OrderTotaltxtbox.Name = "OrderTotaltxtbox";
            this.OrderTotaltxtbox.Size = new System.Drawing.Size(294, 111);
            this.OrderTotaltxtbox.TabIndex = 3;
            this.OrderTotaltxtbox.Text = "Orders +total here";
            // 
            // PayBtn
            // 
            this.PayBtn.Location = new System.Drawing.Point(31, 212);
            this.PayBtn.Name = "PayBtn";
            this.PayBtn.Size = new System.Drawing.Size(100, 32);
            this.PayBtn.TabIndex = 2;
            this.PayBtn.Text = "Pay";
            this.PayBtn.UseVisualStyleBackColor = true;
            this.PayBtn.Click += new System.EventHandler(this.PayBtn_Click);
            // 
            // txtboxTable
            // 
            this.txtboxTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxTable.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtboxTable.Location = new System.Drawing.Point(0, 59);
            this.txtboxTable.Name = "txtboxTable";
            this.txtboxTable.Size = new System.Drawing.Size(294, 29);
            this.txtboxTable.TabIndex = 1;
            this.txtboxTable.Text = "Table Here";
            // 
            // txtordernumber
            // 
            this.txtordernumber.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtordernumber.Location = new System.Drawing.Point(-2, 3);
            this.txtordernumber.Name = "txtordernumber";
            this.txtordernumber.Size = new System.Drawing.Size(294, 47);
            this.txtordernumber.TabIndex = 0;
            this.txtordernumber.Text = "Order number here";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1155, 541);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TextBox txtboxTable;
        private TextBox txtordernumber;
        private Button PayBtn;
        private TextBox OrderTotaltxtbox;
        private Button Closebtn;
        private Button button1;
    }
}