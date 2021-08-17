using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aduana_Gana
{
    public partial class frmMenuPrincipal : Form
    {
        //Parametros Basicos
        public string Idempleado = "";
        public string Empleado = "";
        public string UsuarioLogueado = "";
        public string Idusuario = "";

        //Permisos de Operacion Que Vienen de la Base de Datos

        public string SQL_Guardar = "";
        public string SQL_Editar = "";
        public string SQL_Eliminar = "";
        public string SQL_Consultar = "";
        public string SQL_Imprimir = "";


        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
