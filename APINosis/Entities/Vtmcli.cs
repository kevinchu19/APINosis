using System;
using System.Collections.Generic;

#nullable disable

namespace APINosis.Entities
{
    public partial class Vtmcli
    {
        public string VtmcliNrocta { get; set; }
        public string VtmcliTipimp { get; set; }
        public string VtmcliImpisc { get; set; }
        public string VtmcliCndisc { get; set; }
        public string VtmcliCorres { get; set; }
        public string VtmcliInclui { get; set; }
        public decimal? VtmcliExeden { get; set; }
        public string VtmcliResolc { get; set; }
        public string VtmcliVigenc { get; set; }
        public DateTime? VtmcliFchdes { get; set; }
        public DateTime? VtmcliFechas { get; set; }
        public string VtmcliDisimp { get; set; }
        public DateTime? VtmcliFecalt { get; set; }
        public DateTime? VtmcliFecmod { get; set; }
        public string VtmcliUserid { get; set; }
        public string VtmcliUltopr { get; set; }
        public string VtmcliDebaja { get; set; }
        public string VtmcliHormov { get; set; }
        public string VtmcliModule { get; set; }
        public string VtmcliOalias { get; set; }
        public byte[] VtmcliTstamp { get; set; }
        public string VtmcliLottra { get; set; }
        public string VtmcliLotrec { get; set; }
        public string VtmcliLotori { get; set; }
        public string VtmcliSysver { get; set; }
        public string VtmcliCmpver { get; set; }
        
        public Vtmclh cliente { get; set; }
    }
}
