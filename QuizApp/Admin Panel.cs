using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form2 : BaseForm
    {
        Admin a;
        int fk_ad;
        public Form2(Admin a)
        {
            InitializeComponent();
            this.a = a;
            fk_ad = int.Parse(a.ad_user);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var form = new addStudent(a);
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var form = new addQuestions(a);
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var form = new addExam();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var form = new addAdmin();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var form = new seeResults();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            var form = new Delete();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var form = new AssignExam();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.TabStop = false;
            pictureBox2.TabStop = false;
            pictureBox3.TabStop = false;
            pictureBox4.TabStop = false;
            pictureBox5.TabStop = false;
            pictureBox6.TabStop = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
