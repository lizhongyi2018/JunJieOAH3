using System;
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
    public class LeaveWeb
    {

        public string GetSchema(string schemaCode)
        {
            string strSchemaJson = string.Empty;
            BizStructureSchema stockschema = new BizStructureSchema();
            switch (schemaCode)
            {
                case "HR_Leave_ValidationInfo":

                    stockschema.Code = schemaCode;
                    stockschema.Add(new H3.BizBus.ItemSchema("ValidationInfo", "验证信息", BizDataType.String));
                    strSchemaJson = BizStructureUtility.SchemaToJson(stockschema);
                    break;

                case "HR_Leave_Edit":
                    stockschema.Code = schemaCode;

                    stockschema.Add(new H3.BizBus.ItemSchema("Parent_ObjectId", "父对象编号", BizDataType.String, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("SeqNo", "请假单号", BizDataType.String, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("ProxyBy", "代理人", BizDataType.String, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("UrgentTelephone", "紧急联系电话", BizDataType.String, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("LeaveHour", "请假总小时数", BizDataType.Double, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("Remark", "请假调休原因", BizDataType.String, 1000, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("IsConstrain", "受7天内填写限制", BizDataType.Bool, 200, null));

                    H3.BizBus.BizStructureSchema detailsSchema = new H3.BizBus.BizStructureSchema();
                    detailsSchema.Add(new H3.BizBus.ItemSchema("ObjectId", "子对象编号", BizDataType.String, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EmpNo", "员工编号", BizDataType.String, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("LeaveTypeAutokey", "请假类型", BizDataType.Int, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("BeginDateTime", "开始日期", BizDataType.DateTime, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EndDateTime", "结束日期", BizDataType.DateTime, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("LeaveHour", "请假小时", BizDataType.Double, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("BecomeDueDateTime", "超期邮件提醒日期", BizDataType.DateTime, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("BeginDateTimeHour", "开始日期所在年占小时", BizDataType.Double, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EndDateTimeHour", "结束日期所在年占小时", BizDataType.Double, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyPassDate", "保安放行日期", BizDataType.DateTime, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBy", "保安工号", BizDataType.String, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBackFactorDate", "保安回厂日期", BizDataType.DateTime, 200, null));
                    detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBackFactorBy", "保安回厂工号", BizDataType.String, 200, null));
                    stockschema.Add(new H3.BizBus.ItemSchema("details", "明细", BizDataType.BizStructureArray, detailsSchema));//子表添加到主表
                    strSchemaJson = BizStructureUtility.SchemaToJson(stockschema);
                    break;

                default:
                    strSchemaJson = string.Empty;
                    break;

            }
            return strSchemaJson;
        }
        
        public string GetList(string userCode, string schemaCode, string filter)
        {
            H3.BizBus.BizStructureSchema schema = null;
            string errorMessage = string.Empty;
            BizStructureUtility.JsonToSchema(GetSchema(schemaCode), out schema, out errorMessage);
            ListResult listResult = null;
            string sql = string.Empty;
            string sqlCount = string.Empty;
            string strWhere = " where 1=1 ";
            DataTable dt = new DataTable();
            List<BizStructure> listBizStructure = new List<BizStructure>();

            int number = 1;  //页码
            int size = 10;   //每页条数
            int lowNumber = size * (number - 1);

            Filter filterValue = BizStructureUtility.JsonToFilter(filter);
            int FromRowNum = filterValue.FromRowNum; //起始条数
            int ToRowNum = filterValue.ToRowNum;//结束条数
            bool RequireCount = filterValue.RequireCount;

            size = ToRowNum - FromRowNum;
            number = (FromRowNum / size) + 1;
            lowNumber = size * (number - 1);

            Matcher matcher = filterValue.Matcher; //过滤条件
            SortBy[] sortByCollection = filterValue.SortByCollection;//排序

            //提取所有的条件，也可以自己根据filter的格式，自己构造
            Dictionary<string, string> matcherKeyValues = CustomExpand.MatcherToDictionary(matcher);
            switch (schemaCode)
            {

                case "HR_Leave_ValidationInfo":

                    string ObjectId = matcherKeyValues["ObjectId"].ToString().Trim();
                    string EmpNo = matcherKeyValues["EmpNo"].ToString().Trim();
                    string BeginDateTime = matcherKeyValues["BeginDateTime"].ToString().Trim();
                    string EndDateTime = matcherKeyValues["EndDateTime"].ToString().Trim();
                    string ValidationInfo = "";

                    SqlConnection cn = new SqlConnection(DataBase.PatData);
                    cn.Open();
                    try
                    {


                        SqlCommand cm = cn.CreateCommand(); cm.CommandTimeout = 9999999;
                        cm.CommandTimeout = 9999999;
                        cm.CommandType = CommandType.Text;
                        string sql1 = string.Format(@"execute Proc_Attendance_Leave_Get_ValidationInfo 
'{0}'
,'{1}'
,'{2}'
,'{3}'", ObjectId, EmpNo, BeginDateTime, EndDateTime);
                        cm.CommandText = sql1;

                        ValidationInfo = cm.ExecuteScalar().ToString();



                        SqlCommand cm2 = cn.CreateCommand();
                        cm2.CommandTimeout = 9999999;
                        cm2.CommandTimeout = 9999999;
                        cm2.CommandType = CommandType.Text;
                        cm2.CommandText = string.Format(@"INSERT INTO [Jj_CY_CYDebug]
           ([CYDebugName]
           ,[CYDebugDateTime])
     VALUES
           ('{0'
           ,'{1}')
GO", "a", sql1);
                        cm2.ExecuteNonQuery();



                    }
                    catch (System.Exception ex)
                    {
                        //throw ex;
                    }
                    finally
                    {
                        cn.Close();
                    }

                    BizStructure LeavebizStructure1 = new H3.BizBus.BizStructure(schema);
                    LeavebizStructure1["ValidationInfo"] = JsonMgr.StringToJson(ValidationInfo);  //机构名称
                    listBizStructure.Add(LeavebizStructure1);
                    break;
                default:
                    break;
            }
            int dataCount = 0;
            dataCount = listBizStructure.Count;

            if (listBizStructure.Count > 0)
            {
                listResult = new H3.BizBus.ListResult(0, "获取数据成功", listBizStructure.ToArray(), dataCount);
            }
            return BizStructureUtility.ListResultToJson(listResult);
        }

        public string Invoke(string userCode, string schemaCode, string methodName, string param)
        {
            string returnResult = null;
            if (schemaCode == "HR_Leave_Edit")
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
                                Parent_CM.CommandText = string.Format(@"Proc_Attendance_Leave_Del_Web_FromH3OA");
                                Parent_CM.Parameters.AddWithValue("@mainid", billBizStructure["Parent_ObjectId"].ToString());
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
                                stockschema.Add(new H3.BizBus.ItemSchema("SeqNo", "请假单号", BizDataType.String, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("ProxyBy", "代理人", BizDataType.String, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("UrgentTelephone", "紧急联系电话", BizDataType.String, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("LeaveHour", "请假总小时数", BizDataType.Double, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("Remark", "请假调休原因", BizDataType.String, 1000, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("IsConstrain", "受7天内填写限制", BizDataType.Bool, 200, null));

                                stockschema.Add(new H3.BizBus.ItemSchema("CreatedBy", "新增人", BizDataType.String, 1000, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("CreatedTime", "新增时间", BizDataType.DateTime, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("ModifiedTime", "修改时间", BizDataType.DateTime, 200, null));
                                stockschema.Add(new H3.BizBus.ItemSchema("ConfirmedFlag", "确认状态", BizDataType.String, 200, null));


                                H3.BizBus.BizStructureSchema detailsSchema = new H3.BizBus.BizStructureSchema();
                                detailsSchema.Add(new H3.BizBus.ItemSchema("ObjectId", "子对象编号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EmpNo", "员工编号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("LeaveTypeAutokey", "请假类型", BizDataType.Int, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("BeginDateTime", "开始日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EndDateTime", "结束日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("LeaveHour", "请假小时", BizDataType.Double, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("BecomeDueDateTime", "超期邮件提醒日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("BeginDateTimeHour", "开始日期所在年占小时", BizDataType.Double, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EndDateTimeHour", "结束日期所在年占小时", BizDataType.Double, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyPassDate", "保安放行日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyPassTime", "保安放行时间", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBy", "保安工号", BizDataType.String, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBackFactorDate", "保安回厂日期", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBackFactorTime", "保安回厂时间", BizDataType.DateTime, 200, null));
                                detailsSchema.Add(new H3.BizBus.ItemSchema("EnsureSafetyBackFactorBy", "保安回厂工号", BizDataType.String, 200, null));

                                stockschema.Add(new H3.BizBus.ItemSchema("details", "明细", BizDataType.BizStructureArray, detailsSchema));//子表添加到主表

                                BizStructure billBizStructure = new BizStructure(stockschema);
                                BizStructureUtility.JsonToStructure(param, billBizStructure, out errorMessage);

                                // string billsCustomer = billBizStructure["BillsCustomer"] + string.Empty;


                                SqlCommand Parent_CM = cn.CreateCommand();
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.CommandTimeout = 9999999;
                                Parent_CM.Transaction = tran;
                                Parent_CM.CommandType = CommandType.StoredProcedure;
                                Parent_CM.CommandText = string.Format(@"Proc_Attendance_Leave_Del_Web_FromH3OA");
                                Parent_CM.Parameters.AddWithValue("@mainid", billBizStructure["Parent_ObjectId"].ToString());
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
                                    cm.CommandText = string.Format(@"Proc_Attendance_Leave_New_Web_FromH3OA");
                                    cm.Parameters.AddWithValue("@id", detailsDatas[i]["ObjectId"].ToString());
                                    cm.Parameters.AddWithValue("@mainid", billBizStructure["Parent_ObjectId"].ToString());
                                    string LeaveID = Guid.NewGuid().ToString();
                                    cm.Parameters.AddWithValue("@LeaveID", LeaveID);
                                    cm.Parameters.AddWithValue("@LeaveKey", DBNull.Value);
                                    cm.Parameters.AddWithValue("@LeaveNo", DBNull.Value);
                                    cm.Parameters.AddWithValue("@LeaveDepartmentCode", DBNull.Value);
                                    cm.Parameters.AddWithValue("@EmpNo", detailsDatas[i]["EmpNo"]);

                                    cm.Parameters.AddWithValue("@BeginDateTime", detailsDatas[i]["BeginDateTime"]);
                                    cm.Parameters.AddWithValue("@EndDateTime", detailsDatas[i]["EndDateTime"]);
                                    cm.Parameters.AddWithValue("@LeaveTypeAutokey", detailsDatas[i]["LeaveTypeAutokey"]);
                                    cm.Parameters.AddWithValue("@LeaveHour", detailsDatas[i]["LeaveHour"]);


                                    if (detailsDatas[i]["BecomeDueDateTime"] != null)
                                    {
                                        cm.Parameters.AddWithValue("@BecomeDueDateTime", detailsDatas[i]["BecomeDueDateTime"]);//
                                    }
                                    else
                                    {
                                        cm.Parameters.AddWithValue("@BecomeDueDateTime", DBNull.Value);//
                                    }



                                    if (detailsDatas[i]["BeginDateTimeHour"] != null)
                                    {
                                        cm.Parameters.AddWithValue("@BeginDateTimeHour", detailsDatas[i]["BeginDateTimeHour"]);//
                                    }
                                    else
                                    {
                                        cm.Parameters.AddWithValue("@BeginDateTimeHour", 0);//
                                    }

                                    if (detailsDatas[i]["EndDateTimeHour"] != null)
                                    {
                                        cm.Parameters.AddWithValue("@EndDateTimeHour", detailsDatas[i]["EndDateTimeHour"]);//
                                    }
                                    else
                                    {
                                        cm.Parameters.AddWithValue("@EndDateTimeHour", 0);//
                                    }



                                    if (detailsDatas[i]["EnsureSafetyPassDate"] != null)
                                    {
                                        string EnsureSafetyPassDate = "";
                                        EnsureSafetyPassDate = detailsDatas[i]["EnsureSafetyPassDate"].ToString().Trim().Split(' ')[0];
                                        if (detailsDatas[i]["EnsureSafetyPassTime"] != null)
                                        {
                                            DateTime EnsureSafetyPassTime = DateTime.Parse(detailsDatas[i]["EnsureSafetyPassTime"].ToString().Trim());
                                            EnsureSafetyPassDate = EnsureSafetyPassDate + " " + EnsureSafetyPassTime.Hour.ToString() + ":" + EnsureSafetyPassTime.Minute.ToString();
                                        }
                                        cm.Parameters.AddWithValue("@EnsureSafetyPassDate", EnsureSafetyPassDate);
                                    }
                                    else
                                    {
                                        cm.Parameters.AddWithValue("@EnsureSafetyPassDate", DBNull.Value);//
                                    }

                                    cm.Parameters.AddWithValue("@EnsureSafetyBy", detailsDatas[i]["EnsureSafetyBy"]);

                                    if (detailsDatas[i]["EnsureSafetyBackFactorDate"] != null)
                                    {
                                        string EnsureSafetyBackFactorDate = "";
                                        EnsureSafetyBackFactorDate = detailsDatas[i]["EnsureSafetyBackFactorDate"].ToString().Trim().Split(' ')[0];

                                        if (detailsDatas[i]["EnsureSafetyBackFactorTime"] != null)
                                        {
                                            DateTime EnsureSafetyBackFactorTime = DateTime.Parse(detailsDatas[i]["EnsureSafetyBackFactorTime"].ToString().Trim());
                                            EnsureSafetyBackFactorDate = EnsureSafetyBackFactorDate + " " + EnsureSafetyBackFactorTime.Hour.ToString() + ":" + EnsureSafetyBackFactorTime.Minute.ToString();
                                        }

                                        cm.Parameters.AddWithValue("@EnsureSafetyBackFactorDate", EnsureSafetyBackFactorDate);
                                    }
                                    else
                                    {
                                        cm.Parameters.AddWithValue("@EnsureSafetyBackFactorDate", DBNull.Value);//
                                    }

                                    cm.Parameters.AddWithValue("@EnsureSafetyBackFactorBy", detailsDatas[i]["EnsureSafetyBackFactorBy"]);
                                    cm.Parameters.AddWithValue("@ProxyBy", billBizStructure["ProxyBy"]);
                                    cm.Parameters.AddWithValue("@UrgentTelephone", billBizStructure["UrgentTelephone"]);
                                    cm.Parameters.AddWithValue("@RequestBy", billBizStructure["CreatedBy"]);
                                    cm.Parameters.AddWithValue("@RequestDate", billBizStructure["CreatedTime"]);
                                    cm.Parameters.AddWithValue("@Remark", billBizStructure["Remark"]);
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