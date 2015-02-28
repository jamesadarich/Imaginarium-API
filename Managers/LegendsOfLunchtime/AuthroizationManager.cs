using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataTransferObjects;

namespace LegendsOfLunchtime.Managers
{
    public class AuthroizationManager : IDisposable
    {
        private Imaginarium.DataAccess.AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthroizationManager()
        {
            _ctx = new Imaginarium.DataAccess.AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public IdentityResult RegisterUser(Imaginarium.DataTransferObjects.Identity userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Username
            };

            var result = _userManager.Create(user, userModel.Password);

            var legendsOfLunchtimeUser = new Models.User();
            legendsOfLunchtimeUser.Id = Guid.NewGuid();
            legendsOfLunchtimeUser.Username = userModel.Username;
            legendsOfLunchtimeUser.FirstName = "New";
            legendsOfLunchtimeUser.LastName = "User";

            var repo = new DataAccess.Repository();
            repo.Users.Add(legendsOfLunchtimeUser);
            var t = repo.SaveChanges();

            return result;
        }

        public IdentityUser FindUser(string userName, string password)
        {
            IdentityUser user = _userManager.Find(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
