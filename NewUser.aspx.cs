using onlineweekendschool.WeekendSchool.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using onlineweekendschool.WeekendSchool.DS;
using onlineweekendschool.WeekendSchool.Props;

namespace onlineweekendschool
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitCtrls();
            }

            btnSubmit.Attributes.Add("OnClick", "return ValidateAccount();");
        }

        protected void InitCtrls()
        {
            dvMessage.Visible = false;
            lblMessage.Text = "";

            Session["UserInformation"] = null;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoginInformationProps parentObj = null;

            parentObj = DBSqlWeekendSchool.isParentExist(txtEmail.Text, txtUsername.Text);

            if (parentObj != null)
            {
                dvMessage.Visible = true;
                lblMessage.Text = parentObj.Status;
            }
            else
            {
                dvMessage.Visible = false;
                lblMessage.Text = "";

                parentObj = new LoginInformationProps();
                parentObj.UserName = txtUsername.Text.Trim().ToUpper();
                parentObj.Email = txtEmail.Text.Trim().ToUpper();
                parentObj.Password = txtPassword.Text.Trim();
                parentObj.FirstName = txtFirstName.Text.Trim();
                parentObj.LastName = txtLastName.Text.Trim();
                parentObj.Phone = txtPhoneNumber.Text.Trim();
                parentObj.PreferrredContact = "E";
                parentObj.SecurityQuestion = "1";

                parentObj = DBSqlWeekendSchool.addNewParent(parentObj);

                if (parentObj != null)
                {
                    Session["UserInformation"] = parentObj;
                    Response.Redirect("./UserInformation.aspx");
                }
                else
                {
                    dvMessage.Visible = true;
                    lblMessage.Text = "Error inserting parent information";
                }

            }

           



        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("./login.aspx");
        }
    }
}