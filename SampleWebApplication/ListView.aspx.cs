using SampleWebApplication.HelperClass;
using SampleWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApplication
{
    public partial class ListView : System.Web.UI.Page
    {
        HelperCustomer objHelperCustomer = new HelperCustomer();
        DataTable dtCustomer = new DataTable();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // 1

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // 2

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // 3
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // 5
        }
        protected void Page_Render(object sender, EventArgs e)
        {

        }

        private void FillGrid()
        {
            dtCustomer = Utilities.UtilitiesDataTable.ToDataTable<Model.VM_Customer>(objHelperCustomer.GetAllCustomer());
            if (dtCustomer.Rows.Count == 0)
            {
                dtCustomer.Rows.Add(dtCustomer.NewRow());
            }

            LVCustomer.DataSource = dtCustomer;
            LVCustomer.DataBind();

        }

        protected void LVCustomer_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LVCustomer.EditIndex = -1;
            FillGrid();
        }

        protected void LVCustomer_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Label lblCustomerId = (Label)LVCustomer.Items[e.ItemIndex].FindControl("LblId");

            int customerId = Convert.ToInt32(lblCustomerId.Text);

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

        protected void LVCustomer_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            // Event 4
            LVCustomer.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void LVCustomer_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // we should use commandname as Insert in design page 
            TextBox firstName = (TextBox)e.Item.FindControl("TxtFirstName");
            TextBox lastName = (TextBox)e.Item.FindControl("TxtLastName");
            TextBox city = (TextBox)e.Item.FindControl("TxtCity");
            TextBox country = (TextBox)e.Item.FindControl("TxtCountry");
            TextBox phone = (TextBox)e.Item.FindControl("TxtPhone");

            if (!string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text))
            {
                VM_Customer vm_Model = new VM_Customer();
                vm_Model.FirstName = firstName.Text;
                vm_Model.LastName = lastName.Text;
                vm_Model.City = city.Text;
                vm_Model.Country = country.Text;
                vm_Model.Phone = phone.Text;

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

        protected void LVCustomer_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            // we should use commandname as Update in design page 
            Label customerId = (Label)LVCustomer.Items[e.ItemIndex].FindControl("LblId");
            TextBox firstName = (TextBox)LVCustomer.Items[e.ItemIndex].FindControl("TxtFirstName");
            TextBox lastName = (TextBox)LVCustomer.Items[e.ItemIndex].FindControl("TxtLastName");
            TextBox city = (TextBox)LVCustomer.Items[e.ItemIndex].FindControl("TxtCity");
            TextBox country = (TextBox)LVCustomer.Items[e.ItemIndex].FindControl("TxtCountry");
            TextBox phoneNo = (TextBox)LVCustomer.Items[e.ItemIndex].FindControl("TxtPhone");

            if (!string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text))
            {
                VM_Customer vm_Model = new VM_Customer();
                vm_Model.Id = Convert.ToInt32(customerId.Text);
                vm_Model.FirstName = firstName.Text;
                vm_Model.LastName = lastName.Text;
                vm_Model.City = city.Text;
                vm_Model.Country = country.Text;
                vm_Model.Phone = phoneNo.Text;

                var isSaved = objHelperCustomer.SaveCustomer(vm_Model);

                if (isSaved)
                {
                    HelperUtilities.ShowMessage(this, "Information", "Customer updated successfylly");
                }
                else
                {
                    HelperUtilities.ShowMessage(this, "Information", "Customer not updated");
                }

                FillGrid();
            }
            else
            {
                HelperUtilities.ShowMessage(this, "Information", "Please fill the requied values");
            }


            LVCustomer.EditIndex = -1;
            FillGrid();
        }

        protected void LVCustomer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void PgrCustomer_PreRender(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}