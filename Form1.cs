using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Galmun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            INIT();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            groupBox1.Size = this.Size;
            pictureBox1.Size = this.Size;
            

            PI.Size = pictureBox1.Size;
            PI.Location = pictureBox1.Location;
        }
        
        

        bool fs=false;
        Panel PI = new Panel();
       
        //Creare_elemente

        public void AddSquares()
        {
            int d=400;
            int x=137, y=513;
            PictureBox P1 = new PictureBox();
            P1.Width = d;
            P1.Height = d;
            P1.Location = new Point(x, y);
            P1.Image = Image.FromFile("imagini/Black.jpg");
            this.Controls.Add(P1);
        }


        //FullScreen

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fs = !fs;
                GoFullscreen(fs);
            }
            if (e.KeyCode == Keys.Add && pictureBox1.Width < PI.Width*5)
            {
                pictureBox1.Width += 100;
                pictureBox1.Height += 100;
            }
            if (e.KeyCode == Keys.Subtract && pictureBox1.Width > PI.Width)
            {

                pictureBox1.Width -= 100;
                pictureBox1.Height -= 100;
            }
            if (e.KeyCode == Keys.Multiply)   //"*" -> marimea initiala
            {
                pictureBox1.Size = PI.Size;
            }
            if (e.KeyCode == Keys.Divide)       //"/" -> locatia initiala
            {
                pictureBox1.Location = PI.Location;
            }
        }

        // Captare Mouse
        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
           // AddSquares();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            if (pictureBox1.Location.X + pictureBox1.Width < this.Width - 100)
                pictureBox1.Location = new Point(this.Width - 100 - pictureBox1.Width, pictureBox1.Location.Y);
            if (pictureBox1.Location.X > 100)
                pictureBox1.Location = new Point(100, pictureBox1.Location.Y);
            if (pictureBox1.Location.Y > 50)
                pictureBox1.Location = new Point(pictureBox1.Location.X, 50);
            if (pictureBox1.Location.Y + pictureBox1.Height < this.Height - 100)
                pictureBox1.Location = new Point(pictureBox1.Location.X, this.Height - 50 - pictureBox1.Height);
            
        }


        //Miscare Mapa

        private Point firstPoint = new Point();

        public void INIT()
        {
            pictureBox1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                { firstPoint = Control.MousePosition; }
            };

            pictureBox1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    pictureBox1.Location = new Point(pictureBox1.Location.X - res.X, pictureBox1.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMouseCR fs = new FormMouseCR();
            fs.Show();
            
        }

    }

}
