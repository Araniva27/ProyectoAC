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
    public partial class CartaProductoHojaTrabajo : UserControl
    {
        public CartaProductoHojaTrabajo()
        {
            InitializeComponent();
        }

        private string _codigoProducto;
        private string _nombreProducto;
        private int _cantidad;
        private string _descripcion;
        private int _estadoEntrada;
        private int _idDetalleHT;
        private int _idHojaTrabajo;

        public string CodigoProducto
        {
            get { return _codigoProducto; }
            set { _codigoProducto = value; lblCodigoProducto.Text = value; }
        }
        
        public  string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; lblNombreProducto.Text = value; }
        }
        
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; lblCantidad.Text = value.ToString(); }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; lblDescripción.Text = value; }
        }

        public int EstadoEntrada
        {
            get { return _estadoEntrada; }
            set
            {
                _estadoEntrada = value;

                if (_estadoEntrada == 0)
                {
                    panelIndicador.BackColor = Color.Yellow;
                }

                if (_estadoEntrada == 1)
                {
                    panelIndicador.BackColor = Color.Green;
                    btnMarcarReingreso.Hide();
                }
            }

        }
        
        public int IdDetalleHT
        {
            get { return _idDetalleHT; }
            set { _idDetalleHT = value; }
        }

        public int IdHojaTrabajo
        {
            get { return _idHojaTrabajo; }
            set { _idHojaTrabajo = value; }
        }



        private void lblDescripción_Click(object sender, EventArgs e)
        {

        }

        private void btnMarcarReingreso_Click(object sender, EventArgs e)
        {
            Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
            objHT.IdDetalleHT = _idDetalleHT;
            if(MessageBox.Show("¿Desea marcar como entregado el producto?", "ÉXITO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (objHT.entregarProductoHojaTrabajo())
                {
                    MessageBox.Show("Se ha entregado el producto exitosamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelIndicador.BackColor = Color.Green;
                    btnMarcarReingreso.Hide();
                    objHT.IdHoja = _idHojaTrabajo;
                    if(objHT.cantidadProductoPendienteEntregaHT() == 0)
                    {
                        if (objHT.finalizarHT())
                        {
                            MessageBox.Show("Se han entregado todos los productos de la hoja de trabajo, se marcó como finaalizada", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al finalizar la hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                   
                }
                else
                {
                    MessageBox.Show("Error al marcar el producto como ingresado, comuniquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se marcará como entregado el producto", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                
        }
    }
}
