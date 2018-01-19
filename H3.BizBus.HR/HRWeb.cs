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
    public class HRWeb
    {
        public static string GetSchema(string schemaCode)
        {
            string strSchemaJson = string.Empty;
            string[] schemaCodeList = schemaCode.Split('_');
            string schemaCode2 = schemaCodeList[0] + "_" + schemaCodeList[1];
            switch (schemaCode2)
            {
                case "HR_Leave":

                    LeaveWeb LeaveWebObj = new LeaveWeb();
                    strSchemaJson = LeaveWebObj.GetSchema(schemaCode);
                    break;
                default:
                    strSchemaJson = string.Empty;
                    break;
            }
            return strSchemaJson;
        }

        public static string GetList(string userCode, string schemaCode, string filter)
        {
            string listResult = null;
            string[] schemaCodeList = schemaCode.Split('_');
            string schemaCode2 = schemaCodeList[0] + "_" + schemaCodeList[1];
            switch (schemaCode2)
            {
                case "HR_Leave":

                    LeaveWeb LeaveWebObj = new LeaveWeb();
                    listResult = LeaveWebObj.GetList(userCode, schemaCode, filter);
                    break;
                default:
                    listResult = string.Empty;
                    break;
            }
            return listResult;

        }


        public static string Invoke(string userCode, string schemaCode, string methodName, string param)
        {
            string returnResult = null;
            string[] schemaCodeList = schemaCode.Split('_');
            string schemaCode2 = schemaCodeList[0] + "_" + schemaCodeList[1];
            switch (schemaCode2)
            {
                case "HR_Leave":

                    LeaveWeb LeaveWebObj = new LeaveWeb();
                    returnResult = LeaveWebObj.Invoke(userCode, schemaCode, methodName, param);
                    break;
                case "HR_AttendanceData":

                    AttendanceDataWeb AttendanceDataWebObj = new AttendanceDataWeb();
                    returnResult = AttendanceDataWebObj.Invoke(userCode, schemaCode, methodName, param);
                    break;
                case "HR_RegOvertime":

                    RegOvertimeWeb RegOvertimeWebObj = new RegOvertimeWeb();
                    returnResult = RegOvertimeWebObj.Invoke(userCode, schemaCode, methodName, param);
                    break;
                case "HR_ChangeClass":

                    ChangeClassWeb ChangeClassWebObj = new ChangeClassWeb();
                    returnResult = ChangeClassWebObj.Invoke(userCode, schemaCode, methodName, param);
                    break;
                case "HR_BusinessReport":

                    BusinessReportWeb BusinessReportWebObj = new BusinessReportWeb();
                    returnResult = BusinessReportWebObj.Invoke(userCode, schemaCode, methodName, param);
                    break;
                default:
                    returnResult = string.Empty;
                    break;
            }
            return returnResult;
        }


    }
}