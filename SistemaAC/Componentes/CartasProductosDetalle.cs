using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoControl.Componentes
{
    public partial class CartasProductosDetalle : UserControl
    {
        public CartasProductosDetalle()
        {
            InitializeComponent();
        }

        private string _codigoProducto;
        private int _cantidadProducto;
        private string _descripcion;
        private string _nombreProducto;
        private int _idOC;
        private int _colorIndicador;

        [Category("Custom props")]
        public string CodigoProducto
        {
            get { return _codigoProducto; }
            set { _codigoProducto = value; lblCódigoProducto.Text = value; }
        }

        [Category("Custom props")]
        public int CantidadProducto
        {
            get { return _cantidadProducto; }
            set { _cantidadProducto = value; lblCantidad.Text = Convert.ToString(value); }
        }

        [Category("Custom props")]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; lblDescricpcion.Text = value; }
        }

        [Category("Custom props")]
        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; lblNombreProducto.Text = value; }
        }

        [Category("Custom props")]
        public int IdOC
        {
            get { return _idOC; }
            set { _idOC = value; }
        }

        [Category("Custom props")]
        public int ColorIndicador
        {
            get { return _colorIndicador; }
            set { _colorIndicador = value; 
                if(_colorIndicador == 1)
                {
                    panelIndicador.BackColor = Color.Green;
                    btnEntregarProducto.Hide();
                }
                else
                {
                    panelIndicador.BackColor = Color.Yellow;
                }
            }
        }



        private void CartasProductosDetalle_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnEntregarProducto_Click(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Id_orden_compra = IdOC;
            objOC.Codigo_producto = CodigoProducto;
            if (objOC.actualizarEstadoEntregaProducto())
            {
                MessageBox.Show("Se ha marcado como entregado el producto", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ColorIndicador = 1;
                btnEntregarProducto.Hide();
                if(objOC.obtenerCantidadProductoPendienteEntrega() == 0)
                {
                    if (objOC.finalizarOrdenCompra())
                    {
                        MessageBox.Show("Se ha entregado todos los productos de la orden de compra, se ha finalizado la orden de compra", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al finalizar la orden de compra, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Error al marcar como entregado el producto, comuníquese con el administriador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
