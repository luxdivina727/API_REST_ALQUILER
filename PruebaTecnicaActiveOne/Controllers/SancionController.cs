using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Controllers
{
    public class SancionController
    {
        // GET api/<controller>
        public List<Sancion> Get()
        {
            return SancionData.Listar();
        }

        // GET api/<controller>/5
        public Sancion Get(long nroSancion)
        {
            return SancionData.Obtener(nroSancion);
        }

        // POST api/<controller>
        public bool Post([FromBody] Sancion oSancion)
        {
            return SancionData.Registrar(oSancion);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Sancion oSancion)
        {
            return SancionData.Modificar(oSancion);
        }

        // DELETE api/<controller>/5
        public bool Delete(long nroSancion)
        {
            return SancionData.Eliminar(nroSancion);
        }
    }
}