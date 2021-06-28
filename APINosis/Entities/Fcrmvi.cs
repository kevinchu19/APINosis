using System;
using System.Collections.Generic;

#nullable disable

namespace APINosis.Entities
{
    public partial class Fcrmvi
    {
        public string Fcrmvi_Modfor { get; set; }
        public string Fcrmvi_Codfor { get; set; }
        public int Fcrmvi_Nrofor { get; set; }
        public int Fcrmvi_Nroitm { get; set; }
        public string Fcrmvi_Nivexp { get; set; }
        public string Fcrmvi_Modapl { get; set; }
        public string Fcrmvi_Codapl { get; set; }
        public int Fcrmvi_Nroapl { get; set; }
        public int Fcrmvi_Itmapl { get; set; }
        public string Fcrmvi_Expapl { get; set; }
        public string Fcrmvi_Tipori { get; set; }
        public string Fcrmvi_Artori { get; set; }
        public string Fcrmvi_Tipcpt { get; set; }
        public string Fcrmvi_Codcpt { get; set; }
        public decimal? Fcrmvi_Cantid { get; set; }
        public decimal? Fcrmvi_Precio { get; set; }
        public decimal? Fcrmvi_Cntbon { get; set; }
        public decimal? Fcrmvi_Pctbf1 { get; set; }
        public decimal? Fcrmvi_Pctbf2 { get; set; }
        public decimal? Fcrmvi_Pctbf3 { get; set; }
        public decimal? Fcrmvi_Pctbf4 { get; set; }
        public decimal? Fcrmvi_Pctbf5 { get; set; }
        public decimal? Fcrmvi_Pctbf6 { get; set; }
        public decimal? Fcrmvi_Pctbf7 { get; set; }
        public decimal? Fcrmvi_Pctbf8 { get; set; }
        public decimal? Fcrmvi_Pctbf9 { get; set; }
        public string Fcrmvi_Textos { get; set; }
        public string Usr_Fcrmvi_Modotr { get; set; }
        public string Usr_Fcrmvi_Codotr { get; set; }
        public int Usr_Fcrmvi_Nrootr { get; set; }
        public DateTime Usr_Fcrmvi_Fchotr { get; set; }
        public string  Usr_Fcrmvi_Nrooc { get; set; }
        public int Usr_Fcrmvi_Nroitm { get; set; }
        public string Usr_Fcrmvi_Idcust { get; set; }
        public string Usr_Fcrmvi_Vnddor { get; set; }
        public string Usr_Fcrmvi_Vnddo2 { get; set; }

        public Fcrmvh factura { get; set; }


    }
}
