using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class UserAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.User AdaptModel(Models.LegendsOfLunchtime.User user)
        {
            if (user == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.User();

            dto.Id = user.Id;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.Username = user.Username;

            return dto;
        }

        public Models.LegendsOfLunchtime.User AdaptDto(DataTransferObjects.LegendsOfLunchtime.User user)
        {
            if (user == null)
            {
                return null;
            }

            var model = new Models.LegendsOfLunchtime.User();

            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;

            return model;
        }
    }
}
