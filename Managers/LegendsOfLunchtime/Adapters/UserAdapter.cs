using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class UserAdapter
    {
        public static DataTransferObjects.User ToDto(this Models.User user)
        {
            if (user == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.User();

            dto.Id = user.Id;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.Username = user.Username;

            return dto;
        }

        public static Models.User ToModel(this DataTransferObjects.User user, DataAccess.Repository repository)
        {
            if (user == null)
            {
                return null;
            }

            var model = new Models.User();
            model.Id = Guid.NewGuid();
            if (user.Id != new Guid())
            {
                model = repository.Users.Where(b => b.Id == user.Id).Single();
            }

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;

            return model;
        }
    }
}
