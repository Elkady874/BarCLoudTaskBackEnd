using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarCLoudTaskBackEnd.Entities
{
    [Table("Stock")]
    [Index(nameof(Ticker), IsUnique = true)]
    public class StockEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Ticker { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
      
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<StockAggregateEntity>  StockAggregate { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<BarCloudUserEntity>  SubscribedUsers { get; set; }

    }
}
