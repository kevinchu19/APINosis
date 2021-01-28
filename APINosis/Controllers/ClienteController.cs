using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APINosis.Models;
using APINosis.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINosis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public ClienteRepository Repository { get; }
        public ClienteController(ClienteRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public ActionResult<APIResponse> Post ([FromBody] ClienteDTO cliente)
        {
            APIResponse response = new APIResponse();
                
            response = Repository.GraboCliente(cliente);

            return Ok(response);

        }
        
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get(string? numeroCliente)
        {
            return await Repository.Get(numeroCliente);
        }
        
    }
}
