using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVCSampleGrid.Business;
using System.Data;
using Utilities;
using ViewModel;
using HelperClasses;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace SampleWeb1
{
    public partial class GridView : System.Web.UI.Page
    {
        private string webApi1Url = System.Configuration.ConfigurationManager.AppSettings.Get("WebApi1URL");
        HelperEmployee objHelperEmployee = new HelperEmployee();
        DataTable dtCustomer = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            // dtCustomer = Utilities.UtilitiesDataTable.ToDataTable<Model.VM_Employee>(objHelperEmployee.GetAllEmployee());

            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            List<VM_Employee> lstEmployee = new List<VM_Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi1Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get Employee list
                HttpResponseMessage response = client.GetAsync("api/employee").Result;

                if (response.IsSuccessStatusCode)
                {
                    lstEmployee = response.Content.ReadAsAsync<List<VM_Employee>>().Result;
                    dtCustomer = Utilities.UtilitiesDataTable.ToDataTable<VM_Employee>(lstEmployee);


                    if (dtCustomer.Rows.Count == 0)
                    {
                        dtCustomer.Rows.Add(dtCustomer.NewRow());
                    }

                    GvEmployee.DataSource = dtCustomer;
                    GvEmployee.DataBind();

                    if (dtCustomer.Rows.Count == 0)
                    {
                        int TotalColumns = GvEmployee.Rows[0].Cells.Count;
                        GvEmployee.Rows[0].Cells.Clear();
                        GvEmployee.Rows[0].Cells.Add(new TableCell());
                        GvEmployee.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                        GvEmployee.Rows[0].Cells[0].Text = "No Record Found";
                    }
                }
            }
        }

        protected void GvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                TextBox empId = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewEmpId");
                TextBox firstName = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewFirstName");
                TextBox lastName = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewLastName");
                TextBox age = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewAge");
                TextBox department = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewDepartment");
                TextBox address = (TextBox)GvEmployee.FooterRow.FindControl("TxtNewAddress");

                if (!string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text))
                {
                    VM_Employee vm_Model = new VM_Employee();
                    vm_Model.FirstName = firstName.Text;
                    vm_Model.LastName = lastName.Text;
                    vm_Model.EmpName = firstName.Text + " " + lastName.Text;
                    vm_Model.EmpId = Convert.ToInt32(empId.Text);
                    vm_Model.Age = Convert.ToInt32(age.Text);
                    vm_Model.Department = department.Text;
                    vm_Model.Address = address.Text;

                    // var isSaved = objHelperCustomer.SaveCustomer(vm_Model);

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(webApi1Url);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Create a new Employee
                        StringContent content = new StringContent(JsonConvert.SerializeObject(vm_Model), Encoding.UTF8, "application/json");
                        var response = client.PostAsync("api/employee", content).Result;

                        if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            HelperUtilities.ShowMessage(this, "Information", "Employee saved successfylly");
                        }
                        else
                        {
                            HelperUtilities.ShowMessage(this, "Information", "Employee not saved");
                        }
                    }

                    FillGrid();
                }
                else
                {
                    HelperUtilities.ShowMessage(this, "Information", "Please fill the requied values");
                }
            }
        }

        protected void GvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeId = Convert.ToInt32(GvEmployee.DataKeys[e.RowIndex].Values[0].ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi1Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                HttpResponseMessage response = client.DeleteAsync("api/employee/" + employeeId).Result;

                if (response.IsSuccessStatusCode)
                {
                }
            }

            FillGrid();

        }

        protected void GvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvEmployee.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GvEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox empId = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtEmpId");
            TextBox firstName = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtFirstName");
            TextBox lastName = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtLastName");
            TextBox age = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtAge");
            TextBox department = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtDepartment");
            TextBox address = (TextBox)GvEmployee.Rows[e.RowIndex].FindControl("TxtAddress");

            VM_Employee vmEmployee = new VM_Employee();
            vmEmployee.Id = Convert.ToInt32(GvEmployee.DataKeys[e.RowIndex].Values[0].ToString());
            vmEmployee.EmpId = Convert.ToInt32(empId.Text);
            vmEmployee.FirstName = firstName.Text;
            vmEmployee.LastName = lastName.Text;
            vmEmployee.EmpName = firstName.Text + " " + lastName.Text;
            vmEmployee.Age = Convert.ToInt32(age.Text);
            vmEmployee.Department = department.Text;
            vmEmployee.Address = address.Text;

            // var isUpdated = objHelperEmployee.SaveEmployee(vmEmployee);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi1Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new Employee

                StringContent content = new StringContent(JsonConvert.SerializeObject(vmEmployee), Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/employee", content).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    HelperUtilities.ShowMessage(this, "Information", "Employee saved successfylly");
                }
                else
                {
                    HelperUtilities.ShowMessage(this, "Information", "Employee not saved");
                }
            }

            GvEmployee.EditIndex = -1;
            FillGrid();
        }

        protected void GvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvEmployee.EditIndex = -1;
            FillGrid();
        }

        protected void GvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmployee.PageIndex = e.NewPageIndex;
            FillGrid();
        }
    }
}