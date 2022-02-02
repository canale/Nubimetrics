﻿using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Nubimetrics.API.Controllers
{
    [ApiController]
    [Route("MyRestfulApp/[controller]")]
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
            PaisResponse dto = await _paisApplicationService.GetByIdAsync(id);
            return Ok(dto);
        }
    }
}
