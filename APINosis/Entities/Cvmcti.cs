using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APINosis.Entities
{
    public partial class Cvmcti
    {
        public string Cvmcti_Codcon { get; set; }
        public string Cvmcti_Nrocon { get; set; }
        public short Cvmcti_Nroext { get; set; }
        public int Cvmcti_Nroitm { get; set; }
        public string Cvmcti_Tippro { get; set; }
        public string Cvmcti_Artcod { get; set; }
        public string Cvmcti_Stocks { get; set; }
        public string Cvmcti_Modcpt { get; set; }
        public string Cvmcti_Tipcpt { get; set; }
        public string Cvmcti_Codcpt { get; set; }
        public string Cvmcti_Cuenta { get; set; }
        public string Cvmcti_Texadi { get; set; }
        public decimal? Cvmcti_Precio { get; set; }
        public decimal? Cvmcti_Preaju { get; set; }
        public decimal? Cvmcti_Auxaju { get; set; }
        public decimal? Cvmcti_Cantid { get; set; }
        public string Cvmcti_Unimed { get; set; }
        public string Cvmcti_Debhab { get; set; }
        public string Cvmcti_Travig { get; set; }
        public DateTime? Cvmcti_Vigdde { get; set; }
        public DateTime? Cvmcti_Vighta { get; set; }
        public string Cvmcti_Unisec { get; set; }
        public decimal? Cvmcti_Facsec { get; set; }
        public decimal? Cvmcti_Cntsec { get; set; }
        public string Cvmcti_Recnov { get; set; }
        public string Cvmcti_Tipopr { get; set; }
        public string Cvmcti_Codopr { get; set; }
        public string Cvmcti_Actlis { get; set; }
        public string Cvmcti_Codemp { get; set; }
        public string Cvmcti_Codniv { get; set; }
        public string Cvmcti_Codano { get; set; }
        public short? Cvmcti_Norden { get; set; }
        public string Usr_Cvmcti_Vnddor { get; set; }
        public string Usr_Cvmcti_Vnddo2 { get; set; }
        public string Usr_Cvmcti_Modotr { get; set; }
        public string Usr_Cvmcti_Codotr { get; set; }
        public int? Usr_Cvmcti_Nrootr { get; set; }
        public DateTime? Usr_Cvmcti_Fchmov { get; set; }
        public string Usr_Cvmcti_Modmod { get; set; }
        public string Usr_Cvmcti_Codmod { get; set; }
        public int? Usr_Cvmcti_Nromod { get; set; }
        public DateTime? Usr_Cvmcti_Fchmod { get; set; }
        public DateTime? Usr_Cvmcti_Fchcom { get; set; }
        public string Usr_Cvmcti_Nrooc { get; set; }
        public int? Usr_Cvmcti_Nroitm { get; set; }
        public string Usr_Cvmcti_Archiv { get; set; }
        public string Usr_Cvmcti_Idcust { get; set; }
        public int? Usr_Cvmcti_Nroreg { get; set; }
        public DateTime? Usr_Cvmcti_Fchimp { get; set; }
        public DateTime? Cvmcti_Fecalt { get; set; }
        public DateTime? Cvmcti_Fecmod { get; set; }
        public string Cvmcti_Userid { get; set; }
        public string Cvmcti_Ultopr { get; set; }
        public string Cvmcti_Debaja { get; set; }
        public string Cvmcti_Oalias { get; set; }
        [NotMapped]
        public virtual Cvmcth Contrato { get; set; }
    }
}
