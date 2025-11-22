using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT id_usuario, nombres, apellidos, correo, clave, reestablecer, activo FROM usuario ";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                    Nombres = Convert.ToString(dr["nombres"]),
                                    Apellidos = Convert.ToString(dr["apellidos"]),
                                    Correo = Convert.ToString(dr["correo"]),
                                    Clave = Convert.ToString(dr["clave"]),
                                    Reestablecer = Convert.ToBoolean(dr["reestablecer"]),
                                    Activo = Convert.ToBoolean(dr["activo"])
                                }
                            );
                        }

                    }
                }

            }catch
            {
                lista = new List<Usuario>();
            }

            return lista;
        }
    }
}
