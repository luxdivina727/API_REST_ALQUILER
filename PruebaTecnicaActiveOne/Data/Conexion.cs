using System.Configuration;

namespace PruebaTecnicaActiveOne.Data
{
    public class Conexion
    {
        public static string rutaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}