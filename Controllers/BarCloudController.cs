using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.DTOs.User;
using BarCLoudTaskBackEnd.Entities;
using BarCLoudTaskBackEnd.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BarCLoudTaskBackEnd.Controllers
{
    [Route("api/[controller]")]

    public class BarCloudController : Controller
        
    {
        private IPolygonService _polygonService;
        private UserService _userService;
        private StockService _stockService;

        public BarCloudController(IPolygonService polygonService, UserService userService, StockService stockService)
        {
            _polygonService = polygonService;
            _userService = userService;
            _stockService = stockService;
        }

        [HttpGet]
        [Route(nameof(AllStocks))]

        public async Task<IActionResult> AllStocks() {
            var stocks =   await _stockService.GetAllStocks();
            if (stocks.Any()) {
                return Ok(stocks);

            } else { return BadRequest(stocks); }
        }

        [HttpGet]
        [Route(nameof(AllUsers))]

        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);

        }

        [HttpPost]
        [Route(nameof(User))]

        public async Task<IActionResult> User( [FromBody] NewUserDTO user)
        {
            var users = await _userService.InsertUsers(user);
            return Ok(users);

        }
        [HttpPut]
        [Route(nameof(UpdateUser))]

        public async Task<IActionResult> UpdateUser([FromBody]  UserDTO user)
        {
            var users = await _userService.UpdateUser(user);
            return Ok(users);

        }
        [HttpDelete]
        [Route(nameof(User))]

        public async Task<IActionResult> User(int user)
        {
            await _userService.DeleteUser(user);
            return Ok();

        }



        [HttpPost]
        [Route(nameof(insertStock))]

        public async Task<IActionResult> insertStock([FromBody] NewStockDTO user)
        {
            var users = await _stockService.InsertStock(user);
            return Ok(users);

        }
        [HttpGet]
        [Route(nameof(testtickeraggregate))]

        public async Task<IActionResult> testtickeraggregate(string sympole, string from , string to)
        {
            var stocks = await _polygonService.GetStockAggregate(sympole, from , to );
            if (stocks.StatusCode == 200)
            {
                return Ok(stocks);

            }
            else { return BadRequest(stocks); }

        }







    }
}
