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
    public partial class FmNewDev : Form
    {
        public FmNewDev()
        {
            InitializeComponent();
        }
        private Cs_Utility CU = new Cs_Utility();
        private void button1_Click(object sender, EventArgs e)
        {
            var nowDate = DateTime.Now;
            tb_Device dataModel = new tb_Device()
            {               
                Dev_SN = txtSN.Text,
                Dev_Name = txtName.Text,
                Dev_Model = txtModel.Text,
                Dev_Brand = txtBrand.Text,
                Dev_Spec = txtDetails.Text,
                Dev_Price = Convert.ToDecimal(txtPrice.Text),
                Date_IN = nowDate,
                Warn_Start = dtStart.Value.Date,
                Warn_End = dtEnd.Value.Date,
                Dev_Note = txtNote.Text,
                Dev_NTP_Key = "No Key",
                User_id = 1,// 1 Default User System
                Dev_S_ID = Convert.ToInt32(cbStatus.SelectedValue),
                Dep_id = cbDepart.SelectedValue.ToString(),
                branch_id = Convert.ToInt32(cbBranch.SelectedValue),
                Type_id = Convert.ToInt32(cbType.SelectedValue),
                ST_ID = Convert.ToInt32(cbSub_Type.SelectedValue),
                Des_Date = nowDate
            };
            var Data = CU.AddDevice(dataModel);
            if (Data == true)
            {
                MessageBox.Show("ทำรายการสำเร็จ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void FmNewDev_Load(object sender, EventArgs e)
        {
            //Fill CbType 
            //Fill Combobox /usertype
            DevAppModel context = new DevAppModel();
            var ds = context.tb_Type.ToArray();
            cbType.DataSource = ds;
            cbType.ValueMember = "Type_id";
            cbType.DisplayMember = "Type_name";

            //Fill CbsubType 
            //Fill Combobox /usertype
            DevAppModel context1 = new DevAppModel();
            var ds1 = context.tb_Sub_Type.ToArray();
            cbSub_Type.DataSource = ds1;
            cbSub_Type.ValueMember = "ST_ID";
            cbSub_Type.DisplayMember = "ST_Name";

            //Fill Combobox /usertype
            DevAppModel context2 = new DevAppModel();
            var ds2 = context2.tb_Dev_Status.ToArray();
            cbStatus.DataSource = ds2;
            cbStatus.ValueMember = "Dev_S_ID";
            cbStatus.DisplayMember = "Dev_Status";

            //Fill Combobox /usertype
            DevAppModel context3 = new DevAppModel();
            var ds3 = context3.tb_Department.ToArray();
           cbDepart.DataSource = ds3;
            cbDepart.ValueMember = "Dep_id";
            cbDepart.DisplayMember = "Dep_name";

            //Fill Combobox /usertype
            DevAppModel context4 = new DevAppModel();
            var ds4 = context3.tb_Branch.ToArray();
            cbBranch.DataSource = ds4;
            cbBranch.ValueMember = "branch_id";
            cbBranch.DisplayMember = "branch_name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
