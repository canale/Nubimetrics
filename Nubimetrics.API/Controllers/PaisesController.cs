using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{
    [Route("MyRestfulApp/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisApplicationService _paisApplicationService;

        public PaisesController(IPaisApplicationService paisApplicationService)
        {
            _paisApplicationService = paisApplicationService;
        }
        
        //[Route]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaises(string id)
        {
            PaisDto dto = await _paisApplicationService.GetByIdAsync(id);
            return Ok(dto);
        }
    }
}
