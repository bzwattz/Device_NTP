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
    public partial class FmDevDetails : Form
    {
        public FmDevDetails()
        {
            InitializeComponent();
        }
        private Cs_Utility CU = new Cs_Utility();
        private PublicVal PV = new PublicVal();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FmDevDetails_Load(object sender, EventArgs e)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var Data = db.tb_Device.Where(f => f.Dev_id == PublicVal.DevID).SingleOrDefault();
                if (Data != null)
                {
                    label18.Text = Data.Dev_SN;
                    label19.Text = Data.Dev_Name;
                    label20.Text = Data.Dev_Model;
                    label21.Text = Data.Dev_Brand;
                    label22.Text = Convert.ToDecimal(Data.Dev_Price).ToString("#,##0.##") + " บาท";
                    label23.Text = Convert.ToDateTime(Data.Date_IN).ToString("d/MM/yyyy");
                    label24.Text = Convert.ToDateTime(Data.Warn_Start).ToString("d/MM/yyyy");
                    label25.Text = Convert.ToDateTime(Data.Warn_End).ToString("d/MM/yyyy");
                    txtDetails.Text = Data.Dev_Spec;
                    label27.Text = CU.GET_MainType(Convert.ToInt32(Data.Type_id));
                    label28.Text = CU.GET_SubType(Convert.ToInt32(Data.ST_ID));
                    label29.Text = CU.GET_StatusName(Convert.ToInt32(Data.Dev_S_ID));
                    switch (Convert.ToInt32(Data.Dev_S_ID))
                    {
                        case 1 :
                            label29.ForeColor = Color.White;
                            label29.BackColor = Color.Green;
                            break;
                        case 2:
                            label29.ForeColor = Color.White;
                            label29.BackColor = Color.Red;
                            break;
                        case 3:
                            label29.ForeColor = Color.White;
                            label29.BackColor = Color.YellowGreen;
                            break;
                        case 4:
                            label29.ForeColor = Color.White;
                            label29.BackColor = Color.Blue;
                            break;
                        case 5:
                            label29.ForeColor = Color.White;
                            label29.BackColor = Color.Gray;
                            break;
                    };
                    label30.Text = CU.GET_DepartName(Convert.ToString(Data.Dep_id));
                    var Ex = CU.GET_BranchData(Convert.ToInt32(Data.branch_id));
                    label32.Text = Ex[0];
                    label31.Text = Data.Dev_NTP_Key;
                    txtNote.Text = Data.Dev_Note;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            FmDevEdit fmDevEdit = new FmDevEdit();
            fmDevEdit.ShowDialog();
        }
    }
}
