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
    public class fUsuarios
    {
        public static DataTable Login_SQL(string usuario, string contraseña)
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            return Datos.Login_SQL(usuario, contraseña);
        }
    }
}
