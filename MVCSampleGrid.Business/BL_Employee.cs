using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;
using MVCSampleGrid.Data.GenericRepository;

namespace MVCSampleGrid.Business
{
    public class BL_Employee
    {
        private IEmployeeRepository _employeeRepository;
        //private IGenericRepository<Employee> _employee;
        public BL_Employee()
        {
            _employeeRepository = new EmployeeRepository();            
        }

        public BL_Employee(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> GetAll()
        {
            try
            {
                var lstEmployee = _employeeRepository.GetAll();
                return lstEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                // Include Orders also with employee
                var employee = _employeeRepository.GetSingle(c => c.Id == id);
                return employee;                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveEmployee(Employee employee)
        {
            try
            {
                var isSaved = false;

                if (employee.Id == 0)
                {
                    isSaved = _employeeRepository.Save(employee);
                }
                else
                {
                    isSaved = _employeeRepository.Update(employee);
                }
                
                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var employee = GetEmployee(id);
                var isDeleted = _employeeRepository.Delete(employee);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
