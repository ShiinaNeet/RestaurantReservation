﻿namespace RestaurantReservation
{
    partial class CreateOrderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrderForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbModePayment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tablelablblbl1 = new System.Windows.Forms.Label();
            this.TableNumLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(303, 411);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Remove Selected Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Food";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(451, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 41);
            this.button3.TabIndex = 7;
            this.button3.Text = "Beverages";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::RestaurantReservation.Properties.Resources.BurgerBackground___Copy1;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.cbModePayment);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(340, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 127);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 23);
            this.textBox1.TabIndex = 4;
            // 
            // cbModePayment
            // 
            this.cbModePayment.FormattingEnabled = true;
            this.cbModePayment.Location = new System.Drawing.Point(151, 37);
            this.cbModePayment.Name = "cbModePayment";
            this.cbModePayment.Size = new System.Drawing.Size(165, 23);
            this.cbModePayment.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Change: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Method of Payment: ";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::RestaurantReservation.Properties.Resources.BurgerBackground___Copy1;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(703, 425);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 127);
            this.panel3.TabIndex = 10;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(181, 68);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 39);
            this.button7.TabIndex = 3;
            this.button7.Text = "Print";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 68);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 39);
            this.button6.TabIndex = 2;
            this.button6.Text = "Pay";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 39);
            this.button5.TabIndex = 1;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 39);
            this.button4.TabIndex = 0;
            this.button4.Text = "Order";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 21);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "Go Back";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tablelablblbl1
            // 
            this.tablelablblbl1.AutoSize = true;
            this.tablelablblbl1.BackColor = System.Drawing.Color.Transparent;
            this.tablelablblbl1.Location = new System.Drawing.Point(103, 14);
            this.tablelablblbl1.Name = "tablelablblbl1";
            this.tablelablblbl1.Size = new System.Drawing.Size(87, 15);
            this.tablelablblbl1.TabIndex = 12;
            this.tablelablblbl1.Text = "Table Number: ";
            this.tablelablblbl1.Click += new System.EventHandler(this.tablelablblbl1_Click);
            // 
            // TableNumLabel
            // 
            this.TableNumLabel.AutoSize = true;
            this.TableNumLabel.BackColor = System.Drawing.Color.Transparent;
            this.TableNumLabel.Location = new System.Drawing.Point(196, 14);
            this.TableNumLabel.Name = "TableNumLabel";
            this.TableNumLabel.Size = new System.Drawing.Size(10, 15);
            this.TableNumLabel.TabIndex = 13;
            this.TableNumLabel.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(103, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Date:               ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Location = new System.Drawing.Point(196, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(10, 15);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = " ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BackgroundImage = global::RestaurantReservation.Properties.Resources.BurgerBackground___Copy1;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(340, 68);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(25);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(715, 344);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(12, 523);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(303, 29);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "TOTAL : ";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(12, 549);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(303, 38);
            this.textBox3.TabIndex = 17;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 641);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TableNumLabel);
            this.Controls.Add(this.tablelablblbl1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "CreateOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrdersForm";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private ComboBox cbModePayment;
        private Label label8;
        private Label label5;
        private Panel panel3;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private TextBox textBox1;
        private Button button8;
        private Label tablelablblbl1;
        private Label TableNumLabel;
        private Label label7;
        private Label lblDate;
        private FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Timer timer1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}