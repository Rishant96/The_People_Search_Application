using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public string PathToAvatar { get; set; }

        public int PersonAddressId { get; set; }
        public PersonAddress Address { get; set; }

        public ICollection<PersonInterest> Interests { get; set; }

        public override string ToString()
        {
            return String.Join(' ', this.FirstName, this.MiddleName, this.LastName);
        }
    }
}
