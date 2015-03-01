using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class ProductManager
    {
        public IEnumerable<DataTransferObjects.Product> GetAll()
        {
            var repo = new DataAccess.Repository();
            var products = repo.Products.ToList();
            return products.Select(b => b.ToDto());
        }

        public DataTransferObjects.Product Create(DataTransferObjects.Product product)
        {
            var repository = new DataAccess.Repository();
            var productModel = product.ToModel(repository);
            repository.Products.Add(productModel);
            repository.SaveChanges();
            return productModel.ToDto();
        }

        public DataTransferObjects.Product Update(DataTransferObjects.Product product)
        {
            var repository = new DataAccess.Repository();
            var productModel = product.ToModel(repository);
            repository.Entry(productModel).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return productModel.ToDto();
        }

        public void Delete(Guid productId)
        {
            var repository = new DataAccess.Repository();
            var product = repository.Products.Single(p => p.Id == productId);
            repository.Products.Remove(product);
            repository.SaveChanges();
        }
    }
}
