using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Microsoft.VisualBasic;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Effects;
using Image = System.Drawing.Image;

namespace RestaurantReservation
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
           
            
            BackgroundImage = Resources.texture_background_1404_991;
            
            BackgroundImageLayout = ImageLayout.None;
            


        }
        
    }
}
