using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Contexts
{
    public class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAddress>
    {
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.HasData(
                new PersonAddress
                {
                    Id = 1,
                    Line1 = "1539, Bonnie Rd",
                    City = "Charlotte",
                    State = "North Carolina",
                    ZipCode = "28213",
                    Country = "United States",
                },
                new PersonAddress
                {
                    Id = 2,
                    Line1 = "1624 C, Arlyn Cir",
                    Line2 = "Margie Ann Rd",
                    City = "Charlotte",
                    State = "North Carolina",
                    ZipCode = "28213",
                    Country = "United States",
                },
                new PersonAddress
                {
                    Id = 3,
                    Line1 = "House No. 259, Sector 9A",
                    City = "Gurugram",
                    State = "Haryana",
                    ZipCode = "122001",
                    Country = "India",
                }
            );
        }
    }
}
