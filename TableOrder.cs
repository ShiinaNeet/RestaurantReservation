using Google.Protobuf.WellKnownTypes;
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
    public partial class TableOrder : Form
    {
        int currTablenum;
        public delegate void setvalueTableNum(int ss);
        public setvalueTableNum setTableNum;
        CreateOrderForm orderForm = new CreateOrderForm();

        public TableOrder()
        {
            InitializeComponent();
            
           
            
        }

        private void rs_FormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }

         
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            currTablenum = 1;
            
            
            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
          
            CreateOrderForm.setTableNum(currTablenum);
            MainForm1.loadform(new CreateOrderForm());
            MainForm1.MyrefeshMethod();


        }

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;
            

            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            CreateOrderForm.setTableNum(currTablenum);
            MainForm1.loadform(new CreateOrderForm());
            MainForm1.MyrefeshMethod();

        }

        private void TableOrder_Load(object sender, EventArgs e)
        {
            
            Table1Btn.BackgroundImage = Resources.table;
            Table1Btn.BackgroundImageLayout =ImageLayout.Zoom;
            button2.BackgroundImage = Resources.table;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MainForm1.loadform(new MainMenuWindow());
            MainForm1.MyrefeshMethod();
        }
    }
}
