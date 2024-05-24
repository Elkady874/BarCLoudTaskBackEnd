using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public   List<StockDTO> RegisteredStock { get; set; }


    }
}
