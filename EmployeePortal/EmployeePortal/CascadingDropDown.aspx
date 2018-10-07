<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CascadingDropDown.aspx.cs" Inherits="EmployeePortal.CascadingDropDown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="~/Ajax/AjaxService.asmx" />
                </Services>
            </asp:ScriptManager>

            <asp:DropDownList runat="server" ID="ddlCountries">
                <asp:ListItem Text="Select Country" Value="-1" />
                <asp:ListItem Text="United States" Value="1" />
                <asp:ListItem Text="United Kingdom"  Value="2"/>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlStates">               
            </asp:DropDownList>
        </div>
    </form>
    <script>
        

        $(function () {
            //GetStates();
        });
        function GetStates(countryId) {
            // var country = $get("txtCountry").value;
            EmployeePortal.Ajax.AjaxService.GetStates(countryId, OnWSRequestComplete);
        }
        function OnWSRequestComplete(results) {
            if (results !== null) {
                var ddlStates = $("#ddlStates");
                ddlStates.html('');
                var options = "<option value=''>Select a state</option>";
                for (var i = 0; i < results.length; i++) {
                    options += "<option value='"+results[i].StateID+"'>"+results[i].StateName+"</option>";
                }
                ddlStates.html(options);
            }
        }
        $("#ddlCountries").change(function () {
            GetStates($(":selected").val());
        });

    </script>
</body>
</html>
