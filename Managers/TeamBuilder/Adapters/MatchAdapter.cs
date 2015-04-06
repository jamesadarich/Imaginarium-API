using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Managers.Adapters
{
    public static class MatchAdapter
    {
        public static DataTransferObjects.Match ToDto(this Models.Match model)
        {
            if (model == null) { return null; }

            var dto = new DataTransferObjects.Match();

            dto.Id = model.Id;
            dto.Teams = model.Teams.Select(team => team.ToDto());
            dto.Timestamp = model.Timestamp;

            return dto;
        }

        public static Models.Match ToModel(this DataTransferObjects.Match dto, DataAccess.Repository repository)
        {
            if (dto == null) { return null; }

            var model = new Models.Match();
            model.Id = Guid.NewGuid();

            if (dto.Id != new Guid())
            {
                model = repository.Matches.Single(match => match.Id == dto.Id);
            }

            if (dto.Teams.Count() > 0)
            {
                model.Teams = dto.Teams.Select(team => team.ToModel(repository)).ToList();
            }

            model.Timestamp = dto.Timestamp;

            return model;
        }
    }
}
