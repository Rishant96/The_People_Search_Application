using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchApp.Models
{
    public class PersonAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Line1 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Line2 { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string ZipCode { get; set; }
    }
}
