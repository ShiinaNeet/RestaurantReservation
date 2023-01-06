using Google.Protobuf.WellKnownTypes;
using RestaurantReservation.Properties;
using System;
using System.Collections;
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
        List<Button> btnarray = new List<Button>();
        Button currlastitem;
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
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;


            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();

        }

        private void TableOrder_Load(object sender, EventArgs e)
        {
            
            btn1.BackgroundImage = Resources.table;
            btn1.BackgroundImageLayout =ImageLayout.Zoom;
            btn2.BackgroundImage = Resources.table;
            btn2.BackgroundImageLayout = ImageLayout.Zoom;
            btn3.BackgroundImage = Resources.table;
            btn3.BackgroundImageLayout = ImageLayout.Zoom;
            btn4.BackgroundImage = Resources.table;
            btn4.BackgroundImageLayout = ImageLayout.Zoom;
            btn5.BackgroundImage = Resources.table;
            btn5.BackgroundImageLayout = ImageLayout.Zoom;
            btn6.BackgroundImage = Resources.table;
            btn6.BackgroundImageLayout = ImageLayout.Zoom;

            btnarray.Add(btn1); btnarray.Add(btn2); btnarray.Add(btn3); btnarray.Add(btn4); btnarray.Add(btn5);
            btnarray.Add(btn6); btnarray.Add(btn7); btnarray.Add(btn8); btnarray.Add(btn9); btnarray.Add(btn10);

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn10.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          //  this.Close();
           // MainForm1.loadform(new MainMenuWindow());
           // MainForm1.MyrefeshMethod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currTablenum = 3;


            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currTablenum = 4;


            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currTablenum = 5;


            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currTablenum = 6;


            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }
        int tablenumber;
        int tablenumbincrement=1;
       
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (Button button in btnarray)
            {
                if (button.Enabled == true)
                {

                }
                else
                {
                    button.Enabled = true;
                    button.Visible = true;
                    break;
                }
            }

        }
        void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test added " + tablenumber.ToString());
            panel1.Refresh();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            currTablenum = 7;
            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            currTablenum = 8;
            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            currTablenum = 9;
            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            currTablenum = 10;
            this.setTableNum += new setvalueTableNum(CreateOrderForm.setTableNum);
            this.setTableNum(currTablenum);
            CreateOrderForm.setTableNum(currTablenum);

            CreateOrderForm rs = new CreateOrderForm()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();
            this.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (Button button in btnarray)
            {

                if (button.Enabled == true)
                {

                }
                else if (button.Enabled == false)
                {
                    currlastitem.Enabled = false;
                    currlastitem.Visible = false;

                    break;
                }
                currlastitem = button;
                if (button == btn10)
                {
                    currlastitem = btnarray[9];
                    currlastitem.Enabled = false;
                    currlastitem.Visible = false;

                    break;

                }

            }
        }
    }
}
