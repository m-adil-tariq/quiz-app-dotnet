using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace QuizApp
{
    public partial class delExam : BaseForm
    {
        public delExam()
        {
            InitializeComponent();
        }

        private void delExam_Load(object sender, EventArgs e)
        {
            string q = "select * from exam";
            ViewClass vc1 = new ViewClass(q);
            metroComboBox1.DataSource = vc1.showrecord();
            metroComboBox1.DisplayMember = "ex_name";
            metroComboBox1.ValueMember = "ex_id";

            q = "select * from exam ";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exam.del_exam(int.Parse(metroComboBox1.SelectedValue.ToString()));
            MetroFramework.MetroMessageBox.Show(this, "Exam, its related Exam Assignments, Questions and Results Deleted Successfully", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string q = "select * from exam";
            ViewClass vc1 = new ViewClass(q);
            metroComboBox1.DataSource = vc1.showrecord();
            metroComboBox1.DisplayMember = "ex_name";
            metroComboBox1.ValueMember = "ex_id";


            q = "select * from exam ";
            ViewClass vc = new ViewClass(q);
            metroGrid1.DataSource = vc.showrecord();
        }
    }
}
