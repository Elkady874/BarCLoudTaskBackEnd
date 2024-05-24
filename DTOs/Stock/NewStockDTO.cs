using BarCLoudTaskBackEnd.DTOs.User;

namespace BarCLoudTaskBackEnd.DTOs.Stock
{
    public class NewStockDTO
    {

        public string Ticker { get; set; }


        public string Name { get; set; }
        public List<UserDTO> SubscribedUsers { get; set; }



    }
}
