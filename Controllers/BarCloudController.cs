using BarCLoudTaskBackEnd.DTOs;
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

        public BarCloudController(IPolygonService polygonService, UserService userService)
        {
            _polygonService = polygonService;
            _userService = userService;
        }

        [HttpGet]
        [Route(nameof(AllStocks))]

        public async Task<IActionResult> AllStocks() {
            var stocks =   await _polygonService.GetStocks();
            if (stocks.StatusCode == 200) {
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

        public async Task<IActionResult> User(NewUserDTO user)
        {
            var users = await _userService.InsertUsers(user);
            return Ok(users);

        }
        [HttpPut]
        [Route(nameof(UpdateUser))]

        public async Task<IActionResult> UpdateUser(UserDTO user)
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


    }
}
