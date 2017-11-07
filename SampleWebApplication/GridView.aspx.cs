using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVCSampleGrid.Business;
using SampleWebApplication.HelperClass;
using SampleWebApplication.Model;
using System.Data;
using Utilities;

namespace SampleWebApplication
{
    public partial class GridView : System.Web.UI.Page
    {
        HelperCustomer objHelperCustomer = new HelperCustomer();
        DataTable dtCustomer = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            dtCustomer = Utilities.UtilitiesDataTable.ToDataTable<Model.VM_Customer>(objHelperCustomer.GetAllCustomer());
            // List<VM_Customer> lstCustomers = objCustomer.GetAllCustomer();
            if (dtCustomer.Rows.Count == 0)
            {
                dtCustomer.Rows.Add(dtCustomer.NewRow());
            }

            GvCustomer.DataSource = dtCustomer;
            GvCustomer.DataBind();

            if (dtCustomer.Rows.Count == 0)
            {
                int TotalColumns = GvCustomer.Rows[0].Cells.Count;
                GvCustomer.Rows[0].Cells.Clear();
                GvCustomer.Rows[0].Cells.Add(new TableCell());
                GvCustomer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                GvCustomer.Rows[0].Cells[0].Text = "No Record Found";
            }            
        }

        protected void GvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName.Equals("Add"))
            {
                TextBox firstName = (TextBox)GvCustomer.FooterRow.FindControl("TxtNewFirstName");
                TextBox lastName = (TextBox)GvCustomer.FooterRow.FindControl("TxtNewLastName");
                TextBox city = (TextBox)GvCustomer.FooterRow.FindControl("TxtNewCity");
                TextBox country = (TextBox)GvCustomer.FooterRow.FindControl("TxtNewCountry");
                TextBox phoneNo = (TextBox)GvCustomer.FooterRow.FindControl("TxtNewPhoneNo");

                if (!string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text))
                {
                    Model.VM_Customer vm_Model = new VM_Customer();
                    vm_Model.FirstName = firstName.Text;
                    vm_Model.LastName = lastName.Text;
                    vm_Model.City = city.Text;
                    vm_Model.Country = country.Text;
                    vm_Model.Phone = phoneNo.Text;

                    var isSaved = objHelperCustomer.SaveCustomer(vm_Model);

                    if (isSaved)
                    {
                        HelperUtilities.ShowMessage(this, "Information", "Customer saved successfylly");
                    }
                    else
                    {
                        HelperUtilities.ShowMessage(this, "Information", "Customer not saved");
                    }

                    FillGrid();
                }
                else
                {
                    HelperUtilities.ShowMessage(this, "Information", "Please fill the requied values");
                }


            }
        }

        protected void GvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GvCustomer.DataKeys[e.RowIndex].Values[0].ToString());

            bool isDeleted = objHelperCustomer.DeleteCustomer(customerId);
            if (isDeleted)
            {
                HelperUtilities.ShowMessage(this, "Information", "Customer deleted sucessfully");
            }
            else
            {
                HelperUtilities.ShowMessage(this, "Information", "Customer not deleted");
            }

            FillGrid();

        }

        protected void GvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvCustomer.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox firstName = (TextBox)GvCustomer.Rows[e.RowIndex].FindControl("TxtFirstName");
            TextBox lastName = (TextBox)GvCustomer.Rows[e.RowIndex].FindControl("TxtLastName");
            TextBox city = (TextBox)GvCustomer.Rows[e.RowIndex].FindControl("TxtCity");
            TextBox country = (TextBox)GvCustomer.Rows[e.RowIndex].FindControl("TxtCountry");
            TextBox phoneNo = (TextBox)GvCustomer.Rows[e.RowIndex].FindControl("TxtPhoneNo");

            VM_Customer vmCustomer = new VM_Customer();
            vmCustomer.Id = Convert.ToInt32(GvCustomer.DataKeys[e.RowIndex].Values[0].ToString());
            vmCustomer.FirstName = firstName.Text;
            vmCustomer.LastName = lastName.Text;
            vmCustomer.City = city.Text;
            vmCustomer.Country = country.Text;
            vmCustomer.Phone = phoneNo.Text;

            var isUpdated = objHelperCustomer.SaveCustomer(vmCustomer);

            if (isUpdated)
            {
                HelperUtilities.ShowMessage(this, "Information", "Customer updated sucessfully");
            }
            else
            {
                HelperUtilities.ShowMessage(this, "Information", "Customer not updated");
            }

            GvCustomer.EditIndex = -1;
            FillGrid();
        }

        protected void GvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvCustomer.EditIndex = -1;
            FillGrid();
        }

        protected void GvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCustomer.PageIndex = e.NewPageIndex;
            FillGrid();
        }
    }
}