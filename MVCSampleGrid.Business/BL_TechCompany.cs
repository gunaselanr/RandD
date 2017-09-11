using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public class BL_TechCompany : IBL_TechCompany
    {
        private ITech_CompanyRepository _companyRepository;

        public BL_TechCompany()
        {
            _companyRepository = new Tech_CompanyRepository();
        }

        public IList<Data.Tech_Company> GetAll()
        {
            try
            {
                var lstCompany = _companyRepository.GetAll();
                return lstCompany;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Data.Tech_Company GetCompany(int id)
        {
            try
            {
                var company = _companyRepository.GetSingle(c => c.Id == id);
                return company;   
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveCompany(Data.Tech_Company company)
        {
            try
            {
                var isSaved = false;

                if (company.Id == 0)
                {
                    isSaved = _companyRepository.Save(company);
                }
                else
                {
                    isSaved = _companyRepository.Update(company);
                }

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCompany(int id)
        {
            try
            {
                var company = GetCompany(id);
                var isDeleted = _companyRepository.Delete(company);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
