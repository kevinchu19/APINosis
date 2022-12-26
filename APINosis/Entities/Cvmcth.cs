using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APINosis.Entities
{
    public partial class Cvmcth
    {
        public string Cvmcth_Codcon { get; set; }
        public string Cvmcth_Nrocon { get; set; }
        public short Cvmcth_Nroext { get; set; }
        public string Cvmcth_Descrp { get; set; }
        public string Cvmcth_Nrocta { get; set; }
        public string Cvmcth_Nrosub { get; set; }
        public string Cvmcth_Cndpag { get; set; }
        public string Cvmcth_Vnddor { get; set; }
        public string Cvmcth_Codctr { get; set; }
        public string Cvmcth_Modcvt { get; set; }
        public string Cvmcth_Codcvt { get; set; }
        public string Cvmcth_Modcst { get; set; }
        public string Cvmcth_Codcst { get; set; }
        public string Cvmcth_Deposi { get; set; }
        public string Cvmcth_Sector { get; set; }
        public DateTime Cvmcth_Fchmov { get; set; } = DateTime.Now;
        public string Cvmcth_Actcof { get; set; }
        public DateTime Cvmcth_Facdes { get; set; }
        public DateTime Cvmcth_Prifac { get; set; }
        public DateTime Cvmcth_Ultfac { get; set; }
        public short Cvmcth_Freact { get; set; }
        public short Cvmcth_Frefac { get; set; }
        public string Cvmcth_Codlis { get; set; }
        public string Cvmcth_Grubon { get; set; }
        public DateTime? Cvmcth_Feclis { get; set; }
        public string Cvmcth_Coflis { get; set; }
        public string Cvmcth_Coffac { get; set; }
        public string Cvmcth_Cofdev { get; set; }
        public string Cvmcth_Actlis { get; set; }
        public string Cvmcth_Textos { get; set; }
        public string Cvmcth_Dimobl { get; set; }
        public string Cvmcth_Subcue { get; set; }
        public string Cvmcth_Dimori { get; set; }
        public string Cvmcth_Subori { get; set; }
        public string Cvmcth_Coef01 { get; set; }
        public string Cvmcth_Coef02 { get; set; }
        public string Cvmcth_Coef03 { get; set; }
        public string Cvmcth_Coef04 { get; set; }
        public string Cvmcth_Coef05 { get; set; }
        public decimal? Cvmcth_Pctc01 { get; set; }
        public decimal? Cvmcth_Pctc02 { get; set; }
        public decimal? Cvmcth_Pctc03 { get; set; }
        public decimal? Cvmcth_Pctc04 { get; set; }
        public decimal? Cvmcth_Pctc05 { get; set; }
        public string Cvmcth_Unific { get; set; }
        public decimal? Cvmcth_Coefic { get; set; }
        public string Cvmcth_Rubr01 { get; set; }
        public string Cvmcth_Rubr02 { get; set; }
        public string Cvmcth_Rubr03 { get; set; }
        public string Cvmcth_Rubr04 { get; set; }
        public string Cvmcth_Rubr05 { get; set; }
        public string Cvmcth_Rubr06 { get; set; }
        public string Cvmcth_Rubr07 { get; set; }
        public string Cvmcth_Rubr08 { get; set; }
        public string Cvmcth_Rubr09 { get; set; }
        public string Cvmcth_Rubr10 { get; set; }
        public string Cvmcth_Vtcero { get; set; }
        public string Cvmcth_Oleole { get; set; }
        public string Cvmcth_Estcon { get; set; }
        public string Cvmcth_Estact { get; set; }
        public string Cvmcth_Obshis { get; set; }
        public string Cvmcth_Percan { get; set; }
        public string Cvmcth_Recnov { get; set; }
        public string Cvmcth_Cerdec { get; set; }
        public string Cvmcth_Tipopr { get; set; }
        public string Cvmcth_Codopr { get; set; }
        public string Cvmcth_Codemp { get; set; }
        public string Cvmcth_Tipexp { get; set; }
        public string Cvmcth_Cndcom { get; set; }
        public string Usr_Cvmcth_Mpago { get; set; }
        public DateTime? Cvmcth_Fecalt { get; set; }
        public DateTime? Cvmcth_Fecmod { get; set; }
        public string Cvmcth_Userid { get; set; }
        public string Cvmcth_Ultopr { get; set; }
        public string Cvmcth_Debaja { get; set; }
        public string Cvmcth_Oalias { get; set; }

        public string Usr_Cvmcth_Idcomp { get; set; }
        public ICollection<Cvmcti> Items { get; set; }

        [NotMapped]
        public virtual string Cvmcth_Desfre { get; set; }
    }
}
