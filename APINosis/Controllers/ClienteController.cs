using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Models;
using APINosis.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace APINosis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public ClienteRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public ClienteController(ClienteRepository repository,Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }

        [HttpPut]
        public async Task<ActionResult<List<ClienteResponse>>> Put ([FromBody] List<ClienteDTO> clientes)
        {
            bool hayError = false;
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            List<ClienteResponse> responseList = new List<ClienteResponse>();

            
            foreach (ClienteDTO cliente in clientes)
            {
                Logger.Information($"Se recibio actualizacion de datos del cliente{cliente.NumeroCliente} - {cliente.RazonSocial} - Id de operacion: {cliente.IdOperacion}");
                
                int idOperacion = cliente.IdOperacion;

                if (Env.IsProduction())
                {
                    if (int.TryParse(cliente.NumeroCliente, out _)) { cliente.NumeroCliente = string.Format("{0:00000000}", int.Parse(cliente.NumeroCliente)); };
                    if (int.TryParse(cliente.NumeroSubcuenta, out _)) { cliente.NumeroSubcuenta = string.Format("{0:00000000}", int.Parse(cliente.NumeroSubcuenta)); }
                }

                Vtmclh clienteFormat = Mapper.Map<ClienteDTO, Vtmclh>(cliente);

                //ClienteResponse response = Repository.GraboCliente(clienteFormat, "OPEN");
                ClienteResponse response = await Repository.ActualizoCliente(clienteFormat);

                response.IdOperacion = idOperacion;
                if (response.Estado != 200)
                {
                    hayError = true;
                }

                responseList.Add(response);    

            }
            
            if (hayError)
            {
                return BadRequest(responseList);
            }

            return Ok(responseList);

        }



        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Post ([FromBody] ClienteDTO cliente)
        {
            Logger.Information($"Se recibio posteo de nuevo cliente{cliente.NumeroCliente} - {cliente.RazonSocial} - Id de operacion: {cliente.IdOperacion}");

            int idOperacion = cliente.IdOperacion;

            if (Env.IsProduction())
            {
                if (int.TryParse(cliente.NumeroCliente, out _)) { cliente.NumeroCliente = string.Format("{0:00000000}", int.Parse(cliente.NumeroCliente)); };
                if (int.TryParse(cliente.NumeroSubcuenta, out _)) { cliente.NumeroSubcuenta = string.Format("{0:00000000}", int.Parse(cliente.NumeroSubcuenta)); }
            }


            VtmclhDTO clienteFormat = Mapper.Map<ClienteDTO, VtmclhDTO>(cliente);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            ClienteResponse response = await Repository.GraboCliente(clienteFormat, "NEW");

            response.IdOperacion = idOperacion;

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }
        
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get(string? numeroCliente)
        {
            numeroCliente = string.Format("{0:00000000}", int.Parse(numeroCliente));

            List<ClienteDTO> clientesDTO = Mapper.Map<List<ClienteDTO>>(await Repository.Get(numeroCliente));

            return clientesDTO;
        }
        
    }
}
