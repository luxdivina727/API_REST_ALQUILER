using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Controllers
{
    public class DetalleAlquilerController : ApiController
    {
        // GET api/<controller>
        public List<DetalleAlquiler> Get()
        {
            return DetalleAlquilerData.Listar();
        }

        // GET api/<controller>/5
        public DetalleAlquiler Get(long nroDetalleAlquiler)
        {
            return DetalleAlquilerData.Obtener(nroDetalleAlquiler);
        }

        // POST api/<controller>
        public bool Post([FromBody] DetalleAlquiler oDetalleAlquiler)
        {
            return DetalleAlquilerData.Registrar(oDetalleAlquiler);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] DetalleAlquiler oDetalleAlquiler)
        {
            return DetalleAlquilerData.Modificar(oDetalleAlquiler);
        }

        // DELETE api/<controller>/5
        public bool Delete(long nroDetalleAlquiler)
        {
            return DetalleAlquilerData.Eliminar(nroDetalleAlquiler);
        }
    }
}