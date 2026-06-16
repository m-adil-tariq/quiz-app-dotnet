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
    public partial class addAdmin : BaseForm
    {
        public addAdmin()
        {
            InitializeComponent();
        }

        private void addAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Admin(this, textBox3.Text, textBox4.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
