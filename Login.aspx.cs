using System;
using System.Configuration;
using System.Web.UI;

using onlineweekendschool.WeekendSchool.DS;
using onlineweekendschool.WeekendSchool.Props;


namespace onlineweekendschool
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string logout = Request.Params["Logout"];

                if ((logout != null)&&(logout.Trim().Equals("1")))
                {
                    Session["UserInformation"] = null;
                    Response.Redirect("./login.aspx");
                }

                InitCtrls();

            }

            btnLogin.Attributes.Add("OnClick", "return ValidateLogin();");
        }

        protected void activateMenu()
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();
            LoginInformationProps loginObj = DBSqlWeekendSchool.getUserLoginInformation( email,  password);

            if (loginObj != null)
            {
                Session["UserInformation"] = loginObj;
                Int32 enrollementYear = Convert.ToInt32(ConfigurationManager.AppSettings["EnrollementYear"]);
                Session["TuitionByLevel"] = DBSqlWeekendSchool.getTuitionByLevel(enrollementYear);
                Response.Redirect("./UserInformation.aspx");
            }

            dvMessage.Visible = true;
            lblMessage.Text = "Username or password is incorrect";
            Session["UserInformation"] = null;
            Session["TuitionByLevel"] = null;
           
           


        }

        protected void NewUser_Click(object sender, EventArgs e)
        {

            Response.Redirect("./NewUser.aspx");
        }

        protected void ForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ForgetPassword.aspx");
        }

        protected void InitCtrls()
        {
            dvMessage.Visible = false;
            lblMessage.Text = "";
        }
    }
}