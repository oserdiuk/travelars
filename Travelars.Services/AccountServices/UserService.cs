using System;
using System.Threading.Tasks;
using AutoMapper;
using Travelars.DAL;
using Travelars.Domain.Entities;
using Travelars.DTO;
using Travelars.Services.Abstract;

namespace Travelars.Services.AccountServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid CreateUser(UserModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Id = Guid.NewGuid();
            _unitOfWork.UserRepository.RegisterUser(user);

            return user.Id;
        }

        public async Task<UserModel> FindUserAsync(string userName, string password)
        {
            var user = await _unitOfWork.UserRepository.FindUserAsync(userName, password);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
    }
}
