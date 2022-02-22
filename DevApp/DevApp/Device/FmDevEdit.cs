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

namespace DevApp.Device
{
    public partial class FmDevEdit : Form
    {
        public FmDevEdit()
        {
            InitializeComponent();
        }

        private void FmDevEdit_Load(object sender, EventArgs e)
        {
           Get_Dev_Stat(PublicVal.DevID);
        }
        void Get_Dev_Stat(int DevID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var item = db.tb_Device.Where(d => d.Dev_id == DevID).SingleOrDefault();
                if (item != null)
                {
                    txtSN.Text = item.Dev_SN;
                }
            }
        }
    }
}
