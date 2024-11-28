using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Entities;

namespace TestePraticoDATUM.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasMany(u => u.Posts)
                .WithOne()
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}