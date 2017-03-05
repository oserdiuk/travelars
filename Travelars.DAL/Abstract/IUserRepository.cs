using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Travelars.Domain.Entities;

namespace Travelars.DAL.Abstract
{
    public interface IUserRepository
    {
        void RegisterUser(User userModel);

        Task<IdentityUser> FindUserAsync(string userName, string password);
    }
}
