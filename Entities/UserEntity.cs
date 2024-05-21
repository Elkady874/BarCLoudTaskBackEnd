using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BarCLoudTaskBackEnd.Entities
{
    [Table("User")]
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
