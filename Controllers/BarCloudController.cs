using BarCLoudTaskBackEnd.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BarCLoudTaskBackEnd.Controllers
{
    [Route("api/[controller]")]

    public class BarCloudController : Controller
        
    {
        private IPolygonService _polygonService;

        public BarCloudController(IPolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        [HttpGet]
        public async Task<IActionResult> stocks() {
            var stocks =   await _polygonService.GetStocks();
            return Ok(stocks);
        }
    }
}
