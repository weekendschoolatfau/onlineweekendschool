using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineweekendschool
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                menu.Text = GenerateMenu();
            }
        }

        private string GenerateMenu()
        {
            string initialMenu = null;

            if (Session["UserInformation"] == null)
            {

                initialMenu = "<li><a class=menu-text runat=server href='Default'>Home</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='About'>About</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='Contact'>Contact</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='Location'>Location</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='Login'>Login</a></li>";
            }
            else
            {
                initialMenu = "<li><a class=menu-text runat=server href='Default'>Home</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='About'>About</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='Contact'>Contact</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='Location'>Location</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='UserInformation'>Parent Info</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='UserProfile'>My Profile</a></li>";
                initialMenu += "<li><a class=menu-text runat=server href='UserDocuments'>My Documents</a></li>";
              
                initialMenu += "<li><a class=menu-text runat=server href='Login?Logout=1'>Logout</a></li>";
            }
                      

            return initialMenu;
            
        }
    }
}