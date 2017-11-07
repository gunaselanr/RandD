using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSampleGrid.Business;
using MVCSampleGrid.Data;

namespace SampleWebApplication.HelperClass
{
    public class HelperTechCompany
    {
        private BL_TechCompany objBLCompany = new BL_TechCompany();
        public List<Model.VM_TechCompany> GetAllCompany()
        {
            var dataCompany = objBLCompany.GetAll();
            var modCompany = dataCompany.Select(c => new Model.VM_TechCompany()
            {
                Id = c.Id,
                Name = c.Name,
                Year_2011 = c.Year_2011,
                Year_2012 = c.Year_2012,
                Year_2013 = c.Year_2013,
                Year_2014 = c.Year_2014,
                RowTotal = c.Year_2011 + c.Year_2012 + c.Year_2013 + c.Year_2014
            })
            .OrderByDescending(o => o.Id)
            .ToList();

            return modCompany;
        }

        public Model.VM_TechCompany GetCompanyById(int id)
        {
            Model.VM_TechCompany modCompany = new Model.VM_TechCompany();
            var dataCompany = objBLCompany.GetCompany(id);

            modCompany.Id = dataCompany.Id;
            modCompany.Name = dataCompany.Name;
            modCompany.Year_2011 = dataCompany.Year_2011;
            modCompany.Year_2012 = dataCompany.Year_2012;
            modCompany.Year_2013 = dataCompany.Year_2013;
            modCompany.Year_2014 = dataCompany.Year_2014;

            return modCompany;
        }

        public bool SaveCompany(Model.VM_TechCompany modCompany)
        {
            bool isSaved = false;

            foreach (var item in modCompany.lstCompany)
            {
                Tech_Company dataCompany = new Tech_Company();
                dataCompany.Id = item.Id;
                dataCompany.Name = item.Name;
                dataCompany.Year_2011 = item.Year_2011;
                dataCompany.Year_2012 = item.Year_2012;
                dataCompany.Year_2013 = item.Year_2013;
                dataCompany.Year_2014 = item.Year_2014;

                isSaved = objBLCompany.SaveCompany(dataCompany);
            }

            return isSaved;
        }

        public bool DeleteCompany(int id)
        {
            bool isDeleted = objBLCompany.DeleteCompany(id);
            return isDeleted;
        }
    }
}