using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevApp.Device;
using DevApp.Model;

namespace DevApp
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FmNewDev fmNewDev = new FmNewDev();
            fmNewDev.ShowDialog();
        }

        private void รายการอปกรณลาสดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmDeviceList fmDeviceList = new FmDeviceList();
            fmDeviceList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void เพมขอมลToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmNewDev fmNewDev = new FmNewDev();
            fmNewDev.ShowDialog();
        }

        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var obj = db.tb_User.Where(f => f.User_id == PublicVal.LoginID).SingleOrDefault();
                toolStripStatusLabel1.Text = "User Login : "+obj.Usr_name + " " + obj.Usr_lname + "[" + obj.Position + "]";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FmDevMove fmDevMove = new FmDevMove();
            fmDevMove.Show();
        }
    }
}
