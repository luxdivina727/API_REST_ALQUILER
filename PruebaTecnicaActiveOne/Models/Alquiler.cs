using System;

namespace PruebaTecnicaActiveOne.Models
{
    public class Alquiler
    {
        public Int64 NroAlquiler { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int ValorAlquiler { get; set; }
        public Cliente Cliente { get; set; }
    }
}