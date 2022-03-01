using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevApp.Model;

namespace DevApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private Cs_Utility cU = new Cs_Utility();
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (DevAppModel db = new DevAppModel())
            {
                var Usr_Data = db.tb_User.Where(f => f.Login_name == txtUser.Text && f.Pswd == txtPassword.Text).SingleOrDefault();
                if(Usr_Data != null)
                {
                    PublicVal.LoginID = Usr_Data.User_id;
                    FmMain fmMain = new FmMain();
                    fmMain.Show();
                }
                else
                {
                    MessageBox.Show("โปรดตรวจสอบข้อมูลเเล้วลองอีกครั้ง","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                }
            }
                
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
