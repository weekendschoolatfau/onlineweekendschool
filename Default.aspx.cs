using onlineweekendschool.WeekendSchool.DS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineweekendschool
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Int32 enrollementYear = Convert.ToInt32(ConfigurationManager.AppSettings["EnrollementYear"]);
                DataSet dsDocuments = DBSqlWeekendSchool.getTuitionFeeList(enrollementYear);
                dgTuitionFee.DataSource = dsDocuments;
                dgTuitionFee.DataBind();
            }
        }
    }
}