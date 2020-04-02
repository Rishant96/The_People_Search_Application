using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Contexts
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "David",
                    LastName = "Johnson",
                    DOB = new DateTime(1982, 03, 24),
                    PersonAddressId = 1
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Ashley",
                    LastName = "Thompson",
                    DOB = new DateTime(1991, 09, 01),
                    PersonAddressId = 2
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Varun",
                    LastName = "Dutt",
                    DOB = new DateTime(1994, 02, 20),
                    PersonAddressId = 3
                }
            );
        }
    }
}
