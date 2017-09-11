using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelperClasses;
using ViewModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace SampleWeb1
{
    public partial class Employee : System.Web.UI.Page
    {
        private string webApi1Url = System.Configuration.ConfigurationManager.AppSettings.Get("WebApi1URL");
        private HelperEmployee objHelperEmployee = new HelperEmployee();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            VM_Employee modEmployee = new VM_Employee();
            bool isSaved = false;

            modEmployee.EmpId = Convert.ToInt32(TxtEmpId.Text);
            modEmployee.EmpName = TxtFirstName.Text + " " + TxtLastName.Text;
            modEmployee.Age = Convert.ToInt32(TxtAge.Text);
            modEmployee.Department = TxtDepartment.Text;
            modEmployee.Address = TxtAddress.Text;

            // isSaved = objHelperEmployee.SaveEmployee(modEmployee);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi1Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new Employee

                StringContent content = new StringContent(JsonConvert.SerializeObject(modEmployee), Encoding.UTF8, "application/json");
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
        }
    }
}