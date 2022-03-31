using System.Collections.Generic;
using System.Web.Http;
using PruebaTecnicaActiveOne.Data;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Controllers
{
    public class ClienteController
    {
        // GET api/<controller>
        public List<Cliente> Get()
        {
            return ClienteData.Listar();
        }

        // GET api/<controller>/5
        public Cliente Get(long codigoCliente)
        {
            return ClienteData.Obtener(codigoCliente);
        }

        // POST api/<controller>
        public bool Post([FromBody] Cliente oCliente)
        {
            return ClienteData.Registrar(oCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Cliente oCliente)
        {
            return ClienteData.Modificar(oCliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(long codigoCliente)
        {
            return ClienteData.Eliminar(codigoCliente);
        }
    }
}