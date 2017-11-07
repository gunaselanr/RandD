using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using MVCSampleGrid.Data;
using ViewModel;
using HelperClasses;
using System.Threading.Tasks;

namespace SampleWebAPI2.Controllers
{
    public class EmployeeController : ApiController
    {
        private MVCSampleGridEntities db = new MVCSampleGridEntities();
        private HelperEmployee objHelperEmployee = new HelperEmployee();

        // GET api/Employee
        //public IQueryable<Employee> GetEmployees()
        //{
        //    return db.Employees;
        //}

        public List<VM_Employee> GetEmployees()
        {
            List<VM_Employee> lstEmployee = new List<VM_Employee>();
            lstEmployee = objHelperEmployee.GetAllEmployee();
            return lstEmployee;
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

        // POST api/Employee
        [ResponseType(typeof(VM_Employee))]
        public async Task<IHttpActionResult> SaveEmployee(VM_Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Employees.Add(employee);
            //db.SaveChanges();

            objHelperEmployee.SaveEmployee(employee);
            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE api/Employee/5
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            //Employee employee = db.Employees.Find(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //db.Employees.Remove(employee);
            //db.SaveChanges();

            objHelperEmployee.DeleteEmployee(id);

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