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
    public partial class delExamAssign : BaseForm
    {
        public delExamAssign()
        {
            InitializeComponent();
        }

        private void delExamAssign_Load(object sender, EventArgs e)
        {

            string q = "select se.set_exam_id as [Assignment ID], s.std_name as Student, e.ex_name as Exam from set_exam se join exam e on se.ex_id_fk = e.ex_id join student s on se.std_id_fk = s.std_id";

            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            q = "select * from set_exam";

            ViewClass vc1 = new ViewClass(q);
            DataTable dt = vc1.showrecord();

            if (dt != null && dt.Rows.Count > 0)
            {
                metroComboBox1.DataSource = dt;
                metroComboBox1.DisplayMember = "set_exam_id";
                metroComboBox1.ValueMember = "set_exam_id";
            }
            else
            {
                metroComboBox1.DataSource = null;
                metroComboBox1.Items.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignExamClass.del_assignexam(int.Parse(metroComboBox1.SelectedValue.ToString()));
            MetroFramework.MetroMessageBox.Show(this, "Exam Assignment and its related Score Deleted Successfully!!", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string q = "select se.set_exam_id as [Assignment ID], s.std_name as Student, e.ex_name as Exam from set_exam se join exam e on se.ex_id_fk = e.ex_id join student s on se.std_id_fk = s.std_id";

            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            q = "select * from set_exam";

            ViewClass vc1 = new ViewClass(q);
            DataTable dt = vc1.showrecord();

            if (dt != null && dt.Rows.Count > 0)
            {
                metroComboBox1.DataSource = dt;
                metroComboBox1.DisplayMember = "set_exam_id";
                metroComboBox1.ValueMember = "set_exam_id";
            }
            else
            {
                metroComboBox1.DataSource = null;
                metroComboBox1.Items.Clear();
            }
        }
    }
}
