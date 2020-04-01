using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearchApp.Models
{
    public class PersonInterests
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Interest { get; set; }
    }
}