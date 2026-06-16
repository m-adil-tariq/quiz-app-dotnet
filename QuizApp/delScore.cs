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
    public partial class delScore : BaseForm
    {
        public delScore()
        {
            InitializeComponent();
        }

        private void delScore_Load(object sender, EventArgs e)
        {
            string q = "select s.score_id As [Score ID], s.score as Score,st.std_name as Student, e.ex_name as Exam, se.set_exam_id as[Assignment ID] from score s join set_exam se on s.fk_set_ex_id = se.set_exam_id join student st on se.std_id_fk = st.std_id join exam e on se.ex_id_fk = e.ex_id";

            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            ViewClass vc1 = new ViewClass(q);
            DataTable dt = vc1.showrecord();

            if (dt != null && dt.Rows.Count > 0)
            {
                metroComboBox1.DataSource = dt;
                metroComboBox1.DisplayMember = "Score ID";
                metroComboBox1.ValueMember = "Score ID";
            }
            else
            {
                metroComboBox1.DataSource = null;
                metroComboBox1.Items.Clear();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            score.del_score(int.Parse(metroComboBox1.SelectedValue.ToString()));
            MetroFramework.MetroMessageBox.Show(this, "Score Deleted Successfully", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string q = "select s.score_id As [Score ID], s.score as Score,st.std_name as Student, e.ex_name as Exam, se.set_exam_id as[Assignment ID] from score s join set_exam se on s.fk_set_ex_id = se.set_exam_id join student st on se.std_id_fk = st.std_id join exam e on se.ex_id_fk = e.ex_id";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();

            metroComboBox1.DataSource = vc.showrecord();
            metroComboBox1.DisplayMember = "Score ID";
            metroComboBox1.ValueMember = "Score ID";
        }
    }
}
