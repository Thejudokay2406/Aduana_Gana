using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Area
    {
        //Llaves primarias       
        private int Idarea;

        //Llaves Primarias Auxiliares;
        private int _Auto;

        //Datos Basicos
        private string _Codigo;
        private string _Area;
        private string _Descripcion;

        public int Idarea1 { get => Idarea; set => Idarea = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Area { get => _Area; set => _Area = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
