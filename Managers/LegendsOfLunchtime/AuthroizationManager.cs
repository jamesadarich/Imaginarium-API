using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Managers.LegendsOfLunchtime
{
    public class AuthroizationManager : IDisposable
    {
        private DataAccess.AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthroizationManager()
        {
            _ctx = new DataAccess.AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public IdentityResult RegisterUser(DataTransferObjects.Identity userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Username
            };

            var result = _userManager.Create(user, userModel.Password);

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
