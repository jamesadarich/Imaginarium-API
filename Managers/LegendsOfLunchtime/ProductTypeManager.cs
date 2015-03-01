using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class ProductTypeManager
    {
        public IEnumerable<DataTransferObjects.ProductType> GetAll()
        {
            var repo = new DataAccess.Repository();
            var productTypes = repo.ProductTypes.ToList();
            return productTypes.Select(p => p.ToDto());
        }
        
        public DataTransferObjects.ProductType Create(DataTransferObjects.ProductType productType)
        {
            var repository = new DataAccess.Repository();
            var productTypeModel = productType.ToModel(repository);
            repository.ProductTypes.Add(productTypeModel);
            repository.SaveChanges();
            return productTypeModel.ToDto();
        }

        public DataTransferObjects.ProductType Update(DataTransferObjects.ProductType productType)
        {
            var repository = new DataAccess.Repository();
            var productTypeModel = productType.ToModel(repository);
            repository.Entry(productTypeModel).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return productTypeModel.ToDto();
        }

        public void Delete(Guid productTypeId)
        {
            var repository = new DataAccess.Repository();
            var productType = repository.ProductTypes.Single(p => p.Id == productTypeId);
            repository.ProductTypes.Remove(productType);
            repository.SaveChanges();
        }
    }
}
