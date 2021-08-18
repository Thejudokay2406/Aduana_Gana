using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fEmpleado
    {
        public static DataTable Lista(int Auto)
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Lista(Auto);
        }

        public static DataTable Buscar(int Auto, string Filtro)
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Buscar(Auto, Filtro);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idarea,

               //Datos Basicos
               string Codigo, string nombre, string apellidos, string direccion, string telefono, string salario, string sexo, DateTime fecha, int personal
            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            //Llaves Primarias Auxiliares
            Obj.Idarea = idarea;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Salario = salario;
            Obj.Sexo = sexo;
            Obj.Ingreso = fecha;
            Obj.Personal = personal;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idempleado, int idarea,

               //Datos Basicos
               string Codigo, string nombre, string apellidos, string direccion, string telefono, string salario, string sexo, DateTime fecha, int personal
            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            //Llaves Primarias Auxiliares
            Obj.Idempleado = idempleado;
            Obj.Idarea = idarea;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Salario = salario;
            Obj.Sexo = sexo;
            Obj.Ingreso = fecha;
            Obj.Personal = personal;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

    }
}
