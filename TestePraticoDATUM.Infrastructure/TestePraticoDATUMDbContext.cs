using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestePraticoDATUM.Infrastructure
{
    public class TestePraticoDATUMDbContext : DbContext
    {
        public TestePraticoDATUMDbContext(DbContextOptions<TestePraticoDATUMDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
