using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelars.DAL.Repositories;
using Travelars.Domain.Models;

namespace Travelars.DAL
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }

        void SaveChanges();
    }
}
