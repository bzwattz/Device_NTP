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
        private Cs_Utility cU = new Cs_Utility();
        private void FmDevEdit_Load(object sender, EventArgs e)
        {
           Get_Dev_Stat(PublicVal.DevID);
            //get maintype
            using (DevAppModel context = new DevAppModel())
            {
                var ds1 = context.tb_Type.ToArray();
                cbMainType.DataSource = ds1;
                cbMainType.ValueMember = "Type_id";
                cbMainType.DisplayMember = "Type_name";
            }
            //get sub type            
            using (DevAppModel db_subtype = new DevAppModel())
            {
                var ds1 = db_subtype.tb_Sub_Type.ToArray();
                cbSubType.DataSource = ds1;
                cbSubType.ValueMember = "ST_ID";
                cbSubType.DisplayMember = "ST_Name";
            }
            //get status            
            using (DevAppModel db_status = new DevAppModel())
            {
                var ds1 = db_status.tb_Dev_Status.ToArray();
                cbDevStatus.DataSource = ds1;
                cbDevStatus.ValueMember = "Dev_S_ID";
                cbDevStatus.DisplayMember = "Dev_Status";
            }
            //get depart            
            using (DevAppModel db_depart = new DevAppModel())
            {
                var ds1 = db_depart.tb_Department.ToArray();
                cbDepart.DataSource = ds1;
                cbDepart.ValueMember = "Dep_id";
                cbDepart.DisplayMember = "Dep_name";
            }
            //get branch           
            using (DevAppModel db_branch = new DevAppModel())
            {
                var ds1 = db_branch.tb_Branch.ToArray();
                cbBranch.DataSource = ds1;
                cbBranch.ValueMember = "branch_id";
                cbBranch.DisplayMember = "branch_name";
            }

        }
        void Get_Dev_Stat(int DevID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var item = db.tb_Device.Where(d => d.Dev_id == DevID).SingleOrDefault();
                if (item != null)
                {
                    txtSN.Text = item.Dev_SN;
                    txtName.Text = item.Dev_Name;
                    txtModel.Text = item.Dev_Model;
                    txtBrand.Text = item.Dev_Brand;
                    txtPrice.Text = Convert.ToDecimal(item.Dev_Price).ToString("#,##0.##");
                    dtDateIn.Value = Convert.ToDateTime(item.Date_IN);
                    dtWarn_Start.Value = Convert.ToDateTime(item.Warn_Start);
                    dtWarn_End.Value = Convert.ToDateTime(item.Warn_End);
                    txtDetails.Text = item.Dev_Spec;
                    cbMainType.Text = cU.GET_MainType(Convert.ToInt32(item.Type_id));
                    cbSubType.Text = cU.GET_SubType(Convert.ToInt32(item.ST_ID));
                    cbDevStatus.Text = cU.GET_StatusName(Convert.ToInt32(item.Dev_S_ID));
                    cbDepart.Text = cU.GET_DepartName(Convert.ToString(item.Dep_id));
                    var br_data = cU.GET_BranchData(Convert.ToInt32(item.branch_id));
                    cbBranch.Text = br_data[0];
                    txtNTPKey.Text = item.Dev_NTP_Key;
                    txtNote.Text = item.Dev_Note;
                }                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_Device DV = new tb_Device()
            {
                Dev_id = PublicVal.DevID,
                Dev_SN = txtSN.Text,
                Dev_Name = txtName.Text,
                Dev_Model = txtModel.Text,
                Dev_Brand = txtBrand.Text,
                Dev_Spec = txtDetails.Text,
                Dev_Price = Convert.ToDecimal(txtPrice.Text),
                Date_IN = dtDateIn.Value.Date,
                Warn_Start = dtWarn_Start.Value.Date,
                Warn_End = dtWarn_End.Value.Date,
                Dev_Note = txtNote.Text,
                Dev_NTP_Key = txtNTPKey.Text,
                User_id = PublicVal.LoginID,
                Dep_id = cbDepart.SelectedValue.ToString(),
                branch_id = Convert.ToInt32(cbBranch.SelectedValue),
                Type_id = Convert.ToInt32(cbBranch.SelectedValue),
                ST_ID = Convert.ToInt32(cbSubType.SelectedValue),
                Dev_S_ID = Convert.ToInt32(cbDevStatus.SelectedValue),
                Des_Date = DateTime.Now
            };
            var result = cU.ModifyDevice(DV);
            if (result == true)
            {
                MessageBox.Show("บันทึกสำเร็จ","message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbMainType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var SelectVal = Convert.ToInt32(cbMainType.SelectedValue);
            DevAppModel context1 = new DevAppModel();
            var ds1 = context1.tb_Sub_Type.Where(f => f.Type_id == SelectVal).ToArray();
            cbSubType.DataSource = ds1;
            cbSubType.ValueMember = "ST_ID";
            cbSubType.DisplayMember = "ST_Name";
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
