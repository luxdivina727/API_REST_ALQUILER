using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaActiveOne.Models;

namespace PruebaTecnicaActiveOne.Data
{
    public class ClienteData
    {
        public static bool Eliminar(long codigoCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("EliminarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoCliente", codigoCliente);

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
        public static List<Cliente> Listar()
        {
            List<Cliente> oListaCliente = new List<Cliente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCliente.Add(new Cliente()
                            {
                                CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                Cedula = Convert.ToInt64(dr["Cedula"]),
                                Email = dr["Email"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                FechaInscripcion = Convert.ToDateTime(dr["FechaInscripcion"]),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                Telefono = Convert.ToInt64(dr["Telefono"]),
                                TemaInteres = dr["TemaInteres"].ToString(),

                            });
                        }

                    }



                    return oListaCliente;
                }
                catch (Exception ex)
                {
                    return oListaCliente;
                }
            }
        }
        public static Cliente Obtener(long codigoCliente)
        {
            Cliente oCliente = new Cliente();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {

                SqlCommand cmd = new SqlCommand("ObtenerCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoCliente", codigoCliente);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                CodigoCliente = Convert.ToInt64(dr["CodigoCliente"]),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                Cedula = Convert.ToInt64(dr["Cedula"]),
                                Email = dr["Email"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                FechaInscripcion = Convert.ToDateTime(dr["FechaInscripcion"]),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                Telefono = Convert.ToInt64(dr["Telefono"]),
                                TemaInteres = dr["TemaInteres"].ToString(),
                            };
                        }
                    }
                    return oCliente;

                }
                catch (Exception ex)
                {
                    return oCliente;
                }
            }
        }
        public static bool Modificar(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ActualizarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoCliente", oCliente.CodigoCliente);
                cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.NombreCliente);
                cmd.Parameters.AddWithValue("@email", oCliente.Email);
                cmd.Parameters.AddWithValue("@cedula", oCliente.Cedula);
                cmd.Parameters.AddWithValue("@fechaNacimiento", oCliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@fechaInscripcion", oCliente.FechaInscripcion);
                cmd.Parameters.AddWithValue("@temaInteres", oCliente.TemaInteres);
                cmd.Parameters.AddWithValue("@estado", oCliente.Estado);
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
        public static bool Registrar(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.NombreCliente);
                cmd.Parameters.AddWithValue("@email", oCliente.Email);
                cmd.Parameters.AddWithValue("@cedula", oCliente.Cedula);
                cmd.Parameters.AddWithValue("@fechaNacimiento", oCliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@fechaInscripcion", oCliente.FechaInscripcion);
                cmd.Parameters.AddWithValue("@temaInteres", oCliente.TemaInteres);
                cmd.Parameters.AddWithValue("@estado", oCliente.Estado);



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