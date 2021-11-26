<%@ Page Title="Weekend School" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="onlineweekendschool._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Online weekend school offers courses to student who wants help to improve their knowledge 
            in a specific area of their studies such as languages, sciences, mathematics or physics. 
            The weekend school accepts students from grade 1 to grad 8. 
            Our Teachers are well-trained and highly qualified college graduates 
            and experienced teachers. Our fees are very competitive comparing to other schools. 
            We offer also a payment plain if you enroll more that one student.
            </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Student Enrollement</h2>
            <p>
               The academic program of the weekend school is spread in two semesters. 
                The first semester start from first of september to fifteenth of december and the second semester starts from fifth of Junuary to twentieth of May. Each period of class is 45 minutes duration. <br />
                The parent needs to create an account with the weekend school to register their childreen. 
                By clicking on the login option from the top menu you can login to your existing account or you can create a new account if you do not have one. 
               </p>
           
        </div>
        <div class="col-md-3">
            <h2>Regulations</h2>
            <p>
                To attend the weekend school, the parent need to provide documents of proof that 
                the student is their child on the first day of school, as well as who will 
                pick up the student after school. For each grade level, there a specific 
                color of t-shirt that parent need to buy. The parent will be notified via an email, 
                a phone text , or a phone call if student misses the class. If the student arrives 10 minutes late, 
                the student will wait until the next session to attend the class.
            </p>
           
        </div>
        <div class="col-md-5">
            <h2>Weekend School Fees</h2>
           
                To attend the weekend school, the parent needs to make a payments. 
                Each grade level has its own tuition. 
                The weekend school allows a payment by monthly payment plan.
                The tuition is a conbination of the following
                <br /> <br />
                <ul>
                     <li>The registration Fee</li>
                     <li>The T-shirt Fee</li>
                    <li>The books Fee</li>
                </ul>
                <br />



            
                    <asp:datagrid id="dgTuitionFee" runat="server" ToolTip="Document List" Width="100%"
									                    CellPadding="4" AutoGenerateColumns="False" DataKeyField="level_Id"
									
									                   
                                CellSpacing="1" >
                    <AlternatingItemStyle Font-Size="10pt" Font-Names="Arial" BackColor="#CCCCCC"></AlternatingItemStyle>
                    <ItemStyle Font-Size="10pt" Font-Names="Arial" ForeColor="Black"></ItemStyle>
                    <HeaderStyle Font-Size="10pt" Font-Names="Arial" Font-Bold="True" ForeColor="White" BackColor="#003366"></HeaderStyle>
                    <Columns>

                    <asp:TemplateColumn HeaderText="Grade">
                    <ItemTemplate>
                    <asp:Label runat="server" id="lblDocument_Description" Text='<%# DataBinder.Eval(Container, "DataItem.Level_id") %>'>
                    </asp:Label>
                    </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>

                    <asp:TemplateColumn HeaderText="Tuition Fee">
                    <ItemTemplate>
                    <asp:Label runat="server" id="lblTuitionFee" Text='<%# "$" +DataBinder.Eval(Container, "DataItem.Tuition_Fee") %>'>
                    </asp:Label>
                    </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>

                    <asp:TemplateColumn HeaderText="T-Shirt Price">
                    <ItemTemplate>
                    <asp:Label runat="server" id="lblTShirtPrice" Text='<%# "$" +DataBinder.Eval(Container, "DataItem.T-Shirt_Price") %>'>
                    </asp:Label>
                    </ItemTemplate>
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>

                     <asp:TemplateColumn HeaderText="Book Price">
                    <ItemTemplate>
                    <asp:Label runat="server" id="lblBookPrice" Text='<%# "$" +DataBinder.Eval(Container, "DataItem.Book_Price") %>'>
                    </asp:Label>
                    </ItemTemplate>
                         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                         <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    </Columns>
                    </asp:datagrid>
                    <br />


          
        </div>
    </div>

</asp:Content>
