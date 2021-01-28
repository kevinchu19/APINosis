using APINosis.Entities;
using APINosis.Helpers;
using APINosis.Interfaces;
using APINosis.Models;
using APINosis.OE;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APINosis.Repositories
{
    public class ClienteRepository : Repository
    {
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IOEObject oVTMCLH { get; set; }
        public Translate Translate { get; }

        public ClienteRepository(ApiNosisContext context, IConfiguration configuration, Serilog.ILogger logger, IMapper mapper, IOEObject oInstanceVTMCLH, Translate translate) :
            base(context, configuration, logger)
        {
            Logger = logger;
            Mapper = mapper;
            oVTMCLH = oInstanceVTMCLH;
            Translate = translate;
        }
        
        public async Task<List<ClienteDTO>> Get(string numeroCliente)
        {

            Logger.Information($"Se recibio consulta de cliente{numeroCliente}");
            
            List<Vtmclh> clientes = await Context.Vtmclh
                .Where(c => c.VtmclhNrocta == numeroCliente || numeroCliente == null)
                .Include(c=>c.Contactos)
                .ToListAsync();

            Logger.Information($"Se recuperaron datos correctamente");
            List<ClienteDTO> clientesDTO = Mapper.Map<List<ClienteDTO>>(clientes);

            return clientesDTO;
        }



        public APIResponse GraboCliente(ClienteDTO cliente)
        {
            Logger.Information($"Se recibio posteo de nuevo cliente{cliente.NumeroCliente} - {cliente.RazonSocial}");
            VtmclhDTO clientedto = Mapper.Map<ClienteDTO, VtmclhDTO>(cliente);
            Type typeCliente = clientedto.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeCliente.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {
                oVTMCLH.asignoValor("VTMCLH", propiedad.Name, (string)propiedad.GetValue(clientedto, null), 1);
            }

            oVTMCLH.asignoValor("VTMCLH", "VTMCLH_CODCRD", "NA", 1);
            oVTMCLH.asignoValor("VTMCLH", "VTMCLH_ZONENT", "NA", 1);
            oVTMCLH.asignoValor("VTMCLH", "VTMCLH_CODEXP", "2", 1);

            /**
            foreach (ContactosDTO contacto in cliente.Contactos)
            {

                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_CODCON", contacto.Nombre, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_PUESTO", contacto.Puesto, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_OBSERV", contacto.Observacion, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_TIPSEX", contacto.Sexo, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_DIREML", contacto.Email, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_TELINT", contacto.Telefono, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_CELULA", contacto.Celular, 2);
                oVTMCLH.asignoValor("VTMCLC", "VTMCLC_RECFAC", contacto.ReclamoFacturas, 2);

            }
            ***/
            Save PerformedOperation = oVTMCLH.save();

            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;


            oVTMCLH.closeObjectInstance();

            if (result == false)
            {
                throw new BadRequestException(mensajeError);
            }
            
            return new APIResponse
            {
                estado = 200,
                titulo = "OK",
                mensaje = $"Cliente {cliente.NumeroCliente} generado con éxito"
            };
        }

    }
}

