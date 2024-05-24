using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.Entities
{ 
    [Table("StockAggregate")]
     public class StockAggregateEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal ClosePrice  { get; set; } 
        [Required]
        [Precision(10, 2)]
        public decimal HighestPrice  { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal LowestPrice { get; set; }

        [Required]
        [MaxLength(10)]
        public int NumberOfTransactions { get; set; }

        [Required]
         [Precision(10, 2)]

        public decimal OpenPrice { get; set; }
        public bool otc { get; set; }
        [Required]
                 [Precision(20, 2)]

        public decimal StartOfTheAggregateWindow { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal TradingVolume  { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [System.Text.Json.Serialization.JsonIgnore]

        public virtual StockEntity Stock { get; set; }


    }
}
