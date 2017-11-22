using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistTrainSystem.Models;

namespace AssistTrainSystem.Models
{
    public class SystemContext:DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options):base(options)
        {

        }

        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
        public DbSet<AssistTrainSystem.Models.BodyAbility> BodyAbility { get; set; }
    }
}
