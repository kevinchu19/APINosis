using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Models
{
    public class VtmclhDTO
    {
        public string VTMCLH_NROCTA { get; set; }
        public string VTMCLH_NOMBRE { get; set; }
        public string VTMCLH_NROSUB { get; set; }
        public string VTMCLH_DIRECC { get; set; }
        public string VTMCLH_CODPAI { get; set; }
        public string VTMCLH_CODPOS { get; set; }
        public string VTMCLH_CNDIVA { get; set; }
        public string VTMCLH_TIPDOC { get; set; }
        public string VTMCLH_NRODOC { get; set; }
        public string VTMCLH_VNDDOR { get; set; }
        public string VTMCLH_COBRAD { get; set; }
        public string VTMCLH_JURISD { get; set; }
        public string VTMCLH_CODZON{ get; set; }
        public string VTMCLH_ACTIVD { get; set; }
        public string VTMCLH_CATEGO { get; set; }
        public string VTMCLH_CNDPAG { get; set; }
        public string VTMCLH_CNDPRE { get; set; }        
        public string VTMCLH_DIRENT { get; set; }
        public string VTMCLH_PAIENT { get; set; }
        public string VTMCLH_CODENT { get; set; }
        public string VTMCLH_JURENT { get; set; }
        public string VTMCLH_ZONENT { get; set; }
        public string VTMCLH_TIPDO1 { get; set; }
        public string VTMCLH_NRODO1 { get; set; }
        public string VTMCLH_TIPDO2 { get; set; }
        public string VTMCLH_NRODO2 { get; set; }
        public string VTMCLH_TIPDO3 { get; set; }
        public string VTMCLH_NRODO3 { get; set; }        
        public string VTMCLH_FISJUR { get; set; }
        public string VTMCLH_APELL1 { get; set; }
        public string VTMCLH_APELL2 { get; set; }
        public string VTMCLH_NOMB01 { get; set; }
        public string VTMCLH_NOMB02 { get; set; }
        public string USR_VTMCLH_CODACT { get; set; }
        public string USR_VTMCLH_MPAGO { get; set; }
        public string USR_VTMCLH_MAILFC { get; set; }
        public string USR_VTMCLH_MAILRC { get; set; }
        public string USR_VTMCLH_ENMAIL { get; set; }
        public DateTime USR_VTMCLH_FECANT { get; set; }
        public string USR_VTMCLH_LOCAL1 { get; set; }
        public string USR_VTMCLH_LOCAL2 { get; set; }
        public string VTMCLH_LANEXP { get; set; }
        public List<VtmclcDTO> Contactos { get; set; }
        public List<VtmcliDTO> Impuestos { get; set; }
    }
}
