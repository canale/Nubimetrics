using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly IPaisApplicationService _paisApplicationService;

        public BusquedaController(IPaisApplicationService paisApplicationService)
        {
            _paisApplicationService = paisApplicationService;
        }
        
        //[Route]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaises(string id)
        {
            PaisResponse dto = await _paisApplicationService.GetByIdAsync(id);
            return Ok(dto);
        }
    }
}
