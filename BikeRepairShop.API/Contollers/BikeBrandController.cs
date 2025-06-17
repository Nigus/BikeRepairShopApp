using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeRepairShop.API.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeBrandController: ControllerBase
    {
        private readonly BikeBrandHandler _bikeBrandHandler;
        private readonly ILogger<BikeBrandController> _logger;

        public BikeBrandController(BikeBrandHandler bikeBrandHandler, ILogger<BikeBrandController> logger)
        {
            _bikeBrandHandler = bikeBrandHandler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBikeBrands()
        {
            try
            {
                var bikeBrands = await _bikeBrandHandler.GetAllBikeBrand();
                return Ok(bikeBrands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBikeBrand([FromBody] BikeBrand bikeBrand)
        {
            try
            {
                await _bikeBrandHandler.AddBikeBrand(bikeBrand);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
