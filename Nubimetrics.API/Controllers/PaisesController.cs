using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{
    [ApiController]
    [Route("MyRestfulApp/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly ICountryApplicationService _paisApplicationService;

        public PaisesController(ICountryApplicationService paisApplicationService)
        {
            _paisApplicationService = paisApplicationService;
        }
        
        //[Route]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaises(string id)
        {
            CountryResponse dto = await _paisApplicationService.GetByIdAsync(id);
            return Ok(dto);
        }
    }
}
