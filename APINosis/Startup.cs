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
using ApiNosis.MapperHelp;
using Newtonsoft.Json.Serialization;

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

            services.AddTransient(provider =>
                new VT_TT_VTMCLH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            services.AddTransient(provider =>
                new CV_RR_CVMCTH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            services.AddTransient(provider =>
                new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            services.AddTransient(provider =>
                new VT_TT_VTRMVH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            services.AddTransient(provider =>
                new VT_TT_VTRMVH_ANU("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            services.AddScoped<ClienteRepository>();

            services.AddScoped<ContratoRepository>();

            services.AddScoped<FacturasRepository>();

            services.AddScoped<RecibosRepository>();
            
            services.AddScoped<AnulacionRecibosRepository>();


            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());

                configuration.CreateMap<ClienteDTO, VtmclhDTO>()
                .ForMember(dest => dest.VTMCLH_NROCTA, opt => opt.MapFrom(src => src.NumeroCliente))
                .ForMember(dest => dest.VTMCLH_NOMBRE, opt => opt.MapFrom(src => src.RazonSocial))
                .ForMember(dest => dest.VTMCLH_NROSUB, opt => opt.MapFrom(src => src.NumeroSubcuenta))
                .ForMember(dest => dest.VTMCLH_DIRECC, opt => opt.MapFrom(src => src.DireccionFiscal))
                .ForMember(dest => dest.VTMCLH_CODPAI, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.VTMCLH_CODPOS, opt => opt.MapFrom(src => src.CodigoPostal))
                .ForMember(dest => dest.VTMCLH_CNDIVA, opt => opt.MapFrom(src => src.SituacionFrenteAlIva))
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
                .ForMember(dest => dest.USR_VTMCLH_LOCAL1, opt => opt.MapFrom(src => src.Localidad))
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
                    .ForMember(dest => dest.SituacionFrenteAlIva, opt => opt.MapFrom(src => src.VtmclhCndiva))
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

                configuration.CreateMap<ImpuestosDTO, VtmcliDTO>()
                .ForMember(dest => dest.VTMCLI_TIPIMP, opt => opt.MapFrom(src => src.CodigoImpuesto))
                .ForMember(dest => dest.VTMCLI_CORRES, opt => opt.MapFrom(src => src.Corresponde))
                .ForMember(dest => dest.VTMCLI_INCLUI, opt => opt.MapFrom(src => src.IVAIncluido))
                .ReverseMap();

                configuration.CreateMap<ContratosDTO, Cvmcth>()
                .ForMember(dest => dest.Cvmcth_Codcon, opt => opt.MapFrom(src => src.TipoContrato))
                .ForMember(dest => dest.Cvmcth_Nrocon, opt => opt.MapFrom(src => src.CodigoContrato))
                .ForMember(dest => dest.Cvmcth_Nroext, opt => opt.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Cvmcth_Descrp, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Cvmcth_Nrocta, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Cvmcth_Nrosub, opt => opt.MapFrom(src => src.CodigoDeSubcuenta))
                .ForMember(dest => dest.Cvmcth_Cndpag, opt => opt.MapFrom(src => src.CondicionDePago))
                .ForMember(dest => dest.Cvmcth_Vnddor, opt => opt.MapFrom(src => src.Vendedor))
                .ForMember(dest => dest.Cvmcth_Codctr, opt => opt.MapFrom(src => src.Contratista))
                .ForMember(dest => dest.Cvmcth_Codcvt, opt => opt.MapFrom(src => src.ComprobanteVentas))
                .ForMember(dest => dest.Cvmcth_Facdes, opt => opt.MapFrom(src => src.Del))
                //.ForMember(dest => dest.Cvmcth_Fachas, opt => opt.MapFrom(src => src.Al))
                .ForMember(dest => dest.Cvmcth_Prifac, opt => opt.MapFrom(src => src.EmisionDela1raFactura))
                .ForMember(dest => dest.Cvmcth_Ultfac, opt => opt.MapFrom(src => src.UltimaFacturaAEmitir))
                .ForMember(dest => dest.Cvmcth_Codlis, opt => opt.MapFrom(src => src.ListaDePrecios))
                .ForMember(dest => dest.Cvmcth_Coffac, opt => opt.MapFrom(src => src.MonedaEmision))
                .ForMember(dest => dest.Cvmcth_Actlis, opt => opt.MapFrom(src => src.PreciosVigentesAlFacturar))
                .ForMember(dest => dest.Cvmcth_Textos, opt => opt.MapFrom(src => src.Observaciones))
                .ForMember(dest => dest.Cvmcth_Desfre, opt => opt.MapFrom(src => src.Facturacion))
                .ForMember(dest => dest.Cvmcth_Recnov, opt => opt.MapFrom(src => src.RecuperaItemsEnNovedades))
                .ForMember(dest => dest.Cvmcth_Tipexp, opt => opt.MapFrom(src => src.TipodeExportacion))
                .ForMember(dest => dest.Cvmcth_Cndcom, opt => opt.MapFrom(src => src.CondicionComercial))
                .ForMember(dest => dest.Usr_Cvmcth_Mpago, opt => opt.MapFrom(src => src.ModalidadDePago))
                .ForMember(dest => dest.Usr_Cvmcth_Idcomp, opt => opt.MapFrom(src => src.IdDeCompra))
                .ReverseMap();

                configuration.CreateMap<ItemsContratosDTO, Cvmcti>()
                .ForMember(dest => dest.Cvmcti_Nroitm, opt => opt.MapFrom(src => src.NumeroDeItem))
                .ForMember(dest => dest.Cvmcti_Tippro, opt => opt.MapFrom(src => src.TipoDeProducto))
                .ForMember(dest => dest.Cvmcti_Artcod, opt => opt.MapFrom(src => src.CodigoDeProducto))
                .ForMember(dest => dest.Cvmcti_Texadi, opt => opt.MapFrom(src => src.TextoAdicional))
                .ForMember(dest => dest.Cvmcti_Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Cvmcti_Cantid, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Cvmcti_Travig, opt => opt.MapFrom(src => src.TrabajaConVigencia))
                .ForMember(dest => dest.Cvmcti_Vigdde, opt => opt.MapFrom(src => src.Desde))
                .ForMember(dest => dest.Cvmcti_Vighta, opt => opt.MapFrom(src => src.Hasta))
                .ForMember(dest => dest.Cvmcti_Actlis, opt => opt.MapFrom(src => src.PreciosVigentesAlFacturar))
                .ForMember(dest => dest.Usr_Cvmcti_Vnddor, opt => opt.MapFrom(src => src.Vendedor))
                .ForMember(dest => dest.Usr_Cvmcti_Vnddo2, opt => opt.MapFrom(src => src.Vendedor2))
                .ForMember(dest => dest.Usr_Cvmcti_Modotr, opt => opt.MapFrom(src => src.ModuloOrdenDeTrabajo))
                .ForMember(dest => dest.Usr_Cvmcti_Codotr, opt => opt.MapFrom(src => src.CodigoOrdenDeTrabajo))
                .ForMember(dest => dest.Usr_Cvmcti_Nrootr, opt => opt.MapFrom(src => src.NumeroOrdenDeTrabajo))
                .ForMember(dest => dest.Usr_Cvmcti_Fchmov, opt => opt.MapFrom(src => src.FechaDeMovimiento))
                .ForMember(dest => dest.Usr_Cvmcti_Modmod, opt => opt.MapFrom(src => src.ModulodeOTModificacion))
                .ForMember(dest => dest.Usr_Cvmcti_Fchcom, opt => opt.MapFrom(src => src.FechadeComision))
                .ForMember(dest => dest.Usr_Cvmcti_Codmod, opt => opt.MapFrom(src => src.CodigodeOTModificacion))
                .ForMember(dest => dest.Usr_Cvmcti_Nromod, opt => opt.MapFrom(src => src.NumerodeOTModificacion))
                .ForMember(dest => dest.Usr_Cvmcti_Fchmod, opt => opt.MapFrom(src => src.FechadeOTModificacion))
                .ForMember(dest => dest.Usr_Cvmcti_Nrooc, opt => opt.MapFrom(src => src.NumeroDeOrdenDeCompra))
                .ForMember(dest => dest.Usr_Cvmcti_Archiv, opt => opt.MapFrom(src => src.ArchivoDeExportacion))
                .ForMember(dest => dest.Usr_Cvmcti_Idcust, opt => opt.MapFrom(src => src.IdCustom))
                .ForMember(dest => dest.Usr_Cvmcti_Nroreg, opt => opt.MapFrom(src => src.NumeroDeRegistroExpo))
                .ForMember(dest => dest.Usr_Cvmcti_Fchimp, opt => opt.MapFrom(src => src.FechaDeExportacion))
                .ReverseMap();

                configuration.CreateMap<FacturasDTO, Fcrmvh>()
                .ForMember(dest => dest.Virt_Circom, opt => opt.MapFrom(src => src.CircuitoOrigen))
                .ForMember(dest => dest.Virt_Cirapl, opt => opt.MapFrom(src => src.CircuitoAplicacion))
                .ForMember(dest => dest.Virt_Codcvt, opt => opt.MapFrom(src => src.ComprobanteVentas))
                .ForMember(dest => dest.Fcrmvh_Codfor, opt => opt.MapFrom(src => src.CodigoComprobante))
                .ForMember(dest => dest.Fcrmvh_Nrofor, opt => opt.MapFrom(src => src.NumeroComprobante))
                .ForMember(dest => dest.Fcrmvh_Fchmov, opt => opt.MapFrom(src => src.FechaContable))
                .ForMember(dest => dest.Fcrmvh_Nrocta, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Fcrmvh_Nrosub, opt => opt.MapFrom(src => src.CodigoSubcuenta))
                .ForMember(dest => dest.Fcrmvh_Dirent, opt => opt.MapFrom(src => src.DireccionEntrega))
                .ForMember(dest => dest.Fcrmvh_Paient, opt => opt.MapFrom(src => src.PaisEntrega))
                .ForMember(dest => dest.Fcrmvh_Codent, opt => opt.MapFrom(src => src.CodPosEntrega))
                .ForMember(dest => dest.Fcrmvh_Vnddor, opt => opt.MapFrom(src => src.Vendedor))
                .ForMember(dest => dest.Fcrmvh_Cndpag, opt => opt.MapFrom(src => src.CondicionPago))
                .ForMember(dest => dest.Fcrmvh_Codlis, opt => opt.MapFrom(src => src.ListaPrecios))
                .ForMember(dest => dest.Fcrmvh_Textos, opt => opt.MapFrom(src => src.Texto))
                .ForMember(dest => dest.Fcrmvh_Coflis, opt => opt.MapFrom(src => src.CoeficienteDeuda))
                .ForMember(dest => dest.Fcrmvh_Coffac, opt => opt.MapFrom(src => src.CoeficienteEmision))
                .ForMember(dest => dest.Fcrmvh_Cofdeu, opt => opt.MapFrom(src => src.CoeficienteRegistracion))
                .ForMember(dest => dest.Fcrmvh_Jurisd, opt => opt.MapFrom(src => src.Jurisdiccion))
                .ForMember(dest => dest.Fcrmvh_Tipexp, opt => opt.MapFrom(src => src.TipoExportacion))
                .ForMember(dest => dest.Sar_Virt_Tipdop, opt => opt.MapFrom(src => src.TipoDatoOpcionalAFIP))
                .ForMember(dest => dest.Sar_Virt_Valdop, opt => opt.MapFrom(src => src.ValorDatoOpcionalAFIP))
                .ForMember(dest => dest.Usr_Fcrmvh_Mpago, opt => opt.MapFrom(src => src.ModalidadPago))
                .ForMember(dest => dest.Usr_Fcrmvh_Local2, opt => opt.MapFrom(src => src.LocalidadEntrega))
                .ForMember(dest => dest.Usr_Fcrmvh_Subpo2, opt => opt.MapFrom(src => src.CodigoPostalExtendidoEntrega))
                .ForMember(dest => dest.Usr_Fcrmvh_Fchfac, opt => opt.MapFrom(src => src.FechaFactura))
                .ForMember(dest => dest.Usr_Fcrmvh_Idcrm, opt => opt.MapFrom(src => src.IdOperacion))
                .ForMember(dest => dest.Usr_Fcrmvh_Idpago, opt => opt.MapFrom(src => src.IdPago))
                .ForMember(dest => dest.Usr_Fcrmvh_Idcomp, opt => opt.MapFrom(src => src.IdCompra))
                .ReverseMap();

                configuration.CreateMap<FacturasItemsDTO, Fcrmvi>()
                .ForMember(dest => dest.Fcrmvi_Tipcpt, opt => opt.MapFrom(src => src.TipoConcepto))
                .ForMember(dest => dest.Fcrmvi_Codcpt, opt => opt.MapFrom(src => src.Concepto))
                .ForMember(dest => dest.Fcrmvi_Tipori, opt => opt.MapFrom(src => src.TipoProducto))
                .ForMember(dest => dest.Fcrmvi_Artori, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.Fcrmvi_Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Fcrmvi_Cantid, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Fcrmvi_Pctbf1, opt => opt.MapFrom(src => src.Bonificacion1))
                .ForMember(dest => dest.Fcrmvi_Pctbf2, opt => opt.MapFrom(src => src.Bonificacion2))
                .ForMember(dest => dest.Fcrmvi_Pctbf3, opt => opt.MapFrom(src => src.Bonificacion3))
                .ForMember(dest => dest.Fcrmvi_Pctbf4, opt => opt.MapFrom(src => src.Bonificacion4))
                .ForMember(dest => dest.Fcrmvi_Pctbf5, opt => opt.MapFrom(src => src.Bonificacion5))
                .ForMember(dest => dest.Fcrmvi_Pctbf6, opt => opt.MapFrom(src => src.Bonificacion6))
                .ForMember(dest => dest.Fcrmvi_Pctbf7, opt => opt.MapFrom(src => src.Bonificacion7))
                .ForMember(dest => dest.Fcrmvi_Pctbf8, opt => opt.MapFrom(src => src.Bonificacion8))
                .ForMember(dest => dest.Fcrmvi_Pctbf9, opt => opt.MapFrom(src => src.Bonificacion9))
                .ForMember(dest => dest.Fcrmvi_Textos, opt => opt.MapFrom(src => src.Observaciones))
                .ForMember(dest => dest.Fcrmvi_Cntbon, opt => opt.MapFrom(src => src.CantidadBonificada))
                .ForMember(dest => dest.Usr_Fcrmvi_Modotr, opt => opt.MapFrom(src => src.ModuloOTOriginal))
                .ForMember(dest => dest.Usr_Fcrmvi_Codotr, opt => opt.MapFrom(src => src.CodigoOTOriginal))
                .ForMember(dest => dest.Usr_Fcrmvi_Nrootr, opt => opt.MapFrom(src => src.NumeroOTOriginal))
                .ForMember(dest => dest.Usr_Fcrmvi_Fchotr, opt => opt.MapFrom(src => src.FechaOTOriginal))
                .ForMember(dest => dest.Usr_Fcrmvi_Nrooc, opt => opt.MapFrom(src => src.NumeroOrdendeCompra))
                .ForMember(dest => dest.Usr_Fcrmvi_Nroitm, opt => opt.MapFrom(src => src.NumeroItemCustom))
                .ForMember(dest => dest.Usr_Fcrmvi_Idcust, opt => opt.MapFrom(src => src.IDCustom))
                .ForMember(dest => dest.Usr_Fcrmvi_Vnddor, opt => opt.MapFrom(src => src.Vendedor))
                .ForMember(dest => dest.Usr_Fcrmvi_Vnddo2, opt => opt.MapFrom(src => src.Vendedor2))
                .ReverseMap();

                configuration.CreateMap<RecibosDTO, Vtrrch>()
                .ForMember(dest => dest.Usr_Vtrmvh_Idcrm, opt => opt.MapFrom(src => src.IdOperacion))
                .ForMember(dest => dest.Vtrmvh_Codcom, opt => opt.MapFrom(src => src.CodigoComprobanteAGenerar))
                .ForMember(dest => dest.Vtrmvh_Nrocta, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Vtrmvh_Fchmov, opt => opt.MapFrom(src => src.FechaContable))
                .ForMember(dest => dest.Vtrmvh_Cobrad, opt => opt.MapFrom(src => src.Cobrador))
                .ForMember(dest => dest.Vtrmvh_Textos, opt => opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.Vtrmvh_Nrosub, opt => opt.MapFrom(src => src.CodigoSubcuenta))
                .ForMember(dest => dest.Vtrmvh_Fchpar, opt => opt.MapFrom(src => src.FechaParidades))
                .ForMember(dest => dest.Vtrmvh_Utpaor, opt => opt.MapFrom(src => src.UtilizaParidadesOriginales))
                .ForMember(dest => dest.Usr_Vtrmvh_Fchcbu, opt => opt.MapFrom(src => src.FechaDebito));


                configuration.CreateMap<AplicacionesDTO, Vtrrcc01>()
                .ForMember(dest => dest.Vtrmvc_Codapl, opt => opt.MapFrom(src => src.CodigoFormularioAplicacion))
                .ForMember(dest => dest.Vtrmvc_Nroapl, opt => opt.MapFrom(src => src.NumeroFormularioAplicacion))
                .ForMember(dest => dest.Vtrmvc_Cuotas, opt => opt.MapFrom(src => src.Cuota))
                .ForMember(dest => dest.Vtrmvc_Impnac, opt => opt.MapFrom(src => src.ImporteNacionalAplicado))
                .ForMember(dest => dest.Virt_Cannac, opt => opt.MapFrom(src => src.ImporteNacionalAplicado))
                .ForMember(dest => dest.Virt_Descto, opt => opt.MapFrom(src => src.DescuentoRecargo))
                .ForMember(dest => dest.Vtrmvc_Coflis, opt => opt.MapFrom(src => src.Moneda))
                .ForMember(dest => dest.Vtrmvc_Impext, opt => opt.MapFrom(src => src.ImporteExtranjeraAplicado))
                .ForMember(dest => dest.Virt_Canext, opt => opt.MapFrom(src => src.ImporteExtranjeraAplicado))
                .ForMember(dest => dest.Virt_Pctbf1, opt => opt.MapFrom(src => src.PorcentajeDescuentoRecargo1))
                .ForMember(dest => dest.Virt_Pctbf2, opt => opt.MapFrom(src => src.PorcentajeDescuentoRecargo2))
                .ForMember(dest => dest.Virt_Pctbf3, opt => opt.MapFrom(src => src.PorcentajeDescuentoRecargo3));

                configuration.CreateMap<MediosDeCobroDTO, Vtrrcc04>()
                .ForMember(dest => dest.Cjrmvi_Tipcpt, opt => opt.MapFrom(src => src.TipoConcepto))
                .ForMember(dest => dest.Cjrmvi_Codcpt, opt => opt.MapFrom(src => src.CodigoConcepto))
                .ForMember(dest => dest.Cjrmvi_Cheque, opt => opt.MapFrom(src => src.Cheque))
                .ForMember(dest => dest.Cjrmvi_Chesuc, opt => opt.MapFrom(src => src.SucursalCheque))
                .ForMember(dest => dest.Cjrmvi_Codbco, opt => opt.MapFrom(src => src.CodigoBancoCheque))
                .ForMember(dest => dest.Cjrmvi_Fchaux, opt => opt.MapFrom(src => src.FechaVencimientoCheque))
                .ForMember(dest => dest.Cjrmvi_Catego, opt => opt.MapFrom(src => src.CategoriaCheque))
                .ForMember(dest => dest.Cjrmvi_Import, opt => opt.MapFrom(src => src.ImporteNacional))
                .ForMember(dest => dest.Cjrmvi_Cambio, opt => opt.MapFrom(src => src.TipoCambio))
                .ForMember(dest => dest.Cjrmvi_Impuss, opt => opt.MapFrom(src => src.ImporteExtranjera))
                .ForMember(dest => dest.Cjrmvi_Docfir, opt => opt.MapFrom(src => src.FirmanteCheque))
                .ForMember(dest => dest.Cjrmvi_Textos, opt => opt.MapFrom(src => src.Observaciones))
                .ForMember(dest => dest.Cjrmvi_Tipdoc, opt => opt.MapFrom(src => src.TipoDocumentoCheque))
                .ForMember(dest => dest.Cjrmvi_Nrodoc, opt => opt.MapFrom(src => src.NumeroDocumentoCheque))
                .ForMember(dest => dest.Cjrmvi_Comori, opt => opt.MapFrom(src => src.EstructuraComprobanteOriginal))
                .ForMember(dest => dest.Cjrmvi_Codori, opt => opt.MapFrom(src => src.CodigoOriginal))
                .ForMember(dest => dest.Usr_Cjrmvi_Ctacte, opt => opt.MapFrom(src => src.CuentaCorriente))
                .ForMember(dest => dest.Usr_Cjrmvi_Titula, opt => opt.MapFrom(src => src.Titular))
                .ForMember(dest => dest.Usr_Cjrmvi_Nrotar, opt => opt.MapFrom(src => src.NumerodeTC))
                .ForMember(dest => dest.Usr_Cjrmvi_Codaut, opt => opt.MapFrom(src => src.CodigodeAutorizacionTarjetasIDPaypal))
                .ForMember(dest => dest.Usr_Cjrmvi_Feccbu, opt => opt.MapFrom(src => src.FechaCobranza))
                .ForMember(dest => dest.Usr_Cjrmvi_Numlot, opt => opt.MapFrom(src => src.NumeroLote))
                .ForMember(dest => dest.Usr_Cjrmvi_Numcup, opt => opt.MapFrom(src => src.NumeroCupon))
                .ForMember(dest => dest.Usr_Cjrmvi_Cuotas, opt => opt.MapFrom(src => src.Cuotas))
                .ForMember(dest => dest.Usr_Cjrmvi_Fecope, opt => opt.MapFrom(src => src.FechaOperacion))
                .ForMember(dest => dest.Usr_Cjrmvi_Codest, opt => opt.MapFrom(src => src.CodigoEstablecimiento))
                .ForMember(dest => dest.Usr_Cjrmvi_Idcomp, opt => opt.MapFrom(src => src.IDCompra))
                .ForMember(dest => dest.Usr_Cjrmvi_Idpago, opt => opt.MapFrom(src => src.IDPago));




                ///////////////////////////////////////////////////////////

                configuration.CreateMap<Vtrmvh, RecibosDTO>()
                .ForMember(dest => dest.IdOperacion, opt => opt.MapFrom(src => src.Usr_Vtrmvh_Idcrm))
                .ForMember(dest => dest.CodigoRecibo, opt => opt.MapFrom(src => src.Vtrmvh_Codfor))
                .ForMember(dest => dest.NumeroRecibo, opt => opt.MapFrom(src => src.Vtrmvh_Nrofor))
                .ForMember(dest => dest.CodigoComprobanteAnulacion, opt => opt.MapFrom(src => src.Vtrmvh_Codrev))
                .ForMember(dest => dest.NumeroComprobanteAnulacion, opt => opt.MapFrom(src => src.Vtrmvh_Nrorev))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Vtrmvh_Nrocta))
                .ForMember(dest => dest.FechaContable, opt => opt.MapFrom(src => src.Vtrmvh_Fchmov))
                .ForMember(dest => dest.Cobrador, opt => opt.MapFrom(src => src.Vtrmvh_Cobrad))
                .ForMember(dest => dest.Observacion, opt => opt.MapFrom(src => src.Vtrmvh_Textos))
                .ForMember(dest => dest.CodigoSubcuenta, opt => opt.MapFrom(src => src.Vtrmvh_Nrosub))
                .ForMember(dest => dest.FechaParidades, opt => opt.MapFrom(src => src.Vtrmvh_Fchpar))
                .ForMember(dest => dest.UtilizaParidadesOriginales, opt => opt.MapFrom(src => src.Vtrmvh_Utpaor))
                .ForMember(dest => dest.FechaDebito, opt => opt.MapFrom(src => src.Usr_Vtrmvh_Fchcbu));

                configuration.CreateMap<Vtrmvc, AplicacionesDTO>()
                .ForMember(dest => dest.CodigoFormularioAplicacion, opt => opt.MapFrom(src => src.Vtrmvc_Codapl))
                .ForMember(dest => dest.NumeroFormularioAplicacion, opt => opt.MapFrom(src => src.Vtrmvc_Nroapl))
                .ForMember(dest => dest.Cuota, opt => opt.MapFrom(src => src.Vtrmvc_Cuotas))
                .ForMember(dest => dest.ImporteNacionalAplicado, opt => opt.MapFrom(src => Math.Abs((decimal)src.Vtrmvc_Impnac)))
                .ForMember(dest => dest.Moneda, opt => opt.MapFrom(src => src.Vtrmvc_Coflis))
                .ForMember(dest => dest.ImporteExtranjeraAplicado, opt => opt.MapFrom(src => Math.Abs((decimal)src.Vtrmvc_Impext)));

                configuration.CreateMap<Cjrmvi, MediosDeCobroDTO>()
                .ForMember(dest => dest.TipoConcepto, opt => opt.MapFrom(src => src.Cjrmvi_Tipcpt))
                .ForMember(dest => dest.CodigoConcepto, opt => opt.MapFrom(src => src.Cjrmvi_Codcpt))
                .ForMember(dest => dest.Cheque, opt => opt.MapFrom(src => src.Cjrmvi_Cheque))
                .ForMember(dest => dest.SucursalCheque, opt => opt.MapFrom(src => src.Cjrmvi_Chesuc))
                .ForMember(dest => dest.CodigoBancoCheque, opt => opt.MapFrom(src => src.Cjrmvi_Codbco))
                .ForMember(dest => dest.FechaVencimientoCheque, opt => opt.MapFrom(src => src.Cjrmvi_Fchaux))
                .ForMember(dest => dest.CategoriaCheque, opt => opt.MapFrom(src => src.Cjrmvi_Catego))
                .ForMember(dest => dest.ImporteNacional, opt => opt.MapFrom(src => src.Cjrmvi_Import))
                .ForMember(dest => dest.TipoCambio, opt => opt.MapFrom(src => src.Cjrmvi_Cambio))
                .ForMember(dest => dest.ImporteExtranjera, opt => opt.MapFrom(src => src.Cjrmvi_Impuss))
                .ForMember(dest => dest.FirmanteCheque, opt => opt.MapFrom(src => src.Cjrmvi_Docfir))
                .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.Cjrmvi_Textos))
                .ForMember(dest => dest.TipoDocumentoCheque, opt => opt.MapFrom(src => src.Cjrmvi_Tipdoc))
                .ForMember(dest => dest.NumeroDocumentoCheque, opt => opt.MapFrom(src => src.Cjrmvi_Nrodoc))
                .ForMember(dest => dest.EstructuraComprobanteOriginal, opt => opt.MapFrom(src => src.Cjrmvi_Comori))
                .ForMember(dest => dest.CodigoOriginal, opt => opt.MapFrom(src => src.Cjrmvi_Codori))
                .ForMember(dest => dest.CuentaCorriente, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Ctacte))
                .ForMember(dest => dest.Titular, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Titula))
                .ForMember(dest => dest.NumerodeTC, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Nrotar))
                .ForMember(dest => dest.CodigodeAutorizacionTarjetasIDPaypal, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Codaut))
                .ForMember(dest => dest.FechaCobranza, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Feccbu))
                .ForMember(dest => dest.NumeroLote, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Numlot))
                .ForMember(dest => dest.NumeroCupon, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Numcup))
                .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Cuotas))
                .ForMember(dest => dest.FechaOperacion, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Fecope))
                .ForMember(dest => dest.CodigoEstablecimiento, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Codest))
                .ForMember(dest => dest.IDCompra, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Idcomp))
                .ForMember(dest => dest.IDPago, opt => opt.MapFrom(src => src.Usr_Cjrmvi_Idpago));


                configuration.CreateMap<ImpuestosFacturasDTO, Fcrmvi07>()
                .ForMember(dest => dest.Fcrmvi07_Tipcpt, opt => opt.MapFrom(src => src.TipoConceptoImpuesto))
                .ForMember(dest => dest.Fcrmvi07_Codcpt, opt => opt.MapFrom(src => src.CodigoConceptoImpuesto))
                .ForMember(dest => dest.Fcrmvi07_Impgra, opt => opt.MapFrom(src => src.ImporteGravado))
                .ForMember(dest => dest.Fcrmvi07_Porcen, opt => opt.MapFrom(src => src.Tasa))
                .ForMember(dest => dest.Fcrmvi07_Ingres, opt => opt.MapFrom(src => src.ImporteImpuesto));

            }
                , typeof(Startup));


            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            })
                .AddJsonOptions(options =>
                    { 
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                
            

            services.AddDbContext<ApiNosisContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddControllers();
            services.AddCors();


            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();


            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(
                                connectionString: connstring,
                                sinkOptions: new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable = true },
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
