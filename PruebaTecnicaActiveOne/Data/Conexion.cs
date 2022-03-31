using System.Configuration;

namespace PruebaTecnicaActive.Data
{
    public class Conexion
    {
        public static string rutaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}