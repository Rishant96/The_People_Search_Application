using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string PathToAvatar { get; set; }

        [Required]
        public int PersonAddressId { get; set; }
        public virtual PersonAddress Address { get; set; }

        [Required]
        public bool IsFavorite { get; set; }

        public virtual ICollection<PersonInterest> Interests { get; set; }

        public override string ToString()
        {
            return String.Join(' ', this.FirstName, this.MiddleName, this.LastName);
        }
    }
}
