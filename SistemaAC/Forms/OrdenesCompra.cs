using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using AutoControl.Clases;

namespace AutoControl.Forms
{
    public partial class OrdenesCompra : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public OrdenesCompra()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        int estadoCerrar = 0;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(estadoCerrar == 0)
            {
                frmMenu m = new frmMenu();
                m.Show();
                this.Hide();
            }
            else
            {
                if (MessageBox.Show("No hay productos asignados a la orden de compra.\n Si cierra esta ventana, se eliminará la orden de compra. \n ¿Desea cerrar la ventana?", "VERIFICAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                    objOC.Id_orden_compra = Convert.ToInt32(lblCodigoOC.Text);
                    if (objOC.borrarOC())
                    {
                        MessageBox.Show("Se ha eliminado la orden de compra", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMenu m = new frmMenu();
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar orden de compra, comuniquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se eliminará la hoja de trabajo, agrege productos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int idAsesor = 0;
        private void cmbAsesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Nombre_asesor = cmbAsesores.SelectedItem.ToString();
            idAsesor = objOC.obtenerIdAsesor();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroOC_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCódigoProducto_TextChanged(object sender, EventArgs e)
        {

        }
        DateTime fechaRecordatorio;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /*lblFechaRecordatorio.Text = dtpFechaPropuesta.Value.Date.ToString();
            DateTime fechaActual = DateTime.Today;*/
            int mitadFechas = calcularDiferenciaDias() / 2;
            DateTime fechaPropuesta = dtpFechaPropuesta.Value.Date;
            fechaRecordatorio = fechaPropuesta.AddDays(-mitadFechas);
            lblFechaRecordatorio.Text = fechaRecordatorio.ToString();
        }

        private void txtNumeroRequerimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrdenesCompra_Load(object sender, EventArgs e)
        {
            // string fechaActual = DateTime.Now.ToString("dd-MM-yyyy");
            deshabilitarCamposDetalle();
            habilitarCamposOC();
            dtpFechaPropuesta.Format = DateTimePickerFormat.Custom;
            dtpFechaPropuesta.CustomFormat = "dd-MM-yyyy";
            dtpFechaPropuesta.MinDate = DateTime.Today;
            cmbAsesores.DropDownStyle = ComboBoxStyle.DropDownList;
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.llenarComboBoxAsesores(cmbAsesores);
            if (cmbAsesores.Items.Count == 0)
            {
                MessageBox.Show("No hay asesores registrados", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAgregarOC_Click(object sender, EventArgs e)
        {
            if (cmbAsesores.SelectedIndex != -1)
            {
                if (txtCliente.Text.Trim() != "")
                {
                    if (txtNumeroOC.Text.Trim() != "")
                    {

                        if (txtNumeroRequerimiento.Text.Trim() != "")
                        {
                            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                            objOC.Id_asesor = Convert.ToInt32(idAsesor);
                            objOC.Nombre_empresa = txtCliente.Text;
                            objOC.Numero_orden_compra = txtNumeroOC.Text.ToUpper();
                            objOC.Fecha_propuesta = dtpFechaPropuesta.Value;
                            objOC.Numero_requerimiento = txtNumeroRequerimiento.Text;
                            objOC.Fecha_recordatorio = fechaRecordatorio;
                            
                            if(txtObservaciones.Text == "")
                            {
                                objOC.Observacion = "No se ha añadido obsevación a la orden de compra";
                            }
                            else
                            {
                                objOC.Observacion = txtObservaciones.Text;
                            }


                            if (objOC.obtenerNumeroCompra() == 0)
                            {
                                if (objOC.registrarOrdenCompra())
                                {
                                    //limpiarCampos();
                                    MessageBox.Show("Orden de compra registrada exitosamente", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblCodigoOC.Text = objOC.obtenerUltimaOC().ToString();
                                    deshabilitarCamposOC();
                                    habilitarCamposDetalle();
                                    estadoCerrar = 1;
                                }
                                else
                                {
                                    MessageBox.Show("Debe de ingresar número de requerimiento", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El número de orden de compra ya se encuentra registrado", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar número de requerimiento", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar número de orden de compra", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar cliente", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un asesor", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void limpiarCampos()
        {
            txtCliente.Clear();
            txtNumeroOC.Clear();
            txtNumeroRequerimiento.Clear();
            txtObservaciones.Clear();
        }

        int calcularDiferenciaDias()
        {
            DateTime fechaFinal = dtpFechaPropuesta.Value.Date;
            DateTime fechaActual = DateTime.Today;

            TimeSpan diferenciaFechas = fechaFinal - fechaActual;

            int dias = diferenciaFechas.Days;

            return dias;
        }


        private void btnActualizarOC_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarOC_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaRecordatorio_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void limpiarCamposDetalle()
        {
            txtCodigoProducto.Clear();
            txtCantidadProducto.Clear();
            txtDescripcion.Clear();
            txtNombreProducto.Clear();
        }

        public void habilitarCamposOC()
        {
            cmbAsesores.Enabled = true;
            txtCliente.Enabled = true;
            txtNumeroOC.Enabled = true;
            dtpFechaPropuesta.Enabled = true;
            txtNumeroRequerimiento.Enabled = true;
            btnAgregarOC.Enabled = true;
        }

        public void deshabilitarCamposOC()
        {
            cmbAsesores.Enabled = false;
            txtCliente.Enabled = false;
            txtNumeroOC.Enabled = false;
            dtpFechaPropuesta.Enabled = false;
            txtNumeroRequerimiento.Enabled = false;
            btnAgregarOC.Enabled = false;
            txtObservaciones.Enabled = false;
           // lblCodigoOC.Text = "";
        }

        public void habilitarCamposDetalle()
        {
            txtCodigoProducto.Enabled = true;
            txtCantidadProducto.Enabled = true;
            txtDescripcion.Enabled = true;
            btnAgregarProducto.Enabled = true;
            btnCerrarDetalle.Enabled = true;
            btnActualizarDetalle.Enabled = true;
            btnEliminarProducto.Enabled = true;
            btnLimpiarCampos.Enabled = true;
            txtNombreProducto.Enabled = true;
            txtObservaciones.Enabled = true;
        }

        public void deshabilitarCamposDetalle()
        {
            txtCodigoProducto.Enabled = false;
            txtCantidadProducto.Enabled = false;
            txtDescripcion.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnCerrarDetalle.Enabled = false;
            btnActualizarDetalle.Enabled = false;
            btnEliminarProducto.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            txtNombreProducto.Enabled = false;
        }

        public void llenarTablaDetalle()
        {
            int idOC = Convert.ToInt32(lblCodigoOC.Text);
            Clases.OrdenesCompra  objOC = new Clases.OrdenesCompra();
            dgvDetalleOC.DataSource = objOC.mostrarDetallesOC(idOC);
        }

        public void limpiarTablaDetalle()
        {
            dgvDetalleOC.DataSource = "";
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (lblCodigoOC.Text != "")
            {
                if (txtCodigoProducto.Text != "")
                {
                    if (txtCantidadProducto.Text != "")
                    {
                        if(txtNombreProducto.Text != "")
                        {
                            if (Convert.ToInt32(txtCantidadProducto.Text) > 0)
                            {
                                Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                                objOC.Id_orden_compra = Convert.ToInt32(lblCodigoOC.Text);
                                objOC.Cantidad = Convert.ToInt32(txtCantidadProducto.Text);
                                objOC.Codigo_producto = txtCodigoProducto.Text.ToUpper();
                                objOC.NombreProducto = txtNombreProducto.Text.ToUpper();
                                if (txtDescripcion.Text == "")
                                {
                                    objOC.Descripcion_item = "No se ha añadido descripción";
                                }
                                else
                                {
                                    objOC.Descripcion_item = txtDescripcion.Text;
                                }


                                if (objOC.obtenerProductoDetalle().Trim() == txtCodigoProducto.Text.Trim())
                                {
                                    if (MessageBox.Show("El producto que desea agregar ya ha sido agregado a esta orden de compra, ¿desea actualizar la cantidad de producto?", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        int cantidadActual = objOC.obtenerCantidadProductoDetalle();
                                        if (cantidadActual > 0) //Verificar que ya existe una cantidad de producto anteriormente registrada
                                        {
                                            int cantidadIngresada = Convert.ToInt32(txtCantidadProducto.Text);
                                            int cantidadTotal = cantidadActual + cantidadIngresada;

                                            objOC.Cantidad = cantidadTotal;
                                            if (objOC.actualizarCantidadProductoDetalle())
                                            {
                                                MessageBox.Show("Se ha actualizado la cantidad de producto", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                llenarTablaDetalle();
                                                limpiarCamposDetalle();
                                                llenarTablaDetalle();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error al actualizar cantidad de producto, pongase en contacto con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error al obtener cantidad de producto, pongase en contacto con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se actualizará la cantidad de producto, verifique el código del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    if (objOC.agregarDetalleOC())
                                    {
                                        MessageBox.Show("Producto agregado a la orden de compra", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        limpiarCamposDetalle();
                                        llenarTablaDetalle();
                                        estadoCerrar = 0;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha podido agregar el detalle de orden de compra", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de producto debe de ser mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar nombre del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                                                                                  
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar la cantidad del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar un código de producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No existe orden de compra asignada verificar", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidadProducto_TextChanged(object sender, EventArgs e)
        {

        }

        public void limpiarCamposDetalleOC()
        {
            lblCodigoOC.Text = "--";
            txtCodigoProducto.Clear();
            txtCantidadProducto.Clear();
            txtDescripcion.Clear();
            limpiarTablaDetalle();
            txtNombreProducto.Clear();
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar la orden de compra?, ya no se pondrán agregar producto, ni modificarlos", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deshabilitarCamposDetalle();
                limpiarCampos();
                habilitarCamposOC();
                limpiarTablaDetalle();
                limpiarCamposDetalleOC();
                estadoCerrar = 0;
            }
            else
            {
                MessageBox.Show("Continue...", "INFORMACIÖN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(idDetalle > 0)
            {
                if (MessageBox.Show("¿Seguro que desea eliminar el producto?, ya no podrá recuperar la información", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                    objOC.Id_detalle = idDetalle;
                    if (objOC.eliminarDetalle())
                    {
                        MessageBox.Show("Producto eliminado correctamente", "INFORMACIÖN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenarTablaDetalle();
                        limpiarCamposDetalle();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se eliminar el producto", "INFOMRACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un registro para eliminar", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int idDetalle = 0;
        private void dgvDetalleOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idDetalle = Convert.ToInt32(dgvDetalleOC.Rows[e.RowIndex].Cells[0].Value.ToString().TrimEnd());
                txtCodigoProducto.Text = dgvDetalleOC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNombreProducto.Text = dgvDetalleOC.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCantidadProducto.Text = dgvDetalleOC.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDescripcion.Text = dgvDetalleOC.Rows[e.RowIndex].Cells[4].Value.ToString();
            }catch(Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
                
        }

        Validaciones objValidaciones = new Validaciones();
        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.validarSoloNumeros(e);
        }

        private void txtNumeroOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNumeroRequerimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.validarSoloNumeros(e);
        }

        private void btnActualizarDetalle_Click(object sender, EventArgs e)
        {
            if(txtCodigoProducto.Text != "")
            {
                if(txtCantidadProducto.Text != "")
                {
                    if(Convert.ToInt32(txtCantidadProducto.Text) > 0)
                    {
                        Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                        objOC.Id_detalle = idDetalle;
                        objOC.Codigo_producto = txtCodigoProducto.Text;
                        objOC.Cantidad = Convert.ToInt32(txtCantidadProducto.Text);
                        objOC.Descripcion_item = txtDescripcion.Text;
                        if (objOC.actualizarDetalleOC())
                        {
                            MessageBox.Show("Datos actualizados correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenarTablaDetalle();
                            limpiarCamposDetalle();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar detalle de orden de compra", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de producto debe de ser mayor a cero", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar cantidad de producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de ingresar código de producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            limpiarCamposDetalle();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
