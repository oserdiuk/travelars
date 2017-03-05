﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelars.DAL.Abstract;
using Travelars.DAL.Repositories;
using Travelars.Domain.Entities;

namespace Travelars.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelarsDbContext _dbContext;

        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IRepository<UserDetails>> _userDetailsRepository;

        public UnitOfWork()
        {
            _dbContext = new TravelarsDbContext();
            _userDetailsRepository = new Lazy<IRepository<UserDetails>>(() => new RepositoryBase<UserDetails>(_dbContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_dbContext));
        }

        public IRepository<UserDetails> UserDetailsRepository => _userDetailsRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
