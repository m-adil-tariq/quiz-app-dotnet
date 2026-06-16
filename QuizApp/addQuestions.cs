using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizApp
{
    public partial class addQuestions : BaseForm
    {
        Admin a;
        Exam ex;
        int fk_ad;
        public addQuestions(Admin a)
        {
            InitializeComponent();
            this.a = a;
            fk_ad = int.Parse(a.ad_user);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }




        private void addQuestions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quiz_appDataSet.exam' table. You can move, or remove it, as needed.
            this.examTableAdapter.Fill(this.quiz_appDataSet.exam);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ex = new Exam(int.Parse(comboBox1.SelectedValue.ToString()));
            questions q = new questions(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, a, ex);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addQuestions_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
