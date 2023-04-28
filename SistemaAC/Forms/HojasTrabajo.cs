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

namespace AutoControl.Forms
{
    public partial class HojasTrabajo : Form
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

        public HojasTrabajo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        /*
            estadoCerrar = 0, si no se ha añadido hoja de trabajo o si ya se añadieron productos a la hoja de trabajo
            estadoCerrar = 1, si se ha añadido hoja de trabajo
         */
        int estadoCerrar = 0;
        private void picCerrar_Click(object sender, EventArgs e)
        {
            if(estadoCerrar == 0)
            {
                frmMenu menu = new frmMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                objHT.IdHoja = Convert.ToInt32(lblCodigoHojaTrabajo.Text);
                if (objHT.obtenerCantidadProductosHojaTrabajo() == 0)
                {
                    if (MessageBox.Show("No hay productos asignados a la hoja de trabajo.\n Si cierra esta ventana, se eliminará la hoja de trabajo. \n ¿Desea cerrar la ventana?", "VERIFICAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objHT.eliminarHT())
                        {
                            MessageBox.Show("Se ha eliminado la hoja de trabajo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmMenu menu = new frmMenu();
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al eliminar hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("No se eliminará la hoja de trabajo, agrege productos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    frmMenu menu = new frmMenu();
                    menu.Show();
                    this.Hide();
                }
            }                 
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HojasTrabajo_Load(object sender, EventArgs e)
        {
            dtpFechaSalida.MinDate = DateTime.Today;
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            deshabilitarCamposDetalleHojaTrabajo();
            objOC.llenarComboBoxAsesores(cmbAsesor);
            if (cmbAsesor.Items.Count == 0)
            {
                MessageBox.Show("No hay asesores registrados", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void limpiarCamposHojaTrabajo()
        {
            txtCliente.Clear();
            txtCodigoHoja.Clear();
            txtObservacion.Clear();
        }

        public void deshabilitarCamposHojaTrabajo()
        {
            txtCliente.Enabled = false;
            txtCodigoHoja.Enabled = false;
            txtObservacion.Enabled = false;
            cmbAsesor.Enabled = false;
            dtpFechaSalida.Enabled = false;
            btnAgregaHT.Enabled = false;
        }

        public void habilitarCamposHojaTrabajo()
        {
            txtCliente.Enabled = true;
            txtCodigoHoja.Enabled = true;
            txtObservacion.Enabled = true;
            cmbAsesor.Enabled = true;
            dtpFechaSalida.Enabled = true;
            btnAgregaHT.Enabled = true;
        }

        public void deshabilitarCamposDetalleHojaTrabajo()
        {
            txtCodigoProducto.Enabled = false;
            txtNombreProducto.Enabled = false;
            txtCantidad.Enabled = false;
            txtDescripcion.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnEliminarProducto.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnActualizarDetalleHoja.Enabled = false;
            btnCerrarDetalle.Enabled = false;
        }

        public void habilitarCamposDetalleHojaTrabajo()
        {
            txtCodigoProducto.Enabled = true;
            txtNombreProducto.Enabled = true;
            txtCantidad.Enabled = true;
            txtDescripcion.Enabled = true;
            btnAgregarProducto.Enabled = true;
            btnEliminarProducto.Enabled = true;
            btnLimpiarCampos.Enabled = true;
            btnActualizarDetalleHoja.Enabled = true;
            btnCerrarDetalle.Enabled = true;
        }

        public void limpiarCamposDetalleHojaTrabajo()
        {
            txtCodigoProducto.Clear();
            txtNombreProducto.Clear();
            txtCantidad.Clear();
            txtDescripcion.Clear();
            idDetalleHT = 0;
        }

        int idAsesor = 0;
        private void btnAgregaHT_Click(object sender, EventArgs e)
        {
            if(cmbAsesor.SelectedIndex >= 0)
            {
                if(txtCliente.Text.Trim() != "")
                {
                    if(txtCodigoHoja.Text.Trim() != "")
                    {
                        if(dtpFechaSalida.Value != null)
                        {
                            Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                            objHT.IdAsesor = Convert.ToInt32(idAsesor);
                            objHT.Cliente = txtCliente.Text.Trim();
                            objHT.FechaSalida = dtpFechaSalida.Value;
                            objHT.CodigoHoja = txtCodigoHoja.Text.Trim();
                            objHT.Observacion = txtObservacion.Text;
                            if(txtObservacion.Text == "")
                            {
                                objHT.Observacion = "No se ha añadido observación";
                            }
                            else
                            {
                                objHT.Observacion = txtObservacion.Text;
                            }

                            if(objHT.obtenerCodigoHojaTrabajo() == 0)
                            {
                                if (objHT.agregarHojaTrabajo())
                                {
                                    limpiarCamposHojaTrabajo();
                                    deshabilitarCamposHojaTrabajo();
                                    MessageBox.Show("Hoja de trabajo registrada correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblCodigoHojaTrabajo.Text = objHT.obtenerUltimaHT().ToString();
                                    habilitarCamposDetalleHojaTrabajo();
                                    estadoCerrar = 1;
                                }
                                else
                                {
                                    MessageBox.Show("Error al agregar hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El código de la hoja de trabajo ya se encuetra registrado", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }                                
                        }
                        else
                        {
                            MessageBox.Show("Debe de seleccionar fecha de salida", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar código de hoja", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar cliente", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar asesor", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificarHT_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarHT_Click(object sender, EventArgs e)
        {

        }

        private void cmbAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Nombre_asesor = cmbAsesor.SelectedItem.ToString();
            idAsesor = objOC.obtenerIdAsesor();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            limpiarCamposDetalleHojaTrabajo();
            idDetalleHT = 0;
        }

        public void cargarTablaDetalleHT()
        {
            int idHT = Convert.ToInt32(lblCodigoHojaTrabajo.Text);
            Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
            dgvProductosDetalleHojaTrabajo.DataSource = objHT.mostrarDetallesHT(idHT);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(lblCodigoHojaTrabajo.Text) > 0)
            {
                if(txtCodigoProducto.Text.Trim() != "")
                {
                    if(txtNombreProducto.Text.Trim() != "")
                    {
                        if(txtCantidad.Text.Trim() != "")
                        {
                            Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                            objHT.CodigoProducto = txtCodigoProducto.Text.Trim().ToUpper();
                            objHT.NombreProducto = txtNombreProducto.Text;
                            objHT.Cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
                            if(txtDescripcion.Text == "")
                            {
                                objHT.Descripcion = "No se ha añadido descripción";
                            }
                            else
                            {
                                objHT.Descripcion = txtDescripcion.Text;
                            }                            
                            objHT.CodigoHoja = lblCodigoHojaTrabajo.Text;                            
                            
                            if(objHT.obtenerProductoDetalleHT().Trim() == txtCodigoProducto.Text.Trim())
                            {
                                if (MessageBox.Show("El producto que desea agregar ya se encuentra en la hoja de trabajo, ¿Desea actualizar la cantidad de producto?", "VERIFICAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    int cantidadActual = objHT.obtenerCantidadProductoDetalleHT();
                                    if (cantidadActual > 0) //Verificar que ya existe una cantidad de producto anteriormente registrada
                                    {
                                        int cantidadIngresada = Convert.ToInt32(txtCantidad.Text);
                                        int cantidadTotal = cantidadActual + cantidadIngresada;

                                        objHT.Cantidad = cantidadTotal;
                                        if (objHT.actualizarCantidadProductoDetalleHT())
                                        {
                                            MessageBox.Show("Se ha actualizado la cantidad de producto", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cargarTablaDetalleHT();
                                            limpiarCamposDetalleHojaTrabajo();
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
                                    MessageBox.Show("No se actualizará la cantidad de producto, continue...", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (objHT.agregarDetalleHT())
                                {
                                    limpiarCamposDetalleHojaTrabajo();
                                    MessageBox.Show("Producto añadido correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    estadoCerrar = 0;
                                    cargarTablaDetalleHT();
                                }
                                else
                                {
                                    MessageBox.Show("Error al agregar producto, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }                           
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar cantidad de producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar nombre del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar código de producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay código de hoja de trabajo asignado", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        int idDetalleHT = 0;
        private void dgvProductosDetalleHojaTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow row = dgvProductosDetalleHojaTrabajo.CurrentRow;
            if (row == null)
                return;*/
            try
            {
                idDetalleHT = Convert.ToInt32(dgvProductosDetalleHojaTrabajo.Rows[e.RowIndex].Cells[0].Value.ToString().TrimEnd());
                txtCodigoProducto.Text = dgvProductosDetalleHojaTrabajo.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNombreProducto.Text = dgvProductosDetalleHojaTrabajo.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCantidad.Text = dgvProductosDetalleHojaTrabajo.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDescripcion.Text = dgvProductosDetalleHojaTrabajo.Rows[e.RowIndex].Cells[4].Value.ToString();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(idDetalleHT != 0)
            {
                if(MessageBox.Show("¿Desea eliminar el producto seleccionado?,no se podrá recuperar la información", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                    if (objHT.eliminarDetalleHT(idDetalleHT))
                    {
                        limpiarCamposDetalleHojaTrabajo();
                        MessageBox.Show("Se ha eliminado el producto", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cargarTablaDetalleHT();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al eliminar el producto, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                else
                {
                    MessageBox.Show("No se eliminará el producto, continue...", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un producto de la hoja de trabajo para poder eliminar", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void limpiarTablaDetalleHT()
        {
            dgvProductosDetalleHojaTrabajo.DataSource = "";
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea cerrar la hoja de trabajo?, ya no se podrán modificar los productos", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                estadoCerrar = 0;
                limpiarCamposDetalleHojaTrabajo();
                deshabilitarCamposDetalleHojaTrabajo();
                habilitarCamposHojaTrabajo();
                limpiarCamposDetalleHojaTrabajo();
                limpiarTablaDetalleHT();
                lblCodigoHojaTrabajo.Text = "--";
            }
            else
            {
                MessageBox.Show("No se cerrará el detalle de hoja de trabajo, continue agregando productos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnActualizarDetalleHoja_Click(object sender, EventArgs e)
        {
            if(lblCodigoHojaTrabajo.Text != "--")
            {
                if(txtCodigoProducto.Text != "")
                {
                    if(txtNombreProducto.Text != "")
                    {
                        if(txtCantidad.Text != "")
                        {
                            if(Convert.ToInt32(txtCantidad.Text) > 0)
                            {
                                Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                                objHT.CodigoProducto = txtCodigoProducto.Text.ToUpper();
                                objHT.NombreProducto = txtNombreProducto.Text;
                                objHT.Cantidad = Convert.ToInt32(txtCantidad.Text);
                                objHT.Descripcion = txtDescripcion.Text;
                                objHT.IdDetalleHT = idDetalleHT;

                                if (objHT.actualizarDetalleHT())
                                {
                                    MessageBox.Show("Se ha actualizado el producto", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpiarCamposDetalleHojaTrabajo();
                                    cargarTablaDetalleHT();
                                }
                                else
                                {
                                    MessageBox.Show("Error al actualizar detalle de hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de producto debe de ser mayor a cero", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar cantidad del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar nombre del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar un código del producto", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe de existir una hoja de trabajo asignada", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.Validaciones objValidaciones = new Clases.Validaciones();
            objValidaciones.validarSoloNumeros(e);
        }
    }
}
