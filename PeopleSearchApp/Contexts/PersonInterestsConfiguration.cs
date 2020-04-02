using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Contexts
{
    public class PersonInterestsConfiguration : IEntityTypeConfiguration<PersonInterest>
    {
        public void Configure(EntityTypeBuilder<PersonInterest> builder)
        {
            builder.HasData(
                new PersonInterest
                {
                    Id = 1,
                    PersonId = 1,
                    Interest = "Reading Novels"
                },
                new PersonInterest
                {
                    Id = 2,
                    PersonId = 1,
                    Interest = "Swimming"
                },
                new PersonInterest
                {
                    Id = 3,
                    PersonId = 2,
                    Interest = "Camping"
                },
                new PersonInterest
                {
                    Id = 4,
                    PersonId = 2,
                    Interest = "Listening to Music"
                },
                new PersonInterest
                {
                    Id = 5,
                    PersonId = 2,
                    Interest = "Cooking"
                },
                new PersonInterest
                {
                    Id = 6,
                    PersonId = 3,
                    Interest = "Playing Video Games"
                },
                new PersonInterest
                {
                    Id = 7,
                    PersonId = 3,
                    Interest = "Playing Guitar"
                }
            );
        }
    }
}
