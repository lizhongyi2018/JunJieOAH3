﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using H3.BizBus;

namespace H3.BizBus.HR
{
    public class ChangeClassWeb
    {

        public string Invoke(string userCode, string schemaCode, string methodName, string param)
        {
            string returnResult = null;
            if (schemaCode == "HR_ChangeClass_Edit")
            {
                switch (methodName)
                {
                    case "DeleteData":
                        {
                            string errorMessage = string.Empty;
                            SqlConnection cn = new SqlConnection(DataBase.PatData);
                            cn.Open();
                            SqlTransaction tran = cn.BeginTransaction();
                            string isSuccess = "True";
                            string msg = "处理成功";

                            try
                            {
                                H3.BizBus.BizStructureSchema stockschema = new H3.BizBus.BizStructureSchema();
                                stockschema.Add(new H3.BizBus.ItemSchema("Parent_ObjectId", "父对象编号", BizDataType.String, 200, null));
                                BizStructure billBizStructure = new BizStructure(stockschema);
                                BizStructureUtility.JsonToStructure(param, billBizStructure, out errorMessage);

                                SqlCommand Parent_CM = cn.CreateCommand();
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.Transaction = tran;
                                Parent_CM.CommandType = CommandType.StoredProcedure;
                                Parent_CM.CommandText = string.Format(@"Proc_Attendance_ChangeClass_Del_Web_FromH3OA");
                                Parent_CM.Parameters.AddWithValue("@RefDocumentsHeaderKey", billBizStructure["Parent_ObjectId"].ToString());
                                Parent_CM.ExecuteNonQuery();
                                tran.Commit();
                            }
                            catch (System.Exception ex)
                            {
                                isSuccess = "False";
                                msg = "处理失败:" + MyErrorMesage.GetError(ex.Message, false);
                                tran.Rollback();

                                SqlConnection cn11 = new SqlConnection(DataBase.PatData);
                                cn11.Open();
                                SqlCommand cm11 = cn11.CreateCommand();
                                cm11.CommandTimeout = 9999999;
                                cm11.CommandTimeout = 9999999;
                                cm11.CommandType = CommandType.Text;
                                cm11.CommandText = string.Format(@"INSERT INTO [Jj_CY_CYDebug]
           ([CYDebugName]
           ,[CYDebugDateTime])
     VALUES
           (@CYDebugName
           ,GETDATE()) 
      ");
                                cm11.Parameters.AddWithValue("@CYDebugName", MyErrorMesage.GetError(ex.Message, false));
                                cm11.ExecuteNonQuery();
                                cn11.Close();
                                //throw ex;
                            }
                            finally
                            {
                                cn.Close();
                            }

                            string returnData = "{\"isSuccess\":\"" + isSuccess + "\",\"msg\":\"" + JsonMgr.StringToJson(msg) + "\"}";//, isSuccess, "黎中一");

                            BizStructureSchema returnSchema = new H3.BizBus.BizStructureSchema();
                            returnSchema.Code = DateTime.Now.ToShortDateString();
                            returnSchema.Add(new H3.BizBus.ItemSchema("isSuccess", "是否成功", BizDataType.ShortString, 200, "True1"));
                            returnSchema.Add(new H3.BizBus.ItemSchema("msg", "返回信息", BizDataType.ShortString, 200, "True1"));

                            BizStructure returnBizStructure = new BizStructure(returnSchema);
                            BizStructureUtility.JsonToStructure(returnData, returnBizStructure, out errorMessage);
                            InvokeResult result = new H3.BizBus.InvokeResult(0, "服务器返回成功", returnBizStructure);
                            returnResult = BizStructureUtility.InvokeResultToJson(result);

                        }
                        break;
                    case "InsertData":
                        {
                            //int ddd = int.Parse("dfd");
                            string errorMessage = string.Empty;

                            //BizStructureSchema billSchema = new BizStructureSchema();
                            //BizStructureUtility.JsonToSchema(GetSchema(schemaCode), out billSchema, out errorMessage);
                            //BizStructure billBizStructure = new BizStructure(billSchema);
                            //BizStructureUtility.JsonToStructure(param, billBizStructure, out errorMessage);

                            SqlConnection cn = new SqlConnection(DataBase.PatData);
                            cn.Open();
                            SqlTransaction tran = cn.BeginTransaction();
                            string isSuccess = "True";
                            string msg = "处理成功";

                            try
                            {

                                H3.BizBus.BizStructureSchema stockschema = new H3.BizBus.BizStructureSchema();
                                stockschema.Add(new H3.BizBus.ItemSchema("Parent_ObjectId", "父对象编号", BizDataType.String, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("SeqNo", "转班单号", BizDataType.String, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("Remark", "备注", BizDataType.String, 1000, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("IsConstrain", "受7天内填写限制", BizDataType.Bool, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("CreatedBy", "新增人", BizDataType.String, 1000, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("CreatedTime", "新增时间", BizDataType.DateTime, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("ModifiedTime", "修改时间", BizDataType.DateTime, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("ConfirmedFlag", "确认状态", BizDataType.String, 200, null));


                                H3.BizBus.BizStructureSchema detailsSchema = new H3.BizBus.BizStructureSchema();
                                detailsSchema.Add(new H3.BizBus.ItemSchema("ObjectId", "子对象编号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EmpNo", "员工编号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("BeginDate", "开始日期",BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EndDate", "结束日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("DutyClassID", "目标班次编号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("DetailRemark", "明细备注", BizDataType.String, 1000, null));






                                stockschema.Add(new H3.BizBus.ItemSchema("details", "明细", BizDataType.BizStructureArray, detailsSchema));//子表添加到主表

                                BizStructure billBizStructure = new BizStructure(stockschema);
                                BizStructureUtility.JsonToStructure(param, billBizStructure, out errorMessage);

                                // string billsCustomer = billBizStructure["BillsCustomer"] + string.Empty;


                                SqlCommand Parent_CM = cn.CreateCommand();
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.Transaction = tran;
                                Parent_CM.CommandType = CommandType.StoredProcedure;
                                Parent_CM.CommandText = string.Format(@"Proc_Attendance_ChangeClass_Del_Web_FromH3OA");
                                Parent_CM.Parameters.AddWithValue("@RefDocumentsHeaderKey", billBizStructure["Parent_ObjectId"].ToString());
                                Parent_CM.ExecuteNonQuery();


                                BizStructure[] detailsDatas = (BizStructure[])billBizStructure["details"];
                                int detailsDatasCount = detailsDatas.Length;
                                for (int i = 0; i < detailsDatasCount; i++)
                                {
                                    SqlCommand cm = cn.CreateCommand();
                                    cm.CommandTimeout = 9999999;
                                    cm.CommandTimeout = 9999999;
                                    cm.Transaction = tran;
                                    cm.CommandType = CommandType.StoredProcedure;
                                    cm.CommandText = string.Format(@"Proc_Attendance_ChangeClass_New_Web_FromH3OA");
                                    cm.Parameters.AddWithValue("@id", detailsDatas[i]["ObjectId"].ToString());
                                    cm.Parameters.AddWithValue("@mainid", billBizStructure["Parent_ObjectId"].ToString());
                                    cm.Parameters.AddWithValue("@ChangeClassID", Guid.NewGuid().ToString());
                                    cm.Parameters.AddWithValue("@ChangeClassHeaderKey", DBNull.Value );
                                    cm.Parameters.AddWithValue("@EmpNo", detailsDatas[i]["EmpNo"]);
                                    cm.Parameters.AddWithValue("@BeinDateTime", detailsDatas[i]["BeginDate"]);
                                    cm.Parameters.AddWithValue("@EndDateTime", detailsDatas[i]["EndDate"]);                                    
                                    cm.Parameters.AddWithValue("@AimDutyAutoID", detailsDatas[i]["DutyClassID"]);
                                    cm.Parameters.AddWithValue("@JobClassInstallDetailJobAutoID", 0);
                                    cm.Parameters.AddWithValue("@ProjectManageResponsibleBy", DBNull.Value);
                                    cm.Parameters.AddWithValue("@Remark", detailsDatas[i]["DetailRemark"].ToString() + "来自新H3转班单");
                                    cm.Parameters.AddWithValue("@InsertedBy", billBizStructure["CreatedBy"]);
                                    cm.Parameters.AddWithValue("@InsertedDate", billBizStructure["CreatedTime"]);
                                    cm.Parameters.AddWithValue("@UpdatedBy", billBizStructure["CreatedBy"]);
                                    cm.Parameters.AddWithValue("@UpdatedDate", billBizStructure["CreatedTime"]);
                                    cm.Parameters.AddWithValue("@ConfirmedFlag", billBizStructure["ConfirmedFlag"]);
                                    cm.ExecuteNonQuery();
                                }
                                tran.Commit();
                            }
                            catch (System.Exception ex)
                            {
                                isSuccess = "False";
                                msg = "处理失败:" + MyErrorMesage.GetError(ex.Message, false);
                                tran.Rollback();

                                SqlConnection cn11 = new SqlConnection(DataBase.PatData);
                                cn11.Open();
                                SqlCommand cm11 = cn11.CreateCommand();
                                cm11.CommandTimeout = 9999999;
                                cm11.CommandTimeout = 9999999;
                                cm11.CommandType = CommandType.Text;
                                cm11.CommandText = string.Format(@"INSERT INTO [Jj_CY_CYDebug]
           ([CYDebugName]
           ,[CYDebugDateTime])
     VALUES
           (@CYDebugName
           ,GETDATE()) 
      ");
                                cm11.Parameters.AddWithValue("@CYDebugName", MyErrorMesage.GetError(ex.Message, false));
                                cm11.ExecuteNonQuery();
                                cn11.Close();
                                //throw ex;
                            }
                            finally
                            {
                                cn.Close();
                            }

                            string returnData = "{\"isSuccess\":\"" + isSuccess + "\",\"msg\":\"" + JsonMgr.StringToJson(msg) + "\"}";//, isSuccess, "黎中一");

                            BizStructureSchema returnSchema = new H3.BizBus.BizStructureSchema();
                            returnSchema.Code = DateTime.Now.ToShortDateString();
                            returnSchema.Add(new H3.BizBus.ItemSchema("isSuccess", "是否成功", BizDataType.ShortString, 200, "True1"));
                            returnSchema.Add(new H3.BizBus.ItemSchema("msg", "返回信息", BizDataType.ShortString, 200, "True1"));

                            BizStructure returnBizStructure = new BizStructure(returnSchema);
                            BizStructureUtility.JsonToStructure(returnData, returnBizStructure, out errorMessage);
                            InvokeResult result = new H3.BizBus.InvokeResult(0, "服务器返回成功", returnBizStructure);
                            returnResult = BizStructureUtility.InvokeResultToJson(result);

                        }
                        break;

                    default:
                        break;
                }
            }


            return returnResult;
        }

    }
}
