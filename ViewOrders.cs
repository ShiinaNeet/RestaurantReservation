using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantReservation
{
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Date                                    ",70);
            listView1.Columns.Add("Client Name          ", 70);
            listView1.Columns.Add("Table Number", 70);
            listView1.Columns.Add("Diner Count", 70);
            listView1.View = View.Details;

            listView1.AutoResizeColumn(0,ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(1,ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

            using (SqlConnection cnn2 = ConnectionClasss.connnect())
            {
                cnn2.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Reservations", cnn2);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd2;
                
                da.Fill(ds,"Table Test");
                DataTable dt = new DataTable();

                dt = ds.Tables["Table Test"];
                int i;
                for (i = 0; i <= dt.Rows.Count -1; i++) 
                {
                    listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                }
                cnn2.Close();
            }
        }
    }
}
