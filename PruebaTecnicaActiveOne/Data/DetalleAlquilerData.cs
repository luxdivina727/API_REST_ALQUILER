using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Data
{
    public class DetalleAlquilerData
    {
        public static bool Eliminar(long nroAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("EliminarDetalleAlquiler", oConexion);
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
        public static List<DetalleAlquiler> Listar()
        {
            List<DetalleAlquiler> oListaDetalleAlquiler = new List<DetalleAlquiler>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarDetalleAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaDetalleAlquiler.Add(new DetalleAlquiler()
                            {
                                CodigoDetalleAlquiler = Convert.ToInt64(dr["CodigoDetalleAlquiler"]),
                                Item = Convert.ToInt32(dr["Item"]),
                                CodigoTitulo = Convert.ToInt64(dr["CodigoTitulo"]),
                                Cd = new Cd { NroCd = Convert.ToInt64(dr["NroCd"]) },
                                Alquiler = new Alquiler { NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]) },
                                DiasPrestamo = Convert.ToInt32(dr["DiasPrestamo"]),
                                FechaDevolucion = Convert.ToDateTime(dr["FechaDevolucion"]),

                            });
                        }

                    }



                    return oListaDetalleAlquiler;
                }
                catch (Exception ex)
                {
                    return oListaDetalleAlquiler;
                }
            }
        }
        public static DetalleAlquiler Obtener(long nroDetalleAlquiler)
        {
            DetalleAlquiler oDetalleAlquiler = new DetalleAlquiler();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {

                SqlCommand cmd = new SqlCommand("ObtenerDetalleAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroDetalleAlquiler", nroDetalleAlquiler);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oDetalleAlquiler = new DetalleAlquiler()
                            {
                                CodigoDetalleAlquiler = Convert.ToInt64(dr["CodigoDetalleAlquiler"]),
                                Item = Convert.ToInt32(dr["Item"]),
                                CodigoTitulo = Convert.ToInt64(dr["CodigoTitulo"]),
                                Cd = new Cd { NroCd = Convert.ToInt64(dr["NroCd"]) },
                                Alquiler = new Alquiler { NroAlquiler = Convert.ToInt64(dr["NroAlquiler"]) },
                                DiasPrestamo = Convert.ToInt32(dr["DiasPrestamo"]),
                                FechaDevolucion = Convert.ToDateTime(dr["FechaDevolucion"]),
                            };
                        }
                    }
                    return oDetalleAlquiler;

                }
                catch (Exception ex)
                {
                    return oDetalleAlquiler;
                }
            }
        }
        public static bool Modificar(DetalleAlquiler oDetalleAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ActualizarDetalleAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoTitulo", oDetalleAlquiler.CodigoTitulo);
                cmd.Parameters.AddWithValue("@item", oDetalleAlquiler.Item);
                cmd.Parameters.AddWithValue("@nroCd", oDetalleAlquiler.Cd.NroCd);
                cmd.Parameters.AddWithValue("@diasPrestamos", oDetalleAlquiler.DiasPrestamo);
                cmd.Parameters.AddWithValue("@nroAlquiler", oDetalleAlquiler.Alquiler.NroAlquiler);
                cmd.Parameters.AddWithValue("@fechaDevolucion", oDetalleAlquiler.FechaDevolucion);
                cmd.Parameters.AddWithValue("@codigoDetalleAlquiler", oDetalleAlquiler.CodigoDetalleAlquiler);
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
        public static bool Registrar(DetalleAlquiler oDetalleAlquiler)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarDetalleAlquiler", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoTitulo", oDetalleAlquiler.CodigoTitulo);
                cmd.Parameters.AddWithValue("@item", oDetalleAlquiler.Item);
                cmd.Parameters.AddWithValue("@nroCd", oDetalleAlquiler.Cd.NroCd);
                cmd.Parameters.AddWithValue("@diasPrestamos", oDetalleAlquiler.DiasPrestamo);
                cmd.Parameters.AddWithValue("@nroAlquiler", oDetalleAlquiler.Alquiler.NroAlquiler);
                cmd.Parameters.AddWithValue("@fechaDevolucion", oDetalleAlquiler.FechaDevolucion);
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