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
    public partial class addExam : BaseForm
    {
        public addExam()
        {
            InitializeComponent();
        }

        private void addExam_Load(object sender, EventArgs e)
        {
            pictureBox2.TabStop = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                new Exam(this, textBox1.Text);
            else
                MetroFramework.MetroMessageBox.Show(this, "Please Enter Exam Name!!", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
