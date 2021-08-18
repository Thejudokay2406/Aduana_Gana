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
        public DataTable Lista(int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Gama.GA_Empleado", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = Auto;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public DataTable Buscar(int Auto, string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Gama.GA_Empleado", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Valor;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }


        public string Guardar_DatosBasicos(Entidad_Empleados Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Gama.GA_Empleado", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idarea", SqlDbType.Int).Value = Obj.Idarea;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Obj.Apellidos;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;

                Comando.Parameters.Add("@Jefe", SqlDbType.VarChar).Value = Obj.Jefe;
                Comando.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Obj.Sexo;
                Comando.Parameters.Add("@Ingreso", SqlDbType.DateTime).Value = Obj.Ingreso;
                Comando.Parameters.Add("@Personal", SqlDbType.Int).Value = Obj.Personal;

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


        public string Editar_DatosBasicos(Entidad_Empleados Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Gama.GA_Empleado", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                Comando.Parameters.Add("@Idarea", SqlDbType.Int).Value = Obj.Idarea;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Obj.Apellidos;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Salario", SqlDbType.VarChar).Value = Obj.Salario;

                Comando.Parameters.Add("@Jefe", SqlDbType.VarChar).Value = Obj.Jefe;
                Comando.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Obj.Sexo;
                Comando.Parameters.Add("@Ingreso", SqlDbType.DateTime).Value = Obj.Ingreso;
                Comando.Parameters.Add("@Personal", SqlDbType.Int).Value = Obj.Personal;

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
