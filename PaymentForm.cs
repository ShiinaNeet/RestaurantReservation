using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RestaurantReservation
{
    public partial class PaymentForm : Form
    {
        TextBox OrderNum = new TextBox();
        TextBox tableTextBox = new TextBox();
        Button buttonpay = new Button();
        Button closebutton = new Button();
        TextBox textboxOrderTotal = new TextBox();
        Panel panel = new Panel();
        int counter = 0;
        List<Button> buttonList = new List<Button>();
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Refresh();
            panel.BackColor = Color.Salmon;
            panel.Controls.Add(closebutton);
            panel.Controls.Add(textboxOrderTotal);
            panel.Controls.Add(buttonpay);
            panel.Controls.Add(tableTextBox);
            panel.Controls.Add(OrderNum);
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Name = "panel"+(counter+1).ToString();
            panel.Size = new System.Drawing.Size(294, 257);
            panel.TabIndex = 1;
            flowLayoutPanel1.Controls.Add(panel);
            buttonList.Add(buttonpay);
            counter++;
          
            buttonpay.Click += new EventHandler(this.btnDynamicButton_Click);
        }

        private void PayBtn_Click(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Remove(this.panel1);
            flowLayoutPanel1.Refresh();
        }
        protected void btnDynamicButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Remove(this.panel1);
            flowLayoutPanel1.Refresh();
        }

        public void reloadDGV()
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT UserName,Position,Password FROM AccountUsers", cnn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                
                cnn.Close();
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
           
            textboxOrderTotal.Location = new System.Drawing.Point(0, 94);
            textboxOrderTotal.Multiline = true;
            textboxOrderTotal.Name = "OrderTotaltxtbox";
            textboxOrderTotal.Size = new System.Drawing.Size(294, 111);
            textboxOrderTotal.TabIndex = 3;
            textboxOrderTotal.Text = "Orders +total here";
            closebutton.Location = new System.Drawing.Point(160, 211);
            closebutton.Name = "Closebtn";
            closebutton.Size = new System.Drawing.Size(100, 32);
            closebutton.TabIndex = 4;
            closebutton.Text = "Close";
            closebutton.UseVisualStyleBackColor = true;
            buttonpay.Location = new System.Drawing.Point(31, 212);
            buttonpay.Name = "PayBtn" + (counter + 1).ToString();
            buttonpay.Size = new System.Drawing.Size(100, 32);
            buttonpay.TabIndex = 2;
            buttonpay.Text = "Paid";
            buttonpay.UseVisualStyleBackColor = true;
            tableTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tableTextBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tableTextBox.Location = new System.Drawing.Point(0, 59);
            tableTextBox.Name = "txtboxTable";
            tableTextBox.Size = new System.Drawing.Size(294, 29);
            tableTextBox.TabIndex = 1;
            tableTextBox.Text = "Table Here";
            OrderNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OrderNum.Location = new System.Drawing.Point(-2, 3);
            OrderNum.Name = "txtordernumber";
            OrderNum.Size = new System.Drawing.Size(294, 47);
            OrderNum.TabIndex = 0;
            OrderNum.Text = "Order number here";
        }
    }
}
