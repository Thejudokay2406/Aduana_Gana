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
    public partial class frmArea : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        private string Campo = "Campo Obligatorio";

        // ***************************************************** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        public frmArea()
        {
            InitializeComponent();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            this.Botones();
        }

        private void Limpiar()
        {
            this.TBArea.Clear();
            this.TBDescripcion.Clear();
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

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Aduana Gama - Solicitud Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Aduana Gama - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBArea.Text == Campo)
                {
                    MensajeError("Ingrese el Codigo del Area a Registrar");
                }
                else if (this.TBArea.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Empleado a Registrar");
                }

                else
                {

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fArea.Guardar_DatosBasicos
                            (
                                //Datos Auxiliares
                                1,

                                //Panel Datos Basicos
                                this.TBCodigo.Text, this.TBArea.Text, this.TBDescripcion.Text
                            );
                    }

                    //else
                    //{
                    //    rptaDatosBasicos = fEmpleado.Editar_DatosBasicos

                    //        (
                    //             //Datos Auxiliares y Llave Primaria
                    //             2, Convert.ToInt32(TBIdbodega.Text),

                    //            //Panel Datos Basicos
                    //            Convert.ToInt32(this.CBSucurzal.SelectedValue), this.TBBodega.Text, this.TBDocumento.Text, this.TBDescripcion.Text, this.TBDirector.Text, this.TBCiudad.Text, this.TBTelefono01.Text, this.TBExtension01.Text, this.TBTelefono02.Text, this.TBExtension02.Text, this.TBMovil01.Text, this.TBMovil02.Text, this.TBCorreo.Text, this.TBMedidas.Text, this.TBDireccion01.Text, this.TBDireccion02.Text
                    //        );
                    //}

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Aduana Gama \n\n" + "La Area: “" + this.TBArea.Text + "” a Sido Registrada.");
                        }
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar();
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
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Aduana Gama", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar();
                    }
                }

                //Focus
                this.TBArea.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

    }
}
