using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class BrandManager
    {
        public IEnumerable<DataTransferObjects.Brand> GetAll()
        {
            var repo = new DataAccess.Repository();
            var brands = repo.Brands.ToList();
            return brands.Select(b => b.ToDto());
        }

        public DataTransferObjects.Brand Create(DataTransferObjects.Brand brand)
        {
            var repository = new DataAccess.Repository();
            var brandModel = brand.ToModel(repository);
            repository.Brands.Add(brandModel);
            repository.SaveChanges();
            return brandModel.ToDto();
        }

        public DataTransferObjects.Brand Update(DataTransferObjects.Brand brand)
        {
            var repository = new DataAccess.Repository();
            var brandModel = brand.ToModel(repository);
            repository.Entry(brandModel).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return brandModel.ToDto();
        }

        public void Delete(DataTransferObjects.Brand brand)
        {
            var repository = new DataAccess.Repository();
            repository.Brands.Remove(brand.ToModel(repository));
            repository.SaveChanges();
        }
    }
}
