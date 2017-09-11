using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public interface IBL_Product
    {
        IList<Product> GetAll();
        Product GetProduct(int id);
        bool SaveProduct(Product product);
        bool DeleteProduct(int id);
    }
}
