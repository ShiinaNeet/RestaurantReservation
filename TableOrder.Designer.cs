namespace RestaurantReservation
{
    partial class TableOrder
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
            this.Table1Btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Table1Btn
            // 
            this.Table1Btn.Location = new System.Drawing.Point(177, 125);
            this.Table1Btn.Name = "Table1Btn";
            this.Table1Btn.Size = new System.Drawing.Size(185, 156);
            this.Table1Btn.TabIndex = 0;
            this.Table1Btn.Text = "Table 1";
            this.Table1Btn.UseVisualStyleBackColor = true;
            this.Table1Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 156);
            this.button2.TabIndex = 1;
            this.button2.Text = "Table 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Table1Btn);
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Table1Btn;
        private Button button2;
    }
}