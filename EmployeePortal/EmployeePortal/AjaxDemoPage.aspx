<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemoPage.aspx.cs" Inherits="EmployeePortal.AjaxDemoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="ddlCountries">
            </asp:DropDownList>
            <br />
            <asp:DropDownList runat="server" ID="ddlStates">
            </asp:DropDownList>
        </div>
    </form>
    <script>
        $(function () {            
            getCountries();
        });
        function onCountriesAjaxComplete(results) {
            if (results !== null) {
                var ddlCountries = $("#ddlCountries");
                ddlCountries.html('');
                var options = "<option value='-1'>Select</option>";
                for (var i = 0; i < results.length; i++) {
                    options += "<option value='" + results[i].Code + "'>" + results[i].Value + "</option>";
                }
                ddlCountries.html(options);
            }
        }
        $("#ddlCountries").change(function () {
            var countryId = $(':selected').val();
            getStates(countryId);
        });
        function onStatesAjaxComplete(results) {
            if (results !== null) {
                var ddlStates = $("#ddlStates");
                ddlStates.html('');
                var options = "<option value='-1'>Select</option>";
                for (var i = 0; i < results.length; i++) {
                    options += "<option value='" + results[i].StateID + "'>" + results[i].StateName + "</option>";
                }
                ddlStates.html(options);
            }
        }
        function getCountries() {
            $.ajax({
                type: "GET",
                url: "/Ajax/LookupDropdownAjaxService.asmx/GetCountries",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    onCountriesAjaxComplete(data.d);
                }
            });
        }
        function getStates(countryId) {
            $.ajax({
                type: "GET",
                url: "/Ajax/LookupDropdownAjaxService.asmx/GetStates?countryId=" + countryId,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    onStatesAjaxComplete(data.d);
                }
            });
        }

    </script>
</body>
</html>
