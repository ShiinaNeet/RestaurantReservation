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
            this.btnPaid = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReloadBTN = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaid
            // 
            this.btnPaid.Location = new System.Drawing.Point(421, 426);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(134, 41);
            this.btnPaid.TabIndex = 2;
            this.btnPaid.Text = "Mark as Paid";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightCoral;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 348);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // ReloadBTN
            // 
            this.ReloadBTN.BackColor = System.Drawing.Color.Transparent;
            this.ReloadBTN.BackgroundImage = global::RestaurantReservation.Properties.Resources.output_onlinepngtools_8_;
            this.ReloadBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReloadBTN.FlatAppearance.BorderSize = 0;
            this.ReloadBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReloadBTN.Location = new System.Drawing.Point(12, 427);
            this.ReloadBTN.Name = "ReloadBTN";
            this.ReloadBTN.Size = new System.Drawing.Size(46, 39);
            this.ReloadBTN.TabIndex = 4;
            this.ReloadBTN.UseVisualStyleBackColor = false;
            this.ReloadBTN.Click += new System.EventHandler(this.ReloadBTN_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(561, 426);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(134, 41);
            this.deletebtn.TabIndex = 5;
            this.deletebtn.Text = "Delete OrderID";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "Payment Window";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PaymentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackgroundImage = global::RestaurantReservation.Properties.Resources.BurgerBackground___Copy1;
            this.ClientSize = new System.Drawing.Size(717, 485);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.ReloadBTN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPaid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnPaid;
        private DataGridView dataGridView1;
        private Button ReloadBTN;
        private Button deletebtn;
        private Label label1;
        private Button button1;
    }
}