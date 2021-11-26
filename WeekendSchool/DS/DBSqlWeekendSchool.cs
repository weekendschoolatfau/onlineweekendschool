using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;

using System.Data.SqlClient;
using onlineweekendschool.WeekendSchool.Props;
using onlineweekendschool.WeekendSchool.Utils;


namespace onlineweekendschool.WeekendSchool.DS
{
    public class DBSqlWeekendSchool
    {

        public DBSqlWeekendSchool()
        {

        }


        public static LoginInformationProps getUserLoginInformation(string email, string password)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            LoginInformationProps loginObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Parent_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmByEmail = cmdOwners.Parameters.Add("p_email", SqlDbType.NVarChar, 100);
                prmByEmail.Direction = ParameterDirection.Input;
                if ((email != null) && (!email.Trim().Equals("")))
                    prmByEmail.Value = email.ToUpper();
                else
                    prmByEmail.Value = DBNull.Value;

                SqlParameter prmByPassword = cmdOwners.Parameters.Add("p_password", SqlDbType.NVarChar, 50);
                prmByPassword.Direction = ParameterDirection.Input;
                if ((password != null) && (!password.Trim().Equals("")))
                    prmByPassword.Value = password;
                else
                    prmByPassword.Value = DBNull.Value;

                SqlDataReader parentRdr = cmdOwners.ExecuteReader();

                if (parentRdr.Read())
                {
                    loginObj = new LoginInformationProps();
                    loginObj.ParentId = Convert.ToInt32(parentRdr["PARENT_ID"]);
                    loginObj.UserName = Convert.ToString(parentRdr["USERNAME"]);
                    loginObj.Email = Convert.ToString(parentRdr["EMAIL"]);
                    loginObj.FirstName = Convert.ToString(parentRdr["FIRST_NAME"]);
                    loginObj.LastName = Convert.ToString(parentRdr["LAST_NAME"]);
                    loginObj.Phone = Convert.ToString(parentRdr["PHONE_NUMBER"]);
                }
            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

            return loginObj;
        }


        public static LoginInformationProps isParentExist(string email, string username)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            LoginInformationProps loginObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Is_Parent_Exist", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmByEmail = cmdOwners.Parameters.Add("p_email", SqlDbType.NVarChar, 100);
                prmByEmail.Direction = ParameterDirection.Input;
                if ((email != null) && (!email.Trim().Equals("")))
                    prmByEmail.Value = email.ToUpper();
                else
                    prmByEmail.Value = DBNull.Value;

                SqlParameter prmByPassword = cmdOwners.Parameters.Add("p_username", SqlDbType.NVarChar, 50);
                prmByPassword.Direction = ParameterDirection.Input;
                if ((username != null) && (!username.Trim().Equals("")))
                    prmByPassword.Value = username;
                else
                    prmByPassword.Value = DBNull.Value;


                SqlDataReader parentRdr = cmdOwners.ExecuteReader();

                if (parentRdr.Read())
                {
                    loginObj = new LoginInformationProps();
                    loginObj.UserName = Convert.ToString(parentRdr["USERNAME"]);
                    loginObj.Email = Convert.ToString(parentRdr["EMAIL"]);
                    loginObj.FirstName = Convert.ToString(parentRdr["FIRST_NAME"]);
                    loginObj.LastName = Convert.ToString(parentRdr["LAST_NAME"]);
                    loginObj.Phone = Convert.ToString(parentRdr["PHONE_NUMBER"]);

                    bool usernameExists = false;

                    if ((loginObj.UserName != null)&& (loginObj.UserName.Trim().ToUpper().Equals(username.Trim().ToUpper())))
                    {
                        usernameExists = true;
                        loginObj.Status = "Username already exists";
                    }

                    if ((loginObj.UserName != null) && (loginObj.UserName.Trim().ToUpper().Equals(username.Trim().ToUpper())))
                    {
                        if (usernameExists)
                            loginObj.Status = loginObj.Status + " and ";

                        loginObj.Status = loginObj.Status + " Email Address already exists ";
                    }
                }


            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

            return loginObj;

        }

        public static LoginInformationProps addNewParent(LoginInformationProps parentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            LoginInformationProps subscriberObj = null;



            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Add_New_Parent", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUserName = cmdOwners.Parameters.Add("p_username", SqlDbType.NVarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                if ((parentObj.UserName != null) && (!parentObj.UserName.Trim().Equals("")))
                    prmUserName.Value = parentObj.UserName.Trim().ToUpper();
                else
                    prmUserName.Value = DBNull.Value;

                SqlParameter prmByEmail = cmdOwners.Parameters.Add("p_email", SqlDbType.NVarChar, 100);
                prmByEmail.Direction = ParameterDirection.Input;
                if ((parentObj.Email != null) && (!parentObj.Email.Trim().Equals("")))
                    prmByEmail.Value = parentObj.Email.Trim().ToUpper();
                else
                    prmByEmail.Value = DBNull.Value;

                SqlParameter prmPassword = cmdOwners.Parameters.Add("p_password", SqlDbType.NVarChar, 50);
                prmPassword.Direction = ParameterDirection.Input;
                if ((parentObj.Password != null) && (!parentObj.Password.Trim().Equals("")))
                    prmPassword.Value = parentObj.Password.Trim().ToUpper();
                else
                    prmPassword.Value = DBNull.Value;

                SqlParameter prmFirstName = cmdOwners.Parameters.Add("p_firstname", SqlDbType.NVarChar, 50);
                prmFirstName.Direction = ParameterDirection.Input;
                if ((parentObj.FirstName != null) && (!parentObj.FirstName.Trim().Equals("")))
                    prmFirstName.Value = parentObj.FirstName.Trim().ToUpper();
                else
                    prmFirstName.Value = DBNull.Value;

                SqlParameter prmLastName = cmdOwners.Parameters.Add("p_lastname", SqlDbType.NVarChar, 50);
                prmLastName.Direction = ParameterDirection.Input;
                if ((parentObj.LastName != null) && (!parentObj.LastName.Trim().Equals("")))
                    prmLastName.Value = parentObj.LastName.Trim().ToUpper();
                else
                    prmLastName.Value = DBNull.Value;

                SqlParameter prmPhone = cmdOwners.Parameters.Add("p_phone", SqlDbType.NVarChar, 20);
                prmPhone.Direction = ParameterDirection.Input;
                if ((parentObj.Phone != null) && (!parentObj.Phone.Trim().Equals("")))
                    prmPhone.Value = parentObj.Phone.Trim();
                else
                    prmPhone.Value = DBNull.Value;

                SqlParameter prmPreferredContact = cmdOwners.Parameters.Add("p_preferredcontact", SqlDbType.NVarChar, 1);
                prmPreferredContact.Direction = ParameterDirection.Input;
                if ((parentObj.PreferrredContact != null) && (!parentObj.PreferrredContact.Equals("")))
                    prmPreferredContact.Value = parentObj.PreferrredContact;
                else
                    prmPreferredContact.Value = DBNull.Value;

                SqlParameter prmSecurityQuestion = cmdOwners.Parameters.Add("p_securityquestion", SqlDbType.Int, 1);
                prmSecurityQuestion.Direction = ParameterDirection.Input;
                if ((parentObj.SecurityQuestion != null) && (!parentObj.SecurityQuestion.Equals("")))
                    prmSecurityQuestion.Value = parentObj.SecurityQuestion;
                else
                    prmSecurityQuestion.Value = DBNull.Value;

                SqlDataReader parentRdr = cmdOwners.ExecuteReader();

                if (parentRdr.Read())
                {
                    subscriberObj = new LoginInformationProps();
                    subscriberObj.ParentId = Convert.ToInt32(parentRdr["Parent_Id"]);
                    subscriberObj.UserName = Convert.ToString(parentRdr["USERNAME"]);
                    subscriberObj.Email = Convert.ToString(parentRdr["EMAIL"]);
                    subscriberObj.FirstName = Convert.ToString(parentRdr["FIRST_NAME"]);
                    subscriberObj.LastName = Convert.ToString(parentRdr["LAST_NAME"]);
                    subscriberObj.Phone = Convert.ToString(parentRdr["PHONE_NUMBER"]);
                    subscriberObj.AccountCreated = Convert.ToString(parentRdr["ACCOUNT_CREATED_DATE"]);

                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

           
            return subscriberObj;
        }

        public static void updateParentInformation(LoginInformationProps parentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Update_Parent_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = parentObj.ParentId;
              

                SqlParameter prmUserName = cmdOwners.Parameters.Add("p_username", SqlDbType.NVarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                if ((parentObj.UserName != null) && (!parentObj.UserName.Trim().Equals("")))
                    prmUserName.Value = parentObj.UserName.Trim().ToUpper();
                else
                    prmUserName.Value = DBNull.Value;

                SqlParameter prmByEmail = cmdOwners.Parameters.Add("p_email", SqlDbType.NVarChar, 100);
                prmByEmail.Direction = ParameterDirection.Input;
                if ((parentObj.Email != null) && (!parentObj.Email.Trim().Equals("")))
                    prmByEmail.Value = parentObj.Email.Trim().ToUpper();
                else
                    prmByEmail.Value = DBNull.Value;


                SqlParameter prmFirstName = cmdOwners.Parameters.Add("p_firstname", SqlDbType.NVarChar, 50);
                prmFirstName.Direction = ParameterDirection.Input;
                if ((parentObj.FirstName != null) && (!parentObj.FirstName.Trim().Equals("")))
                    prmFirstName.Value = parentObj.FirstName.Trim().ToUpper();
                else
                    prmFirstName.Value = DBNull.Value;

                SqlParameter prmLastName = cmdOwners.Parameters.Add("p_lastname", SqlDbType.NVarChar, 50);
                prmLastName.Direction = ParameterDirection.Input;
                if ((parentObj.LastName != null) && (!parentObj.LastName.Trim().Equals("")))
                    prmLastName.Value = parentObj.LastName.Trim().ToUpper();
                else
                    prmLastName.Value = DBNull.Value;

                SqlParameter prmPhone = cmdOwners.Parameters.Add("p_phone", SqlDbType.NVarChar, 20);
                prmPhone.Direction = ParameterDirection.Input;
                if ((parentObj.Phone != null) && (!parentObj.Phone.Trim().Equals("")))
                    prmPhone.Value = parentObj.Phone.Trim();
                else
                    prmPhone.Value = DBNull.Value;


                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


          
        }

        public static LoginInformationProps IsUsernameOrEmailExists(string username, string email,  int parentId)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            LoginInformationProps loginObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Parent_Information_ById", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmByUsername = cmdOwners.Parameters.Add("p_username", SqlDbType.NVarChar, 50);
                prmByUsername.Direction = ParameterDirection.Input;
                if ((username != null) && (!username.Trim().Equals("")))
                    prmByUsername.Value = username.ToUpper();
                else
                    prmByUsername.Value = DBNull.Value;

                SqlParameter prmByEmail = cmdOwners.Parameters.Add("p_email", SqlDbType.NVarChar, 100);
                prmByEmail.Direction = ParameterDirection.Input;
                if ((email != null) && (!email.Trim().Equals("")))
                    prmByEmail.Value = email.ToUpper();
                else
                    prmByEmail.Value = DBNull.Value;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = parentId;
 
                SqlDataReader parentRdr = cmdOwners.ExecuteReader();

                if (parentRdr.Read())
                {
                    loginObj = new LoginInformationProps();
                    loginObj.ParentId = Convert.ToInt32(parentRdr["PARENT_ID"]);
                    loginObj.UserName = Convert.ToString(parentRdr["USERNAME"]);
                    loginObj.Email = Convert.ToString(parentRdr["EMAIL"]);
                    loginObj.FirstName = Convert.ToString(parentRdr["FIRST_NAME"]);
                    loginObj.LastName = Convert.ToString(parentRdr["LAST_NAME"]);
                    loginObj.Phone = Convert.ToString(parentRdr["PHONE_NUMBER"]);
                }
            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

            return loginObj;
        }



        public static List<StudentInformationProps> addNewStudents(StudentInformationProps studentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<StudentInformationProps> studentsList = new List<StudentInformationProps>();
            StudentInformationProps newStudentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Add_New_Student", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = studentObj.ParentId;



                SqlParameter prmFirstName = cmdOwners.Parameters.Add("p_firstname", SqlDbType.NVarChar, 50);
                prmFirstName.Direction = ParameterDirection.Input;
                if ((studentObj.FirstName != null) && (!studentObj.FirstName.Trim().Equals("")))
                    prmFirstName.Value = studentObj.FirstName.Trim().ToUpper();
                else
                    prmFirstName.Value = DBNull.Value;

                SqlParameter prmLastName = cmdOwners.Parameters.Add("p_lastname", SqlDbType.NVarChar, 50);
                prmLastName.Direction = ParameterDirection.Input;
                if ((studentObj.LastName != null) && (!studentObj.LastName.Trim().Equals("")))
                    prmLastName.Value = studentObj.LastName.Trim().ToUpper();
                else
                    prmLastName.Value = DBNull.Value;

                SqlParameter prmAge = cmdOwners.Parameters.Add("p_age", SqlDbType.Int, 2);
                prmAge.Direction = ParameterDirection.Input;
                prmAge.Value = studentObj.Age;

                SqlParameter prmLevel = cmdOwners.Parameters.Add("p_level", SqlDbType.Int, 2);
                prmLevel.Direction = ParameterDirection.Input;
                prmLevel.Value = studentObj.Level;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = studentObj.EnrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                if (studentRdr.Read())
                {
                    newStudentObj = new StudentInformationProps();
                    newStudentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    newStudentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    newStudentObj.FirstName = Convert.ToString(studentRdr["FIRST_NAME"]);
                    newStudentObj.LastName = Convert.ToString(studentRdr["LAST_NAME"]);
                    newStudentObj.Age = Convert.ToInt32(studentRdr["AGE"]);
                    newStudentObj.Level = Convert.ToInt32(studentRdr["LEVEL"]);
                    newStudentObj.EnrollementYear = Convert.ToInt32(studentRdr["ENROLLMENT_YEAR"]);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return studentsList;
        }


        public static List<StudentInformationProps> getStudentsInformation(Int32 parentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<StudentInformationProps> studentsList = new List<StudentInformationProps>();
            StudentInformationProps newStudentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Add_New_Student", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = parentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                if (studentRdr.Read())
                {
                    newStudentObj = new StudentInformationProps();
                    newStudentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    newStudentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    newStudentObj.FirstName = Convert.ToString(studentRdr["FIRST_NAME"]);
                    newStudentObj.LastName = Convert.ToString(studentRdr["LAST_NAME"]);
                    newStudentObj.Age = Convert.ToInt32(studentRdr["AGE"]);
                    newStudentObj.Level = Convert.ToInt32(studentRdr["LEVEL"]);
                    newStudentObj.EnrollementYear = Convert.ToInt32(studentRdr["ENROLLMENT_YEAR"]);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return studentsList;
        }

        public static DataSet getStudentsList(Int32 parentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsStudentsList = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Students_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = parentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;


                //Retrieve Rows
                dsStudentsList = new DataSet();
                SqlDataAdapter daStudentList = new SqlDataAdapter(cmdOwners);
                daStudentList.Fill(dsStudentsList, "StudentsList");


            }
            catch (Exception pbisException)
            {
                throw pbisException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsStudentsList;
        }

        public static void deleteStudentInformation(Int32 studentId)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Delete_Students_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentId;

                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

        }


        public static void updateStudentInformation(StudentInformationProps studentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<StudentInformationProps> studentsList = new List<StudentInformationProps>();
          

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Update_Student_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentObj.StudentId;

                SqlParameter prmFirstName = cmdOwners.Parameters.Add("p_firstname", SqlDbType.NVarChar, 50);
                prmFirstName.Direction = ParameterDirection.Input;
                if ((studentObj.FirstName != null) && (!studentObj.FirstName.Trim().Equals("")))
                    prmFirstName.Value = studentObj.FirstName.Trim().ToUpper();
                else
                    prmFirstName.Value = DBNull.Value;

                SqlParameter prmLastName = cmdOwners.Parameters.Add("p_lastname", SqlDbType.NVarChar, 50);
                prmLastName.Direction = ParameterDirection.Input;
                if ((studentObj.LastName != null) && (!studentObj.LastName.Trim().Equals("")))
                    prmLastName.Value = studentObj.LastName.Trim().ToUpper();
                else
                    prmLastName.Value = DBNull.Value;

                SqlParameter prmAge = cmdOwners.Parameters.Add("p_age", SqlDbType.Int, 2);
                prmAge.Direction = ParameterDirection.Input;
                prmAge.Value = studentObj.Age;

                SqlParameter prmLevel = cmdOwners.Parameters.Add("p_level", SqlDbType.Int, 2);
                prmLevel.Direction = ParameterDirection.Input;
                prmLevel.Value = studentObj.Level;

                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }
        }

        public static StudentInformationProps getStudentInformation(Int32 studentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
           
            StudentInformationProps newStudentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Student_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = studentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                if (studentRdr.Read())
                {
                    newStudentObj = new StudentInformationProps();
                    newStudentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    newStudentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    newStudentObj.FirstName = Convert.ToString(studentRdr["FIRST_NAME"]);
                    newStudentObj.LastName = Convert.ToString(studentRdr["LAST_NAME"]);
                    newStudentObj.Age = Convert.ToInt32(studentRdr["AGE"]);
                    newStudentObj.Level = Convert.ToInt32(studentRdr["LEVEL"]);
                    newStudentObj.EnrollementYear = Convert.ToInt32(studentRdr["ENROLLMENT_YEAR"]);

                    if (studentRdr["PAYMENT_PLAN"] != DBNull.Value)
                        newStudentObj.PaymentPlan = Convert.ToInt32(studentRdr["PAYMENT_PLAN"]);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return newStudentObj;
        }


        public static List<TuitionByLevelProps> getTuitionByLevel( Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<TuitionByLevelProps> tuitionList = new List<TuitionByLevelProps>();
            TuitionByLevelProps tuitionObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Tuition_By_Level", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                while (studentRdr.Read())
                {
                    tuitionObj = new TuitionByLevelProps();
                    tuitionObj.LevelId = Convert.ToInt32(studentRdr["Level_id"]);
                    tuitionObj.TuitionFee= Convert.ToDecimal(studentRdr["Tuition_Fee"]);
                    tuitionObj.TShirtPrice = Convert.ToDecimal(studentRdr["T-Shirt_Price"]);
                    tuitionObj.BookPrice = Convert.ToDecimal(studentRdr["Book_Price"]);

                    tuitionList.Add(tuitionObj);

                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return tuitionList;
        }


        public static List<PaymentInformationProps> getPaymentsInformation(Int32 studentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<PaymentInformationProps> paymentsList = new List<PaymentInformationProps>();
            PaymentInformationProps paymentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Payments_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                while (studentRdr.Read())
                {
                    paymentObj = new PaymentInformationProps();
                    paymentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    paymentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    paymentObj.EnrollementYear = Convert.ToInt32(studentRdr["ENROLLMENT_YEAR"]);
                    paymentObj.PaymentPlan = Convert.ToInt32(studentRdr["PAYMENT_PLAN"]);
                    paymentObj.PaymentDate = Convert.ToString(studentRdr["PAYMENT_DATE"]);
                    paymentObj.SchoolPeriod = Convert.ToInt32(studentRdr["SCHOOL_PERIOD"]);
                    paymentObj.Tuition = Convert.ToDecimal("0"+studentRdr["TUITION"]);
                    paymentObj.TShirt = Convert.ToDecimal("0" + studentRdr["T_SHIRT"]);
                    paymentObj.Books = Convert.ToDecimal("0" + studentRdr["BOOKS"]);
                    paymentObj.PaymentType = Convert.ToInt32("0" + studentRdr["PAYMENT_TYPE"]);
                    paymentObj.TotalPaymentToPay = Convert.ToDecimal("0" + studentRdr["TOTAL_AMOUNT_DUE"]);
                    paymentObj.TotalPaymentPayed = Convert.ToDecimal("0" + studentRdr["TOTAL_AMOUNT_PAYED"]);
                    paymentObj.TotalPaymentRemaining = Convert.ToDecimal("0" + studentRdr["REMAINING"]);

                    paymentsList.Add(paymentObj);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return paymentsList;
        }


        public static void addPaymentInformation(PaymentInformationProps paymentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<PaymentInformationProps> studentsList = new List<PaymentInformationProps>();


            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Add_Payment_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = paymentObj.StudentId;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = paymentObj.ParentId;

                SqlParameter prmSchoolPeriod = cmdOwners.Parameters.Add("p_schoolperiodId", SqlDbType.Int,1);
                prmSchoolPeriod.Direction = ParameterDirection.Input;
                prmSchoolPeriod.Value = paymentObj.SchoolPeriod;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int,4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = paymentObj.EnrollementYear;

                SqlParameter prmPaymentPlan = cmdOwners.Parameters.Add("p_paymentplain", SqlDbType.Int, 1);
                prmPaymentPlan.Direction = ParameterDirection.Input;
                prmPaymentPlan.Value = paymentObj.PaymentPlan;

                SqlParameter prmTuition = cmdOwners.Parameters.Add("p_tuition", SqlDbType.Decimal);
                prmTuition.Direction = ParameterDirection.Input;
                prmTuition.Value = paymentObj.Tuition;

                SqlParameter prmTShirt = cmdOwners.Parameters.Add("p_tshirt", SqlDbType.Decimal);
                prmTShirt.Direction = ParameterDirection.Input;
                prmTShirt.Value = paymentObj.TShirt;

                SqlParameter prmBooks = cmdOwners.Parameters.Add("p_books", SqlDbType.Decimal);
                prmBooks.Direction = ParameterDirection.Input;
                prmBooks.Value = paymentObj.Books;

                SqlParameter prmPaymentType = cmdOwners.Parameters.Add("p_paymenttype", SqlDbType.Int, 1);
                prmPaymentType.Direction = ParameterDirection.Input;
                prmPaymentType.Value = paymentObj.PaymentType;

                SqlParameter prmTotalAmountToPay = cmdOwners.Parameters.Add("p_totalamounttopay", SqlDbType.Decimal);
                prmTotalAmountToPay.Precision = 7;
                prmTotalAmountToPay.Scale = 3;
                prmTotalAmountToPay.Direction = ParameterDirection.Input;
                prmTotalAmountToPay.Value = (paymentObj.Tuition + paymentObj.TShirt + paymentObj.Books);

                SqlParameter prmTotalAmountPayed = cmdOwners.Parameters.Add("p_totalamountpayed", SqlDbType.Decimal);
                prmTotalAmountPayed.Precision = 7;
                prmTotalAmountPayed.Scale = 3;
                prmTotalAmountPayed.Direction = ParameterDirection.Input;
                prmTotalAmountPayed.Value = paymentObj.TotalPaymentPayed;

                


                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }
        }


        public static List<StudentPaymentInformationProps> getStudentsPaymentInformation(Int32 parentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<StudentPaymentInformationProps> paymentsList = new List<StudentPaymentInformationProps>();
            StudentPaymentInformationProps paymentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Students_Financial_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = parentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                while (studentRdr.Read())
                {
                    paymentObj = new StudentPaymentInformationProps();
                    paymentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    paymentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    paymentObj.FirstName =""+ studentRdr["FIRST_NAME"];
                    paymentObj.Age = Convert.ToInt32(studentRdr["AGE"]);
                    paymentObj.Tuition = Convert.ToDecimal("0" + studentRdr["TUITION"]);
                    paymentObj.TShirt = Convert.ToDecimal("0" + studentRdr["T_SHIRT"]);
                    paymentObj.Books = Convert.ToDecimal("0" + studentRdr["BOOKS"]);
                    paymentObj.TotalPaymentToPay = Convert.ToDecimal("0" + studentRdr["TOTAL_AMOUNT_DUE"]);
                    paymentObj.TotalPaymentPayed = Convert.ToDecimal("0" + studentRdr["TOTAL_AMOUNT_PAYED"]);
                    paymentObj.TotalPaymentRemaining = Convert.ToDecimal("0" + studentRdr["REMAINING"]);

                    paymentsList.Add(paymentObj);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return paymentsList;
        }


        public static List<DocumentInformationProps> getDocumentsInformation(Int32 studentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<DocumentInformationProps> documentsList = new List<DocumentInformationProps>();
            DocumentInformationProps documentObj = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Student_Documents_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentId;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;

                SqlDataReader studentRdr = cmdOwners.ExecuteReader();

                while (studentRdr.Read())
                {
                    documentObj = new DocumentInformationProps();
                    documentObj.ParentId = Convert.ToInt32(studentRdr["PARENT_ID"]);
                    documentObj.StudentId = Convert.ToInt32(studentRdr["STUDENT_ID"]);
                    documentObj.FirstName = "" + studentRdr["FIRST_NAME"];
                    documentObj.Age = Convert.ToString(studentRdr["AGE"]);
                   

                    documentsList.Add(documentObj);
                }

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }


            return documentsList;
        }

        public static void addDocumentformation(DocumentInformationProps documentObj)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();
            List<DocumentInformationProps> studentsList = new List<DocumentInformationProps>();

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Add_Document_Information", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = documentObj.StudentId;

                SqlParameter prmParentId = cmdOwners.Parameters.Add("p_parentId", SqlDbType.Int, 10);
                prmParentId.Direction = ParameterDirection.Input;
                prmParentId.Value = documentObj.ParentId;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = documentObj.EnrollementYear;

                SqlParameter prmDocumentType = cmdOwners.Parameters.Add("p_documenttype", SqlDbType.Int, 1);
                prmDocumentType.Direction = ParameterDirection.Input;
                prmDocumentType.Value = documentObj.DocumentType;

                SqlParameter prmDocumentName = cmdOwners.Parameters.Add("p_documentname", SqlDbType.VarChar);
                prmDocumentName.Direction = ParameterDirection.Input;
                prmDocumentName.Value = documentObj.DocumentName ;

                SqlParameter prmDocumentPath = cmdOwners.Parameters.Add("p_documentpath", SqlDbType.VarChar);
                prmDocumentPath.Direction = ParameterDirection.Input;
                prmDocumentPath.Value = documentObj.DocumentPath;

                SqlParameter prmAddedBy = cmdOwners.Parameters.Add("p_addedby", SqlDbType.VarChar);
                prmAddedBy.Direction = ParameterDirection.Input;
                prmAddedBy.Value = documentObj.AddedBy;

                SqlParameter prmIsParent = cmdOwners.Parameters.Add("p_isparent", SqlDbType.VarChar);
                prmIsParent.Direction = ParameterDirection.Input;
                prmIsParent.Value = documentObj.IsParent;

                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }
        }


        public static DataSet getDocumentsList(Int32 studentId, Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsStudentsList = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Documents_By_Student", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_studentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentId;


                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;


                //Retrieve Rows
                dsStudentsList = new DataSet();
                SqlDataAdapter daStudentList = new SqlDataAdapter(cmdOwners);
                daStudentList.Fill(dsStudentsList, "StudentDocumentsList");


            }
            catch (Exception pbisException)
            {
                throw pbisException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsStudentsList;
        }


        public static void deleteDocument(Int32 studentId)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Delete_document", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmStudentId = cmdOwners.Parameters.Add("p_documentId", SqlDbType.Int, 10);
                prmStudentId.Direction = ParameterDirection.Input;
                prmStudentId.Value = studentId;

                cmdOwners.ExecuteReader();

            }
            catch (Exception weekendschoolException)
            {
                throw weekendschoolException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                    dbWeekendSchoolConn.Close();
            }

        }


        public static DataSet getTuitionFeeList(Int32 enrollementYear)
        {
            DBSqlConnect dbConn = new DBSqlConnect();
            SqlCommand cmdOwners = null;
            SqlConnection dbWeekendSchoolConn = dbConn.getSqlConnection();

            DataSet dsTuitionListList = null;

            try
            {
                dbWeekendSchoolConn.Open();

                //Instantiate and inialize command
                cmdOwners = new SqlCommand("Proc_Get_Tuition_Fee", dbWeekendSchoolConn);
                cmdOwners.CommandType = CommandType.StoredProcedure;

                SqlParameter prmEnrollementYear = cmdOwners.Parameters.Add("p_enrollementyear", SqlDbType.Int, 4);
                prmEnrollementYear.Direction = ParameterDirection.Input;
                prmEnrollementYear.Value = enrollementYear;


                //Retrieve Rows
                dsTuitionListList = new DataSet();
                SqlDataAdapter daTuitionFeeList = new SqlDataAdapter(cmdOwners);
                daTuitionFeeList.Fill(dsTuitionListList, "TuitionFeeList");


            }
            catch (Exception pbisException)
            {
                throw pbisException;
            }
            finally
            {
                if (dbWeekendSchoolConn != null)
                {
                    dbWeekendSchoolConn.Close();
                    dbWeekendSchoolConn.Dispose();
                }
            }


            return dsTuitionListList;
        }



    }
}