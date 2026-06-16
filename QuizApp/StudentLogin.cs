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
    public partial class StudentLogin : BaseForm
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            string user = textBox4.Text;
            string password = textBox3.Text;

            string userdb = returnClass.scalarReturn("SELECT COUNT(std_id) FROM student WHERE std_id ='" + user + "'");

            if (userdb == "0")
            {
                MessageBox.Show("Invalid user name!");
                return;
            }

            string passworddb = returnClass.scalarReturn("SELECT std_password FROM student WHERE std_id ='" + user + "'");
            if (passworddb != password)
            {
                MessageBox.Show("Invalid Password!");
                return;
            }

            string examCheck = returnClass.scalarReturn("SELECT COUNT(std_id_fk) FROM set_exam WHERE std_id_fk = '" + user + "'");
            if (int.Parse(examCheck) > 0)
            {
                // Load available exams
                string query = "SELECT * FROM set_exam se JOIN exam e ON se.ex_id_fk = e.ex_id WHERE std_id_fk = '" + user + "'";
                ViewClass vc = new ViewClass(query);
                comboBox1.DataSource = vc.showrecord();
                comboBox1.DisplayMember = "ex_name";
                comboBox1.ValueMember = "set_exam_id";

                comboBox1.Enabled = true;
                button1.Enabled = true;

                MetroFramework.MetroMessageBox.Show(this, "Login successful", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Login successful! But no exam is assigned.");
                string query = "SELECT * FROM set_exam se JOIN exam e ON se.ex_id_fk = e.ex_id WHERE std_id_fk = '" + user + "'";
                ViewClass vc = new ViewClass(query);
                comboBox1.DataSource = vc.showrecord();
                try
                {
                    comboBox1.DisplayMember = "ex_name";
                    comboBox1.ValueMember = "set_exam_id";
                }
                catch(Exception ex)
                {
                    comboBox1.ValueMember = null;
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select an exam.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Student ID missing.");
                return;
            }

            try
            {
                string examId = comboBox1.SelectedValue.ToString();
                int studentId = int.Parse(textBox4.Text);
                string checkAttempted = returnClass.scalarReturn($"select count(*) from score where fk_set_ex_id = {examId}");
                if (checkAttempted.Equals("0"))
                {
                    var form = new Test(examId, studentId);
                    this.Hide();
                    form.FormClosed += (s, args) => this.Show();
                    form.Show();
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "You have already attempted this exam!! Select another exam", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.TabStop = false;
            label1.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
