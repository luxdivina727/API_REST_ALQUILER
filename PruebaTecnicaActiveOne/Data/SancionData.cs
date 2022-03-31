using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Data
{
    public class SancionData
    {
        public static bool Eliminar(long nroSancion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("EliminarSancion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroSancion", nroSancion);

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
        public static List<Sancion> Listar()
        {
            List<Sancion> oListaSancion = new List<Sancion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarSancion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaSancion.Add(new Sancion()
                            {
                                NroSancion = Convert.ToInt64(dr["NroSancion"]),
                                TipoSancion = dr["TipoSancion"].ToString(),
                                NroDiasSancion = Convert.ToInt32(dr["NroDiasSancion"]),
                                Cliente = new Cliente { CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]) },
                                Alquiler = new Alquiler { NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]) },

                            });
                        }

                    }



                    return oListaSancion;
                }
                catch (Exception ex)
                {
                    return oListaSancion;
                }
            }
        }
        public static Sancion Obtener(long nroSancion)
        {
            Sancion oSancion = new Sancion();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {

                SqlCommand cmd = new SqlCommand("ObtenerSancion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroSancion", nroSancion);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oSancion = new Sancion()
                            {
                                NroSancion = Convert.ToInt64(dr["NroSancion"]),
                                TipoSancion = dr["TipoSancion"].ToString(),
                                NroDiasSancion = Convert.ToInt32(dr["NroDiasSancion"]),
                                Cliente = new Cliente { CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]) },
                                Alquiler = new Alquiler { NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]) },
                            };
                        }
                    }
                    return oSancion;

                }
                catch (Exception ex)
                {
                    return oSancion;
                }
            }
        }
        public static bool Modificar(Sancion oSancion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ActualizarSancion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroSancion", oSancion.NroSancion);
                cmd.Parameters.AddWithValue("@tipoSancion", oSancion.TipoSancion);
                cmd.Parameters.AddWithValue("@nroDiasSancion", oSancion.NroDiasSancion);
                cmd.Parameters.AddWithValue("@codigoCliente", oSancion.Cliente.CodigoCliente);
                cmd.Parameters.AddWithValue("@nroAlquiler", oSancion.Alquiler.NroAlquiler);

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
        public static bool Registrar(Sancion oSancion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarSancion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipoSancion", oSancion.TipoSancion);
                cmd.Parameters.AddWithValue("@nroDiasSancion", oSancion.NroDiasSancion);
                cmd.Parameters.AddWithValue("@codigoCliente", oSancion.Cliente.CodigoCliente);
                cmd.Parameters.AddWithValue("@nroAlquiler", oSancion.Alquiler.NroAlquiler);

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