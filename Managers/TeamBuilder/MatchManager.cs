using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Managers.Adapters;

namespace TeamBuilder.Managers
{
    public class MatchManager
    {
        public IEnumerable<DataTransferObjects.Match> GetAll()
        {
            var repository = new DataAccess.Repository();

            return repository.Matches.ToList().Select(model => model.ToDto());
        }

        public DataTransferObjects.Match GetById(Guid id)
        {
            var repository = new DataAccess.Repository();

            return repository.Matches.ToList().Single(model => model.Id == id).ToDto();
        }

        public DataTransferObjects.Match Create(DataTransferObjects.Match match)
        {
            var repository = new DataAccess.Repository();

            var model = match.ToModel(repository);
            repository.Matches.Add(model);
            repository.SaveChanges();
            return model.ToDto();
        }

        public DataTransferObjects.Match Update(DataTransferObjects.Match match)
        {
            var repository = new DataAccess.Repository();

            var model = match.ToModel(repository);
            repository.Entry(model).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return model.ToDto();
        }

        public void Delete(DataTransferObjects.Match match)
        {
            var repository = new DataAccess.Repository();

            var model = match.ToModel(repository);
            repository.Matches.Remove(model);
            repository.SaveChanges();
        }
    }
}
