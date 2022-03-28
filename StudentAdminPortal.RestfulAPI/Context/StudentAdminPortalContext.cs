using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using StudentAdminPortal.RestfulAPI.Models;

namespace StudentAdminPortal.RestfulAPI.Context
{
    public class StudentAdminPortalContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<Address> Addresses => Set<Address>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlite("Data Source=StudentAdminPortal.db")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}
