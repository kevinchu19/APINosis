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
    public class FacturaController : ControllerBase
    {

        public FacturasRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public FacturaController(FacturasRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }

        [HttpPost]
        public async Task<ActionResult<FacturaResponse>> Post([FromBody] FacturasDTO factura)
        {
            Logger.Information($"Se recibio posteo de nueva factura {factura.CircuitoOrigen} - {factura.CircuitoAplicacion} - " +
                                $"Id de operacion: {factura.IdOperacion}");

            int idOperacion = factura.IdOperacion;

            if (Env.IsProduction())
            {
                if (int.TryParse(factura.Cliente, out _)) { factura.Cliente = string.Format("{0:00000000}", int.Parse(factura.Cliente)); };
                if (int.TryParse(factura.CodigoSubcuenta, out _)) { factura.CodigoSubcuenta = string.Format("{0:00000000}", int.Parse(factura.CodigoSubcuenta)); }
            }


            Fcrmvh facturaFormat = Mapper.Map<FacturasDTO, Fcrmvh>(factura);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            FacturaResponse response = await Repository.GraboFactura(facturaFormat, "NEW");

            response.IdOperacion = idOperacion;

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

     
    }
}
