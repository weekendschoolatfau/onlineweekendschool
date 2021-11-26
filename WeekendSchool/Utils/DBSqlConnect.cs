using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace onlineweekendschool.WeekendSchool.Utils
{
    public class DBSqlConnect
    {
        public DBSqlConnect()
        {

        }

        public SqlConnection getSqlConnection()
        {
            string tppConStr = ConfigurationManager.AppSettings["ConWeekendSchool"]; 
            SqlConnection dbConn = new SqlConnection(tppConStr);
            return dbConn;
        }

    }
}