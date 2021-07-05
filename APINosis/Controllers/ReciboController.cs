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
    public class ReciboController : ControllerBase
    {

        public RecibosRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public ReciboController(RecibosRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        [HttpGet]
        public async Task<ActionResult<RecibosDTO>> Get(string codigoComprobante, int? numeroComprobante, int? idOperacion)
        {

            RecibosDTO recibo = Mapper.Map<RecibosDTO>(await Repository.Get(codigoComprobante, numeroComprobante, idOperacion));

            if (recibo== null)
            {
                throw new BadRequestException("El comprobante solicitado no existe.");
            }

            return recibo;
        }


        [HttpPost]
        public async Task<ActionResult<ReciboResponse>> Post([FromBody] RecibosDTO recibo)
        {
            Logger.Information($"Se recibio posteo de nuevo recibo {recibo.CodigoComprobanteAGenerar} - " +
                                $"Id de operacion: {recibo.IdOperacion}");

            int idOperacion = recibo.IdOperacion;

            if (Env.IsProduction())
            {
                if (int.TryParse(recibo.Cliente, out _)) { recibo.Cliente = string.Format("{0:00000000}", int.Parse(recibo.Cliente)); };
                if (int.TryParse(recibo.CodigoSubcuenta, out _)) { recibo.CodigoSubcuenta = string.Format("{0:00000000}", int.Parse(recibo.CodigoSubcuenta)); }
            }


            Vtrrch reciboFormat = Mapper.Map<RecibosDTO, Vtrrch>(recibo);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            ReciboResponse response = recibo.TipoMovimiento == "R" ? await Repository.GraboRecibo(reciboFormat, "RUN_FOR_SCRIPT") :
                                                                     await Repository.GraboAnulacion (reciboFormat, "NEW");
         
            response.IdOperacion = idOperacion;

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

     
    }
}
