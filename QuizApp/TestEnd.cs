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
    public partial class TestEnd : BaseForm
    {
        int score;
        int noOFQ;
        public TestEnd(int score, int noOFQ)
        {
            InitializeComponent();
            this.score = score;
            this.noOFQ = noOFQ;
        }

        private void TestEnd_Load(object sender, EventArgs e)
        {
            
            
            label1.Text = "Score : " + score + " / " + noOFQ;
        }
    }
}
