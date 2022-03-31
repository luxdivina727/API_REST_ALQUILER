using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Controllers
{
    public class AlquilerController : ApiController
    {
        // GET api/<controller>
        public List<Alquiler> Get()
        {
            return AlquilerData.Listar();
        }

        // GET api/<controller>/5
        public Alquiler Get(long nroAlquiler)
        {
            return AlquilerData.Obtener(nroAlquiler);
        }

        // POST api/<controller>
        public bool Post([FromBody] Alquiler oAlquiler)
        {
            return AlquilerData.Registrar(oAlquiler);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Alquiler oAlquiler)
        {
            return AlquilerData.Modificar(oAlquiler);
        }

        // DELETE api/<controller>/5
        public bool Delete(long nroAlquiler)
        {
            return AlquilerData.Eliminar(nroAlquiler);
        }
    }
}