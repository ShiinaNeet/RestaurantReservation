using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlException = MySql.Data.MySqlClient.MySqlException;
using RestaurantReservation.Properties;
using System.IO;

namespace RestaurantReservation
{
    public partial class Login : Form
    {

        SqlConnection cnn = ConnectionClasss.connnect();
        SqlCommand command = new SqlCommand();
        private string gencrip;
        private string hash = "%4h&bn9873*7^><?:'";
        public string UserName;
        public string Pwd;
        
        public Login()
        {
            InitializeComponent();
        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }
        private void SignlnBtn_Click(object sender, EventArgs e)
        {
            ConnectionClasss conclass = new ConnectionClasss();

            if (UserNameTxtBox.Text == "") { MessageBox.Show("Please Enter a Username first", "INVALID USERNAME", MessageBoxButtons.OK); UserNameTxtBox.Select(); }
            else if (PWTxtBox.Text == "") { MessageBox.Show("Your Password is Empty", "INVALID PASSWORD", MessageBoxButtons.OK); PWTxtBox.Select(); }
            else
            {
                cnn.Open();
                
                cripter();
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;

                command.CommandText = "SELECT * FROM AccountUsers WHERE UserName='" + UserNameTxtBox.Text + "'AND Password='" + PWTxtBox.Text + "'";
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    Account account = new Account();
                    Account.Job= dr["Position"].ToString();
                    Account.Username = dr["UserName"].ToString();
                    Account.Picture = (byte[])dr["Picture"];
                    newMainForm nn = new newMainForm();
                    nn.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Username and Password!");
                    UserNameTxtBox.Clear();
                    PWTxtBox.Clear();
                }


            }


            cnn.Close();

        }
        public class Account
        {
            private static string username;
            private string password;
            private static string job;
            private static byte[] picture;

            public static string Username 
            {
                get { return username; }
                set {
                    username = value;
                    }
            }
            public static string Job { 
                get { return job; }  
                set { job = value; } 
                }
            public static byte[] Picture 
            { 
                get { return picture; }
                set { picture = value;  } 
            } 
           

        }

        public void cripter()
        {

            byte[] data = UTF8Encoding.UTF8.GetBytes(PWTxtBox.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

                    gencrip = Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }
        public void authenlogin()
        {

            cnn.Close();
            cnn.Open();

            command.Connection = cnn;
            command.CommandText = "SELECT * FROM Useraccount WHERE Username='" + UserNameTxtBox.Text + "'AND Userpassword='" + PWTxtBox;

            SqlDataReader dr2 = command.ExecuteReader();
            while (dr2.Read())
            {
                UserName = dr2["UserName"].ToString();
                Pwd = dr2["Password"].ToString();
            }
            cnn.Close();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            IsServerconnected();
        }
        public static bool IsServerconnected() {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                try
                {
                    cnn.Open();
                    return true;
                }
                catch (SqlException ee) { return false; }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (IsServerconnected() == true)
            {
                toolStripButton1.Enabled = true;
                toolStripButton1.Visible = true;

                toolStripButton1.Image = Resources._checked;

            }
            else 
            {
                toolStripButton1.Enabled = true;
                toolStripButton1.Visible = true;
                toolStripButton1.Image = Resources.remove;
            } 
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MainForm1 mf = new MainForm1();
           // mf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}