using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SampleWebApplication.HelperClass;
using SampleWebApplication.Model;
using System.Data;

namespace SampleWebApplication
{
    public partial class TechGridView : System.Web.UI.Page
    {
        private HelperTechCompany objHelperCompany = new HelperTechCompany();
        DataTable dtCustomer = new DataTable();
        double total_year_2011 = 0;
        double total_year_2012 = 0;
        double total_year_2013 = 0;
        double total_year_2014 = 0;
        double finalTotal = 0;
        double rowTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }
        private void FillGrid()
        {
            dtCustomer = Utilities.UtilitiesDataTable.ToDataTable<Model.VM_TechCompany>(objHelperCompany.GetAllCompany());
            if (dtCustomer.Rows.Count == 0)
            {
                dtCustomer.Rows.Add(dtCustomer.NewRow());
            }

            GvCompany.DataSource = dtCustomer;
            GvCompany.DataBind();

            if (dtCustomer.Rows.Count == 0)
            {
                int TotalColumns = GvCompany.Rows[0].Cells.Count;
                GvCompany.Rows[0].Cells.Clear();
                GvCompany.Rows[0].Cells.Add(new TableCell());
                GvCompany.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                GvCompany.Rows[0].Cells[0].Text = "No Record Found";
            }
        }

        protected void GvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total_year_2011 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Year_2011"));
                total_year_2012 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Year_2012"));
                total_year_2013 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Year_2013"));
                total_year_2014 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Year_2014"));
                finalTotal = total_year_2011 + total_year_2012 + total_year_2013 + total_year_2014;

                Label lblRowTotal = (Label)e.Row.FindControl("LblRowTotal");
                TextBox txtYear2011 = (TextBox)e.Row.FindControl("TxtYear_2011");
                TextBox txtYear2012 = (TextBox)e.Row.FindControl("TxtYear_2012");
                TextBox txtYear2013 = (TextBox)e.Row.FindControl("TxtYear_2013");
                TextBox txtYear2014 = (TextBox)e.Row.FindControl("TxtYear_2014");

                //txtYear2011.Attributes.Add("onchange", "CaluculateRowTotal('" + e.Row.RowIndex + "','" + lblRowTotal.ClientID + "')");
                //txtYear2012.Attributes.Add("onchange", "CaluculateRowTotal('" + e.Row.RowIndex + "','" + lblRowTotal.ClientID + "')");
                //txtYear2013.Attributes.Add("onchange", "CaluculateRowTotal('" + e.Row.RowIndex + "','" + lblRowTotal.ClientID + "')");
                //txtYear2014.Attributes.Add("onchange", "CaluculateRowTotal('" + e.Row.RowIndex + "','" + lblRowTotal.ClientID + "')");
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalYear2011 = (Label)e.Row.FindControl("LblTotalYear_2011");
                lblTotalYear2011.Text = total_year_2011.ToString();

                Label lblTotalYear2012 = (Label)e.Row.FindControl("LblTotalYear_2012");
                lblTotalYear2012.Text = total_year_2012.ToString();

                Label lblTotalYear2013 = (Label)e.Row.FindControl("LblTotalYear_2013");
                lblTotalYear2013.Text = total_year_2013.ToString();

                Label lblTotalYear2014 = (Label)e.Row.FindControl("LblTotalYear_2014");
                lblTotalYear2014.Text = total_year_2014.ToString();

                Label lblFinalTotal = (Label)e.Row.FindControl("LblFinalTotal");
                lblFinalTotal.Text = finalTotal.ToString();
            }


        }

        protected void GvCompany_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GvCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvCompany_DataBinding(object sender, EventArgs e)
        {

        }

        protected void GvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}