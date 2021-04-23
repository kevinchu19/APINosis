using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APINosis.Entities
{
    public partial class ApiNosisContext : DbContext
    {
        public ApiNosisContext()
        {
        }

        public ApiNosisContext(DbContextOptions<ApiNosisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vtmclc> Vtmclc { get; set; }
        public virtual DbSet<Vtmclh> Vtmclh { get; set; }
        public virtual DbSet<Grtpac> Grtpac { get; set; }
        public virtual DbSet<Vtmcli> Vtmcli { get; set; }
        public virtual DbSet<Cvmcth> Cvmcth { get; set; }
        public virtual DbSet<Cvmcti> Cvmcti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Vtmclc>(entity =>
            {
                entity.HasKey(e => new { e.VtmclcNrocta, e.VtmclcCodcon });

                entity.ToTable("VTMCLC");

                entity.HasOne(e => e.cliente)
                      .WithMany(c => c.Contactos)
                      .HasForeignKey(c => c.VtmclcNrocta);

                entity.Property(e => e.VtmclcNrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_NROCTA");

                entity.Property(e => e.VtmclcCodcon)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_CODCON");

                entity.Property(e => e.UsrVtmclcArchiv)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLC_ARCHIV");

                entity.Property(e => e.UsrVtmclcClavec).HasColumnName("USR_VTMCLC_CLAVEC");

                entity.Property(e => e.UsrVtmclcFchimp)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_VTMCLC_FCHIMP");

                entity.Property(e => e.UsrVtmclcIdcust)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLC_IDCUST");

                entity.Property(e => e.UsrVtmclcNroreg).HasColumnName("USR_VTMCLC_NROREG");

                entity.Property(e => e.VtmclcCelula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_CELULA");

                entity.Property(e => e.VtmclcCmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_CMPVER");

                entity.Property(e => e.VtmclcDebaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclcDireml)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_DIREML");

                entity.Property(e => e.VtmclcFecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLC_FECALT");

                entity.Property(e => e.VtmclcFecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLC_FECMOD");

                entity.Property(e => e.VtmclcHormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_HORMOV");

                entity.Property(e => e.VtmclcLotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_LOTORI");

                entity.Property(e => e.VtmclcLotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_LOTREC");

                entity.Property(e => e.VtmclcLottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_LOTTRA");

                entity.Property(e => e.VtmclcModule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_MODULE");

                entity.Property(e => e.VtmclcOalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_OALIAS");

                entity.Property(e => e.VtmclcObserv)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLC_OBSERV");

                entity.Property(e => e.VtmclcPuesto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_PUESTO");

                entity.Property(e => e.VtmclcRecfac)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_RECFAC")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclcSysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_SYSVER");

                entity.Property(e => e.VtmclcTelint)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_TELINT");

                entity.Property(e => e.VtmclcTipsex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_TIPSEX");

                entity.Property(e => e.VtmclcTstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("VTMCLC_TSTAMP");

                entity.Property(e => e.VtmclcUltopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclcUserid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLC_USERID");
            });

            modelBuilder.Entity<Vtmclh>(entity =>
            {
                
                entity.HasKey(e => e.VtmclhNrocta);

                entity.ToTable("VTMCLH");

                entity.HasIndex(e => new { e.VtmclhNrocta, e.VtmclhNombre }, "VTMCLH_SuperFind");

                entity.HasIndex(e => e.VtmclhCobrad, "W_CV_CVRMVHWIZ");

                entity.HasMany(e => e.Contactos)
                      .WithOne(c => c.cliente);

                entity.Property(e => e.VtmclhNrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROCTA");

                entity.Property(e => e.UsrVtmclhArchiv)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ARCHIV");

                entity.Property(e => e.UsrVtmclhAtentr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ATENTR");

                entity.Property(e => e.UsrVtmclhCbubco)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CBUBCO");

                entity.Property(e => e.UsrVtmclhCbudia)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("USR_VTMCLH_CBUDIA");

                entity.Property(e => e.UsrVtmclhCbunro)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CBUNRO");

                entity.Property(e => e.UsrVtmclhCbusuc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CBUSUC");

                entity.Property(e => e.UsrVtmclhCbutip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CBUTIP");

                entity.Property(e => e.UsrVtmclhCodact)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CODACT");

                entity.Property(e => e.UsrVtmclhCodcob)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CODCOB");

                entity.Property(e => e.UsrVtmclhCodpen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CODPEN");

                entity.Property(e => e.UsrVtmclhCodpfi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_CODPFI");

                entity.Property(e => e.UsrVtmclhDepa1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_DEPA1");

                entity.Property(e => e.UsrVtmclhDepa2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_DEPA2");

                entity.Property(e => e.UsrVtmclhDirco2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_DIRCO2");

                entity.Property(e => e.UsrVtmclhDircob)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_DIRCOB");

                entity.Property(e => e.UsrVtmclhEnmail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_ENMAIL")
                    .IsFixedLength(true);

                entity.Property(e => e.UsrVtmclhFchimp)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_VTMCLH_FCHIMP");

                entity.Property(e => e.UsrVtmclhFecant)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_VTMCLH_FECANT");

                entity.Property(e => e.UsrVtmclhIdcust)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_IDCUST");

                entity.Property(e => e.UsrVtmclhLeyco1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_LEYCO1");

                entity.Property(e => e.UsrVtmclhLeyco2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_LEYCO2");

                entity.Property(e => e.UsrVtmclhLocal1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_LOCAL1");

                entity.Property(e => e.UsrVtmclhLocal2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_LOCAL2");

                entity.Property(e => e.UsrVtmclhMailfc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_MAILFC");

                entity.Property(e => e.UsrVtmclhMailrc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_MAILRC");

                entity.Property(e => e.UsrVtmclhMotivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_MOTIVO");

                entity.Property(e => e.UsrVtmclhMpago)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_MPAGO");

                entity.Property(e => e.UsrVtmclhNomant)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NOMANT");

                entity.Property(e => e.UsrVtmclhNro1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NRO1");

                entity.Property(e => e.UsrVtmclhNro2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NRO2");

                entity.Property(e => e.UsrVtmclhNroreg).HasColumnName("USR_VTMCLH_NROREG");

                entity.Property(e => e.UsrVtmclhNrpis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NRPIS1");

                entity.Property(e => e.UsrVtmclhNrpis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_NRPIS2");

                entity.Property(e => e.UsrVtmclhPaicob)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_PAICOB");

                entity.Property(e => e.UsrVtmclhSubpo1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_SUBPO1");

                entity.Property(e => e.UsrVtmclhSubpo2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_SUBPO2");

                entity.Property(e => e.UsrVtmclhTelcob)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_VTMCLH_TELCOB");

                entity.Property(e => e.VtmclhActivd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ACTIVD");

                entity.Property(e => e.VtmclhApell1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_APELL1");

                entity.Property(e => e.VtmclhApell2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_APELL2");

                entity.Property(e => e.VtmclhBmpbmp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_BMPBMP");

                entity.Property(e => e.VtmclhCamalt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CAMALT");

                entity.Property(e => e.VtmclhCamion)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CAMION");

                entity.Property(e => e.VtmclhCatego)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CATEGO");

                entity.Property(e => e.VtmclhCmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CMPVER");

                entity.Property(e => e.VtmclhCndint)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDINT");

                entity.Property(e => e.VtmclhCndiva)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDIVA");

                entity.Property(e => e.VtmclhCndpag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDPAG");

                entity.Property(e => e.VtmclhCndpre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CNDPRE")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhCobrad)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_COBRAD");

                entity.Property(e => e.VtmclhCodcof)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCOF");

                entity.Property(e => e.VtmclhCodcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCPT");

                entity.Property(e => e.VtmclhCodcrd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODCRD");

                entity.Property(e => e.VtmclhCodent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODENT");

                entity.Property(e => e.VtmclhCodexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODEXP");

                entity.Property(e => e.VtmclhCodfil)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODFIL");

                entity.Property(e => e.VtmclhCodopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODOPR");

                entity.Property(e => e.VtmclhCodpai)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODPAI");

                entity.Property(e => e.VtmclhCodpos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODPOS");

                entity.Property(e => e.VtmclhCodzon)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CODZON");

                entity.Property(e => e.VtmclhContad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CONTAD")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhCopifc).HasColumnName("VTMCLH_COPIFC");

                entity.Property(e => e.VtmclhCopist).HasColumnName("VTMCLH_COPIST");

                entity.Property(e => e.VtmclhCopivt).HasColumnName("VTMCLH_COPIVT");

                entity.Property(e => e.VtmclhCuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_CUENTA");

                entity.Property(e => e.VtmclhDebaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhDeposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPOSI");

                entity.Property(e => e.VtmclhDeptos)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPTOS");

                entity.Property(e => e.VtmclhDeptra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DEPTRA");

                entity.Property(e => e.VtmclhDifdes)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_DIFDES");

                entity.Property(e => e.VtmclhDifdia).HasColumnName("VTMCLH_DIFDIA");

                entity.Property(e => e.VtmclhDifhas)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_DIFHAS");

                entity.Property(e => e.VtmclhDirecc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIRECC");

                entity.Property(e => e.VtmclhDireml)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREML");

                entity.Property(e => e.VtmclhDirent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIRENT");

                entity.Property(e => e.VtmclhDirep1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP1");

                entity.Property(e => e.VtmclhDirep2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP2");

                entity.Property(e => e.VtmclhDirep3)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP3");

                entity.Property(e => e.VtmclhDirep4)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP4");

                entity.Property(e => e.VtmclhDirep5)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DIREP5");

                entity.Property(e => e.VtmclhDistri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DISTRI")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhDppiso)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_DPPISO");

                entity.Property(e => e.VtmclhEdisub)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_EDISUB")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_EMAIL");

                entity.Property(e => e.VtmclhFecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_FECALT");

                entity.Property(e => e.VtmclhFecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLH_FECMOD");

                entity.Property(e => e.VtmclhFisjur)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_FISJUR");

                entity.Property(e => e.VtmclhFletes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_FLETES")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhGenxml)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GENXML")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhGlndes)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GLNDES");

                entity.Property(e => e.VtmclhGrubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_GRUBON");

                entity.Property(e => e.VtmclhHormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_HORMOV");

                entity.Property(e => e.VtmclhHorrec)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_HORREC");

                entity.Property(e => e.VtmclhImpdif)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTMCLH_IMPDIF");

                entity.Property(e => e.VtmclhInhibe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_INHIBE")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhJurent)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_JURENT");

                entity.Property(e => e.VtmclhJurisd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_JURISD");

                entity.Property(e => e.VtmclhLanexp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LANEXP");

                entity.Property(e => e.VtmclhLiscli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LISCLI")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhLotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTORI");

                entity.Property(e => e.VtmclhLotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTREC");

                entity.Property(e => e.VtmclhLottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_LOTTRA");

                entity.Property(e => e.VtmclhMaxitm).HasColumnName("VTMCLH_MAXITM");

                entity.Property(e => e.VtmclhMedpag)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MEDPAG");

                entity.Property(e => e.VtmclhModcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODCPT");

                entity.Property(e => e.VtmclhModpag)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODPAG");

                entity.Property(e => e.VtmclhModule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MODULE");

                entity.Property(e => e.VtmclhMunicp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_MUNICP");

                entity.Property(e => e.VtmclhNomb01)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMB01");

                entity.Property(e => e.VtmclhNomb02)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMB02");

                entity.Property(e => e.VtmclhNombre)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NOMBRE");

                entity.Property(e => e.VtmclhNrodis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODIS");

                entity.Property(e => e.VtmclhNrodo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO1");

                entity.Property(e => e.VtmclhNrodo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO2");

                entity.Property(e => e.VtmclhNrodo3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO3");

                entity.Property(e => e.VtmclhNrodo4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO4");

                entity.Property(e => e.VtmclhNrodo5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODO5");

                entity.Property(e => e.VtmclhNrodoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NRODOC");

                entity.Property(e => e.VtmclhNrofax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROFAX");

                entity.Property(e => e.VtmclhNrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NROSUB");

                entity.Property(e => e.VtmclhNtelex)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NTELEX");

                entity.Property(e => e.VtmclhNumero)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_NUMERO");

                entity.Property(e => e.VtmclhOalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_OALIAS");

                entity.Property(e => e.VtmclhOblcon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_OBLCON")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhOleole)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLH_OLEOLE");

                entity.Property(e => e.VtmclhPaient)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_PAIENT");

                entity.Property(e => e.VtmclhPerina)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("VTMCLH_PERINA");

                entity.Property(e => e.VtmclhPrmipr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTMCLH_PRMIPR");

                entity.Property(e => e.VtmclhPrmxpr)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTMCLH_PRMXPR");

                entity.Property(e => e.VtmclhRespon)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RESPON");

                entity.Property(e => e.VtmclhRubr01)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR01");

                entity.Property(e => e.VtmclhRubr02)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR02");

                entity.Property(e => e.VtmclhRubr03)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR03");

                entity.Property(e => e.VtmclhRubr04)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR04");

                entity.Property(e => e.VtmclhRubr05)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR05");

                entity.Property(e => e.VtmclhRubr06)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR06");

                entity.Property(e => e.VtmclhRubr07)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR07");

                entity.Property(e => e.VtmclhRubr08)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR08");

                entity.Property(e => e.VtmclhRubr09)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR09");

                entity.Property(e => e.VtmclhRubr10)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_RUBR10");

                entity.Property(e => e.VtmclhSector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SECTOR");

                entity.Property(e => e.VtmclhSectra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SECTRA");

                entity.Property(e => e.VtmclhSegpro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SEGPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhSysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_SYSVER");

                entity.Property(e => e.VtmclhTelefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TELEFN");

                entity.Property(e => e.VtmclhTextos)
                    .HasColumnType("text")
                    .HasColumnName("VTMCLH_TEXTOS");

                entity.Property(e => e.VtmclhTipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhTipdo1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO1");

                entity.Property(e => e.VtmclhTipdo2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO2");

                entity.Property(e => e.VtmclhTipdo3)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO3");

                entity.Property(e => e.VtmclhTipdo4)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO4");

                entity.Property(e => e.VtmclhTipdo5)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDO5");

                entity.Property(e => e.VtmclhTipdoc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPDOC");

                entity.Property(e => e.VtmclhTipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPOPR");

                entity.Property(e => e.VtmclhTippag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TIPPAG")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhTracod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TRACOD");

                entity.Property(e => e.VtmclhTrafcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_TRAFCR")
                    .IsFixedLength(true);

                //entity.Property(e => e.VtmclhTstamp)
                //    .IsRowVersion()
                //    .IsConcurrencyToken()
                //    .HasColumnName("VTMCLH_TSTAMP");

                entity.Property(e => e.VtmclhUltopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmclhUserid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_USERID");

                entity.Property(e => e.VtmclhVnddor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_VNDDOR");

                entity.Property(e => e.VtmclhZonent)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLH_ZONENT");
            });


            modelBuilder.Entity<Grtpac>(entity =>
            {
                entity.HasKey(e => new { e.GrtpacCodpai, e.GrtpacCodpos });

                entity.ToTable("GRTPAC");

                entity.Property(e => e.GrtpacCodpai)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPAI");

                entity.Property(e => e.GrtpacCodpos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPOS");

                entity.Property(e => e.GrtpacCmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CMPVER");

                entity.Property(e => e.GrtpacCodpro)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_CODPRO");

                entity.Property(e => e.GrtpacDebaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.GrtpacDescrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_DESCRP");

                entity.Property(e => e.GrtpacFecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("GRTPAC_FECALT");

                entity.Property(e => e.GrtpacFecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("GRTPAC_FECMOD");

                entity.Property(e => e.GrtpacHormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_HORMOV");

                entity.Property(e => e.GrtpacJurisd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_JURISD");

                entity.Property(e => e.GrtpacLotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTORI");

                entity.Property(e => e.GrtpacLotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTREC");

                entity.Property(e => e.GrtpacLottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_LOTTRA");

                entity.Property(e => e.GrtpacModule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_MODULE");

                entity.Property(e => e.GrtpacOalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_OALIAS");

                entity.Property(e => e.GrtpacPaipro)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_PAIPRO");

                entity.Property(e => e.GrtpacSysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_SYSVER");

                entity.Property(e => e.GrtpacTstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("GRTPAC_TSTAMP");

                entity.Property(e => e.GrtpacUltopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.GrtpacUserid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("GRTPAC_USERID");
            });

            modelBuilder.Entity<Vtmcli>(entity =>
            {
                entity.HasKey(e => new { e.VtmcliNrocta, e.VtmcliTipimp });

                entity.ToTable("VTMCLI");

                entity.HasOne(e => e.cliente)
                      .WithMany(i => i.Impuestos)
                      .HasForeignKey(c => c.VtmcliNrocta);

                entity.Property(e => e.VtmcliNrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_NROCTA");

                entity.Property(e => e.VtmcliTipimp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_TIPIMP");

                entity.Property(e => e.VtmcliCmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_CMPVER");

                entity.Property(e => e.VtmcliCndisc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_CNDISC");

                entity.Property(e => e.VtmcliCorres)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_CORRES")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmcliDebaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmcliDisimp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_DISIMP")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmcliExeden)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTMCLI_EXEDEN");

                entity.Property(e => e.VtmcliFchdes)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLI_FCHDES");

                entity.Property(e => e.VtmcliFecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLI_FECALT");

                entity.Property(e => e.VtmcliFechas)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLI_FECHAS");

                entity.Property(e => e.VtmcliFecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTMCLI_FECMOD");

                entity.Property(e => e.VtmcliHormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_HORMOV");

                entity.Property(e => e.VtmcliImpisc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_IMPISC");

                entity.Property(e => e.VtmcliInclui)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_INCLUI")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmcliLotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_LOTORI");

                entity.Property(e => e.VtmcliLotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_LOTREC");

                entity.Property(e => e.VtmcliLottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_LOTTRA");

                entity.Property(e => e.VtmcliModule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_MODULE");

                entity.Property(e => e.VtmcliOalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_OALIAS");

                entity.Property(e => e.VtmcliResolc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_RESOLC");

                entity.Property(e => e.VtmcliSysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_SYSVER");

                entity.Property(e => e.VtmcliTstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("VTMCLI_TSTAMP");

                entity.Property(e => e.VtmcliUltopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.VtmcliUserid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_USERID");

                entity.Property(e => e.VtmcliVigenc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTMCLI_VIGENC")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cvmcth>(entity =>
            {
                entity.HasKey(e => new { e.Cvmcth_Codcon, e.Cvmcth_Nrocon, e.Cvmcth_Nroext });

                entity.ToTable("CVMCTH");

                entity.HasMany(e => e.Items)
                      .WithOne(c => c.Contrato);

                entity.HasIndex(e => new { e.Cvmcth_Nroext, e.Cvmcth_Descrp }, "CVMCTH_SuperFind");

                entity.HasIndex(e => e.Cvmcth_Nroext, "W_CV_VTRMVH");

                entity.Property(e => e.Cvmcth_Codcon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODCON");

                entity.Property(e => e.Cvmcth_Nrocon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_NROCON");

                entity.Property(e => e.Cvmcth_Nroext).HasColumnName("CVMCTH_NROEXT");

                entity.Property(e => e.Cvmcth_Actcof)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_ACTCOF")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Actlis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_ACTLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Auxaju)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_AUXAJU");

                entity.Property(e => e.Cvmcth_Auxfba)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_AUXFBA");

                entity.Property(e => e.Cvmcth_Auxrte)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_AUXRTE");

                entity.Property(e => e.Cvmcth_Cerdec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CERDEC")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Cndcom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CNDCOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Cndpag)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CNDPAG");

                entity.Property(e => e.Cvmcth_Codcst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODCST")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Codctr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODCTR");

                entity.Property(e => e.Cvmcth_Codcvt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODCVT")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODEMP");

                entity.Property(e => e.Cvmcth_Codlis)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_CODOPR");

                entity.Property(e => e.Cvmcth_Coef01)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COEF01");

                entity.Property(e => e.Cvmcth_Coef02)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COEF02");

                entity.Property(e => e.Cvmcth_Coef03)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COEF03");

                entity.Property(e => e.Cvmcth_Coef04)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COEF04");

                entity.Property(e => e.Cvmcth_Coef05)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COEF05");

                entity.Property(e => e.Cvmcth_Coefic)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("CVMCTH_COEFIC");

                entity.Property(e => e.Cvmcth_Cofdev)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COFDEV");

                entity.Property(e => e.Cvmcth_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COFFAC");

                entity.Property(e => e.Cvmcth_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_COFLIS");

                entity.Property(e => e.Cvmcth_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_DEPOSI");

                entity.Property(e => e.Cvmcth_Descrp)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_DESCRP");

                entity.Property(e => e.Cvmcth_Dimobl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_DIMOBL");

                entity.Property(e => e.Cvmcth_Dimori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_DIMORI");

                entity.Property(e => e.Cvmcth_Estact)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_ESTACT");

                entity.Property(e => e.Cvmcth_Estcon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_ESTCON");

                entity.Property(e => e.Cvmcth_Facdes)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FACDES");

                entity.Property(e => e.Cvmcth_Fachas)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FACHAS");

                entity.Property(e => e.Cvmcth_Fchaju)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHAJU");

                entity.Property(e => e.Cvmcth_Fchbas)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHBAS");

                entity.Property(e => e.Cvmcth_Fchinb)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHINB");

                entity.Property(e => e.Cvmcth_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHMOV");

                entity.Property(e => e.Cvmcth_Fchpeb)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHPEB");

                entity.Property(e => e.Cvmcth_Fchper)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHPER");

                entity.Property(e => e.Cvmcth_Fchrte)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHRTE");

                entity.Property(e => e.Cvmcth_Fchteb)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHTEB");

                entity.Property(e => e.Cvmcth_Fchter)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHTER");

                entity.Property(e => e.Cvmcth_Fchula)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHULA");

                entity.Property(e => e.Cvmcth_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FECALT");

                entity.Property(e => e.Cvmcth_Feclis)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FECLIS");

                entity.Property(e => e.Cvmcth_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FECMOD");

                entity.Property(e => e.Cvmcth_Freact).HasColumnName("CVMCTH_FREACT");

                entity.Property(e => e.Cvmcth_Frefac).HasColumnName("CVMCTH_FREFAC");

                entity.Property(e => e.Cvmcth_Grubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_GRUBON");
                entity.Property(e => e.Cvmcth_Modcst)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_MODCST");

                entity.Property(e => e.Cvmcth_Modcvt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_MODCVT");

                entity.Property(e => e.Cvmcth_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_NROCTA");

                entity.Property(e => e.Cvmcth_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_NROSUB");

                entity.Property(e => e.Cvmcth_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_OALIAS");

                entity.Property(e => e.Cvmcth_Obshis)
                    .HasColumnType("text")
                    .HasColumnName("CVMCTH_OBSHIS");

                entity.Property(e => e.Cvmcth_Oleole)
                    .HasColumnType("text")
                    .HasColumnName("CVMCTH_OLEOLE");

                entity.Property(e => e.Cvmcth_Pctc01)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("CVMCTH_PCTC01");

                entity.Property(e => e.Cvmcth_Pctc02)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("CVMCTH_PCTC02");

                entity.Property(e => e.Cvmcth_Pctc03)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("CVMCTH_PCTC03");

                entity.Property(e => e.Cvmcth_Pctc04)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("CVMCTH_PCTC04");

                entity.Property(e => e.Cvmcth_Pctc05)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("CVMCTH_PCTC05");

                entity.Property(e => e.Cvmcth_Percan)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_PERCAN")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Priact)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_PRIACT");

                entity.Property(e => e.Cvmcth_Priaju)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_PRIAJU");

                entity.Property(e => e.Cvmcth_Prifac)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_PRIFAC");

                entity.Property(e => e.Cvmcth_Recnov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RECNOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Rubr01)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR01");

                entity.Property(e => e.Cvmcth_Rubr02)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR02");

                entity.Property(e => e.Cvmcth_Rubr03)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR03");

                entity.Property(e => e.Cvmcth_Rubr04)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR04");

                entity.Property(e => e.Cvmcth_Rubr05)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR05");

                entity.Property(e => e.Cvmcth_Rubr06)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR06");

                entity.Property(e => e.Cvmcth_Rubr07)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR07");

                entity.Property(e => e.Cvmcth_Rubr08)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR08");

                entity.Property(e => e.Cvmcth_Rubr09)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR09");

                entity.Property(e => e.Cvmcth_Rubr10)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_RUBR10");

                entity.Property(e => e.Cvmcth_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_SECTOR");

                entity.Property(e => e.Cvmcth_Subcue)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_SUBCUE");

                entity.Property(e => e.Cvmcth_Subori)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_SUBORI");

                entity.Property(e => e.Cvmcth_Textos)
                    .HasColumnType("text")
                    .HasColumnName("CVMCTH_TEXTOS");

                entity.Property(e => e.Cvmcth_Tipexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_TIPEXP");

                entity.Property(e => e.Cvmcth_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_TIPOPR");

                entity.Property(e => e.Cvmcth_Ufaaux)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_UFAAUX");

                entity.Property(e => e.Cvmcth_Ultaju)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_ULTAJU");

                entity.Property(e => e.Cvmcth_Ultbas)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_ULTBAS");

                entity.Property(e => e.Cvmcth_Ultfac)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_ULTFAC");

                entity.Property(e => e.Cvmcth_Ultfba)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_ULTFBA");

                entity.Property(e => e.Cvmcth_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Unific)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_UNIFIC")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcth_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_USERID");

                entity.Property(e => e.Cvmcth_Vnddor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_VNDDOR");

                entity.Property(e => e.Cvmcth_Vtcero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTH_VTCERO")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Cvmcth_Mpago)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTH_MPAGO");
            });

            modelBuilder.Entity<Cvmcti>(entity =>
            {
                entity.HasKey(e => new { e.Cvmcti_Codcon, e.Cvmcti_Nrocon, e.Cvmcti_Nroext, e.Cvmcti_Nroitm, e.Cvmcti_Debhab });

                entity.ToTable("CVMCTI");

                entity.HasIndex(e => new { e.Cvmcti_Tippro, e.Cvmcti_Artcod, e.Usr_Cvmcti_Codotr, e.Usr_Cvmcti_Nrootr }, "USR_FCH_COM_N");

                entity.Property(e => e.Cvmcti_Codcon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODCON");

                entity.Property(e => e.Cvmcti_Nrocon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_NROCON");

                entity.Property(e => e.Cvmcti_Nroext).HasColumnName("CVMCTI_NROEXT");

                entity.Property(e => e.Cvmcti_Nroitm).HasColumnName("CVMCTI_NROITM");

                entity.Property(e => e.Cvmcti_Debhab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_DEBHAB");

                entity.Property(e => e.Cvmcti_Actlis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_ACTLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_ARTCOD");

                entity.Property(e => e.Cvmcti_Auxaju)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("CVMCTI_AUXAJU");

                entity.Property(e => e.Cvmcti_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("CVMCTI_CANTID");

                entity.Property(e => e.Cvmcti_Cntsec)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("CVMCTI_CNTSEC");

                entity.Property(e => e.Cvmcti_Codano)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODANO");

                entity.Property(e => e.Cvmcti_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODCPT");

                entity.Property(e => e.Cvmcti_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODEMP");

                entity.Property(e => e.Cvmcti_Codniv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODNIV");

                entity.Property(e => e.Cvmcti_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CODOPR");

                entity.Property(e => e.Cvmcti_Cuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_CUENTA");

                entity.Property(e => e.Cvmcti_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Facsec)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("CVMCTI_FACSEC");

                entity.Property(e => e.Cvmcti_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTI_FECALT");

                entity.Property(e => e.Cvmcti_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTI_FECMOD");

                entity.Property(e => e.Cvmcti_Norden).HasColumnName("CVMCTI_NORDEN");

                entity.Property(e => e.Cvmcti_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_OALIAS");

                entity.Property(e => e.Cvmcti_Preaju)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("CVMCTI_PREAJU");

                entity.Property(e => e.Cvmcti_Precio)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("CVMCTI_PRECIO");

                entity.Property(e => e.Cvmcti_Recnov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_RECNOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Stocks)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_STOCKS");

                entity.Property(e => e.Cvmcti_Texadi)
                    .HasColumnType("text")
                    .HasColumnName("CVMCTI_TEXADI");

                entity.Property(e => e.Cvmcti_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_TIPOPR");

                entity.Property(e => e.Cvmcti_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Travig)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_TRAVIG")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Cvmcti_Unimed)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_UNIMED");

                entity.Property(e => e.Cvmcti_Unisec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_UNISEC");

                entity.Property(e => e.Cvmcti_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CVMCTI_USERID");

                entity.Property(e => e.Cvmcti_Vigdde)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTI_VIGDDE");

                entity.Property(e => e.Cvmcti_Vighta)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTI_VIGHTA");

                entity.Property(e => e.Usr_Cvmcti_Archiv)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_ARCHIV");

                entity.Property(e => e.Usr_Cvmcti_Codmod)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_CODMOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Cvmcti_Codotr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_CODOTR")
                    .IsFixedLength(true);

                entity.Property(e => e.Usr_Cvmcti_Fccnew)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CVMCTI_FCCNEW");

                entity.Property(e => e.Usr_Cvmcti_Fchcom)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CVMCTI_FCHCOM");

                entity.Property(e => e.Usr_Cvmcti_Fchimp)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CVMCTI_FCHIMP");

                entity.Property(e => e.Usr_Cvmcti_Fchmod)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CVMCTI_FCHMOD");

                entity.Property(e => e.Usr_Cvmcti_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CVMCTI_FCHMOV");

                entity.Property(e => e.Usr_Cvmcti_Idcust)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_IDCUST");

                entity.Property(e => e.Usr_Cvmcti_Modmod)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_MODMOD");

                entity.Property(e => e.Usr_Cvmcti_Modotr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_MODOTR");

                entity.Property(e => e.Usr_Cvmcti_Nroitm).HasColumnName("USR_CVMCTI_NROITM");

                entity.Property(e => e.Usr_Cvmcti_Nromod).HasColumnName("USR_CVMCTI_NROMOD");

                entity.Property(e => e.Usr_Cvmcti_Nrooc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_NROOC");

                entity.Property(e => e.Usr_Cvmcti_Nrootr).HasColumnName("USR_CVMCTI_NROOTR");

                entity.Property(e => e.Usr_Cvmcti_Nroreg).HasColumnName("USR_CVMCTI_NROREG");

                entity.Property(e => e.Usr_Cvmcti_Vnddo2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_VNDDO2");

                entity.Property(e => e.Usr_Cvmcti_Vnddor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTI_VNDDOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
