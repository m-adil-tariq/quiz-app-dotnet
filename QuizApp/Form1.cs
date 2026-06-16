using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.TabStop = false;
            pictureBox2.TabStop = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var form = new AdminLogin();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var form = new StudentLogin();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
    }
}
