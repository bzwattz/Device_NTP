using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DevApp.Model;

namespace DevApp
{
    public class Cs_Utility
    {
        public bool AddDevice(tb_Device dataModel)
        {
            bool result = false;
            using (TransactionScope tran1 = new TransactionScope())
            {
                using (DevAppModel context = new DevAppModel())
                {
                    try
                    {
                        context.tb_Device.Add(dataModel);
                        context.SaveChanges();
                        tran1.Complete();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        result = true;
                        context.Database.Connection.Close();
                        context.Dispose();
                        tran1.Dispose();
                    }
                }
            }
            return result;
        }
        public bool DeleteDevice(int KeyID)
        {
            bool Result = false;
            using (TransactionScope tran1 = new TransactionScope())
            {
                using (DevAppModel context = new DevAppModel())
                {
                    try
                    {
                        var item = context.tb_Device.Where(f => f.Dev_id == KeyID).SingleOrDefault();
                        if (item != null)
                        {
                            context.tb_Device.Remove(item);
                            context.SaveChanges();
                            tran1.Complete();
                        }
                        
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        Result = true;
                        context.Database.Connection.Close();
                        context.Dispose();
                        tran1.Dispose();
                    }
                }
            }
            return Result;
        }
        public bool ModifyDevice(tb_Device dataModel)
        {
            bool Result = false;
            using (TransactionScope tran1 = new TransactionScope())
            {
                using (DevAppModel context = new DevAppModel())
                {
                    try
                    {
                        var item = context.tb_Device.Where(f => f.Dev_id == dataModel.Dev_id).SingleOrDefault();
                        if (item != null)
                        {
                            tb_Device data = new tb_Device()
                            {
                                Dev_id = dataModel.Dev_id,
                                Dev_SN = dataModel.Dev_SN,
                                Dev_Name = dataModel.Dev_Name,
                                Dev_Model = dataModel.Dev_Model,
                                Dev_Brand = dataModel.Dev_Brand,
                                Dev_Spec = dataModel.Dev_Spec,
                                Dev_Price = dataModel.Dev_Price,
                                Date_IN = dataModel.Date_IN,
                                Warn_Start = dataModel.Warn_Start,
                                Warn_End = dataModel.Warn_End,
                                Dev_Note = dataModel.Dev_Note,
                                Dev_NTP_Key = dataModel.Dev_NTP_Key,
                                User_id = dataModel.User_id,
                                Dev_S_ID = dataModel.Dev_S_ID,
                                Dep_id = dataModel.Dep_id,
                                branch_id = dataModel.branch_id,
                                Type_id = dataModel.Type_id,
                                ST_ID = dataModel.ST_ID,
                                Des_Date = dataModel.Des_Date
                            };
                        }
                        context.SaveChanges();
                        tran1.Complete();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        Result = true;
                        context.Database.Connection.Close();
                        context.Dispose();
                        tran1.Dispose();
                    }
                }
            }
            return Result;
        }
        string Str_Status;
        public string GET_StatusName(int Status_ID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var data = db.tb_Dev_Status.Where(f => f.Dev_S_ID == Status_ID).SingleOrDefault();
                Str_Status = data.Dev_Status;
            }
                return Str_Status;
        }
        string Str_Depart;
        public string GET_DepartName(string Depart_ID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var data = db.tb_Department.Where(f => f.Dep_id == Depart_ID).SingleOrDefault();
                Str_Depart = data.Dep_name;
            }
                return Str_Depart;
        }
        string[] Str_Branch = new string[2];
        public string[] GET_BranchData(int BR_ID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var data = db.tb_Branch.Where(f => f.branch_id == BR_ID).SingleOrDefault();
                Str_Branch[0] = data.branch_name;
                Str_Branch[1] = data.branch_addr;
            }
                return Str_Branch;
        }
        string Str_Type;
        public string GET_MainType(int typeID)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var data = db.tb_Type.Where(f => f.Type_id == typeID).SingleOrDefault();
                Str_Type = data.Type_name;
            }
            return Str_Type;
        }
        string Str_Sub_Type;
        public string GET_SubType(int typeIDr)
        {
            using (DevAppModel db = new DevAppModel())
            {
                var data = db.tb_Sub_Type.Where(f =>f.ST_ID == typeIDr).SingleOrDefault();
                Str_Sub_Type = data.ST_Name;
            }
            return Str_Sub_Type;
        }
        
    }
}
