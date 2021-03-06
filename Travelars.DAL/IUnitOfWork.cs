﻿using Travelars.DAL.Abstract;
using Travelars.DAL.Repositories;
using Travelars.Domain.Entities;

namespace Travelars.DAL
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRepository<UserDetails> UserDetailsRepository { get; }

        IRepository<Place> PlaceRepository { get; }

        IRepository<UserVote> VoteRepository { get; }

        void SaveChanges();
    }
}
