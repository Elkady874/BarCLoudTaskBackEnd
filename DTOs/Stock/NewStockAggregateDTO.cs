using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.DTOs.Stock
{
    public class NewStockAggregateDTO
    {
     
        public decimal ClosePrice { get; set; }
    
        public decimal HighestPrice { get; set; }
 
        public decimal LowestPrice { get; set; }

     
        public int NumberOfTransactions { get; set; }

     
        public decimal OpenPrice { get; set; }
        public bool otc { get; set; }
     
        public decimal StartOfTheAggregateWindow { get; set; }
    
        public decimal TradingVolume { get; set; }
        public string? Name { get; set; }

}
}
