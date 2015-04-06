using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Managers.Adapters;

namespace TeamBuilder.Managers
{
    public class PlayerManager
    {
        public IEnumerable<DataTransferObjects.Player> GetAll()
        {
            var repository = new DataAccess.Repository();
            return repository.Players.ToList().Select(model => model.ToDto());
        }

        public DataTransferObjects.Player GetById(Guid id)
        {
            var repository = new DataAccess.Repository();
            return repository.Players.Single(model => model.Id == id).ToDto();
        }

        public DataTransferObjects.Player Create(DataTransferObjects.Player player)
        {
            var repository = new DataAccess.Repository();

            var model = player.ToModel(repository);
            repository.Players.Add(model);
            repository.SaveChanges();
            return model.ToDto();
        }

        public DataTransferObjects.Player Update(DataTransferObjects.Player player)
        {
            var repository = new DataAccess.Repository();

            var model = player.ToModel(repository);
            repository.Entry(model).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
            return model.ToDto();
        }

        public void Delete(Guid playerId)
        {
            var repository = new DataAccess.Repository();

            var model = repository.Players.Single(player => player.Id == playerId);
            repository.Players.Remove(model);
            repository.SaveChanges();
        }
    }
}
