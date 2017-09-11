using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;

namespace MVCSampleGrid.Business
{
    public interface IBL_Employee
    {
        IList<Employee> GetAll();
        Employee GetEmployee(int id);
        bool SaveCustomer(Employee employee);
        bool DeleteEmployee(int id);
    }
}
