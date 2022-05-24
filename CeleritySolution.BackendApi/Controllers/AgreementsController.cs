using CeleritySolution.Application.Catalog.Agreements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeleritySolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly IAgreementService _agreementService;
        public AgreementsController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agreements = await _agreementService.GetAll();
            return Ok(agreements);
        }
    }
}
