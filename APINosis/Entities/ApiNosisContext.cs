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
        public virtual DbSet<Fcrmvh> Fcrmvh { get; set; }
        public virtual DbSet<Fcrmvi> Fcrmvi { get; set; }
        public virtual DbSet<Vtrmvh> Vtrmvh { get; set; }
        public virtual DbSet<Vtrmvi> Vtrmvi { get; set; }
        public virtual DbSet<Vtrmvp> Vtrmvp { get; set; }

        public virtual DbSet<Vtmclc> Vtmclc { get; set; }
        public virtual DbSet<Vtmclh> Vtmclh { get; set; }
        public virtual DbSet<Grtpac> Grtpac { get; set; }
        public virtual DbSet<Vtmcli> Vtmcli { get; set; }
        public virtual DbSet<Cvmcth> Cvmcth { get; set; }
        public virtual DbSet<Cvmcti> Cvmcti { get; set; }
        public virtual DbSet<Grccbh> Grccbh { get; set; }
        public virtual DbSet<Cjrmvi> Cjrmvi { get; set; }
        public virtual DbSet<Vtrmvc> Vtrmvc { get; set; }


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
                      .WithOne(c => c.Contrato)
                      .HasForeignKey(d => new { d.Cvmcti_Codcon, d.Cvmcti_Nrocon, d.Cvmcti_Nroext });

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


                entity.Property(e => e.Cvmcth_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_FCHMOV");
                
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

                entity.Property(e => e.Cvmcth_Ultfac)
                    .HasColumnType("datetime")
                    .HasColumnName("CVMCTH_ULTFAC");


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


                entity.Property(e => e.Usr_Cvmcth_Idcomp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_CVMCTH_IDCOMP");
            });

            modelBuilder.Entity<Cvmcti>(entity =>
            {
                entity.HasKey(e => new { e.Cvmcti_Codcon, e.Cvmcti_Nrocon, e.Cvmcti_Nroext, e.Cvmcti_Nroitm});

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

            modelBuilder.Entity<Grccbh>(entity =>
            {
                entity.HasKey(e => new { e.Grccbh_Modcom, e.Grccbh_Codcom });

                entity.ToTable("GRCCBH");

                entity.HasIndex(e => new { e.Grccbh_Modcom, e.Grccbh_Codcom, e.Grccbh_Vtcodasi }, "GR_WW_CPRMVHWIZ");

                entity.HasIndex(e => new { e.Grccbh_Modcom, e.Grccbh_Codcom, e.Grccbh_Cjvalcta }, "P_EO_CJVALCTA");

                entity.HasIndex(e => new { e.Grccbh_Stregdes, e.Grccbh_Modcom, e.Grccbh_Codcom }, "P_ST_STTEVHWIZ");

                entity.HasIndex(e => e.Grccbh_Stregdes, "P_ST_STTEVHWIZ_II");

                entity.HasIndex(e => new { e.Grccbh_Codcom, e.Grccbh_Modcom, e.Grccbh_Pvrelaci, e.Grccbh_Descrp }, "R_PV_PagoProveedores");

                entity.HasIndex(e => new { e.Grccbh_Pvincsel, e.Grccbh_Modcom, e.Grccbh_Codcom, e.Grccbh_Pvrelaci, e.Grccbh_Pveditimp }, "R_PV_SeleccionOblig");

                entity.HasIndex(e => new { e.Grccbh_Cjmodasi, e.Grccbh_Cjcodasi }, "W_CJ_CGTRANWIZ");

                entity.HasIndex(e => new { e.Grccbh_Pvmodasi, e.Grccbh_Pvcodasi }, "W_PV_CGTRANWIZ");

                entity.HasIndex(e => new { e.Grccbh_Vtmodasi, e.Grccbh_Vtcodasi }, "W_VT_CGTRANWIZ");

                entity.Property(e => e.Grccbh_Modcom)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MODCOM");

                entity.Property(e => e.Grccbh_Codcom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CODCOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Canulp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CANULP")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cbctacte)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CBCTACTE");

                entity.Property(e => e.Grccbh_Cbinfche)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CBINFCHE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cbnrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CBNROCTA");

                entity.Property(e => e.Grccbh_Cftipesm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CFTIPESM");

                entity.Property(e => e.Grccbh_Cfvenc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CFVENC");

                entity.Property(e => e.Grccbh_Cgcoflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGCOFLIS");

                entity.Property(e => e.Grccbh_Cgdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGDIMUNI");

                entity.Property(e => e.Grccbh_Cgedimon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGEDIMON")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cgmascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGMASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cgsubdia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGSUBDIA");

                entity.Property(e => e.Grccbh_Cgtipmov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CGTIPMOV");

                entity.Property(e => e.Grccbh_Cjcierre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJCIERRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjclasif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJCLASIF");

                entity.Property(e => e.Grccbh_Cjcodasi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJCODASI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjcodcaj)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJCODCAJ");

                entity.Property(e => e.Grccbh_Cjdefitm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJDEFITM")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJDIMUNI");

                entity.Property(e => e.Grccbh_Cjfchdes)
                    .HasColumnType("datetime")
                    .HasColumnName("GRCCBH_CJFCHDES");

                entity.Property(e => e.Grccbh_Cjincsub)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJINCSUB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjlector)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJLECTOR");

                entity.Property(e => e.Grccbh_Cjmodasi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJMODASI");

                entity.Property(e => e.Grccbh_Cjreqcob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJREQCOB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjsubdia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJSUBDIA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjtrafch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJTRAFCH")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cjvalcta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CJVALCTA")
                    .IsFixedLength(true);


                entity.Property(e => e.Grccbh_Cntadc).HasColumnName("GRCCBH_CNTADC");

                entity.Property(e => e.Grccbh_Codcdv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CODCDV")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Coddim)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CODDIM");

                
                entity.Property(e => e.Grccbh_Coincest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_COINCEST")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Comascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_COMASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Condia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CONDIA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Copias).HasColumnName("GRCCBH_COPIAS");

                entity.Property(e => e.Grccbh_Cvmascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CVMASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Cvtipcom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_CVTIPCOM");

                entity.Property(e => e.Grccbh_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Defstd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_DEFSTD")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Descrp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_DESCRP");

                entity.Property(e => e.Grccbh_Estaut).HasColumnName("GRCCBH_ESTAUT");

                entity.Property(e => e.Grccbh_Estrec).HasColumnName("GRCCBH_ESTREC");

                entity.Property(e => e.Grccbh_Fcincest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_FCINCEST")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Fcmascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_FCMASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("GRCCBH_FECALT");

                entity.Property(e => e.Grccbh_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("GRCCBH_FECMOD");

                entity.Property(e => e.Grccbh_Gcfchmov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_GCFCHMOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Gpclasif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_GPCLASIF");

                entity.Property(e => e.Grccbh_Gpsaveal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_GPSAVEAL")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hatrib)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HATRIB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hdespa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HDESPA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Henvas)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HENVAS")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hestan)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HESTAN")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hfecha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HFECHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hotros)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HOTROS")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hserie)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HSERIE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Hubica)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_HUBICA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Ideven)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_IDEVEN");

                entity.Property(e => e.Grccbh_Lector)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_LECTOR");

                entity.Property(e => e.Grccbh_Manulp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MANULP");

                entity.Property(e => e.Grccbh_Modcdv)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MODCDV");

                entity.Property(e => e.Grccbh_Modfec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MODFEC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Modnum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MODNUM")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Mulfrm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_MULFRM")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Noreci)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_NORECI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_OALIAS");

                entity.Property(e => e.Grccbh_Pdnroint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PDNROINT")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Person)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PERSON")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcodasi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCODASI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcodsem)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCODSEM");

                entity.Property(e => e.Grccbh_Pvcoltot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOLTOT");

                entity.Property(e => e.Grccbh_Pvcomanu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMANU")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcomanuc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMANUC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcomcre)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMCRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcomcrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMCREC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcomdeb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMDEB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvcomdebc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCOMDEBC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvctactr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVCTACTR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVDIMUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pveditimp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVEDITIMP")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvfiscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVFISCAL")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvimptcn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVIMPTCN");

                entity.Property(e => e.Grccbh_Pvincest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVINCEST")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvinciti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVINCITI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvincpvs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVINCPVS")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvincsel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVINCSEL")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvincvta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVINCVTA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvmodanu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODANU");

                entity.Property(e => e.Grccbh_Pvmodanuc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODANUC");

                entity.Property(e => e.Grccbh_Pvmodasi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODASI");

                entity.Property(e => e.Grccbh_Pvmodcre)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODCRE");

                entity.Property(e => e.Grccbh_Pvmodcrec)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODCREC");

                entity.Property(e => e.Grccbh_Pvmoddeb)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODDEB");

                entity.Property(e => e.Grccbh_Pvmoddebc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVMODDEBC");

                entity.Property(e => e.Grccbh_Pvnoapli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVNOAPLI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvnoauto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVNOAUTO")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvnodif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVNODIF")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvpormax)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("GRCCBH_PVPORMAX");

                entity.Property(e => e.Grccbh_Pvpormin)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("GRCCBH_PVPORMIN");

                entity.Property(e => e.Grccbh_Pvrelaci)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVRELACI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Pvsigtot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVSIGTOT");

                entity.Property(e => e.Grccbh_Pvsubdia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVSUBDIA");

                entity.Property(e => e.Grccbh_Pvvalrec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_PVVALREC");

                entity.Property(e => e.Grccbh_Recfec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_RECFEC");

                entity.Property(e => e.Grccbh_Repece)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_REPECE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Reppre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_REPPRE");

                entity.Property(e => e.Grccbh_Secfec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SECFEC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Secnum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SECNUM")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Sjcodcpt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SJCODCPT");

                entity.Property(e => e.Grccbh_Sjdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SJDIMUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Sjtipcom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SJTIPCOM");

                entity.Property(e => e.Grccbh_Stclasif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STCLASIF");

                entity.Property(e => e.Grccbh_Stcodasi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STCODASI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Stdephas)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STDEPHAS");

                entity.Property(e => e.Grccbh_Stdeposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STDEPOSI");

                entity.Property(e => e.Grccbh_Stdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STDIMUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Stllepla)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STLLEPLA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Stmascar)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STMASCAR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Stmodasi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STMODASI");

                entity.Property(e => e.Grccbh_Stregdes)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STREGDES");

                entity.Property(e => e.Grccbh_Stsechas)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STSECHAS");

                entity.Property(e => e.Grccbh_Stsector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STSECTOR");

                entity.Property(e => e.Grccbh_Sttipcue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STTIPCUE");

                entity.Property(e => e.Grccbh_Sttipmov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STTIPMOV");

                entity.Property(e => e.Grccbh_Stvalxcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_STVALXCR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Subcue)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_SUBCUE");

                entity.Property(e => e.Grccbh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("GRCCBH_TEXTOS");

                entity.Property(e => e.Grccbh_Tipcom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_TIPCOM");

                entity.Property(e => e.Grccbh_Tipreg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_TIPREG")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Titulo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_TITULO");

                entity.Property(e => e.Grccbh_Trafcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_TRAFCR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_USERID");

                entity.Property(e => e.Grccbh_Vtcodasi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCODASI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcoltot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOLTOT");

                entity.Property(e => e.Grccbh_Vtcomanu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMANU")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcomanuc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMANUC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcomcre)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMCRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcomcrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMCREC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcomdeb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMDEB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtcomdebc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTCOMDEBC")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtdimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTDIMUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vteditimp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTEDITIMP")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtexport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTEXPORT")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtimptcn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTIMPTCN");

                entity.Property(e => e.Grccbh_Vtinccob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCCOB")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtincest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCEST")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtinciti)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCITI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtincpvs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCPVS")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtincvnd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCVND")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtincvta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINCVTA")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtindbcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTINDBCR")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtmodanu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODANU");

                entity.Property(e => e.Grccbh_Vtmodanuc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODANUC");

                entity.Property(e => e.Grccbh_Vtmodasi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODASI");

                entity.Property(e => e.Grccbh_Vtmodcre)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODCRE");

                entity.Property(e => e.Grccbh_Vtmodcrec)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODCREC");

                entity.Property(e => e.Grccbh_Vtmoddeb)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODDEB");

                entity.Property(e => e.Grccbh_Vtmoddebc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTMODDEBC");

                entity.Property(e => e.Grccbh_Vtnoapli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTNOAPLI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtnodif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTNODIF")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtpormax)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("GRCCBH_VTPORMAX");

                entity.Property(e => e.Grccbh_Vtpormin)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("GRCCBH_VTPORMIN");

                entity.Property(e => e.Grccbh_Vtrelaci)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTRELACI")
                    .IsFixedLength(true);

                entity.Property(e => e.Grccbh_Vtsigtot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTSIGTOT");

                entity.Property(e => e.Grccbh_Vtsubdia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTSUBDIA");

                entity.Property(e => e.Grccbh_Vtvalrec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRCCBH_VTVALREC");
            });

            modelBuilder.Entity<Fcrmvh>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor });

                entity.ToTable("FCRMVH");

                entity.HasMany(e => e.Items)
                      .WithOne(c => c.factura);

                entity.HasIndex(e => e.Fcrmvh_Nrofor, "GR_NUMERATION");
                
                entity.HasIndex(e => new { e.Fcrmvh_Modfor, e.Fcrmvh_Codfor, e.Fcrmvh_Nrofor, e.Fcrmvh_Fchmov }, "W_FC_FCRMVH");
                
                entity.Property(e => e.Fcrmvh_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_MODFOR");

                entity.Property(e => e.Fcrmvh_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODFOR");

                entity.Property(e => e.Fcrmvh_Nrofor).HasColumnName("FCRMVH_NROFOR");

                
                entity.Property(e => e.Fcrmvh_Cndpag)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CNDPAG");

                entity.Property(e => e.Fcrmvh_Codent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODENT");

                entity.Property(e => e.Fcrmvh_Codlis)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvh_Codori)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODORI");

                entity.Property(e => e.Fcrmvh_Codpai)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODPAI");

                entity.Property(e => e.Fcrmvh_Codpos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODPOS");

                entity.Property(e => e.Fcrmvh_Codzon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CODZON");

                entity.Property(e => e.Fcrmvh_Cofdeu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFDEU");

                entity.Property(e => e.Fcrmvh_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFFAC");

                entity.Property(e => e.Fcrmvh_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COFLIS");

                entity.Property(e => e.Fcrmvh_Comori)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_COMORI");

                entity.Property(e => e.Fcrmvh_Contac)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_CONTAC");

                entity.Property(e => e.Fcrmvh_Direcc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIRECC");

                entity.Property(e => e.Fcrmvh_Dirent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_DIRENT");

                
                entity.Property(e => e.Fcrmvh_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("FCRMVH_FCHMOV");

                entity.Property(e => e.Fcrmvh_Grubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_GRUBON");

                
                entity.Property(e => e.Fcrmvh_Jurisd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_JURISD");

                
                entity.Property(e => e.Fcrmvh_Nrocta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NROCTA");

                entity.Property(e => e.Fcrmvh_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_NROSUB");

                entity.Property(e => e.Fcrmvh_Paient)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_PAIENT");

                
                entity.Property(e => e.Fcrmvh_Telefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TELEFN");

                entity.Property(e => e.Fcrmvh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("FCRMVH_TEXTOS");

                entity.Property(e => e.Fcrmvh_Tipexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_TIPEXP");

                entity.Property(e => e.Fcrmvh_Vnddor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVH_VNDDOR");
                entity.Property(e => e.Usr_Fcrmvh_Idpago)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_IDPAGO");

                entity.Property(e => e.Usr_Fcrmvh_Idcomp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USR_FCRMVH_IDCOMP");

                entity.Property(e => e.Usr_Fcrmvh_Idcrm).HasColumnName("USR_FCRMVH_IDCRM");
            });

            modelBuilder.Entity<Fcrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor, e.Fcrmvi_Nroitm, e.Fcrmvi_Nivexp, e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl });

                entity.ToTable("FCRMVI");
                entity.HasOne(e => e.factura)
                      .WithMany(c => c.Items)
                      .HasForeignKey(c => new { c.Fcrmvi_Modfor, c.Fcrmvi_Codfor, c.Fcrmvi_Nrofor });

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Itmapl, e.Fcrmvi_Expapl }, "S_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl }, "T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Fcrmvi_Modapl, e.Fcrmvi_Codapl, e.Fcrmvi_Nroapl, e.Fcrmvi_Modfor, e.Fcrmvi_Codfor, e.Fcrmvi_Nrofor }, "W_FC_FCRMVH1UPD");

                entity.Property(e => e.Fcrmvi_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODFOR");

                entity.Property(e => e.Fcrmvi_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODFOR");

                entity.Property(e => e.Fcrmvi_Nrofor).HasColumnName("FCRMVI_NROFOR");

                entity.Property(e => e.Fcrmvi_Nroitm).HasColumnName("FCRMVI_NROITM");

                entity.Property(e => e.Fcrmvi_Nivexp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_NIVEXP");

                entity.Property(e => e.Fcrmvi_Modapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_MODAPL");

                entity.Property(e => e.Fcrmvi_Codapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODAPL")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Nroapl).HasColumnName("FCRMVI_NROAPL");

                entity.Property(e => e.Fcrmvi_Itmapl).HasColumnName("FCRMVI_ITMAPL");

                entity.Property(e => e.Fcrmvi_Expapl)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_EXPAPL");

                entity.Property(e => e.Fcrmvi_Artori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_ARTORI");

                entity.Property(e => e.Fcrmvi_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("FCRMVI_CANTID");

                entity.Property(e => e.Fcrmvi_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_CODCPT");

                entity.Property(e => e.Fcrmvi_Pctbf1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF1");

                entity.Property(e => e.Fcrmvi_Pctbf2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF2");

                entity.Property(e => e.Fcrmvi_Pctbf3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF3");

                entity.Property(e => e.Fcrmvi_Pctbf4)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF4");

                entity.Property(e => e.Fcrmvi_Pctbf5)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF5");

                entity.Property(e => e.Fcrmvi_Pctbf6)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF6");

                entity.Property(e => e.Fcrmvi_Pctbf7)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF7");

                entity.Property(e => e.Fcrmvi_Pctbf8)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF8");

                entity.Property(e => e.Fcrmvi_Pctbf9)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("FCRMVI_PCTBF9");

                
                entity.Property(e => e.Fcrmvi_Precio)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("FCRMVI_PRECIO");

                
                entity.Property(e => e.Fcrmvi_Textos)
                    .HasColumnType("text")
                    .HasColumnName("FCRMVI_TEXTOS");

                entity.Property(e => e.Fcrmvi_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Fcrmvi_Tipori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("FCRMVI_TIPORI")
                    .IsFixedLength(true);



            });

            modelBuilder.Entity<Vtrmvh>(entity =>
            {
                entity.HasKey(e => new {e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor });

                entity.ToTable("VTRMVH");

                entity.HasMany(e => e.Aplicaciones)
                      .WithOne(c => c.Recibo)
                      .HasForeignKey(d => new {  d.Vtrmvc_Codfor, d.Vtrmvc_Nrofor});

                entity.HasMany(e => e.MediosDeCobro)
                      .WithOne(c => c.Recibo)
                      .HasForeignKey(d => new { d.Cjrmvi_Codfor, d.Cjrmvi_Nrofor});


                entity.HasIndex(e => new { e.Vtrmvh_Nroasi, e.Vtrmvh_Modasi, e.Vtrmvh_Codasi, e.Vtrmvh_Fchmov, e.Vtrmvh_Modcom, e.Vtrmvh_Codcom, e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Coflis }, "CP_WW_CPRMVHWIZ");

                entity.HasIndex(e => e.Vtrmvh_Nrofor, "GR_NUMERATION");

                entity.HasIndex(e => new { e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Modcom, e.Vtrmvh_Codcom }, "P_EO_MODFORMODCOM");

                entity.HasIndex(e => new { e.Vtrmvh_Codasi, e.Vtrmvh_Nroasi, e.Vtrmvh_Modasi, e.Vtrmvh_Fchmov, e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Modcom, e.Vtrmvh_Codcom, e.Vtrmvh_Coflis }, "P_IG_PRFMNCE1");

                entity.HasIndex(e => new { e.Vtrmvh_Modcom, e.Vtrmvh_Codcom, e.Vtrmvh_Cndiva, e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Codemp, e.Vtrmvh_Nrofor, e.Vtrmvh_Nrocae }, "P_VT_MovPendCAE");

                entity.HasIndex(e => new { e.Vtrmvh_Nrofor, e.Vtrmvh_Coffac, e.Vtrmvh_Codfor, e.Vtrmvh_Codemp, e.Vtrmvh_Modfor }, "P_VT_MovPendCAE_02");

                entity.HasIndex(e => new { e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Codemp, e.Vtrmvh_Nrocta, e.Vtrmvh_Tipexp, e.Vtrmvh_Coffac, e.Vtrmvh_Codzon }, "P_VT_MovPendCAE_03");

                entity.HasIndex(e => new { e.Vtrmvh_Moddcr, e.Vtrmvh_Coddcr, e.Vtrmvh_Nrodcr }, "R_VT_DEBCRE");

                entity.HasIndex(e => new { e.Vtrmvh_Modrev, e.Vtrmvh_Codrev, e.Vtrmvh_Nrorev, e.Vtrmvh_Modasi, e.Vtrmvh_Codasi, e.Vtrmvh_Nroasi }, "W_CG_CGTRANWIZ");

                entity.HasIndex(e => new { e.Vtrmvh_Fchmov, e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Modcom, e.Vtrmvh_Codcom }, "W_GR_IGRMVHWIZ");

                entity.HasIndex(e => new { e.Vtrmvh_Modasi, e.Vtrmvh_Codasi, e.Vtrmvh_Nroasi, e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor }, "W_GR_IGRMVHWIZ_2");

                entity.HasIndex(e => new { e.Vtrmvh_Modfor, e.Vtrmvh_Codfor, e.Vtrmvh_Nrofor, e.Vtrmvh_Codrev }, "W_VT_FCRMVUPD");

                entity.Property(e => e.Vtrmvh_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODFOR");

                entity.Property(e => e.Vtrmvh_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODFOR");

                entity.Property(e => e.Vtrmvh_Nrofor).HasColumnName("VTRMVH_NROFOR");

                entity.Property(e => e.Usr_Vtrmvh_Idcrm).HasColumnName("USR_VTRMVH_IDCRM");


                entity.Property(e => e.Vtrmvh_Cambio)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("VTRMVH_CAMBIO");

                entity.Property(e => e.Vtrmvh_Camsec)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("VTRMVH_CAMSEC");

                entity.Property(e => e.Vtrmvh_Camuss)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("VTRMVH_CAMUSS");

                entity.Property(e => e.Vtrmvh_Claaut).HasColumnName("VTRMVH_CLAAUT");

                entity.Property(e => e.Vtrmvh_Clamov)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CLAMOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Cndcom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CNDCOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Cndiva)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CNDIVA");

                entity.Property(e => e.Vtrmvh_Cndpag)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CNDPAG");

                entity.Property(e => e.Vtrmvh_Cobrad)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_COBRAD");

                entity.Property(e => e.Vtrmvh_Codasi)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODASI")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Codcom)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODCOM")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Coddcr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODDCR");

                entity.Property(e => e.Vtrmvh_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODEMP");

                entity.Property(e => e.Vtrmvh_Codfcr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODFCR");

                entity.Property(e => e.Vtrmvh_Codlis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODLIS")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Codope)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODOPE");

                entity.Property(e => e.Vtrmvh_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODOPR");

                entity.Property(e => e.Vtrmvh_Codori).HasColumnName("VTRMVH_CODORI");

                entity.Property(e => e.Vtrmvh_Codrev)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODREV");

                entity.Property(e => e.Vtrmvh_Codrim)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODRIM");

                entity.Property(e => e.Vtrmvh_Codsce)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODSCE");

                entity.Property(e => e.Vtrmvh_Codzon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_CODZON");

                entity.Property(e => e.Vtrmvh_Cofdeu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_COFDEU");

                entity.Property(e => e.Vtrmvh_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_COFFAC");

                entity.Property(e => e.Vtrmvh_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_COFLIS");

                entity.Property(e => e.Vtrmvh_Desmov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_DESMOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Dimobl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_DIMOBL");

                entity.Property(e => e.Vtrmvh_Dimori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_DIMORI");

                entity.Property(e => e.Vtrmvh_Dimuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_DIMUNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Docfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_DOCFIS");

                entity.Property(e => e.Vtrmvh_Empasi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_EMPASI");

                entity.Property(e => e.Vtrmvh_Empdcr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_EMPDCR");

                entity.Property(e => e.Vtrmvh_Empfcr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_EMPFCR");

                entity.Property(e => e.Vtrmvh_Emprev)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_EMPREV");

                entity.Property(e => e.Vtrmvh_Emprim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_EMPRIM");

                entity.Property(e => e.Vtrmvh_Estaut).HasColumnName("VTRMVH_ESTAUT");

                entity.Property(e => e.Vtrmvh_Fchaut)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FCHAUT");

                entity.Property(e => e.Vtrmvh_Fchfce)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FCHFCE");

                entity.Property(e => e.Vtrmvh_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FCHMOV");

                //entity.Property(e => e.Usr_Vtrmvh_Fchcbu)
                //    .HasColumnType("datetime")
                //    .IsRequired(false)
                //    .HasColumnName("USR_VTRMVH_FCHCBU");

                entity.Property(e => e.Vtrmvh_Fchpar)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FCHPAR");

                entity.Property(e => e.Vtrmvh_Fchven)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FCHVEN");

                entity.Property(e => e.Vtrmvh_Fecfcr)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_FECFCR");

                entity.Property(e => e.Vtrmvh_Grubon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_GRUBON");

                entity.Property(e => e.Vtrmvh_Hstfor).HasColumnName("VTRMVH_HSTFOR");

                entity.Property(e => e.Vtrmvh_Idtfex).HasColumnName("VTRMVH_IDTFEX");

                entity.Property(e => e.Vtrmvh_Impres).HasColumnName("VTRMVH_IMPRES");

                entity.Property(e => e.Vtrmvh_Imptcn)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_IMPTCN");

                entity.Property(e => e.Vtrmvh_Jurisd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_JURISD");

                entity.Property(e => e.Vtrmvh_Letfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_LETFIS");

                entity.Property(e => e.Vtrmvh_Lotein).HasColumnName("VTRMVH_LOTEIN");


                entity.Property(e => e.Vtrmvh_Modasi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODASI");

                entity.Property(e => e.Vtrmvh_Modcom)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODCOM");

                entity.Property(e => e.Vtrmvh_Moddcr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODDCR");

                entity.Property(e => e.Vtrmvh_Modfcr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODFCR");

                entity.Property(e => e.Vtrmvh_Modrev)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODREV");

                entity.Property(e => e.Vtrmvh_Modrim)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_MODRIM");
                entity.Property(e => e.Vtrmvh_Nidcae).HasColumnName("VTRMVH_NIDCAE");

                entity.Property(e => e.Vtrmvh_Nidfex).HasColumnName("VTRMVH_NIDFEX");

                entity.Property(e => e.Vtrmvh_Nroasi).HasColumnName("VTRMVH_NROASI");

                entity.Property(e => e.Vtrmvh_Nrocae)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_NROCAE");

                entity.Property(e => e.Vtrmvh_Nrocta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_NROCTA");

                entity.Property(e => e.Vtrmvh_Nrodcr).HasColumnName("VTRMVH_NRODCR");

                entity.Property(e => e.Vtrmvh_Nrofcr).HasColumnName("VTRMVH_NROFCR");

                entity.Property(e => e.Vtrmvh_Nrofis).HasColumnName("VTRMVH_NROFIS");

                entity.Property(e => e.Vtrmvh_Nrorev).HasColumnName("VTRMVH_NROREV");

                entity.Property(e => e.Vtrmvh_Nrorim).HasColumnName("VTRMVH_NRORIM");

                entity.Property(e => e.Vtrmvh_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_NROSUB");

                entity.Property(e => e.Vtrmvh_Oricod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_ORICOD");

                entity.Property(e => e.Vtrmvh_Oricom)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_ORICOM");

                entity.Property(e => e.Vtrmvh_Stafcr).HasColumnName("VTRMVH_STAFCR");

                entity.Property(e => e.Vtrmvh_Subcue)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_SUBCUE");

                entity.Property(e => e.Vtrmvh_Subori)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_SUBORI");

                entity.Property(e => e.Vtrmvh_Sucfis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_SUCFIS");

                entity.Property(e => e.Vtrmvh_Sucurs)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_SUCURS");

                
                entity.Property(e => e.Vtrmvh_Textos)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVH_TEXTOS");

                entity.Property(e => e.Vtrmvh_Tipexp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_TIPEXP");

                entity.Property(e => e.Vtrmvh_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_TIPOPR");

                entity.Property(e => e.Vtrmvh_Usraut)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_USRAUT");

                entity.Property(e => e.Vtrmvh_Utpaor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_UTPAOR")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvh_Vencae)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVH_VENCAE");

                entity.Property(e => e.Vtrmvh_Vnddor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVH_VNDDOR");
            });

            modelBuilder.Entity<Vtrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Nrofor, e.Vtrmvi_Nroitm, e.Vtrmvi_Debhab });

                entity.ToTable("VTRMVI");

                entity.HasIndex(e => new { e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Nrofor, e.Vtrmvi_Debhab, e.Vtrmvi_Cuenta, e.Vtrmvi_Impnac, e.Vtrmvi_Impsec }, "P_IG_PRFMNCE1");

                entity.HasIndex(e => new { e.Vtrmvi_Nrofor, e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Codemp, e.Vtrmvi_Modcpt, e.Vtrmvi_Tipcpt, e.Vtrmvi_Nroitm, e.Vtrmvi_Debhab, e.Vtrmvi_Codcpt }, "P_VT_MovPendCAE");

                entity.HasIndex(e => new { e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Nrofor, e.Vtrmvi_Modcpt, e.Vtrmvi_Tipcpt, e.Vtrmvi_Codcpt, e.Vtrmvi_Nroitm, e.Vtrmvi_Debhab }, "R_VT_DESGIMP_1");

                entity.HasIndex(e => new { e.Vtrmvi_Nrofor, e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Modcpt, e.Vtrmvi_Tipcpt, e.Vtrmvi_Codcpt, e.Vtrmvi_Nroitm, e.Vtrmvi_Debhab }, "R_VT_DESGIMP_2");

                entity.HasIndex(e => new { e.Vtrmvi_Tippro, e.Vtrmvi_Artcod }, "T_FC_VTRMVI");

                entity.HasIndex(e => e.Vtrmvi_Nrofor, "T_VT_VTRRCH");

                entity.HasIndex(e => new { e.Vtrmvi_Modapl, e.Vtrmvi_Codapl, e.Vtrmvi_Nroapl, e.Vtrmvi_Modfor, e.Vtrmvi_Codfor, e.Vtrmvi_Nrofor, e.Vtrmvi_Debhab, e.Vtrmvi_Modcpt, e.Vtrmvi_Tipcpt, e.Vtrmvi_Codcpt, e.Vtrmvi_Cuenta, e.Vtrmvi_Cuoapl }, "T_VT_VTRRCH2");

                entity.HasIndex(e => new { e.Vtrmvi_Cuenta, e.Vtrmvi_Debhab }, "W_GR_IGRMVHWIZ");

                entity.HasIndex(e => new { e.Vtrmvi_Modapl, e.Vtrmvi_Codapl, e.Vtrmvi_Nroapl }, "W_VT_VTDBCR");

                entity.Property(e => e.Vtrmvi_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_MODFOR");

                entity.Property(e => e.Vtrmvi_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODFOR");

                entity.Property(e => e.Vtrmvi_Nrofor).HasColumnName("VTRMVI_NROFOR");

                entity.Property(e => e.Vtrmvi_Nroitm).HasColumnName("VTRMVI_NROITM");

                entity.Property(e => e.Vtrmvi_Debhab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_DEBHAB");

                entity.Property(e => e.Vtrmvi_Anovig).HasColumnName("VTRMVI_ANOVIG");

                entity.Property(e => e.Vtrmvi_Artcod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_ARTCOD");

                entity.Property(e => e.Vtrmvi_Artdes)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_ARTDES");

                entity.Property(e => e.Vtrmvi_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("VTRMVI_CANTID");

                entity.Property(e => e.Vtrmvi_Clamov)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CLAMOV")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvi_Cntalt)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("VTRMVI_CNTALT");

                entity.Property(e => e.Vtrmvi_Cntcon)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("VTRMVI_CNTCON");

                entity.Property(e => e.Vtrmvi_Cntfac)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("VTRMVI_CNTFAC");

                entity.Property(e => e.Vtrmvi_Codano)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODANO");

                entity.Property(e => e.Vtrmvi_Codapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODAPL");

                entity.Property(e => e.Vtrmvi_Codcon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODCON");

                entity.Property(e => e.Vtrmvi_Codcpt)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODCPT");

                entity.Property(e => e.Vtrmvi_Codcur)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODCUR");

                entity.Property(e => e.Vtrmvi_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODEMP");

                entity.Property(e => e.Vtrmvi_Codniv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODNIV");

                entity.Property(e => e.Vtrmvi_Codopr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODOPR");

                entity.Property(e => e.Vtrmvi_Codori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODORI");

                entity.Property(e => e.Vtrmvi_Codpro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CODPRO");

                entity.Property(e => e.Vtrmvi_Cuenta)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_CUENTA");

                entity.Property(e => e.Vtrmvi_Cuoapl).HasColumnName("VTRMVI_CUOAPL");

                entity.Property(e => e.Vtrmvi_Deposi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_DEPOSI");

                entity.Property(e => e.Vtrmvi_Despro)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_DESPRO");

                entity.Property(e => e.Vtrmvi_Empapl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_EMPAPL");

                entity.Property(e => e.Vtrmvi_Empcon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_EMPCON");

                entity.Property(e => e.Vtrmvi_Empori)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_EMPORI");

                entity.Property(e => e.Vtrmvi_Envase)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_ENVASE");

                entity.Property(e => e.Vtrmvi_Expori)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_EXPORI");

                entity.Property(e => e.Vtrmvi_Extdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_EXTDEB");

                entity.Property(e => e.Vtrmvi_Exthab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_EXTHAB");

                entity.Property(e => e.Vtrmvi_Facalt)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("VTRMVI_FACALT");

                entity.Property(e => e.Vtrmvi_Faccon)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("VTRMVI_FACCON");

                entity.Property(e => e.Vtrmvi_Facfac)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("VTRMVI_FACFAC");

                entity.Property(e => e.Vtrmvi_Factor)
                    .HasColumnType("numeric(12, 6)")
                    .HasColumnName("VTRMVI_FACTOR");

                entity.Property(e => e.Vtrmvi_Iciext)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_ICIEXT");

                entity.Property(e => e.Vtrmvi_Icinac)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_ICINAC");

                entity.Property(e => e.Vtrmvi_Iciuss)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_ICIUSS");

                entity.Property(e => e.Vtrmvi_Impdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPDEB");

                entity.Property(e => e.Vtrmvi_Impext)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPEXT");

                entity.Property(e => e.Vtrmvi_Imphab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPHAB");

                entity.Property(e => e.Vtrmvi_Impnac)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPNAC");

                entity.Property(e => e.Vtrmvi_Impori)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPORI");

                entity.Property(e => e.Vtrmvi_Impsec)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPSEC");

                entity.Property(e => e.Vtrmvi_Impu01)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU01");

                entity.Property(e => e.Vtrmvi_Impu02)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU02");

                entity.Property(e => e.Vtrmvi_Impu03)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU03");

                entity.Property(e => e.Vtrmvi_Impu04)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU04");

                entity.Property(e => e.Vtrmvi_Impu05)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU05");

                entity.Property(e => e.Vtrmvi_Impu06)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_IMPU06");

                entity.Property(e => e.Vtrmvi_Impuss)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_IMPUSS");

                entity.Property(e => e.Vtrmvi_Intnoi)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_INTNOI");

                entity.Property(e => e.Vtrmvi_Itmcon).HasColumnName("VTRMVI_ITMCON");

                entity.Property(e => e.Vtrmvi_Itmori).HasColumnName("VTRMVI_ITMORI");

                entity.Property(e => e.Vtrmvi_Modapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_MODAPL")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvi_Modcpt)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_MODCPT");

                entity.Property(e => e.Vtrmvi_Modori)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_MODORI");

                
                entity.Property(e => e.Vtrmvi_Natrib)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NATRIB");

                entity.Property(e => e.Vtrmvi_Ndespa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NDESPA");

                entity.Property(e => e.Vtrmvi_Nestan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NESTAN");

                entity.Property(e => e.Vtrmvi_Newpre)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_NEWPRE");

                entity.Property(e => e.Vtrmvi_Nfecha)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NFECHA");

                entity.Property(e => e.Vtrmvi_Notros)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NOTROS");

                entity.Property(e => e.Vtrmvi_Nroapl).HasColumnName("VTRMVI_NROAPL");

                entity.Property(e => e.Vtrmvi_Nrocon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NROCON");

                entity.Property(e => e.Vtrmvi_Nroext).HasColumnName("VTRMVI_NROEXT");

                entity.Property(e => e.Vtrmvi_Nroori).HasColumnName("VTRMVI_NROORI");

                entity.Property(e => e.Vtrmvi_Nserie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NSERIE");

                entity.Property(e => e.Vtrmvi_Nubica)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_NUBICA");


                entity.Property(e => e.Vtrmvi_Oldpre)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_OLDPRE");

                entity.Property(e => e.Vtrmvi_Pciext)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PCIEXT");

                entity.Property(e => e.Vtrmvi_Pcinac)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PCINAC");

                entity.Property(e => e.Vtrmvi_Pciuss)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PCIUSS");

                entity.Property(e => e.Vtrmvi_Pctbf1)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF1");

                entity.Property(e => e.Vtrmvi_Pctbf2)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF2");

                entity.Property(e => e.Vtrmvi_Pctbf3)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF3");

                entity.Property(e => e.Vtrmvi_Pctbf4)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF4");

                entity.Property(e => e.Vtrmvi_Pctbf5)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF5");

                entity.Property(e => e.Vtrmvi_Pctbf6)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF6");

                entity.Property(e => e.Vtrmvi_Pctbf7)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF7");

                entity.Property(e => e.Vtrmvi_Pctbf8)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF8");

                entity.Property(e => e.Vtrmvi_Pctbf9)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBF9");

                entity.Property(e => e.Vtrmvi_Pctbfn)
                    .HasColumnType("numeric(15, 7)")
                    .HasColumnName("VTRMVI_PCTBFN");

                entity.Property(e => e.Vtrmvi_Preext)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PREEXT");

                entity.Property(e => e.Vtrmvi_Prenac)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PRENAC");

                entity.Property(e => e.Vtrmvi_Preuss)
                    .HasColumnType("numeric(20, 6)")
                    .HasColumnName("VTRMVI_PREUSS");

                entity.Property(e => e.Vtrmvi_Secdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_SECDEB");

                entity.Property(e => e.Vtrmvi_Sechab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_SECHAB");

                entity.Property(e => e.Vtrmvi_Sector)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_SECTOR");


                entity.Property(e => e.Vtrmvi_Tasa01)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA01");

                entity.Property(e => e.Vtrmvi_Tasa02)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA02");

                entity.Property(e => e.Vtrmvi_Tasa03)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA03");

                entity.Property(e => e.Vtrmvi_Tasa04)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA04");

                entity.Property(e => e.Vtrmvi_Tasa05)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA05");

                entity.Property(e => e.Vtrmvi_Tasa06)
                    .HasColumnType("numeric(15, 4)")
                    .HasColumnName("VTRMVI_TASA06");

                entity.Property(e => e.Vtrmvi_Tatrib)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TATRIB");

                entity.Property(e => e.Vtrmvi_Tdespa)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TDESPA");

                entity.Property(e => e.Vtrmvi_Tenvas)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TENVAS");

                entity.Property(e => e.Vtrmvi_Testan)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TESTAN");

                entity.Property(e => e.Vtrmvi_Textos)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TEXTOS");

                entity.Property(e => e.Vtrmvi_Tfecha)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TFECHA");

                entity.Property(e => e.Vtrmvi_Tipcpt)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvi_Tipdes)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_TIPDES")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvi_Tipopr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_TIPOPR");

                entity.Property(e => e.Vtrmvi_Tippro)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_TIPPRO")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvi_Tipuni)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_TIPUNI");

                entity.Property(e => e.Vtrmvi_Totros)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TOTROS");

                entity.Property(e => e.Vtrmvi_Tserie)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TSERIE");

                entity.Property(e => e.Vtrmvi_Tubica)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVI_TUBICA");

                entity.Property(e => e.Vtrmvi_Unialt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_UNIALT");

                entity.Property(e => e.Vtrmvi_Unicon)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_UNICON");

                entity.Property(e => e.Vtrmvi_Unifac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_UNIFAC");

                entity.Property(e => e.Vtrmvi_Unimed)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVI_UNIMED");

                
                entity.Property(e => e.Vtrmvi_Ussdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_USSDEB");

                entity.Property(e => e.Vtrmvi_Usshab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVI_USSHAB");
            });

            modelBuilder.Entity<Vtrmvp>(entity =>
            {
                entity.HasKey(e => new { e.Vtrmvp_Modfor, e.Vtrmvp_Codfor, e.Vtrmvp_Nrofor, e.Vtrmvp_Nroitm });

                entity.ToTable("VTRMVP");

                entity.HasIndex(e => new { e.Vtrmvp_Modfor, e.Vtrmvp_Codfor, e.Vtrmvp_Nrofor }, "W_RP_DGSUBDWIZ");

                entity.Property(e => e.Vtrmvp_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_MODFOR");

                entity.Property(e => e.Vtrmvp_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_CODFOR");

                entity.Property(e => e.Vtrmvp_Nrofor).HasColumnName("VTRMVP_NROFOR");

                entity.Property(e => e.Vtrmvp_Nroitm).HasColumnName("VTRMVP_NROITM");

               
                entity.Property(e => e.Vtrmvp_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_CODCPT");

                entity.Property(e => e.Vtrmvp_Cuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_CUENTA");

                
                entity.Property(e => e.Vtrmvp_Impbru)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVP_IMPBRU");

                entity.Property(e => e.Vtrmvp_Impgra)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVP_IMPGRA");

                entity.Property(e => e.Vtrmvp_Imptot)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVP_IMPTOT");

                entity.Property(e => e.Vtrmvp_Impues)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVP_IMPUES");
                
                entity.Property(e => e.Vtrmvp_Modcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_MODCPT");

                entity.Property(e => e.Vtrmvp_Porcen)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("VTRMVP_PORCEN");

                entity.Property(e => e.Vtrmvp_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvp_Tipimp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVP_TIPIMP");

                
            });

            modelBuilder.Entity<Cjrmvi>(entity =>
            {
                entity.HasKey(e => new { e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor, e.Cjrmvi_Debhab, e.Cjrmvi_Nroitm });

                entity.ToTable("CJRMVI");

                entity.HasOne(e => e.Recibo)
                      .WithMany(c => c.MediosDeCobro)
                      .HasForeignKey(c => new { c.Cjrmvi_Codfor, c.Cjrmvi_Nrofor});

                entity.HasIndex(e => new { e.Cjrmvi_Nrofor, e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Cuenta, e.Cjrmvi_Debhab, e.Cjrmvi_Import, e.Cjrmvi_Impsec }, "P_IG_PRFMNCE1");

                entity.HasIndex(e => new { e.Cjrmvi_Ctacte, e.Cjrmvi_Nroint }, "T_CJ_CJRMVH");

                entity.HasIndex(e => new { e.Cjrmvi_Ctacte, e.Cjrmvi_Nroint, e.Cjrmvi_Debhab }, "T_CJ_CJRMVH2");

                entity.HasIndex(e => new { e.Cjrmvi_Checom, e.Cjrmvi_Nroint }, "T_CJ_CJRMVH_CHE");

                entity.HasIndex(e => new { e.Cjrmvi_Ctacte, e.Cjrmvi_Cheque, e.Cjrmvi_Nroint, e.Cjrmvi_Fecalt }, "T_CJ_CJRMVI_CHE");

                entity.HasIndex(e => new { e.Cjrmvi_Checom, e.Cjrmvi_Nroint }, "T_CJ_RETCJRMVI");

                entity.HasIndex(e => new { e.Cjrmvi_Nrocvt, e.Cjrmvi_Fchvnc, e.Cjrmvi_Modfor }, "T_FC_FCRMVH");

                entity.HasIndex(e => new { e.Cjrmvi_Nrocvt, e.Cjrmvi_Ctacte, e.Cjrmvi_Fchvnc, e.Cjrmvi_Nroint, e.Cjrmvi_Impdeb, e.Cjrmvi_Imphab }, "T_GC_GCRMVI");

                entity.HasIndex(e => e.Cjrmvi_Ctacte, "T_PV_PVRRPPH");

                entity.HasIndex(e => new { e.Cjrmvi_Fchvnc, e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor, e.Cjrmvi_Ctacte }, "W_CF_CFPROWIZ");

                entity.HasIndex(e => new { e.Cjrmvi_Tipcpt, e.Cjrmvi_Codcpt, e.Cjrmvi_Nroint, e.Cjrmvi_Cuenta }, "W_CJRMVHWIZ");

                entity.HasIndex(e => new { e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor, e.Cjrmvi_Impdeb }, "W_EORMVHWIZ_1");

                entity.HasIndex(e => new { e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor, e.Cjrmvi_Imphab }, "W_EORMVHWIZ_2");

                entity.HasIndex(e => new { e.Cjrmvi_Cuenta, e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor }, "W_GR_IGRMVHWIZ");

                entity.HasIndex(e => new { e.Cjrmvi_Modfor, e.Cjrmvi_Codfor, e.Cjrmvi_Nrofor, e.Cjrmvi_Cuenta, e.Cjrmvi_Impdeb, e.Cjrmvi_Imphab }, "W_RP_DGBSUBDWIZ");

                entity.Property(e => e.Cjrmvi_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MODFOR");

                entity.Property(e => e.Cjrmvi_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODFOR")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Nrofor).HasColumnName("CJRMVI_NROFOR");

                entity.Property(e => e.Cjrmvi_Debhab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_DEBHAB");

                entity.Property(e => e.Cjrmvi_Nroitm).HasColumnName("CJRMVI_NROITM");

                entity.Property(e => e.Cjrmvi_Autpos)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_AUTPOS");

                entity.Property(e => e.Cjrmvi_Cambio)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("CJRMVI_CAMBIO");

                entity.Property(e => e.Cjrmvi_Camori)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("CJRMVI_CAMORI");

                entity.Property(e => e.Cjrmvi_Cantid)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("CJRMVI_CANTID");

                entity.Property(e => e.Cjrmvi_Catego)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CATEGO")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Checom)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CHECOM");

                entity.Property(e => e.Cjrmvi_Cheque).HasColumnName("CJRMVI_CHEQUE");

                entity.Property(e => e.Cjrmvi_Chesuc).HasColumnName("CJRMVI_CHESUC");

                entity.Property(e => e.Cjrmvi_Clring).HasColumnName("CJRMVI_CLRING");

                entity.Property(e => e.Cjrmvi_Cmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CMPVER");

                entity.Property(e => e.Cjrmvi_Codbc2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODBC2");

                entity.Property(e => e.Cjrmvi_Codbco)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODBCO");

                entity.Property(e => e.Cjrmvi_Codcla)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODCLA");

                entity.Property(e => e.Cjrmvi_Codcpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODCPT");

                entity.Property(e => e.Cjrmvi_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODEMP");

                entity.Property(e => e.Cjrmvi_Codori)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODORI");

                entity.Property(e => e.Cjrmvi_Codrex)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODREX")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Codsuc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODSUC");

                entity.Property(e => e.Cjrmvi_Codtar)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODTAR");

                entity.Property(e => e.Cjrmvi_Codtra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CODTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Comori)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_COMORI");

                entity.Property(e => e.Cjrmvi_Concil)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CONCIL")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Ctaban)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CTABAN");

                entity.Property(e => e.Cjrmvi_Ctacte)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CTACTE");

                entity.Property(e => e.Cjrmvi_Ctaori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CTAORI");

                entity.Property(e => e.Cjrmvi_Cuenta)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_CUENTA");

                entity.Property(e => e.Cjrmvi_Cuotas).HasColumnName("CJRMVI_CUOTAS");

                entity.Property(e => e.Cjrmvi_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Docfir)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_DOCFIR");

                entity.Property(e => e.Cjrmvi_Emiche)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_EMICHE");

                entity.Property(e => e.Cjrmvi_Empleg)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_EMPLEG");

                entity.Property(e => e.Cjrmvi_Empori)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_EMPORI");

                entity.Property(e => e.Cjrmvi_Emprex)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_EMPREX");

                entity.Property(e => e.Cjrmvi_Emptra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_EMPTRA");

                entity.Property(e => e.Cjrmvi_Fchaux)
                    .HasColumnType("datetime")
                    .HasColumnName("CJRMVI_FCHAUX");

                entity.Property(e => e.Cjrmvi_Fchvnc)
                    .HasColumnType("datetime")
                    .HasColumnName("CJRMVI_FCHVNC");

                entity.Property(e => e.Cjrmvi_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("CJRMVI_FECALT");

                entity.Property(e => e.Cjrmvi_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("CJRMVI_FECMOD");

                entity.Property(e => e.Cjrmvi_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_HORMOV");

                entity.Property(e => e.Cjrmvi_Impdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPDEB");

                entity.Property(e => e.Cjrmvi_Imphab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPHAB");

                entity.Property(e => e.Cjrmvi_Imping)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPING");

                entity.Property(e => e.Cjrmvi_Import)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPORT");

                entity.Property(e => e.Cjrmvi_Impsec)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPSEC");

                entity.Property(e => e.Cjrmvi_Impuss)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_IMPUSS");

                entity.Property(e => e.Cjrmvi_Indica)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_INDICA");

                entity.Property(e => e.Cjrmvi_Intori).HasColumnName("CJRMVI_INTORI");

                entity.Property(e => e.Cjrmvi_Lotecb).HasColumnName("CJRMVI_LOTECB");

                entity.Property(e => e.Cjrmvi_Lotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_LOTORI");

                entity.Property(e => e.Cjrmvi_Lotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_LOTREC");

                entity.Property(e => e.Cjrmvi_Lottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_LOTTRA");

                entity.Property(e => e.Cjrmvi_Minifc)
                    .HasColumnType("datetime")
                    .HasColumnName("CJRMVI_MINIFC");

                entity.Property(e => e.Cjrmvi_Minist)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MINIST")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Minius)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MINIUS");

                entity.Property(e => e.Cjrmvi_Modcpt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MODCPT");

                entity.Property(e => e.Cjrmvi_Modrex)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MODREX");

                entity.Property(e => e.Cjrmvi_Modtra)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MODTRA");

                entity.Property(e => e.Cjrmvi_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MODULE");

                entity.Property(e => e.Cjrmvi_Monext)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MONEXT");

                entity.Property(e => e.Cjrmvi_Monori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_MONORI");

                entity.Property(e => e.Cjrmvi_Nombpv)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NOMBPV");

                entity.Property(e => e.Cjrmvi_Nombvt)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NOMBVT");

                entity.Property(e => e.Cjrmvi_Nrocpv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NROCPV");

                entity.Property(e => e.Cjrmvi_Nrocvt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NROCVT");

                entity.Property(e => e.Cjrmvi_Nrodoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NRODOC");

                entity.Property(e => e.Cjrmvi_Nroint).HasColumnName("CJRMVI_NROINT");

                entity.Property(e => e.Cjrmvi_Nroleg)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NROLEG");

                entity.Property(e => e.Cjrmvi_Nrolot).HasColumnName("CJRMVI_NROLOT");

                entity.Property(e => e.Cjrmvi_Nrorex).HasColumnName("CJRMVI_NROREX");

                entity.Property(e => e.Cjrmvi_Nrospv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NROSPV");

                entity.Property(e => e.Cjrmvi_Nrosvt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_NROSVT");

                entity.Property(e => e.Cjrmvi_Nrotra).HasColumnName("CJRMVI_NROTRA");

                entity.Property(e => e.Cjrmvi_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_OALIAS");

                entity.Property(e => e.Cjrmvi_Online)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_ONLINE")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Pagado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_PAGADO")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Pritar).HasColumnName("CJRMVI_PRITAR");

                entity.Property(e => e.Cjrmvi_Secdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_SECDEB");

                entity.Property(e => e.Cjrmvi_Sechab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_SECHAB");

                entity.Property(e => e.Cjrmvi_Sysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_SYSVER");

                entity.Property(e => e.Cjrmvi_Termid)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_TERMID");

                entity.Property(e => e.Cjrmvi_Textos)
                    .HasColumnType("text")
                    .HasColumnName("CJRMVI_TEXTOS");

                entity.Property(e => e.Cjrmvi_Tipcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_TIPCPT")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Tipdoc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_TIPDOC");

                entity.Property(e => e.Cjrmvi_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Cjrmvi_Ulttar).HasColumnName("CJRMVI_ULTTAR");

                entity.Property(e => e.Cjrmvi_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CJRMVI_USERID");

                entity.Property(e => e.Cjrmvi_Ussdeb)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_USSDEB");

                entity.Property(e => e.Cjrmvi_Usshab)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_USSHAB");

                entity.Property(e => e.Cjrmvi_Vuelto)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CJRMVI_VUELTO");

                entity.Property(e => e.Usr_Cjrmvi_Codaut)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_CODAUT");

                entity.Property(e => e.Usr_Cjrmvi_Codest)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_CODEST");

                entity.Property(e => e.Usr_Cjrmvi_Ctacte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_CTACTE");

                entity.Property(e => e.Usr_Cjrmvi_Cuotas).HasColumnName("USR_CJRMVI_CUOTAS");

                entity.Property(e => e.Usr_Cjrmvi_Feccbu)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CJRMVI_FECCBU");

                entity.Property(e => e.Usr_Cjrmvi_Fecope)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CJRMVI_FECOPE");

                entity.Property(e => e.Usr_Cjrmvi_Fecrec)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_CJRMVI_FECREC");

                entity.Property(e => e.Usr_Cjrmvi_Idcomp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_IDCOMP");

                entity.Property(e => e.Usr_Cjrmvi_Idpago)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_IDPAGO");

                entity.Property(e => e.Usr_Cjrmvi_Liquid).HasColumnName("USR_CJRMVI_LIQUID");

                entity.Property(e => e.Usr_Cjrmvi_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_NROCTA");

                entity.Property(e => e.Usr_Cjrmvi_Nroint).HasColumnName("USR_CJRMVI_NROINT");

                entity.Property(e => e.Usr_Cjrmvi_Nroori).HasColumnName("USR_CJRMVI_NROORI");

                entity.Property(e => e.Usr_Cjrmvi_Nrorec).HasColumnName("USR_CJRMVI_NROREC");

                entity.Property(e => e.Usr_Cjrmvi_Nrotar)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_NROTAR");

                entity.Property(e => e.Usr_Cjrmvi_Numcup).HasColumnName("USR_CJRMVI_NUMCUP");

                entity.Property(e => e.Usr_Cjrmvi_Numlot).HasColumnName("USR_CJRMVI_NUMLOT");

                entity.Property(e => e.Usr_Cjrmvi_Titula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_CJRMVI_TITULA");
            });

            modelBuilder.Entity<Vtrmvc>(entity =>
            {
                entity.HasKey(e => new { e.Vtrmvc_Modfor, e.Vtrmvc_Codfor, e.Vtrmvc_Nrofor, e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Cuotas, e.Vtrmvc_Clamov });

                entity.ToTable("VTRMVC");

                entity.HasOne(e => e.Recibo)
                      .WithMany(c => c.Aplicaciones)
                      .HasForeignKey(c => new {c.Vtrmvc_Codfor, c.Vtrmvc_Nrofor});


                entity.HasIndex(e => new { e.Vtrmvc_Nrofor, e.Vtrmvc_Modfor, e.Vtrmvc_Codfor, e.Vtrmvc_Codemp, e.Vtrmvc_Nroapl, e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Empapl, e.Vtrmvc_Cuotas, e.Vtrmvc_Clamov }, "P_VT_MovPendCAE");

                entity.HasIndex(e => new { e.Vtrmvc_Modfcr, e.Vtrmvc_Codfcr, e.Vtrmvc_Nrofcr }, "R_GR_FCRMVH");

                entity.HasIndex(e => new { e.Vtrmvc_Nrocta, e.Vtrmvc_Fchvnc, e.Vtrmvc_Impnac, e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Cuotas }, "R_VT_GCRREP");

                entity.HasIndex(e => new { e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Cuotas }, "R_VT_USRREP");

                entity.HasIndex(e => new { e.Vtrmvc_Nrocta, e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Cuotas }, "T_VT_VTRRCHWIZ");

                entity.HasIndex(e => new { e.Vtrmvc_Modfor, e.Vtrmvc_Codfor, e.Vtrmvc_Nrofor, e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Clamov, e.Vtrmvc_Impnac }, "W_EORMVHWIZ");

                entity.HasIndex(e => new { e.Vtrmvc_Nrocta, e.Vtrmvc_Imptcn, e.Vtrmvc_Coflis, e.Vtrmvc_Impnac }, "W_GR_FCRMVH");

                entity.HasIndex(e => new { e.Vtrmvc_Modapl, e.Vtrmvc_Codapl, e.Vtrmvc_Nroapl, e.Vtrmvc_Cuotas, e.Vtrmvc_Coflis, e.Vtrmvc_Nrocta, e.Vtrmvc_Nrosub, e.Vtrmvc_Imptcn, e.Vtrmvc_Fchvnc }, "W_VT_VTDBCR");

                entity.Property(e => e.Vtrmvc_Modfor)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_MODFOR");

                entity.Property(e => e.Vtrmvc_Codfor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CODFOR");

                entity.Property(e => e.Vtrmvc_Nrofor).HasColumnName("VTRMVC_NROFOR");

                entity.Property(e => e.Vtrmvc_Modapl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_MODAPL");

                entity.Property(e => e.Vtrmvc_Codapl)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CODAPL");

                entity.Property(e => e.Vtrmvc_Nroapl).HasColumnName("VTRMVC_NROAPL");

                entity.Property(e => e.Vtrmvc_Cuotas).HasColumnName("VTRMVC_CUOTAS");

                entity.Property(e => e.Vtrmvc_Clamov)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CLAMOV");

                entity.Property(e => e.Vtrmvc_Cambio)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("VTRMVC_CAMBIO");

                entity.Property(e => e.Vtrmvc_Camuss)
                    .HasColumnType("numeric(20, 8)")
                    .HasColumnName("VTRMVC_CAMUSS");

                entity.Property(e => e.Vtrmvc_Cmpver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CMPVER");

                entity.Property(e => e.Vtrmvc_Codbar)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CODBAR");

                entity.Property(e => e.Vtrmvc_Codemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CODEMP");

                entity.Property(e => e.Vtrmvc_Codfcr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_CODFCR");

                entity.Property(e => e.Vtrmvc_Cofdeu)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_COFDEU");

                entity.Property(e => e.Vtrmvc_Coffac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_COFFAC");

                entity.Property(e => e.Vtrmvc_Coflis)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_COFLIS");

                entity.Property(e => e.Vtrmvc_Debaja)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_DEBAJA")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvc_Empapl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_EMPAPL");

                entity.Property(e => e.Vtrmvc_Empfcr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_EMPFCR");

                entity.Property(e => e.Vtrmvc_Fchint)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVC_FCHINT");

                entity.Property(e => e.Vtrmvc_Fchmov)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVC_FCHMOV");

                entity.Property(e => e.Vtrmvc_Fchvnc)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVC_FCHVNC");

                entity.Property(e => e.Vtrmvc_Fecalt)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVC_FECALT");

                entity.Property(e => e.Vtrmvc_Fecmod)
                    .HasColumnType("datetime")
                    .HasColumnName("VTRMVC_FECMOD");

                entity.Property(e => e.Vtrmvc_Hormov)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_HORMOV");

                entity.Property(e => e.Vtrmvc_Impext)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVC_IMPEXT");

                entity.Property(e => e.Vtrmvc_Impnac)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVC_IMPNAC");

                entity.Property(e => e.Vtrmvc_Impsec)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVC_IMPSEC");

                entity.Property(e => e.Vtrmvc_Imptcn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_IMPTCN");

                entity.Property(e => e.Vtrmvc_Impuss)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VTRMVC_IMPUSS");

                entity.Property(e => e.Vtrmvc_Lotori)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_LOTORI");

                entity.Property(e => e.Vtrmvc_Lotrec)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_LOTREC");

                entity.Property(e => e.Vtrmvc_Lottra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_LOTTRA");

                entity.Property(e => e.Vtrmvc_Modfcr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_MODFCR");

                entity.Property(e => e.Vtrmvc_Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_MODULE");

                entity.Property(e => e.Vtrmvc_Nrocta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_NROCTA");

                entity.Property(e => e.Vtrmvc_Nrofcr).HasColumnName("VTRMVC_NROFCR");

                entity.Property(e => e.Vtrmvc_Nrosub)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_NROSUB");

                entity.Property(e => e.Vtrmvc_Oalias)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_OALIAS");

                entity.Property(e => e.Vtrmvc_Obsimp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_OBSIMP");

                entity.Property(e => e.Vtrmvc_Sysver)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_SYSVER");

                entity.Property(e => e.Vtrmvc_Textos)
                    .HasColumnType("text")
                    .HasColumnName("VTRMVC_TEXTOS");

                entity.Property(e => e.Vtrmvc_Ultopr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_ULTOPR")
                    .IsFixedLength(true);

                entity.Property(e => e.Vtrmvc_Userid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VTRMVC_USERID");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
