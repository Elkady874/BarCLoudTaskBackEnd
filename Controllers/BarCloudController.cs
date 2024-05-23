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
        [Route(nameof(stocks))]

        public async Task<IActionResult> stocks() {
            var stocks =   await _polygonService.GetStocks();
            if (stocks.StatusCode == 200) {
                return Ok(stocks);

            } else { return BadRequest(stocks); }
        }
    }
}
