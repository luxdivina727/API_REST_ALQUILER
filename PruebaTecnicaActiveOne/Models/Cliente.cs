using System;

namespace PruebaTecnicaActive.Models
{
    public class Cliente
    {
        public Int64 CodigoCliente { get; set; }
        public Int32 Telefono { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public Int32 Cedula { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string TemaInteres{ get; set; }
        public string Estado { get; set; }
    }
}