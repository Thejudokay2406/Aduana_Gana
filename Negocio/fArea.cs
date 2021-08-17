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
        public static DataTable Lista()
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Lista();
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
    }
}
