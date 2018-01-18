using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace H3.BizBus
{
    [Serializable()]
    public class DataBase
    {
        public static string PatData
        {
            get
            {
                string PatDataStr = "";
                PatDataStr = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3};Pooling=true; MAX Pool Size=512;Min Pool Size=50;Connection Lifetime=30;", ConfigurationManager.AppSettings["DataSource"].ToString(), ConfigurationManager.AppSettings["ErpDataBaseName"].ToString(), ConfigurationManager.AppSettings["UserID"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
                return PatDataStr;
            }
        }

    }
}