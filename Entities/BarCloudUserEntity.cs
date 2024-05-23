using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BarCLoudTaskBackEnd.Entities
{
    [Table("BarCloudUser")]
    [Index(nameof(Email), IsUnique = true)]
    public class BarCloudUserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
      [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<StockEntity> RegisteredStock { get; set; }



    }
}
