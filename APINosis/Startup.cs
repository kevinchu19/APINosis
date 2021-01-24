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
                .ForMember(dest => dest.USR_VTMCLH_FECANT, opt => opt.MapFrom(src => src.FechaCambioRazonSocial));
            }
                , typeof(Startup));

            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            }).
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ApiNosisContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

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
