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
    public partial class delQuestion : BaseForm
    {
        public delQuestion()
        {
            InitializeComponent();
        }

        private void delQuestion_Load(object sender, EventArgs e)
        {
            metroComboBox2.Enabled = false;
            button1.Enabled = false;

            string q = "select q.q_id as ID, q.q_title as Title, e.ex_name as Exam from question q join exam e on q.q_fk_ex = e.ex_id";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            q = "select * from exam";
            ViewClass vc1 = new ViewClass(q);
            metroComboBox1.DataSource = vc1.showrecord();
            metroComboBox1.DisplayMember = "ex_name";
            metroComboBox1.ValueMember = "ex_id";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string q = "select q_id from question where q_fk_ex = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            metroComboBox2.DataSource = vc3.showrecord();
            metroComboBox2.DisplayMember = "q_id";
            metroComboBox2.ValueMember = "q_id";

            q = "select q.q_id as ID, q.q_title as Title, e.ex_name as Exam from question q join exam e on q.q_fk_ex = e.ex_id where e.ex_id = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            metroComboBox2.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            questions.del_q(int.Parse(metroComboBox2.SelectedValue.ToString()));
            MetroFramework.MetroMessageBox.Show(this, "Question Deleted Successfully", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string q = "select q_id from question where q_fk_ex = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc3 = new ViewClass(q);
            metroComboBox2.DataSource = vc3.showrecord();
            metroComboBox2.DisplayMember = "q_id";
            metroComboBox2.ValueMember = "q_id";

            q = "select q.q_id as ID, q.q_title as Title, e.ex_name as Exam from question q join exam e on q.q_fk_ex = e.ex_id where e.ex_id = '" + metroComboBox1.SelectedValue + "'";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();
        }
    }
}
