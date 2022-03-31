using System;

namespace PruebaTecnicaActive.Models
{
    public class DetalleAlquiler
    {
        public Int64 CodigoDetalleAlquiler { get; set; }
        public Alquiler Alquiler{ get; set; }
        public Int32 Item { get; set; }
        public Int64 CodigoTitulo { get; set; }
        public Cd Cd { get; set; }
        public Int32 DiasPrestamos { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}