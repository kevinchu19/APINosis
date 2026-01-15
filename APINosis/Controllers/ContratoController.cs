using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNosis.Models;
using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Models;
using APINosis.Models.Response;
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
    public class ContratoController : ControllerBase
    {

        public ContratoRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public ContratoController(ContratoRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }

        [HttpPut]
        public async Task<ActionResult<List<ContratoResponse>>> Put([FromBody] List<ContratosDTO> contratos)
        {
            bool hayError = false;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            List<ContratoResponse> responseList = new List<ContratoResponse>();


            foreach (ContratosDTO contrato in contratos)
            {
                Logger.Information($"Se recibio actualizacion de datos del contrato{contrato.TipoContrato} - " +
                                   $"'{contrato.CodigoContrato} - Id de operacion: {contrato.IdOperacion}");

                int idOperacion = contrato.IdOperacion;

                if (Env.IsProduction())
                {
                    if (int.TryParse(contrato.Cliente, out _)) { contrato.Cliente = string.Format("{0:00000000}", int.Parse(contrato.Cliente)); };
                    if (int.TryParse(contrato.CodigoDeSubcuenta, out _)) { contrato.CodigoDeSubcuenta = string.Format("{0:00000000}", int.Parse(contrato.CodigoDeSubcuenta)); }
                }

                Cvmcth contratoFormat = Mapper.Map<ContratosDTO, Cvmcth>(contrato);

                //ClienteResponse response = Repository.GraboCliente(clienteFormat, "OPEN");
                ContratoResponse response = await Repository.ActualizoContrato(contratoFormat);

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
        public async Task<ActionResult<ClienteResponse>> Post([FromBody] ContratosDTO contrato)
        {
            Logger.Information($"Se recibio posteo de nuevo contrato{contrato.TipoContrato} - {contrato.CodigoContrato} - " +
                                $"Id de operacion: {contrato.IdOperacion}");

            int idOperacion = contrato.IdOperacion;

            if (Env.IsProduction())
            {
                if (int.TryParse(contrato.Cliente, out _)) { contrato.Cliente = string.Format("{0:00000000}", int.Parse(contrato.Cliente)); };
                if (int.TryParse(contrato.CodigoDeSubcuenta, out _)) { contrato.CodigoDeSubcuenta = string.Format("{0:00000000}", int.Parse(contrato.CodigoDeSubcuenta)); }
            }


            Cvmcth contratoFormat = Mapper.Map<ContratosDTO, Cvmcth>(contrato);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            ContratoResponse response = await Repository.GraboContrato(contratoFormat, "NEW");

            response.IdOperacion = idOperacion;

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpGet]
        public async Task<ActionResult<List<ContratosDTO>>> Get(string? tipoContrato, string codigoContrato, int numeroExtension)
        {

            List<ContratosDTO> contrato = await Repository.Get(tipoContrato, codigoContrato, numeroExtension);

            return contrato;
        }

        [HttpGet]
        [Route("transaccion/{id}")]
        public async Task<ActionResult<Transaccion>> GetByIdOperacion(string id)
        {

            //List<ClienteDTO> clientesDTO = Mapper.Map<List<ClienteDTO>>(await Repository.Get(numeroCliente));

            return await Repository.GetTransaccionById(id);


        }

    }
}


