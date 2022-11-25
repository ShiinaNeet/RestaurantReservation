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

namespace RestaurantReservation
{
    public partial class SqlConnectionForm : Form
    {
        public SqlConnectionForm()
        {
            InitializeComponent();
        }

        private void SqlConnectionForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = "Data Source=SHIINANEET;Initial Catalog=RestaurantDB;Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open !");
            cnn.Close();
        }
    }
}
