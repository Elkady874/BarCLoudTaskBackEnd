using BarCLoudTaskBackEnd.DTOs.User;
using BarCLoudTaskBackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.DTOs.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }

        public string Ticker { get; set; }


        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<UserDTO> SubscribedUsers { get; set; }
    }
}
