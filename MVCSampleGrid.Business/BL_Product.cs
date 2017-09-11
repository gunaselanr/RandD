using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public class BL_Product:IBL_Product
    {
        private IProductRepository _productRepository;
        public BL_Product()
        {
            _productRepository = new ProductRepository();
        }

        public BL_Product(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAll()
        {
            try
            {
                var lstProduct = _productRepository.GetAll();
                return lstProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                // Include Orders also with product
                var product = _productRepository.GetSingle(c => c.Id == id);
                return product;                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                var isSaved = false;

                if (product.Id == 0)
                {
                    isSaved = _productRepository.Save(product);
                }
                else
                {
                    isSaved = _productRepository.Update(product);
                }

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = GetProduct(id);
                var isDeleted = _productRepository.Delete(product);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
