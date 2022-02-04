using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Shared.Models;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly ISearchApplicationService searchApplicationService;

        public BusquedaController(ISearchApplicationService searchApplicationService)
        {
            this.searchApplicationService = searchApplicationService;
        }
        
        //[Route]
        [HttpGet("{term}")]
        public async Task<IActionResult> GetFiltered(string term)
        {
            Search  dto = await searchApplicationService.GetFilteredAsync(term);
            return Ok(dto);
        }
    }
}
