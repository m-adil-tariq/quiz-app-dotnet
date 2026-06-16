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
    public partial class AssignExam : BaseForm
    {
        public AssignExam()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AssignExam_Load(object sender, EventArgs e)
        {

            string q = "select std_id as Std_ID, std_name as Std_Name, std_batchcode as Std_BatchCode from student";
            ViewClass vc = new ViewClass(q);
            dataGridView1.DataSource = vc.showrecord();

            q = "select distinct std_batchcode from student";
            ViewClass vc1 = new ViewClass(q);
            comboBox1.DataSource = vc1.showrecord();
            comboBox1.DisplayMember = "std_batchcode";
            comboBox1.ValueMember = "std_batchcode";

            q = "select * from exam";
            ViewClass vc2 = new ViewClass(q);
            comboBox2.DataSource = vc2.showrecord();
            comboBox2.DisplayMember = "ex_name";
            comboBox2.ValueMember = "ex_id";

            q = "select * from student where std_batchcode = '" + comboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            comboBox3.DataSource = vc3.showrecord();
            comboBox3.DisplayMember = "std_name";
            comboBox3.ValueMember = "std_id";

            q = "select se.std_id_fk as Std_ID, s.std_name as Std_Name, s.std_batchcode as Std_BatchCode, e.ex_name as Exam_Name, se.set_exam_date as Exam_Assign_Date from set_exam se join exam e on se.ex_id_fk = e.ex_id join student s on se.std_id_fk = s.std_id";
            ViewClass vc4 = new ViewClass(q);
            dataGridView2.DataSource = vc4.showrecord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select std_id as Std_ID, std_name as Std_Name, std_batchcode as Std_BatchCode from student where std_batchcode = '" + comboBox1.SelectedValue + "'";
            ViewClass vc = new ViewClass(q);
            dataGridView1.DataSource = vc.showrecord();

            q = "select * from student where std_batchcode = '" + comboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            comboBox3.DataSource = vc3.showrecord();
            comboBox3.DisplayMember = "std_name";
            comboBox3.ValueMember = "std_id";
        }
        private void button2_Click(object sender, EventArgs e)
        { 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            student s = new student(int.Parse(comboBox3.SelectedValue.ToString()));
            Exam ex = new Exam(int.Parse(comboBox2.SelectedValue.ToString()));

            new AssignExamClass(this, s, ex);
            string q = "select se.std_id_fk as Std_ID, s.std_name as Std_Name, s.std_batchcode as Std_BatchCode, e.ex_name as Exam_Name, se.set_exam_date as Exam_Assign_Date from set_exam se join exam e on se.ex_id_fk = e.ex_id join student s on se.std_id_fk = s.std_id";
            ViewClass vc = new ViewClass(q);
            dataGridView2.DataSource = vc.showrecord();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
