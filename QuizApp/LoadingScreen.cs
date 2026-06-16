using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MetroFramework.Controls;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace QuizApp
{
    public partial class LoadingScreen : BaseForm
    {
        public LoadingScreen()
        {
            InitializeComponent();

        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            pictureBox1.TabStop = false;
            metroProgressBar1.Value = 0;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metroProgressBar1.Value < 100)
            {
                metroProgressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();

                var form = new Form1();
                form.FormClosed += (s, args) => this.Close();
                form.Show();
                this.Hide();
            }
        }
    }
    }

