<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EmployeePortal.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>
        $(function () {
            $("#txtDOB").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                onClose: function (selectedDate) {                   
                }
            });

            $("#txtDOB").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                onClose: function (selectedDate) {                  
                }

            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtID"  ReadOnly="true"/>
                        <asp:HiddenField ID="hdnMode" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" />
                    </td>
                </tr>
                 <tr>
                    <td>Gender</td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rblGender">                            
                        </asp:RadioButtonList>
                    </td>
                </tr>
                 <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPhone" />
                    </td>
                </tr>
                 <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" />
                    </td>
                </tr>
                 <tr>
                    <td>DOB</td>
                    <td>

                        <asp:TextBox runat="server" ID="txtDOB" />

                    </td>
                </tr>
                 <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine"  Rows="3"/>
                    </td>
                </tr>
                 <tr>
                    <td>Documents</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDocuments">                            
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>Education</td>
                    <td>
                        <asp:CheckBoxList runat="server" RepeatDirection ="Horizontal" ID="cblEducation">                            
                        </asp:CheckBoxList>
                    </td>
                </tr>               
            </table>
            <table>
                 <tr>
                    <td>
                        <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                        </td><td>
                        <asp:Button Text="Clear" ID="btnClear" runat="server" />
                        </td><td>
                        <asp:Button Text="View" ID="btnView" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView runat="server" ID ="gvEmployees" AutoGenerateColumns="false" OnRowCommand="gvEmployees_RowCommand" OnRowDeleting="gvEmployees_RowDeleting" OnRowEditing="gvEmployees_RowEditing">
                <Columns>
                    <asp:TemplateField  HeaderText ="Username">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Username") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Gender">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"GenderDesc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Phone">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Phone") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Email") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Education">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Education") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="DOB">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"DOB") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Address">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Address") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Document">
                        <ItemTemplate>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"DocumentDesc") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField  HeaderText ="Action">
                        <ItemTemplate>
                            <asp:LinkButton Text="Edit" CommandArgument ='<%# DataBinder.Eval(Container.DataItem,"ID") %>' CommandName ="Edit" runat="server" />
                            <asp:LinkButton Text="Delete" CommandArgument ='<%# DataBinder.Eval(Container.DataItem,"ID") %>' CommandName ="Delete" runat="server" />                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
