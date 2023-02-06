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
            

            using (SqlConnection cnn2 = ConnectionClasss.connnect())
            {
                cnn2.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Reservations", cnn2);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd2;
                DataTable dt = new DataTable();
                da.Fill(dt);


                dataGridView1.DataSource = dt;
                cnn2.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
