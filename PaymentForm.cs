using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        int orderid;
        long OrderID;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (var command = new SqlCommand("UPDATE Orders set Paid = 1 where OrderID = @orderid", cnn))
                {
                    cnn.Open();


                    command.Parameters.AddWithValue("@orderid",OrderID);


                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                    cnn.Close();
                }
                using (SqlCommand command1 = new SqlCommand("Select Paid from Orders where OrderID = OrderID", cnn))
                {

                    command1.Parameters.AddWithValue("@OrderID", OrderID);


                    cnn.Open();
                    var result = command1.ExecuteScalar();

                    if (result == DBNull.Value)
                    {
                        MessageBox.Show("Not Found!");

                    }
                    else if (Convert.ToInt32(result) == 1)
                    {
                        MessageBox.Show("OrderID " + OrderID + " Marked as paid", "Payment Successful!");
                    }
                    else 
                    {
                        MessageBox.Show("Payment for OrderID "+OrderID +" failed!","Payment Failed!");
                    }


                    cnn.Close();
                }

            }



            reloadDGV();

        }

        private void PayBtn_Click(object sender, EventArgs e)
        {
            
           
        }
        protected void btnDynamicButton_Click(object sender, EventArgs e)
        {
            
        }

        public void reloadDGV()
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
               

                using (SqlCommand cmd2 = new SqlCommand("SELECT OrderID,DateOrder,tablenum,Price  " +
                    "from Orders where DateOrder = Convert(date,GETDATE()) " +
                    "and Paid = 0", cnn))
                {
                    cnn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd2;
                    dt.Clear();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    cnn.Close();
                }
            }
            


        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
           
            reloadDGV();
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Paid";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {   // ignore header row and any column
                return;
            }

            //var result = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            // var orderid = this.dataGridView1[1, e.RowIndex].Value;


            //Set value of your own connection string above.

            OrderID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());



          //  this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
           dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            /*
             orderid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {


                    using (SqlCommand cmd2 = new SqlCommand("UPDATE Orders set Paid = 1 where OrderID = @orderid", cnn))
                    {

                        cmd2.Parameters.AddWithValue("@orderid", orderid);

                        cnn.Close();
                    }
                }*/


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = 0;
            if (e.ColumnIndex == columnIndex)
            {
                var isChecked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;

                        }
                    }
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("DELETE From Orders where OrderID = @orderid", cnn))
                {
                    cnn.Open();


                    command.Parameters.AddWithValue("@orderid", OrderID);


                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            reloadDGV();
        }

        private void ReloadBTN_Click(object sender, EventArgs e)
        {
            reloadDGV();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
           // this.Close();
            
        }
    }
}
