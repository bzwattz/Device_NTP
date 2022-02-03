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
                    label26.Text = Data.Dev_Spec;
                    label27.Text = CU.GET_MainType(Convert.ToInt32(Data.Type_id));
                    label28.Text = CU.GET_SubType(Convert.ToInt32(Data.ST_ID));

                        //CU.GET_StatusName(Convert.ToInt32(Data.Dev_S_ID));
                    //switch (Data.Dev_S_ID)
                    //{
                    //    case 1:label27.BackColor = Color.
                    //};

                }
            }
        }
    }
}
