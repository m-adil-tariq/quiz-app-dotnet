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
    public partial class Delete : BaseForm
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var form = new DelStudent();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var form = new delExam();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var form = new delQuestion();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

            var form = new delExamAssign();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var form = new delScore();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Show();

        }
    }
}
