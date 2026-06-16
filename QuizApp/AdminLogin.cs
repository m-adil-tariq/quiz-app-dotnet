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
    public partial class AdminLogin : BaseForm
    {
        public string fk_ad;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox4.Text;
            string password = textBox3.Text;
            string userdb, passworddb;

            userdb = returnClass.scalarReturn("select count(ad_id) from admin_auth where ad_user='" + user + "'");


            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid user name!");
            }
            else
            {
                passworddb = returnClass.scalarReturn("select ad_password from admin_auth where ad_user='" + user + "'");

                if (passworddb.Equals(password))
                {
                    Admin a = new Admin(userdb, passworddb);
                    //fk_ad = returnClass.scalarReturn("select ad_id from admin_auth where ad_user='" + user + "'");

                    //var form = new Form2(int.Parse(fk_ad));
                    var form = new Form2(a);
                    this.Hide();
                    form.FormClosed += (s, args) => this.Show();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password!");
                }
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.TabStop = false;    
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
