using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Galmun
{

    public partial class FormMouseCR : Form
    {
        public FormMouseCR()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Form1 fs = new Form1();
            this.Hide();
            fs.Show();
            
        }

        private void FormMouseCR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
