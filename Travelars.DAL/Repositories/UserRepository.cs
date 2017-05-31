using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Travelars.DAL.Abstract;
using Travelars.Domain.Entities;

namespace Travelars.DAL.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(TravelarsDbContext dbContext)
        {
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(dbContext));
        }

        public void RegisterUser(User userModel)
        {
            var user = new IdentityUser
            {
                Id = userModel.Id.ToString(),
                UserName = userModel.UserName
            };
            var result = _userManager.Create(user, userModel.Password);
            VerifyResult(result);
        }

        public async Task<IdentityUser> FindUserAsync(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        private void VerifyResult(IdentityResult roleAddedresult)
        {
            if (!roleAddedresult.Succeeded)
            {
                throw new Exception(string.Join("\n", roleAddedresult.Errors));
            }
        }
    }
}
