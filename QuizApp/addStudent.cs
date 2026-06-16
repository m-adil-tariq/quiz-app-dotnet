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
    public partial class addStudent : BaseForm
    {
        Admin a;
        int fk_ad;
        public addStudent(Admin a)
        {
            InitializeComponent();
            this.a = a;
            fk_ad = int.Parse(a.ad_user);
        }

        private void addStudent_Load(object sender, EventArgs e)
        {
            pictureBox1.TabStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student s = new student(textBox4.Text, textBox3.Text, textBox1.Text, a, this);
            //MetroFramework.MetroMessageBox.Show(this, "Student Added Successfully!!", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
