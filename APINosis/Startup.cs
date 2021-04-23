using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APINosis.Entities;
using APINosis.Models;
using APINosis.OE;
using APINosis.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using APINosis.Helpers;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using APINosis.Interfaces;
using ApiNosis.Models;

namespace APINosis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<Translate>();
            services.AddTransient<IOEObject, VT_TT_VTMCLH>(provider => 
                new VT_TT_VTMCLH( "admin",Configuration["PasswordAdmin"],Configuration["CompanyName"]));

            services.AddTransient<IOEObject, CV_RR_CVMCTH>(provider =>
                new CV_RR_CVMCTH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"]));

            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<ClienteDTO, VtmclhDTO>()
                .ForMember(dest => dest.VTMCLH_NROCTA, opt => opt.MapFrom(src => src.NumeroCliente))
                .ForMember(dest => dest.VTMCLH_NOMBRE, opt => opt.MapFrom(src => src.RazonSocial))
                .ForMember(dest => dest.VTMCLH_NROSUB, opt => opt.MapFrom(src => src.NumeroSubcuenta))
                .ForMember(dest => dest.VTMCLH_DIRECC, opt => opt.MapFrom(src => src.DireccionFiscal))
                .ForMember(dest => dest.VTMCLH_CODPAI, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.VTMCLH_CODPOS, opt => opt.MapFrom(src => src.CodigoPostal))
                .ForMember(dest => dest.VTMCLH_CNDIVA, opt => opt.MapFrom(src => src.SituacionFrenteAlIVA))
                .ForMember(dest => dest.VTMCLH_TIPDOC, opt => opt.MapFrom(src => src.TipoDocumento))
                .ForMember(dest => dest.VTMCLH_NRODOC, opt => opt.MapFrom(src => src.NumeroDocumento))
                .ForMember(dest => dest.VTMCLH_VNDDOR, opt => opt.MapFrom(src => src.Vendedor))
                .ForMember(dest => dest.VTMCLH_COBRAD, opt => opt.MapFrom(src => src.Cobrador))
                .ForMember(dest => dest.VTMCLH_JURISD, opt => opt.MapFrom(src => src.Provincia))
                .ForMember(dest => dest.VTMCLH_CODZON, opt => opt.MapFrom(src => src.Zona))
                .ForMember(dest => dest.VTMCLH_ACTIVD, opt => opt.MapFrom(src => src.Actividad))
                .ForMember(dest => dest.VTMCLH_CATEGO, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.VTMCLH_CNDPAG, opt => opt.MapFrom(src => src.CondicionDePago))
                .ForMember(dest => dest.VTMCLH_CNDPRE, opt => opt.MapFrom(src => src.ListaPrecios))
                .ForMember(dest => dest.VTMCLH_DIRENT, opt => opt.MapFrom(src => src.DireccionEntrega))
                .ForMember(dest => dest.VTMCLH_PAIENT, opt => opt.MapFrom(src => src.PaisEntrega))
                .ForMember(dest => dest.VTMCLH_CODENT, opt => opt.MapFrom(src => src.CodigoPostalEntrega))
                .ForMember(dest => dest.VTMCLH_JURENT, opt => opt.MapFrom(src => src.ProvinciaEntrega))
                .ForMember(dest => dest.VTMCLH_TIPDO1, opt => opt.MapFrom(src => src.TipoDocumento1))
                .ForMember(dest => dest.VTMCLH_NRODO1, opt => opt.MapFrom(src => src.TipoDocumento2))
                .ForMember(dest => dest.VTMCLH_TIPDO2, opt => opt.MapFrom(src => src.TipoDocumento3))
                .ForMember(dest => dest.VTMCLH_NRODO2, opt => opt.MapFrom(src => src.NumeroDocumento1))
                .ForMember(dest => dest.VTMCLH_TIPDO3, opt => opt.MapFrom(src => src.NumeroDocumento2))
                .ForMember(dest => dest.VTMCLH_NRODO3, opt => opt.MapFrom(src => src.NumeroDocumento3))
                .ForMember(dest => dest.VTMCLH_FISJUR, opt => opt.MapFrom(src => src.TipodePersona))
                .ForMember(dest => dest.VTMCLH_APELL1, opt => opt.MapFrom(src => src.ApellidoPaterno))
                .ForMember(dest => dest.VTMCLH_APELL2, opt => opt.MapFrom(src => src.ApellidoMaterno))
                .ForMember(dest => dest.VTMCLH_NOMB01, opt => opt.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.VTMCLH_NOMB02, opt => opt.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.USR_VTMCLH_CODACT, opt => opt.MapFrom(src => src.Activadora))
                .ForMember(dest => dest.USR_VTMCLH_MPAGO, opt => opt.MapFrom(src => src.ModalidadPago))
                .ForMember(dest => dest.USR_VTMCLH_MAILFC, opt => opt.MapFrom(src => src.EmailFacturas))
                .ForMember(dest => dest.USR_VTMCLH_MAILRC, opt => opt.MapFrom(src => src.EmailRecibos))
                .ForMember(dest => dest.USR_VTMCLH_ENMAIL, opt => opt.MapFrom(src => src.EnviaMail))
                .ForMember(dest => dest.USR_VTMCLH_FECANT, opt => opt.MapFrom(src => src.FechaCambioRazonSocial))
                .ForMember(dest => dest.USR_VTMCLH_LOCAL1 , opt => opt.MapFrom(src => src.Localidad))
                .ForMember(dest => dest.USR_VTMCLH_LOCAL2, opt => opt.MapFrom(src => src.LocalidadEntrega))
                .ForMember(dest => dest.VTMCLH_LANEXP, opt => opt.MapFrom(src => src.IdiomaReferencia))
                .ReverseMap();

                configuration.CreateMap<Vtmclh, ClienteDTO>()
                    .ForMember(dest => dest.NumeroCliente, opt => opt.MapFrom(src => src.VtmclhNrocta))
                    .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.VtmclhNombre))
                    .ForMember(dest => dest.NumeroSubcuenta, opt => opt.MapFrom(src => src.VtmclhNrosub))
                    .ForMember(dest => dest.DireccionFiscal, opt => opt.MapFrom(src => src.VtmclhDirecc))
                    .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.VtmclhCodpai))
                    .ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.VtmclhCodpos))
                    .ForMember(dest => dest.SituacionFrenteAlIVA, opt => opt.MapFrom(src => src.VtmclhCndiva))
                    .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(src => src.VtmclhTipdoc))
                    .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.VtmclhNrodoc))
                    .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.VtmclhVnddor))
                    .ForMember(dest => dest.Cobrador, opt => opt.MapFrom(src => src.VtmclhCobrad))
                    .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.VtmclhJurisd))
                    .ForMember(dest => dest.Zona, opt => opt.MapFrom(src => src.VtmclhCodzon))
                    .ForMember(dest => dest.Actividad, opt => opt.MapFrom(src => src.VtmclhActivd))
                    .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.VtmclhCatego))
                    .ForMember(dest => dest.CondicionDePago, opt => opt.MapFrom(src => src.VtmclhCndpag))
                    .ForMember(dest => dest.ListaPrecios, opt => opt.MapFrom(src => src.VtmclhCndpre))
                    .ForMember(dest => dest.DireccionEntrega, opt => opt.MapFrom(src => src.VtmclhDirent))
                    .ForMember(dest => dest.PaisEntrega, opt => opt.MapFrom(src => src.VtmclhPaient))
                    .ForMember(dest => dest.CodigoPostalEntrega, opt => opt.MapFrom(src => src.VtmclhCodent))
                    .ForMember(dest => dest.ProvinciaEntrega, opt => opt.MapFrom(src => src.VtmclhJurent))
                    .ForMember(dest => dest.TipoDocumento1, opt => opt.MapFrom(src => src.VtmclhTipdo1))
                    .ForMember(dest => dest.TipoDocumento2, opt => opt.MapFrom(src => src.VtmclhNrodo1))
                    .ForMember(dest => dest.TipoDocumento3, opt => opt.MapFrom(src => src.VtmclhTipdo2))
                    .ForMember(dest => dest.NumeroDocumento1, opt => opt.MapFrom(src => src.VtmclhNrodo2))
                    .ForMember(dest => dest.NumeroDocumento2, opt => opt.MapFrom(src => src.VtmclhTipdo3))
                    .ForMember(dest => dest.NumeroDocumento3, opt => opt.MapFrom(src => src.VtmclhNrodo3))
                    .ForMember(dest => dest.TipodePersona, opt => opt.MapFrom(src => src.VtmclhFisjur))
                    .ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.VtmclhApell1))
                    .ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.VtmclhApell2))
                    .ForMember(dest => dest.PrimerNombre, opt => opt.MapFrom(src => src.VtmclhNomb01))
                    .ForMember(dest => dest.SegundoNombre, opt => opt.MapFrom(src => src.VtmclhNomb02))
                    .ForMember(dest => dest.Activadora, opt => opt.MapFrom(src => src.UsrVtmclhCodact))
                    .ForMember(dest => dest.ModalidadPago, opt => opt.MapFrom(src => src.UsrVtmclhMpago))
                    .ForMember(dest => dest.EmailFacturas, opt => opt.MapFrom(src => src.UsrVtmclhMailfc))
                    .ForMember(dest => dest.EmailRecibos, opt => opt.MapFrom(src => src.UsrVtmclhMailrc))
                    .ForMember(dest => dest.EnviaMail, opt => opt.MapFrom(src => src.UsrVtmclhEnmail))
                    .ForMember(dest => dest.FechaCambioRazonSocial, opt => opt.MapFrom(src => src.UsrVtmclhFecant))
                    .ForMember(dest => dest.Localidad, opt => opt.MapFrom(src => src.UsrVtmclhLocal1))
                    .ForMember(dest => dest.LocalidadEntrega, opt => opt.MapFrom(src => src.UsrVtmclhLocal2))
                    .ForMember(dest => dest.IdiomaReferencia, opt => opt.MapFrom(src => src.VtmclhLanexp))
                .ReverseMap();

                configuration.CreateMap<Vtmclc, ContactosDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.VtmclcCodcon))
                .ForMember(dest => dest.Puesto, opt => opt.MapFrom(src => src.VtmclcPuesto))
                .ForMember(dest => dest.Observacion, opt => opt.MapFrom(src => src.VtmclcObserv))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.VtmclcTipsex))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.VtmclcDireml))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.VtmclcTelint))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.VtmclcCelula))
                .ForMember(dest => dest.ReclamoFacturas, opt => opt.MapFrom(src => src.VtmclcRecfac))
                .ReverseMap();

                configuration.CreateMap<ContactosDTO, VtmclcDTO>()
                .ForMember(dest => dest.VTMCLC_CODCON, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.VTMCLC_PUESTO, opt => opt.MapFrom(src => src.Puesto))
                .ForMember(dest => dest.VTMCLC_OBSERV, opt => opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.VTMCLC_TIPSEX, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.VTMCLC_DIREML, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.VTMCLC_TELINT, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.VTMCLC_CELULA, opt => opt.MapFrom(src => src.Celular))
                .ForMember(dest => dest.VTMCLC_RECFAC, opt => opt.MapFrom(src => src.ReclamoFacturas))
                .ReverseMap();

                configuration.CreateMap<Vtmcli, ImpuestosDTO>()
                .ForMember(dest => dest.CodigoImpuesto, opt => opt.MapFrom(src => src.VtmcliTipimp))
                .ForMember(dest => dest.Corresponde, opt => opt.MapFrom(src => src.VtmcliCorres))
                .ForMember(dest => dest.IVAIncluido, opt => opt.MapFrom(src => src.VtmcliInclui))
                .ReverseMap();

                configuration.CreateMap<Cvmcth, ContratosDTO>()
                .ForMember(dest => dest.TipoContrato, opt => opt.MapFrom(src => src.Cvmcth_Codcon))
                .ForMember(dest => dest.CodigoContrato, opt => opt.MapFrom(src => src.Cvmcth_Nrocon))
                .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Cvmcth_Nroext))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Cvmcth_Descrp))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cvmcth_Nrocta))
                .ForMember(dest => dest.Codigodesubcuenta, opt => opt.MapFrom(src => src.Cvmcth_Nrosub))
                .ForMember(dest => dest.Condiciondepago, opt => opt.MapFrom(src => src.Cvmcth_Cndpag))
                .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Cvmcth_Vnddor))
                .ForMember(dest => dest.Contratista, opt => opt.MapFrom(src => src.Cvmcth_Codctr))
                .ForMember(dest => dest.ComprobanteVentas, opt => opt.MapFrom(src => src.Cvmcth_Codcvt))
                .ForMember(dest => dest.Del, opt => opt.MapFrom(src => src.Cvmcth_Facdes))
                .ForMember(dest => dest.Al, opt => opt.MapFrom(src => src.Cvmcth_Fachas))
                .ForMember(dest => dest.Emisiondela1rafactura, opt => opt.MapFrom(src => src.Cvmcth_Prifac))
                .ForMember(dest => dest.Ultimafacturaaemitir, opt => opt.MapFrom(src => src.Cvmcth_Ultfac))
                .ForMember(dest => dest.Listadeprecios, opt => opt.MapFrom(src => src.Cvmcth_Codlis))
                .ForMember(dest => dest.MonedaEmision, opt => opt.MapFrom(src => src.Cvmcth_Coffac))
                .ForMember(dest => dest.Preciosvigentesalfacturar, opt => opt.MapFrom(src => src.Cvmcth_Actlis))
                .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.Cvmcth_Textos))
                .ForMember(dest => dest.Facturacion, opt => opt.MapFrom(src => src.Cvmcth_Frefac))
                .ForMember(dest => dest.RecuperaitemsenNovedades, opt => opt.MapFrom(src => src.Cvmcth_Recnov))
                .ForMember(dest => dest.Tipodeexportacion, opt => opt.MapFrom(src => src.Cvmcth_Tipexp))
                .ForMember(dest => dest.Condicioncomercial, opt => opt.MapFrom(src => src.Cvmcth_Cndcom))
                .ForMember(dest => dest.ModalidaddePago, opt => opt.MapFrom(src => src.Usr_Cvmcth_Mpago))
                .ReverseMap();

                configuration.CreateMap<Cvmcti, ItemsContratosDTO>()
                .ForMember(dest => dest.Numerodeitem, opt => opt.MapFrom(src => src.Cvmcti_Nroitm))
                .ForMember(dest => dest.Tipodeproducto, opt => opt.MapFrom(src => src.Cvmcti_Tippro))
                .ForMember(dest => dest.Codigodeproducto, opt => opt.MapFrom(src => src.Cvmcti_Artcod))
                .ForMember(dest => dest.TextoAdicional, opt => opt.MapFrom(src => src.Cvmcti_Texadi))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Cvmcti_Precio))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cvmcti_Cantid))
                .ForMember(dest => dest.TrabajaConVigencia, opt => opt.MapFrom(src => src.Cvmcti_Travig))
                .ForMember(dest => dest.Desde, opt => opt.MapFrom(src => src.Cvmcti_Vigdde))
                .ForMember(dest => dest.Hasta, opt => opt.MapFrom(src => src.Cvmcti_Vighta))
                .ForMember(dest => dest.Preciosvigentesalfacturar, opt => opt.MapFrom(src => src.Cvmcti_Actlis))
                .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Usr_Cvmcti_Vnddor))
                .ForMember(dest => dest.Vendedor2, opt => opt.MapFrom(src => src.Usr_Cvmcti_Vnddo2))
                .ForMember(dest => dest.ModuloOrdendeTrabajo, opt => opt.MapFrom(src => src.Usr_Cvmcti_Modotr))
                .ForMember(dest => dest.CodigoOrdendeTrabajo, opt => opt.MapFrom(src => src.Usr_Cvmcti_Codotr))
                .ForMember(dest => dest.NumeroOrdendeTrabajo, opt => opt.MapFrom(src => src.Usr_Cvmcti_Nrootr))
                .ForMember(dest => dest.FechadeMovimiento, opt => opt.MapFrom(src => src.Usr_Cvmcti_Fchmov))
                .ForMember(dest => dest.ModulodeOTModificacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Modmod))
                .ForMember(dest => dest.FechadeComision, opt => opt.MapFrom(src => src.Usr_Cvmcti_Fchcom))
                .ForMember(dest => dest.CodigodeOTModificacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Codmod))
                .ForMember(dest => dest.NumerodeOTModificacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Nromod))
                .ForMember(dest => dest.FechadeOTModificacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Fchmod))
                .ForMember(dest => dest.NumerodeOrdendecompra, opt => opt.MapFrom(src => src.Usr_Cvmcti_Nrooc))
                .ForMember(dest => dest.ArchivodeExportacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Archiv))
                .ForMember(dest => dest.IDCustom, opt => opt.MapFrom(src => src.Usr_Cvmcti_Idcust))
                .ForMember(dest => dest.NumerodeRegistroExpo, opt => opt.MapFrom(src => src.Usr_Cvmcti_Nroreg))
                .ForMember(dest => dest.FechadeExportacion, opt => opt.MapFrom(src => src.Usr_Cvmcti_Fchimp))
                .ReverseMap();
            }
                , typeof(Startup));

            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            }).
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ApiNosisContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddControllers();
            services.AddCors();

            
            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();

            services.AddScoped<ClienteRepository>();

            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(
                                connectionString: connstring,
                                sinkOptions: new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable = true},
                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                            .CreateLogger();
            
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
