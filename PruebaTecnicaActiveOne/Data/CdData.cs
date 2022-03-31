using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Data
{
    public class CdData
    {
        public static bool Eliminar(long nroCd)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("EliminarCd", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroCd", nroCd);

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
        public static List<Cd> Listar()
        {
            List<Cd> oListaCd = new List<Cd>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarCd", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCd.Add(new Cd()
                            {
                                NroCd = Convert.ToInt64(dr["NroCd"]),
                                CodigoTitulo = Convert.ToInt64(dr["CodigoTitulo"]),
                                Condicion = dr["Condicion"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Estado = dr["Estado"].ToString(),

                            });
                        }

                    }



                    return oListaCd;
                }
                catch (Exception ex)
                {
                    return oListaCd;
                }
            }
        }
        public static Cd Obtener(long nroCd)
        {
            Cd oCd = new Cd();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {

                SqlCommand cmd = new SqlCommand("ObtenerCd", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroCd", nroCd);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCd = new Cd()
                            {
                                NroCd = Convert.ToInt64(dr["NroCd"]),
                                CodigoTitulo = Convert.ToInt64(dr["CodigoTitulo"]),
                                Condicion = dr["Condicion"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Estado = dr["Estado"].ToString(),
                            };
                        }
                    }
                    return oCd;

                }
                catch (Exception ex)
                {
                    return oCd;
                }
            }
        }
        public static bool Modificar(Cd oCd)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ActualizarCd", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoTitulo", oCd.NroCd);
                cmd.Parameters.AddWithValue("@condicion", oCd.Condicion);
                cmd.Parameters.AddWithValue("@ubicacion", oCd.Ubicacion);
                cmd.Parameters.AddWithValue("@estado", oCd.Estado);
                cmd.Parameters.AddWithValue("@nroCd", oCd.NroCd);

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
        public static bool Registrar(Cd oCd)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarCd", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoTitulo", oCd.CodigoTitulo);
                cmd.Parameters.AddWithValue("@condicion", oCd.Condicion);
                cmd.Parameters.AddWithValue("@ubicacion", oCd.Ubicacion);
                cmd.Parameters.AddWithValue("@estado", oCd.Estado);

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