using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;

namespace MVCSampleGrid.Business
{
    public interface IBL_TechCompany
    {
        IList<Tech_Company> GetAll();
        Tech_Company GetCompany(int id);
        bool SaveCompany(Tech_Company company);
        bool DeleteCompany(int id);
    }
}
