using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace onlineweekendschool.WeekendSchool.Utils
{
    public class DBUtils
    {
        public DBUtils()
        {
        }

        public static DataSet getStudentAge()
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsStudentAge = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Student_Age", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

               
                //Retrieve Rows
                dsStudentAge = new DataSet();
                SqlDataAdapter daStudentAge = new SqlDataAdapter(cmdOwners);
                daStudentAge.Fill(dsStudentAge, "StudentAge");


            }
            catch (Exception weekendSchoolException)
            {
                throw weekendSchoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsStudentAge;
        }

        public static DataSet getStudentLevel()
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsStudentAge = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Student_Level", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;


                //Retrieve Rows
                dsStudentAge = new DataSet();
                SqlDataAdapter daStudentAge = new SqlDataAdapter(cmdOwners);
                daStudentAge.Fill(dsStudentAge, "StudentLevel");


            }
            catch (Exception weekendSchoolException)
            {
                throw weekendSchoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsStudentAge;
        }

        public static DataSet getStudentPaymentStatus()
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsStudentPaymentStatus = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Student_Payment_Status", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;


                //Retrieve Rows
                dsStudentPaymentStatus = new DataSet();
                SqlDataAdapter daStudentPayment = new SqlDataAdapter(cmdOwners);
                daStudentPayment.Fill(dsStudentPaymentStatus, "StudentPaymentStatus");


            }
            catch (Exception weekendSchoolException)
            {
                throw weekendSchoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsStudentPaymentStatus;
        }


        public static DataSet getDocumentsType()
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsDocumentsType = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Documents_Type", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;


                //Retrieve Rows
                dsDocumentsType = new DataSet();
                SqlDataAdapter daDocumentsType = new SqlDataAdapter(cmdOwners);
                daDocumentsType.Fill(dsDocumentsType, "DocumentsType");


            }
            catch (Exception weekendSchoolException)
            {
                throw weekendSchoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsDocumentsType;
        }




    }
}