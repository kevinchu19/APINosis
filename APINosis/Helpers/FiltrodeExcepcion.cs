using APINosis.Models;
using APINosis.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APINosis.Helpers
{
    public class FiltrodeExcepcion : ExceptionFilterAttribute, IExceptionFilter
    {
       public Serilog.ILogger logger { get; }

        public FiltrodeExcepcion(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public async override void  OnException(ExceptionContext context)
        {
            string errorMessage;
            if (context.Exception.InnerException != null)
            {
                errorMessage = $"{context.Exception.InnerException}";
                
                if (typeof(AutoMapperMappingException) == context.Exception.InnerException.GetType())
                {
                    AutoMapperMappingException errorAutomapper = (AutoMapperMappingException)context.Exception.InnerException;
                    errorMessage = $"Error: {errorAutomapper} origen: {errorAutomapper.MemberMap.SourceMember.Name}. " +
                        $"Destino:{errorAutomapper.MemberMap.DestinationName}";
                }
            }
            else
            {
                errorMessage = $"{context.Exception.Message}"; //- {context.Exception.StackTrace}";
            }

            logger.Fatal(errorMessage);


            ClienteResponse response = new ClienteResponse("",0,"") { };


            switch (context.Exception.GetType().ToString())
            {
                case "APINosis.Helpers.NotFoundException":
                    response.Estado = 404;
                    response.Titulo = "Not Found";
                    response.IdOperacion = 0;
                    response.Mensaje = "El recurso solicitado no fue encontrado";
                    context.Result = new NotFoundObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                        (int)HttpStatusCode.NotFound;
                    break;
                case "APINosis.Helpers.BadRequestException":
                    response.Estado = 400;
                    response.Titulo = "Bad Request";
                    response.IdOperacion = 0;
                    response.Mensaje = errorMessage;
                    context.Result = new NotFoundObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                        (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.Estado = 500;
                    response.Titulo = "Error interno de la aplicación";
                    response.Mensaje = errorMessage;
                    response.IdOperacion = 0;
                    context.Result = new ObjectResult(response);
                    context.HttpContext.Response.StatusCode =
                              (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.ExceptionHandled = true;

        }
    }
}
