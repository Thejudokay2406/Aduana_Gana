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
    public class fArea
    {
        public static DataTable Lista(int Auto)
        {
            Conexion_Area Datos = new Conexion_Area();
            return Datos.Lista(Auto);
        }

        public static DataTable Buscar(int Auto, string Filtro)
        {
            Conexion_Area Datos = new Conexion_Area();
            return Datos.Buscar(Auto, Filtro);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, 

               //Datos Basicos
               string Codigo, string nombre, string descripcion
            )
        {
            Conexion_Area Datos = new Conexion_Area();
            Entidad_Area Obj = new Entidad_Area();

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Area = nombre;
            Obj.Descripcion = descripcion;
            
            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }


        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idarea,

               //Datos Basicos
               string Codigo, string nombre, string descripcion
            )
        {
            Conexion_Area Datos = new Conexion_Area();
            Entidad_Area Obj = new Entidad_Area();

            //Datos Basicos
            Obj.Idarea = idarea;
            Obj.Codigo = Codigo;
            Obj.Area = nombre;
            Obj.Descripcion = descripcion;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Area Datos = new Conexion_Area();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
