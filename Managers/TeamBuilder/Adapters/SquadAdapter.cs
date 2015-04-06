using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Managers.Adapters
{
    public static class SquadAdapter
    {
        public static DataTransferObjects.Squad ToDto(this Models.Squad model)
        {
            if (model == null) { return null; }

            var dto = new DataTransferObjects.Squad();

            dto.Name = model.Name;

            if (model.Players.Count() > 0)
            {
                dto.Players = model.Players.Select(player => player.ToDto());
            }

            return dto;
        }

        public static Models.Squad ToModel(this DataTransferObjects.Squad dto, DataAccess.Repository repository)
        {
            if (dto == null) { return null; }

            var model = new Models.Squad();
            model.Id = Guid.NewGuid();

            if (dto.Id != new Guid())
            {
                model = repository.Squads.Single(squad => squad.Id == dto.Id);
            }

            model.Name = dto.Name;

            if (dto.Players.Count() > 0)
            {
                model.Players = dto.Players.Select(player => player.ToModel(repository)).ToList();
            }

            return model;
        }
    }
}
