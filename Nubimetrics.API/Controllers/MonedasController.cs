using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{

    [ApiController]
    [Route("MyRestfulApp/[controller]")]
    public class MonedasController : ControllerBase
    {
        private readonly IMonedaApplicationService monedaApplicationService;

        public MonedasController(IMonedaApplicationService monedaApplicationService)
        {
            this.monedaApplicationService = monedaApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MonedaItemResponse> monedas = await monedaApplicationService.GetAllAsync();
            return Ok(monedas);
        }
    }
}
