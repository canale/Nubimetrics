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
        private readonly ICurrencyApplicationService monedaApplicationService;

        public MonedasController(ICurrencyApplicationService monedaApplicationService)
        {
            this.monedaApplicationService = monedaApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CurrencyItemResponse> monedas = await monedaApplicationService.GetAllAsync();
            return Ok(monedas);
        }
    }
}
