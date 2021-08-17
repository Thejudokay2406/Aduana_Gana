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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                ////<<<<<<----- Al pasar las pruebas de seguridad se procede a verificar los usuarios ingresados

                DataTable Datos = Negocio.fUsuarios.Login_SQL(this.TBUsuario.Text, this.TBContraseña.Text);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Acceso Denegado al Sistema, Usuario o Contraseña Incorrecto. Si el Problema Persiste Contacte al Area de Sistemas", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    frmMenuPrincipal frm = new frmMenuPrincipal();
                    frm.Idempleado = Datos.Rows[0][0].ToString();
                    frm.Idusuario = Datos.Rows[0][1].ToString();
                    frm.Empleado = Datos.Rows[0][2].ToString();
                    frm.UsuarioLogueado = Datos.Rows[0][3].ToString();

                    //Captura de Valores en la Base de Datos

                    frm.SQL_Guardar = Datos.Rows[0][4].ToString();
                    frm.SQL_Editar = Datos.Rows[0][5].ToString();
                    frm.SQL_Eliminar = Datos.Rows[0][6].ToString();
                    frm.SQL_Consultar = Datos.Rows[0][7].ToString();

                    frm.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
