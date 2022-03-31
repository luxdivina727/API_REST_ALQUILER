using System;

namespace PruebaTecnicaActiveOne.Models
{
    public class Sancion
    {
        public Int64 NroSancion { get; set; }
        public string TipoSancion { get; set; }
        public int NroDiasSancion { get; set; }
        public Cliente Cliente { get; set; }
        public Alquiler Alquiler{ get; set; }

    }

}