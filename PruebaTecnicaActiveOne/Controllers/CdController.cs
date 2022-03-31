using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Controllers
{
    public class CdController : ApiController
    {
        // GET api/<controller>
        public List<Cd> Get()
        {
            return CdData.Listar();
        }

        // GET api/<controller>/5
        public Cd Get(long nroCd)
        {
            return CdData.Obtener(nroCd);
        }

        // POST api/<controller>
        public bool Post([FromBody] Cd oCd)
        {
            return CdData.Registrar(oCd);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Cd oCd)
        {
            return CdData.Modificar(oCd);
        }

        // DELETE api/<controller>/5
        public bool Delete(long nroCd)
        {
            return CdData.Eliminar(nroCd);
        }
    }
}