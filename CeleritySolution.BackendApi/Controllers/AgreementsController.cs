using CeleritySolution.Application.Catalog.Agreements;
using CeleritySolution.ViewModels.Catalog.Agreements;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeleritySolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("PolicyCelerity")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly IAgreementService _agreementService;
        public AgreementsController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgreement([FromQuery] GetAgreementPagingRequest request)
        {
            var agreements = await _agreementService.GetAll(request);
            return Ok(agreements);
        }

        [HttpGet("{agreementId}")]
        public async Task<IActionResult> GetById(int agreementId)
        {
            var agreement = await _agreementService.GetById(agreementId);
            if (agreement == null)
                return BadRequest("Cannot find agreement");
            return Ok(agreement);
        }

        [HttpGet("getbyagreementName/{agreementName}")]
        public async Task<IActionResult> GetByAgreementName(string agreementName)
        {
            var agreement = await _agreementService.GetByAgreementName(agreementName);
            if (agreement == null)
                return BadRequest("Cannot find agreement");
            return Ok(agreement);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgreementCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agreementId = await _agreementService.Create(request);
            if (agreementId == 0)
                return BadRequest();

            var agreement = await _agreementService.GetById(agreementId);

            return CreatedAtAction(nameof(GetById), new { id = agreementId }, agreement);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AgreementUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var affectedResult = await _agreementService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{agreementId}")]
        public async Task<IActionResult> Delete(int agreementId)
        {
            var affectedResult = await _agreementService.Delete(agreementId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
    }
}
