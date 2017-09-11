using MVCSampleGrid.Business;
using MVCSampleGrid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace HelperClasses
{
    public class HelperEmployee
    {
        private BL_Employee objBLEmployee = new BL_Employee();

        public List<VM_Employee> GetAllEmployee()
        {
            var dataEmployee = objBLEmployee.GetAll();
            var modEmployee = dataEmployee.Select(s => new VM_Employee()
            {
                Id = s.Id,
                EmpId = s.EmpID,
                EmpName = s.EmpName,
                FirstName = s.EmpName,
                LastName = s.EmpName,
                Age = s.Age.GetValueOrDefault(),
                Address = s.Address,
                Department = s.Department
            }).OrderByDescending(o => o.EmpId).ToList();

            return modEmployee;
        }

        public VM_Employee GetEmployeeById(int id)
        {
            VM_Employee modEmployee = new VM_Employee();
            var dataEmployee = objBLEmployee.GetEmployee(id);

            modEmployee.Id = dataEmployee.Id;
            modEmployee.EmpId = dataEmployee.EmpID;
            modEmployee.EmpName = dataEmployee.EmpName;
            modEmployee.Age = dataEmployee.Age.GetValueOrDefault();
            modEmployee.Address = dataEmployee.Address;
            modEmployee.Department = dataEmployee.Department;

            return modEmployee;
        }

        public bool SaveEmployee(VM_Employee modEmployee)
        {
            bool isSaved = false;
            Employee dataEmployee = new Employee();

            dataEmployee.Id = modEmployee.Id;
            dataEmployee.EmpID = modEmployee.EmpId;
            dataEmployee.EmpName = modEmployee.EmpName;
            dataEmployee.Age = modEmployee.Age;
            dataEmployee.Address = modEmployee.Address;
            dataEmployee.Department = modEmployee.Department;

            isSaved = objBLEmployee.SaveEmployee(dataEmployee);

            return isSaved;
        }

        public bool DeleteEmployee(int id)
        {
            bool isDeleted = objBLEmployee.DeleteEmployee(id);
            return isDeleted;
        }
    }
}