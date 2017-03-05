using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using Travelars.Domain.Entities;
using Travelars.DTO;
using Travelars.Models;

namespace Travelars
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappingModules()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, RegisterModel>().ReverseMap();
                cfg.CreateMap<UserModel, User>().ReverseMap();
                cfg.CreateMap<IdentityUser, UserModel>();
            });

            return config;
        }
    }
}