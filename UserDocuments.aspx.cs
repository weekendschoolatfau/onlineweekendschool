﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineweekendschool
{
    public partial class UserDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInformation"] == null)
                {
                    Response.Redirect("./Login.aspx?Login=MyDocuments");
                }

            }
        }
    }
}