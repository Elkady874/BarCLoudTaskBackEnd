﻿using BarCLoudTaskBackEnd.DTOs.Stock;
using System.ComponentModel.DataAnnotations;

namespace BarCLoudTaskBackEnd.DTOs.User
{
    public class NewUserDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
 
        public List<StockDTO> RegisteredStock { get; set; }

    }
}
