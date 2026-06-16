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
    public partial class seeResults : BaseForm
    {
        public seeResults()
        {
            InitializeComponent();
        }

        private void seeResults_Load(object sender, EventArgs e)
        {
            string q = "select std.std_id as Std_ID, std.std_name as Std_Name, e.ex_name as Exam, s.score as Score, s.percentage as Percentage from score s join set_exam se on s.fk_set_ex_id = se.set_exam_id join student std on se.std_id_fk = std.std_id join exam e on se.ex_id_fk = e.ex_id\r\n";
            ViewClass vc = new ViewClass(q);
            DataTable dt = vc.showrecord();

            metroListView1.Clear(); 
            
            foreach (DataColumn col in dt.Columns)
            {
                metroListView1.Columns.Add(col.ColumnName, 120);
            }

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                metroListView1.Items.Add(item);
            }
    }
    }
}
