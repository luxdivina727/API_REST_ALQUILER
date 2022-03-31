using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;
using System;
using System.Linq;
namespace PruebaTecnicaActiveOne.Controllers
{
    public class CobrarAlquilerController : ApiController
    {

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<controller>
        public bool Post()
        {
            List<Alquiler> alquilers = AlquilerData.Listar();
            List<Cliente> clientes = ClienteData.Listar();
            Sancion sancion = new Sancion();
            foreach (var alquiler in alquilers)
            {
                List<DetalleAlquiler> detalleAlquilers = DetalleAlquilerData.Listar().FindAll(x => x.Alquiler.NroAlquiler.Equals(alquiler.NroAlquiler) && x.FechaDevolucion > DateTime.Now);
                if (detalleAlquilers.Any())
                {
                    alquiler.ValorAlquiler = alquiler.ValorAlquiler + 500;
                    sancion.Alquiler = new Alquiler() { NroAlquiler = alquiler.NroAlquiler };
                    sancion.Cliente = new Cliente() { CodigoCliente = alquiler.Cliente.CodigoCliente };
                    sancion.TipoSancion = "Multa";
                    sancion.NroDiasSancion = 1;
                    AlquilerData.Modificar(alquiler);
                    return SancionData.Registrar(sancion);
                }
            }
            return false;
        }
    }

}