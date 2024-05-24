using BarCLoudTaskBackEnd.DTOs.User;
using BarCLoudTaskBackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.DTOs.Stock
{
    public class StockDTO
    {
 
        public string Ticker { get; set; }


        public string Name { get; set; }


        public List<UserDTO>? SubscribedUsers { get; set; }
    }
}
