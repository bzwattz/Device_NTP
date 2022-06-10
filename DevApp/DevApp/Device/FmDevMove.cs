using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevApp.Device
{
    public partial class FmDevMove : MetroFramework.Forms.MetroForm
    {
        public FmDevMove()
        {
            InitializeComponent();
        }

        private void FmDevMove_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Message","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
