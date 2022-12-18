using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class MainForm1 : Form
    {
        
        public Form _instance;
        public MainForm1()
        {
            InitializeComponent();
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.TopLevel = false;
            panel1.Controls.Add(mainMenuWindow);
            mainMenuWindow.Dock = DockStyle.Fill;
            mainMenuWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            mainMenuWindow.Show();
            this.FormBorderStyle = FormBorderStyle.None;

            BackgroundImage = Resources.BurgerBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
       
        public static void loadform(Form Form) 
        { 
            
            if(panel1.Controls.Count > 0)panel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel1.Controls.Add(f);
            panel1.Tag = f;
            f.Parent = MainForm1.panel1;
            f.Show();
          //  f.ParentForm.Refresh(); this refresh the parentform 
          
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm1.loadform(new MainMenuWindow());
        }

        public static void MyrefeshMethod()
        {
            MainForm1.panel1.Refresh();
        }
    }
}
