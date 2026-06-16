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
    public partial class DelStudent : BaseForm
    {
        public DelStudent()
        {
            InitializeComponent();
        }

        private void DelStudent_Load(object sender, EventArgs e)
        {
            metroComboBox2.Enabled = false;
            button1.Enabled = false;

            string q = "select std_id as Std_ID, std_name as Std_Name, std_batchcode as Std_BatchCode from student";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            q = "select distinct std_batchcode from student";
            ViewClass vc1 = new ViewClass(q);
            metroComboBox1.DataSource = vc1.showrecord();
            metroComboBox1.DisplayMember = "std_batchcode";
            metroComboBox1.ValueMember = "std_batchcode";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string q = "select * from student where std_batchcode = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            metroComboBox2.DataSource = vc3.showrecord();
            metroComboBox2.DisplayMember = "std_name";
            metroComboBox2.ValueMember = "std_id";

            q = "select std_id as Std_ID, std_name as Std_Name, std_batchcode as Std_BatchCode from student where std_batchcode = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            metroComboBox2.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student.del_student(int.Parse(metroComboBox2.SelectedValue.ToString()));
            MetroFramework.MetroMessageBox.Show(this, "Student, its related Exam Assignments and Results Deleted Successfully", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);


            string q = "select * from student where std_batchcode = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            metroComboBox2.DataSource = vc3.showrecord();
            metroComboBox2.DisplayMember = "std_name";
            metroComboBox2.ValueMember = "std_id";


            q = "select std_id as Std_ID, std_name as Std_Name, std_batchcode as Std_BatchCode from student where std_batchcode = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
