using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Empleados
    {
        //Llaves primarias       
        private int _Idempleado;

        //Llaves Primarias Auxiliares;
        private int _Idarea;
        private int _Auto;

        //Datos Basicos
        private string _Codigo;
        private string _Nombre;
        private string _Apellidos;
        private string _Direccion;
        private string _Telefono;
        private string _Salario;
        private string _Jefe;
        private string _Sexo;
        private int _Personal;
        private DateTime _Ingreso;

        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idarea { get => _Idarea; set => _Idarea = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Salario { get => _Salario; set => _Salario = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Jefe { get => _Jefe; set => _Jefe = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Ingreso { get => _Ingreso; set => _Ingreso = value; }
        public int Personal { get => _Personal; set => _Personal = value; }
    }
}
