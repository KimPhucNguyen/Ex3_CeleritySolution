using CeleritySolution.Application.Catalog.Distributors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeleritySolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        private readonly IDistributorService _distributorService;
        public DistributorsController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var distributors = await _distributorService.GetAll();
            return Ok(distributors);
        }
    }
}
