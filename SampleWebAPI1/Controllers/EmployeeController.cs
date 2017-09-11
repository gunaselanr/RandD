using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCSampleGrid.Data;
using ViewModel;
using HelperClasses;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace SampleWebAPI1.Controllers
{
    public class EmployeeController : ApiController
    {
        private MVCSampleGridEntities db = new MVCSampleGridEntities();
        private string webApi2Url = System.Configuration.ConfigurationManager.AppSettings.Get("WebApi2URL");

        // GET api/Employee
        public List<VM_Employee> GetEmployees()
        {
            List<VM_Employee> lstEmployee = new List<VM_Employee>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi2Url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/employee").Result;
                if (response.IsSuccessStatusCode)
                {
                    lstEmployee = response.Content.ReadAsAsync<List<VM_Employee>>().Result;
                    //foreach (var x in data)
                    //{
                    //    //Call your store method and pass in your own object
                    //}                    
                }
            }

            return lstEmployee;
            // return db.Employees;
        }

        // GET api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT api/Employee/5
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        //public bool SaveEmployee(VM_Employee employee_data)
        //{

        //    return true;
        //}

        // POST api/Employee
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> SaveEmployee(VM_Employee employee_data)
        {
            VM_Employee vm_employee = employee_data; // JsonConvert.DeserializeObject<VM_Employee>(employee_data);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi2Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // StringContent content = new StringContent(JsonConvert.SerializeObject(employee));
                StringContent content = new StringContent(JsonConvert.SerializeObject(vm_employee), Encoding.UTF8, "application/json");

                // HTTP POST
                HttpResponseMessage response = await client.PostAsync("api/employee/SaveEmployee", content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    vm_employee = JsonConvert.DeserializeObject<VM_Employee>(data);
                }
            }

            //db.Employees.Add(employee);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vm_employee.Id }, employee_data);
        }

        // DELETE api/Employee/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            //Employee employee = db.Employees.Find(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //db.Employees.Remove(employee);
            //db.SaveChanges();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApi2Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
               // HttpResponseMessage response1 = client.DeleteAsync("api/employee/DeleteEmployee/" + id).Result;
                HttpResponseMessage response = client.DeleteAsync("api/employee/" + id).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}