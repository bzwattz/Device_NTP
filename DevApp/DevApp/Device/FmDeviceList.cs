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
using DevApp.Device;

namespace DevApp.Device
{
    public partial class FmDeviceList : Form
    {
        public FmDeviceList()
        {
            InitializeComponent();
        }
        int RowIndex;
        decimal TotalVal;
        private Cs_Utility CU = new Cs_Utility();
        private void FmDeviceList_Load(object sender, EventArgs e)
        {
            gridData.Columns.Add("A0","DevID");
            gridData.Columns.Add("A1", "ชื่อ");
            gridData.Columns.Add("A6", "Serial Number");
            gridData.Columns.Add("A2", "ราคา");
            gridData.Columns.Add("A3", "สถานะ");
            gridData.Columns.Add("A4", "แผนก");
            gridData.Columns.Add("A5", "สาขา");
            

            gridData.Columns[0].Width = 80;
            gridData.Columns[1].Width = 200;
            gridData.Columns[2].Width = 150;
            gridData.Columns[3].Width = 100;
            gridData.Columns[4].Width = 100;
            gridData.Columns[5].Width = 120;
            gridData.Columns[6].Width = 150;

            for (int i =0;i<7;i++)
            {
                gridData.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
            gridData.Columns["A2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridData.Columns["A0"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridData.Columns["A3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridData.Columns["A4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridData.Columns["A5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridData.Columns["A6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            using (DevAppModel DA = new DevAppModel())
            {
                var DeviceList = DA.tb_Device.OrderByDescending(f=>f.Dev_id).Take(500).ToList();
                if (DeviceList != null)
                {
                    gridData.Rows.Clear();
                    foreach (var item in DeviceList)
                    {
                        gridData.Rows.Add();
                        gridData.Rows[RowIndex].Cells[0].Value = item.Dev_id;
                        gridData.Rows[RowIndex].Cells[1].Value = item.Dev_Name;
                        gridData.Rows[RowIndex].Cells[2].Value = item.Dev_SN;
                        gridData.Rows[RowIndex].Cells[3].Value = Convert.ToDecimal(item.Dev_Price).ToString("#,##0.##");
                        gridData.Rows[RowIndex].Cells[4].Value = CU.GET_StatusName(Convert.ToInt32(item.Dev_S_ID));
                        gridData.Rows[RowIndex].Cells[5].Value = CU.GET_DepartName(item.Dep_id);
                        var data = CU.GET_BranchData(Convert.ToInt32(item.branch_id));
                        gridData.Rows[RowIndex].Cells[6].Value = data[0];
                        RowIndex += 1;
                        TotalVal = TotalVal + Convert.ToDecimal(item.Dev_Price);
                    }
                    RowIndex = 0;
                    label1.Text = "จำนวนทั้งหมด : "+(gridData.Rows.Count - 1).ToString()+ " รายการ";
                    label2.Text = "มูลค่ารวม : "+TotalVal.ToString("#,##0.##") +" บาท";
                    TotalVal = 0;
                }
            }
        }
        void Search_Data(string InputSN)
        {
            gridData.Rows.Clear();
            using (DevAppModel DA = new DevAppModel())
            {
                var DeviceList = DA.tb_Device.Where(f=>f.Dev_SN.Contains(InputSN)).ToList(); // Mean = Like
                if (DeviceList != null)
                {
                    foreach (var item in DeviceList)
                    {
                        gridData.Rows.Add();
                        gridData.Rows[RowIndex].Cells[0].Value = item.Dev_id;
                        gridData.Rows[RowIndex].Cells[1].Value = item.Dev_Name;
                        gridData.Rows[RowIndex].Cells[2].Value = item.Dev_SN;
                        gridData.Rows[RowIndex].Cells[3].Value = Convert.ToDecimal(item.Dev_Price).ToString("#,##0.##");
                        gridData.Rows[RowIndex].Cells[4].Value = CU.GET_StatusName(Convert.ToInt32(item.Dev_S_ID));
                        gridData.Rows[RowIndex].Cells[5].Value = CU.GET_DepartName(item.Dep_id);
                        var data = CU.GET_BranchData(Convert.ToInt32(item.branch_id));
                        gridData.Rows[RowIndex].Cells[6].Value = data[0];
                        RowIndex += 1;
                        TotalVal = TotalVal + Convert.ToDecimal(item.Dev_Price);
                    }
                    RowIndex = 0;
                    label1.Text = "จำนวนทั้งหมด : " + (gridData.Rows.Count - 1).ToString() + " รายการ";
                    label2.Text = "มูลค่ารวม : " + TotalVal.ToString("#,##0.##") + " บาท";
                    TotalVal = 0;
                }
            }
        }
        void Search_Data_N(string DevName)
        {
            gridData.Rows.Clear();
            using (DevAppModel DA = new DevAppModel())
            {
                var DeviceList = DA.tb_Device.Where(f => f.Dev_Name.Contains(DevName)).ToList(); // Mean = Like
                if (DeviceList != null)
                {
                    foreach (var item in DeviceList)
                    {
                        gridData.Rows.Add();
                        gridData.Rows[RowIndex].Cells[0].Value = item.Dev_id;
                        gridData.Rows[RowIndex].Cells[1].Value = item.Dev_Name;
                        gridData.Rows[RowIndex].Cells[2].Value = item.Dev_SN;
                        gridData.Rows[RowIndex].Cells[3].Value = Convert.ToDecimal(item.Dev_Price).ToString("#,##0.##");
                        gridData.Rows[RowIndex].Cells[4].Value = CU.GET_StatusName(Convert.ToInt32(item.Dev_S_ID));
                        gridData.Rows[RowIndex].Cells[5].Value = CU.GET_DepartName(item.Dep_id);
                        var data = CU.GET_BranchData(Convert.ToInt32(item.branch_id));
                        gridData.Rows[RowIndex].Cells[6].Value = data[0];
                        RowIndex += 1;
                        TotalVal = TotalVal + Convert.ToDecimal(item.Dev_Price);
                    }
                    RowIndex = 0;
                    label1.Text = "จำนวนทั้งหมด : " + (gridData.Rows.Count - 1).ToString() + " รายการ";
                    label2.Text = "มูลค่ารวม : " + TotalVal.ToString("#,##0.##") + " บาท";
                    TotalVal = 0;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void gridData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PublicVal.DevID = Convert.ToInt32(gridData.CurrentRow.Cells[0].Value);
            FmDevDetails fmDevDetails = new FmDevDetails();
            fmDevDetails.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ckName.Checked == true)
            {
                Search_Data_N(txtSN.Text);

            }else if (ckSN.Checked == true)
            {
               
                Search_Data(txtSN.Text);
            }
            
        }

        private void ckName_CheckedChanged(object sender, EventArgs e)
        {
            if (ckName.Checked == true)
            {
                ckSN.Checked = false;
                txtSN.Text = "";
            }
            else
            {

            }
        }

        private void ckSN_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSN.Checked ==true)
            {
                ckName.Checked = false;
                txtSN.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DevAppModel DA = new DevAppModel())
            {
                var DeviceList = DA.tb_Device.OrderByDescending(f => f.Dev_id).Take(1000).ToList();
                if (DeviceList != null)
                {
                    gridData.Rows.Clear();
                    foreach (var item in DeviceList)
                    {
                        gridData.Rows.Add();
                        gridData.Rows[RowIndex].Cells[0].Value = item.Dev_id;
                        gridData.Rows[RowIndex].Cells[1].Value = item.Dev_Name;
                        gridData.Rows[RowIndex].Cells[2].Value = item.Dev_SN;
                        gridData.Rows[RowIndex].Cells[3].Value = Convert.ToDecimal(item.Dev_Price).ToString("#,##0.##");
                        gridData.Rows[RowIndex].Cells[4].Value = CU.GET_StatusName(Convert.ToInt32(item.Dev_S_ID));
                        gridData.Rows[RowIndex].Cells[5].Value = CU.GET_DepartName(item.Dep_id);
                        var data = CU.GET_BranchData(Convert.ToInt32(item.branch_id));
                        gridData.Rows[RowIndex].Cells[6].Value = data[0];
                        RowIndex += 1;
                        TotalVal = TotalVal + Convert.ToDecimal(item.Dev_Price);
                    }
                    RowIndex = 0;
                    label1.Text = "จำนวนทั้งหมด : " + (gridData.Rows.Count - 1).ToString() + " รายการ";
                    label2.Text = "มูลค่ารวม : " + TotalVal.ToString("#,##0.##") + " บาท";
                    TotalVal = 0;
                }
            }
        }
    }
}
