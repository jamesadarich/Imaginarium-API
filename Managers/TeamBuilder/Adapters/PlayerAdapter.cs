using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Managers.Adapters
{
    public static class PlayerAdapter
    {
        public static DataTransferObjects.Player ToDto(this Models.Player model)
        {
            if (model == null) { return null; }

            var dto = new DataTransferObjects.Player();

            dto.Id = model.Id;
            dto.FirstName = model.FirstName;
            dto.LastName = model.LastName;
            dto.IsActive = model.IsActive;

            return dto;
        }

        public static Models.Player ToModel(this DataTransferObjects.Player dto, DataAccess.Repository repository)
        {
            if (dto == null) { return null; }

            var model = new Models.Player();
            model.Id = Guid.NewGuid();

            if (dto.Id != new Guid())
            {
                model = repository.Players.Single(player => player.Id == dto.Id);
            }

            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.IsActive = dto.IsActive;

            return model;
        }
    }
}
