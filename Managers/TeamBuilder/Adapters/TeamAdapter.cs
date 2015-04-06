using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Managers.Adapters
{
    public static class TeamAdapter
    {
        public static DataTransferObjects.Team ToDto(this Models.Team model)
        {
            if (model == null) { return null; }

            var dto = new DataTransferObjects.Team();

            dto.Id = model.Id;
            dto.Score = model.Score;
            dto.Squad = model.Squad.ToDto();

            return dto;
        }

        public static Models.Team ToModel(this DataTransferObjects.Team dto, DataAccess.Repository repository)
        {
            if (dto == null) { return null; }

            var model = new Models.Team();
            model.Id = Guid.NewGuid();

            if (dto.Id != new Guid())
            {
                model.Score = dto.Score;
                model.SquadId = dto.Squad.Id;
                model.Squad = dto.Squad.ToModel(repository);
            }

            return model;
        }
    }
}
