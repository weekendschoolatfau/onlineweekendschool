<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="onlineweekendschool.NewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
    <div class="container">
         
          <div class="row" >
              <div class="col">
              </div>
              <div class="col">
                  <div class="loginPage  rounded">
                    <h4 class="form-signin-heading">  New User <span class="requiredMessage"> (* Required Field)</span></h4>
                     
                    <div class="loginMargin">
                        <label for="txtUsername" class="form-signin-heading loginSeparation"> Username</label><span class="required">*</span>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"  value=""  placeholder="Enter Username" />

                        <label for="txtEmail" class="form-signin-heading loginSeparation"> Email</label><span class="required">*</span>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"  value=""  placeholder="Enter Your Email" />
                       
                        <label for="txtPassword" class="form-signin-heading loginSeparation">Password</label><span class="required">*</span>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" value="" CssClass="form-control" placeholder="Enter Password"  />
                      
                          <label for="txtConfirmPassword" class="form-signin-heading loginSeparation">Confirm Password</label><span class="required">*</span>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" value="" CssClass="form-control" placeholder="Confirm Password"  />
                       
                        <label for="txtFirstName" class="form-signin-heading loginSeparation"> First Name</label><span class="required">*</span>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"  value=""  placeholder="Enter Your First Name" />
                      
                        <label for="txtLastName" class="form-signin-heading loginSeparation"> Last Name</label><span class="required">*</span>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"  value=""  placeholder="Enter Your Last Name" />
                      
                        <label for="txtPhoneNumber" class="form-signin-heading loginSeparation"> Phone Number</label><span class="required">*</span>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"  value=""  placeholder="Enter Your Phone Number" />
                       <%-- <asp:TextBox ID="txtPhoneExtension" runat="server" CssClass="form-control"  value=""  placeholder="Phone Number Extension" />--%>
                        <%-- <label for="" class="form-signin-heading loginSeparation"> How do you prefer receive your messages?</label><span class="required">*</span>
                         <asp:RadioButton ID="chbText" runat="server" Text=" By Phone Text"  GroupName ="MessageMethod" class="LoginMessageMethod" />
                        <asp:RadioButton ID="chbEmail" runat="server" Text=" By Email"   GroupName ="MessageMethod" class="LoginMessageMethod" />--%>
                        <br />
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" Class="btn btn-primary loginSeparation" />

                        <br />
                         <br />
                              <asp:LinkButton runat="server"  CssClass="loginLink" ID="btnBackToLogin" OnClick="btnBackToLogin_Click">Back to login page </asp:LinkButton>
                        <br />
                       <br />

                         <div id="dvMessage"  runat="server"   class="alert alert-danger loginSeparation">
                            <strong>Message</strong>
                            <asp:Label ID="lblMessage" runat="server"  />
                        </div>
                     </div>
                  </div>
              </div>

              <div class="col">
             
              </div>
          
         </div>
   </div>

   </div> 
    
<script type = "text/javascript">

    function ValidateAccount()
    {
        var txtUserName = document.getElementById("<%=txtUsername.ClientID%>").value;

        if (txtUserName.trim() == "")
        {
            alert("Username is required field.");
            document.getElementById("<%=txtUsername.ClientID%>").focus();
                return false;
        }

        var txtEmail = document.getElementById("<%=txtEmail.ClientID%>").value;

        if (txtEmail.trim() == "") {
            alert("Email is required field.");
            document.getElementById("<%=txtEmail.ClientID%>").focus();
            return false;
        }

        if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/.test(txtEmail)) {

            alert("Enter a valid e-mail address");
            document.getElementById("<%=txtEmail.ClientID%>").focus();
            document.getElementById("<%=txtEmail.ClientID%>").select();
            return false;
        }


        var txtPassword = document.getElementById("<%=txtPassword.ClientID%>").value;

        if (txtPassword.trim() == "") {
            alert("Password is required field.");
            document.getElementById("<%=txtPassword.ClientID%>").focus();
            return false;
        }

        if (txtPassword.trim().length < 8) {
            alert("Password must be at least 8 characters.");
            document.getElementById("<%=txtPassword.ClientID%>").focus();
            document.getElementById("<%=txtPassword.ClientID%>").select();
            return false;
        }

        var txtConfirmPassword = document.getElementById("<%=txtConfirmPassword.ClientID%>").value;

        if (txtConfirmPassword.trim() == "") {
            alert("Confirm password is required field.");
            document.getElementById("<%=txtConfirmPassword.ClientID%>").focus();
            return false;
        }

        if (txtPassword != txtConfirmPassword) {
            alert("A password and a confirm password must match.");
            document.getElementById("<%=txtPassword.ClientID%>").focus();
            document.getElementById("<%=txtPassword.ClientID%>").select();
            return false;
        }

        var txtFirstName = document.getElementById("<%=txtFirstName.ClientID%>").value;

        if (txtFirstName.trim() == "") {
            alert("First name is required field.");
            document.getElementById("<%=txtFirstName.ClientID%>").focus();
            return false;
        }

        var txtLastName = document.getElementById("<%=txtLastName.ClientID%>").value;

        if (txtLastName.trim() == "") {
            alert("Last name is required field.");
            document.getElementById("<%=txtLastName.ClientID%>").focus();
            return false;
        }

        var txtPhoneNumber = document.getElementById("<%=txtPhoneNumber.ClientID%>").value;

        if (txtPhoneNumber.trim() == "") {
            alert("Phone number is required field.");
            document.getElementById("<%=txtPhoneNumber.ClientID%>").focus();
            return false;
        }

        return true;
    }
</script>


</asp:Content>
