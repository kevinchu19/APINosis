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
    public class AnulacionReciboController : ControllerBase
    {

        public AnulacionRecibosRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public AnulacionReciboController(AnulacionRecibosRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        
        [HttpPost]
        public async Task<ActionResult<ReciboResponse>> Post([FromBody] RecibosDTO anulacionRecibo)
        {
            Logger.Information($"Se recibio posteo de nuevo anulacionRecibo {anulacionRecibo.CodigoComprobanteAGenerar} - " +
                                $"Id de operacion: {anulacionRecibo.IdOperacion}");

            int idOperacion = anulacionRecibo.IdOperacion;


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            ReciboResponse response = await Repository.GraboAnulacionRecibo(anulacionRecibo, "RUN_FOR_SCRIPT");
         
            response.IdOperacion = idOperacion;

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

     
    }
}
