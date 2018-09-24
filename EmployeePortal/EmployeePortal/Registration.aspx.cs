using EmployeePortal.DAL;
using EmployeePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitializeControls();
                hdnMode.Value = "Add";
            }
        }

        private void InitializeControls()
        {
            rblGender.DataSource = EmployeeDAL.GetGenders();
            rblGender.DataValueField = "Code";
            rblGender.DataTextField = "Value";
            rblGender.DataBind();

            cblEducation.DataSource = EmployeeDAL.GetDocuments();
            cblEducation.DataValueField = "Code";
            cblEducation.DataTextField = "Value";
            cblEducation.DataBind();

            ddlDocuments.DataSource = EmployeeDAL.GetDocuments();
            ddlDocuments.DataValueField = "Code";
            ddlDocuments.DataTextField = "Value";
            ddlDocuments.DataBind();

            LoadData();

        }

        private void LoadData()
        {
            gvEmployees.DataSource = EmployeeDAL.GetEmployees(null);
            gvEmployees.DataBind();
        }

        private void Save() {
            string mode = hdnMode.Value;
            Employee employee = new Employee();
            employee.ID = Convert.ToInt32(txtID.Text); 
            employee.Username = txtUsername.Text;
            employee.Phone = txtPhone.Text;
            employee.Email = txtEmail.Text;
            employee.DOB = Convert.ToDateTime(txtDOB.Text);
            employee.DocumentID = Convert.ToInt32(ddlDocuments.SelectedValue);
            employee.GenderID = Convert.ToInt32(rblGender.SelectedValue);
            employee.Address = txtAddress.Text;
            foreach (ListItem item in cblEducation.Items)
            {
                if (item.Text == "SSC")
                {
                    employee.SSC = item.Selected;
                }
                if (item.Text == "Inter")
                {
                    employee.Inter = item.Selected;
                }
                if (item.Text == "Degree")
                {
                    employee.Degree = item.Selected;
                }
            }
            
            switch (mode)
            {
                case "Add":
                    EmployeeDAL.AddEmployee(employee);
                    break;
                case "Update":
                    EmployeeDAL.UpdateEmployee(employee);
                    break;
                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="Edit")
            {
                int ID = Convert.ToInt32(e.CommandArgument.ToString());
                Employee employee = EmployeeDAL.GetEmployees(ID).FirstOrDefault();
                txtAddress.Text = employee.Address;
                txtDOB.Text = employee.DOB.ToShortDateString();
                txtEmail.Text = employee.Email;
                txtID.Text = employee.ID.ToString();
                txtUsername.Text = employee.Username;
                txtPhone.Text = employee.Phone;
                foreach (ListItem item in cblEducation.Items)
                {
                    if (item.Text == "SSC")
                    {
                        item.Selected = employee.SSC;
                    }
                    if (item.Text == "Inter")
                    {
                        item.Selected = employee.Inter;
                    }
                    if (item.Text == "Degree")
                    {
                        item.Selected = employee.Degree;
                    }
                }
                rblGender.SelectedValue = employee.GenderID.ToString();
                ddlDocuments.SelectedValue = employee.DocumentID.ToString();
                btnSave.Text = "Update";
                hdnMode.Value = "Update";
            }
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EmployeeDAL.DeleteEmployee(id);
                LoadData();
            }
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}