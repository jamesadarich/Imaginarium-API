using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeamBuilder.Api
{
    public class MatchController : ApiController
    {
        [HttpGet]
        [Route("team-builder/matches")]
        public IEnumerable<DataTransferObjects.Match> GetAll()
        {
            return new Managers.MatchManager().GetAll();
        }

        [HttpPost]
        [Route("team-builder/match")]
        [Authorize]
        public DataTransferObjects.Match Post(DataTransferObjects.Match match)
        {
            return new Managers.MatchManager().Create(match);
        }
    }
}
