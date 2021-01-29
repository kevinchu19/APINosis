using APINosis.Models;
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
        private ClienteResponse respuestaPorExcepcionPost = new ClienteResponse("", 0, "");
        private ClienteResponse respuestaPorExcepcionGet = new ClienteResponse("", 0, "");
        public Serilog.ILogger logger { get; }

        public FiltrodeExcepcion(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public async override void  OnException(ExceptionContext context)
        {

            logger.Fatal(context.Exception.Message);

            var exception = context.Exception;

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
                default:
                    response.Estado = 500;
                    response.Titulo = "Error interno de la aplicación";
                    response.Mensaje = exception.Message;
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
