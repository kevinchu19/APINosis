using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class Vtrrch
    {
        public string Usr_Vtrmvh_Idcrm { get; set; }
        public string Vtrmvh_Codcom { get; set; }
        public string Vtrmvh_Nrocta { get; set; }
        public DateTime? Vtrmvh_Fchmov { get; set; }
        public string Vtrmvh_Cobrad { get; set; }
        public string Vtrmvh_Textos { get; set; }
        public string Vtrmvh_Nrosub { get; set; }
        public DateTime? Vtrmvh_Fchpar { get; set; }
        public string Vtrmvh_Utpaor { get; set; }
        public DateTime? Usr_Vtrmvh_Fchcbu { get; set; }
        public List<Vtrrcc01> Aplicaciones { get; set; }
        public List<Vtrrcc04> MediosDeCobro { get; set; }

    }
}
