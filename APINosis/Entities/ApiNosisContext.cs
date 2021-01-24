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

        public virtual DbSet<Vtmclh> Vtmclhs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Vtmclh>(entity =>
            {
                entity.HasKey(e => e.VtmclhNrocta);

                entity.ToTable("VTMCLH");

                entity.HasIndex(e => new { e.VtmclhNrocta, e.VtmclhNombre }, "VTMCLH_SuperFind");

                entity.HasIndex(e => e.VtmclhCobrad, "W_CV_CVRMVHWIZ");

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

                entity.Property(e => e.VtmclhTstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("VTMCLH_TSTAMP");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
