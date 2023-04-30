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
    public partial class DetalleOrdenCompra : Form
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

        int idOCG = 0;
        public DetalleOrdenCompra(int idOC)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Forms.ControlOrdenes frmControlOrdenes = new Forms.ControlOrdenes();
            frmControlOrdenes.Hide();
            idOCG = idOC;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picCerrarFormulario_Click(object sender, EventArgs e)
        {
            ControlOrdenes frmControlOC = new ControlOrdenes();
            frmControlOC.Show();
            this.Hide();
        }

        private void DetalleOrdenCompra_Load(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Id_orden_compra = idOCG;
            objOC.obtenerOC(lblClienteDetalle, txtNumOCDetalle, dtpFechaPropuestaDetalle, lblFechaRecordatorioDetalle, txtNumRequerimientoDetalle, lblAsesoresDetalle, txtObservacion);
            dtpFechaPropuestaDetalle.Format = DateTimePickerFormat.Custom;
            dtpFechaPropuestaDetalle.CustomFormat = "dd-MM-yyyy";
            dtpFechaPropuestaDetalle.MinDate = DateTime.Today;
            obtenerProductos();
        }

        public void obtenerProductos()
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Id_orden_compra = idOCG;
            objOC.obtenerProductos(flpProductos);
        }

        private void btnActualizarOC_Click(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Id_orden_compra = idOCG;
            objOC.Fecha_propuesta = dtpFechaPropuestaDetalle.Value;
            objOC.Fecha_recordatorio = fechaRecordatorio;
            objOC.Observacion = txtObservacion.Text;
            if (objOC.actualizarFechaPropuestaOC())
            {
                MessageBox.Show("Orden de compra registrada exitosamente", "INDORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar datos, comuniquese con el administrador", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int calcularDiferenciaDias()
        {
            DateTime fechaFinal = dtpFechaPropuestaDetalle.Value.Date;
            DateTime fechaActual = DateTime.Today;

            TimeSpan diferenciaFechas = fechaFinal - fechaActual;

            int dias = diferenciaFechas.Days;

            return dias;
        }

        DateTime fechaRecordatorio;
        private void dtpFechaPropuestaDetalle_ValueChanged(object sender, EventArgs e)
        {
            int mitadFechas = calcularDiferenciaDias() / 2;
            DateTime fechaPropuesta = dtpFechaPropuestaDetalle.Value.Date;
            fechaRecordatorio = fechaPropuesta.AddDays(-mitadFechas);
            lblFechaRecordatorioDetalle.Text = fechaRecordatorio.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminarOC_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea eliminar la orden de compra?, No se podrá recuperar la información", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                objOC.Id_orden_compra = idOCG;
                if (objOC.eliminarOC())
                {
                    MessageBox.Show("Orden de compra eliminada correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al eliminar orden de compra, comuniquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se eliminará la orden de compra", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
