using System;
using System.Threading.Tasks;
using Travelars.DTO;

namespace Travelars.Services.Abstract
{
    public interface IUserService
    {
        Guid CreateUser(UserModel model);

        Task<UserModel> FindUserAsync(string contextUserName, string contextPassword);
    }
}
