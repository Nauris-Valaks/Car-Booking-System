using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Nauris Valaks 
// Version 1.0 15/05/2018

namespace Car_Booking_System
{
    public partial class Home : Form
    {
       
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAston_Click(object sender, EventArgs e)
        {
            Hide();
            (new Aston()).Show();
        }

        private void btnLamb_Click(object sender, EventArgs e)
        {
            Hide();
            (new Lamborghini()).Show();
        }

        private void btnFerrari_Click(object sender, EventArgs e)
        {
            Hide();
            (new Ferrari()).Show();
        }

        private void btnJaguar_Click_1(object sender, EventArgs e)
        {
            Hide();
            (new Jaguar()).Show();
        }
    }
}
