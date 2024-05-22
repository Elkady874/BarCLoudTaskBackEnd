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

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
      

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public virtual ICollection<StockAggregateEntity>  StockAggregate { get; set; }
        public virtual ICollection<BarCloudUserEntity>  SubscribedUsers { get; set; }

    }
}
