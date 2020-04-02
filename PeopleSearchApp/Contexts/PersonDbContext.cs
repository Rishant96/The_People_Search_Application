using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Contexts
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonAddressConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonInterestsConfiguration());
        }

        public DbSet<Person> People { get; set; }

        public DbSet<PeopleSearchApp.Models.PersonAddress> PersonAddress { get; set; }

        public DbSet<PeopleSearchApp.Models.PersonInterest> PersonInterest { get; set; }
    }
}
