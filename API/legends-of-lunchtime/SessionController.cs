using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Imaginarium_API.legends_of_lunchtime
{
    public class SessionController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/login")]
        public DataTransferObjects.LegendsOfLunchtime.Session Get(string username, string password)
        {
            var session = new DataTransferObjects.LegendsOfLunchtime.Session();

            session.Id = Guid.NewGuid();
            session.ExpiresOn = DateTime.UtcNow.AddMinutes(10);

            return session;
        }
    }
}
