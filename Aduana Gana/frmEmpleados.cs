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

        //
        private string Personal_Cargo = "";

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            this.CBArea.SelectedIndex = 0;
            this.CBSexo.SelectedIndex = 0;
            this.CBJefe.SelectedIndex = 0;


            this.TBCodigo.Text = Campo;
            this.TBNombre.Text = Campo;
            this.TBApellidos.Text = Campo;

            this.Botones();
        }

        public frmEmpleados()
        {
            InitializeComponent();
        }


        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos

            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBApellidos.Clear();
            this.TBDireccion.Clear();
            this.TBTelefono.Clear();
            this.TBSalario.Text = Campo;
            this.CBArea.SelectedIndex = 0;
            this.CBSexo.SelectedIndex = 0;
            this.CBJefe.SelectedIndex = 0;

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBCodigo.Select();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";
            }
        }

        private void Combobox_Sucurzal()
        {
            try
            {
                this.CBJefe.DataSource = fSucurzal.Lista(3);
                this.CBJefe.ValueMember = "Codigo";
                this.CBJefe.DisplayMember = "Sucursal";

                this.CBArea.DataSource = fArea.Lista(3);
                this.CBArea.ValueMember = "Codigo";
                this.CBArea.DisplayMember = "Sucursal";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Validacion()
        {
            if (CHPersonal.Checked)
            {
                this.Personal_Cargo = "1";
            }
            else
            {
                this.Personal_Cargo = "0";
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

                if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Ingrese el Codigo del Empleado a Registrar");
                }
                else if (this.TBNombre.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Empleado a Registrar");
                }
                else if (this.TBApellidos.Text == Campo)
                {
                    MensajeError("Ingrese los Apellidos del Empleado a Registrar");
                }

                else
                {

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fEmpleado.Guardar_DatosBasicos
                            (
                                //Datos Auxiliares
                                1,

                                //Panel Datos Basicos
                                Convert.ToInt32(this.CBArea.SelectedValue), this.TBCodigo.Text, this.TBNombre.Text, this.TBApellidos.Text, this.TBDireccion.Text, this.TBTelefono.Text, this.TBSalario.Text, this.CBJefe.Text, this.CBSexo.Text, this.DTFecha.Value, Convert.ToInt32(Personal_Cargo)
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
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Aduana Gama \n\n" + "La Bodega: “" + this.TBBodega.Text + "” a Sido Registrada.");
                        }
                        else
                        {
                            this.MensajeOk("Procedimiento de Modificación Exitoso - Aduana Gama \n\n" + "El Registro de la Bodega: “" + this.TBBodega.Text + "” a Sido Modificado.");
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
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Aduana Gama", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Aduana Gama", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
