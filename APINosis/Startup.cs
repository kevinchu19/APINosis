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
            }
                , typeof(Startup));

            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            }).
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ApiNosisContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());

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
