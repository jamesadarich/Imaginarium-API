using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class RatingTypeManager
    {
        public IEnumerable<DataTransferObjects.RatingType> GetAll()
        {
            var repo = new DataAccess.Repository();
            var ratingTypes = repo.RatingTypes.ToList();
            return ratingTypes.Select(r => r.ToDto());
        }

        public DataTransferObjects.RatingType Create(DataTransferObjects.RatingType ratingType)
        {
            var repository = new DataAccess.Repository();
            var ratingTypeModel = ratingType.ToModel(repository);
            repository.RatingTypes.Add(ratingTypeModel);
            repository.SaveChanges();
            return ratingTypeModel.ToDto();
        }

        public DataTransferObjects.RatingType Update(DataTransferObjects.RatingType ratingType)
        {
            var repository = new DataAccess.Repository();
            var ratingTypeModel = ratingType.ToModel(repository);
            repository.Entry(ratingTypeModel).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return ratingTypeModel.ToDto();
        }

        public void Delete(Guid ratingTypeId)
        {
            var repository = new DataAccess.Repository();
            var ratingType = repository.RatingTypes.Single(x => x.Id == ratingTypeId);
            repository.RatingTypes.Remove(ratingType);
            repository.SaveChanges();
        }
    }
}
