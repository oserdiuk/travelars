using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Travelars.Domain.Entities;

namespace Travelars.DAL
{
    public class TravelarsDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
