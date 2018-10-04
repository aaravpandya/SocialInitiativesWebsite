using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialInitiatives2.Models
{
    public class InitiativeDbContext : DbContext
    {
        public InitiativeDbContext(DbContextOptions<InitiativeDbContext> options)
            : base(options) { }

        public DbSet<Initiative> intiatives;
    }
}
