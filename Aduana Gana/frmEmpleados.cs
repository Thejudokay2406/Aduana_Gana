using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;

namespace Aduana_Gana
{
    public partial class frmEmpleados : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        private string Campo = "Campo Obligatorio";

        // ***************************************************** Variable para Captura el Empleado Logueado ****************************************************

        public int Idempleado;

        // ***************************************************** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //Panel Datos Basicos
        private string Idbodega, Nombre, Apellidos, Direccion, Telefono, Salario = "";

        private void frmEmpleados_Load(object sender, EventArgs e)
        {

        }

        public frmEmpleados()
        {
            InitializeComponent();
        }


        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos

            this.TBNombre.Clear();
            this.CBSucurzal.SelectedIndex = 0;
            this.TBApellidos.Clear();
            this.TBDocumento.Clear();
            this.TBDescripcion.Clear();
            this.TBDescripcion.Text = Campo;
            //this.TBDescripcion.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDirector.Clear();
            this.TBDirector.Text = Campo;
            //this.TBDirector.ForeColor = Color.FromArgb(255, 255, 255);

            this.TBCiudad.Clear();
            this.TBMovil01.Clear();
            this.TBMovil02.Clear();
            this.TBTelefono01.Clear();
            this.TBExtension01.Clear();
            this.TBTelefono02.Clear();
            this.TBExtension02.Clear();
            this.TBCorreo.Clear();
            this.TBDireccion01.Clear();
            this.TBDireccion02.Clear();
            this.TBMedidas.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBBodega.Select();
            this.TBIdbodega.Clear();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
        }



        private void Combobox_Sucurzal()
        {
            try
            {
                this.CBSucurzal.DataSource = fSucurzal.Lista(3);
                this.CBSucurzal.ValueMember = "Codigo";
                this.CBSucurzal.DisplayMember = "Sucursal";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Solicitud Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBBodega.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre de la Bodega a Registrar");
                }
                else if (this.TBDescripcion.Text == Campo)
                {
                    MensajeError("Ingrese la Descripción de la Bodega a Registrar");
                }
                else if (this.TBDirector.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Director o Responsable de la bodega");
                }
                else if (this.CBSucurzal.SelectedIndex == 0)
                {
                    MensajeError("Seleccione la Sucursal a la Cual Pernecera la Bodega");
                }
                else
                {

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = f.Guardar_DatosBasicos
                            (
                                //Datos Auxiliares
                                1,

                                //Panel Datos Basicos
                                Convert.ToInt32(this.CBSucurzal.SelectedValue), this.TBBodega.Text, this.TBDocumento.Text, this.TBDescripcion.Text, this.TBDirector.Text, this.TBCiudad.Text, this.TBTelefono01.Text, this.TBExtension01.Text, this.TBTelefono02.Text, this.TBExtension02.Text, this.TBMovil01.Text, this.TBMovil02.Text, this.TBCorreo.Text, this.TBMedidas.Text, this.TBDireccion01.Text, this.TBDireccion02.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fBodega.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llave Primaria
                                 2, Convert.ToInt32(TBIdbodega.Text),

                                //Panel Datos Basicos
                                Convert.ToInt32(this.CBSucurzal.SelectedValue), this.TBBodega.Text, this.TBDocumento.Text, this.TBDescripcion.Text, this.TBDirector.Text, this.TBCiudad.Text, this.TBTelefono01.Text, this.TBExtension01.Text, this.TBTelefono02.Text, this.TBExtension02.Text, this.TBMovil01.Text, this.TBMovil02.Text, this.TBCorreo.Text, this.TBMedidas.Text, this.TBDireccion01.Text, this.TBDireccion02.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Leal Enterprise \n\n" + "La Bodega: “" + this.TBBodega.Text + "” a Sido Registrada.");
                        }
                        else
                        {
                            this.MensajeOk("Procedimiento de Modificación Exitoso - Leal Enterprise \n\n" + "El Registro de la Bodega: “" + this.TBBodega.Text + "” a Sido Modificado.");
                        }
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (Guardar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }

                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }
                }

                else
                {
                    if (Editar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }
                }

                //Focus
                this.TBBodega.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
