using APINosis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APINosis.Entities
{
    public partial class Fcrmvh
    {
        public string Fcrmvh_Modfor { get; set; }
        public string Fcrmvh_Codfor { get; set; }
        public int Fcrmvh_Nrofor { get; set; }
        public DateTime Fcrmvh_Fchmov { get; set; }
        public string Fcrmvh_Nrocta { get; set; }
        public string Fcrmvh_Nrosub { get; set; }
        public string Fcrmvh_Dirent { get; set; }
        public string Fcrmvh_Paient { get; set; }
        public string Fcrmvh_Codent { get; set; }
        public string Fcrmvh_Vnddor { get; set; }
        public string Fcrmvh_Cndpag { get; set; }
        public string Fcrmvh_Codlis { get; set; }
        public string Fcrmvh_Grubon { get; set; }
        public string Fcrmvh_Textos { get; set; }
        public string Fcrmvh_Coflis { get; set; }
        public string Fcrmvh_Coffac { get; set; }
        public string Fcrmvh_Cofdeu { get; set; }
        public string Fcrmvh_Direcc { get; set; }
        public string Fcrmvh_Codpai { get; set; }
        public string Fcrmvh_Codpos { get; set; }
        public string Fcrmvh_Jurisd { get; set; }
        public string Fcrmvh_Contac { get; set; }
        public string Fcrmvh_Telefn { get; set; }
        public string Fcrmvh_Codzon { get; set; }
        public string Fcrmvh_Comori { get; set; }
        public string Fcrmvh_Codori { get; set; }
        public string Fcrmvh_Tipexp { get; set; }
        public string Usr_Fcrmvh_Mpago { get; set; }
        public string Usr_Fcrmvh_Local2 { get; set; }
        public string Usr_Fcrmvh_Subpo2 { get; set; }
        public DateTime Usr_Fcrmvh_Fchfac { get; set; }
        public int? Usr_Fcrmvh_Idcrm { get; set; }
        public string  Usr_Fcrmvh_Idpago{ get; set; }
        public string Usr_Fcrmvh_Idcomp { get; set; }

        [NotMapped]
        public string Sar_Virt_Tipdop { get; set; }
        [NotMapped]
        public string Sar_Virt_Valdop { get; set; }

        [NotMapped]
        public string Virt_Circom { get; set; }
        [NotMapped]
        public string Virt_Cirapl { get; set; }
        [NotMapped]
        public string Virt_Codcvt{ get; set; }
        public ICollection<Fcrmvi> Items { get; set; }

        [NotMapped]
        public ICollection<Fcrmvi07> Impuestos { get; set; }

    }
}
