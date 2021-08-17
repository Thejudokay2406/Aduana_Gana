using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_Empleados
    {

        public string Guardar_DatosBasicos(Entidad_Empleados Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Obj.Apellidos;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;
               
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Realizar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }
    }
}
