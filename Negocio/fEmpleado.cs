﻿using System;
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

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idarea,

                //Datos Basicos
                string nombre, string apellidos, string direccion, string telefono, string salario
            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            //Llaves Primarias Auxiliares
            Obj.Idarea = idarea;

            //Datos Basicos
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Salario = salario;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

    }
}
