using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeamBuilder.Api
{
    public class PlayerController : ApiController
    {
        [HttpGet]
        [Route("team-builder/players")]
        public IEnumerable<DataTransferObjects.Player> GetAll()
        {
            return new Managers.PlayerManager().GetAll();
        }

        [HttpPost]
        [Authorize]
        [Route("team-builder/player")]
        public DataTransferObjects.Player Post(DataTransferObjects.Player player)
        {
            return new Managers.PlayerManager().Create(player);
        }

        [HttpPut]
        [Authorize]
        [Route("team-builder/player")]
        public DataTransferObjects.Player Put(DataTransferObjects.Player player)
        {
            return new Managers.PlayerManager().Update(player);
        }

        [HttpDelete]
        [Authorize]
        [Route("team-builder/player/{playerId}")]
        public void Delete(Guid playerId)
        {
            new Managers.PlayerManager().Delete(playerId);
        }
    }
}
