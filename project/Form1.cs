using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        Label[] L;
        Random r = new Random();
        const int N = 3;
        int points = 0;
        int hp = 5;

        public Form1()
        {
            InitializeComponent();
            updateLbl();
        }

        private void updateLbl() {

            label6.Text = timer1.Interval.ToString();
            label5.Text = "Score: " + points.ToString();
            label4.Text = "HP: " + hp.ToString();
        }

        private void resetLbl(int i)
        {
            L[i].Top = 0;
            L[i].Left = r.Next(0, panel1.Width - L[i].Width);
            L[i].Text = Convert.ToString((char)r.Next(65, 90));

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool check = false;
            for (int i = 0; i < N; i++)
            {
                if (L[i].Text == Convert.ToString(e.KeyCode))
                {
                    resetLbl(i);

                    if (timer1.Interval > 25)
                        timer1.Interval -= 25;
                    else if (timer1.Interval > 1)
                        timer1.Interval -= 1;

                    points += 1;

                    updateLbl();
                    check = true;

                }
        
            }
            if (!check)
            {
                hp--;
                    updateLbl();
                if (hp < 1) Game_Over();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L = new Label[N];
            L[0] = label1;
            L[1] = label2;
            L[2] = label3;


            for (int i = 0; i < N; i++)
            {
                L[i].AutoSize = false;
                L[i].BorderStyle = BorderStyle.FixedSingle;
                L[i].TextAlign = ContentAlignment.MiddleCenter;
                L[i].Width = 25;
                L[i].Height = 25;
                resetLbl(i);
            }
        }

        private void Game_Over()
        {

            timer1.Stop();
            label7.Visible = true;
            panel2.Visible = true;
            button1.Visible = true;
            button1.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            for (int i = 0; i < N; i++)
            {
                L[i].Top = L[i].Top + 2;
                if (L[i].Top + L[i].Height >= panel1.Height)
                {
                    resetLbl(i);
                    hp--;

                    updateLbl();
                    if (hp < 1) Game_Over();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Reset game variables
            points = 0;
            hp = 5;
            timer1.Interval = 200;

            // Update UI elements
            updateLbl();
            label7.Visible = false;
            panel2.Visible = false;
            button1.Visible = false;

            // Reset label positions and texts
            for (int i = 0; i < N; i++)
            {
                resetLbl(i);
            }

            // Start the timer
            timer1.Start();
            this.Focus();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
