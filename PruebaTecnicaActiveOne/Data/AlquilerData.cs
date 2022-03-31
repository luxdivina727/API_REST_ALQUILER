using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Data
{
    public class AlquilerData
    {
        public static bool Eliminar(long nroAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("EliminarAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroAlquiler", nroAlquiler);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<Alquiler> Listar()
        {
            List<Alquiler> oListaAlquiler = new List<Alquiler>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaAlquiler.Add(new Alquiler()
                            {
                                NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]),
                                FechaAlquiler = Convert.ToDateTime(dr["FechaAlquiler"]),
                                ValorAlquiler = Convert.ToInt32(dr["ValorAlquiler"]),
                                Cliente = new Cliente { CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]) },
                            });
                        }

                    }



                    return oListaAlquiler;
                }
                catch (Exception ex)
                {
                    return oListaAlquiler;
                }
            }
        }
        public static Alquiler Obtener(long nroAlquiler)
        {
            Alquiler oAlquiler = new Alquiler();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {

                SqlCommand cmd = new SqlCommand("ObtenerAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroAlquiler", nroAlquiler);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oAlquiler = new Alquiler()
                            {
                                NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]),
                                FechaAlquiler = Convert.ToDateTime(dr["FechaAlquiler"]),
                                ValorAlquiler = Convert.ToInt32(dr["ValorAlquiler"]),
                                Cliente = new Cliente { CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]) },
                            };
                        }
                    }
                    return oAlquiler;

                }
                catch (Exception ex)
                {
                    return oAlquiler;
                }
            }
        }
        public static bool Modificar(Alquiler oAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ActualizarAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroAlquiler", oAlquiler.NroAlquiler);
                cmd.Parameters.AddWithValue("@fechaAlquiler", oAlquiler.FechaAlquiler);
                cmd.Parameters.AddWithValue("@valorAlquiler", oAlquiler.ValorAlquiler);
                cmd.Parameters.AddWithValue("@codigoCliente", oAlquiler.Cliente.CodigoCliente);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Registrar(Alquiler oAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaAlquiler", oAlquiler.FechaAlquiler);
                cmd.Parameters.AddWithValue("@valorAlquiler", oAlquiler.ValorAlquiler);
                cmd.Parameters.AddWithValue("@codigoCliente", oAlquiler.Cliente.CodigoCliente);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}