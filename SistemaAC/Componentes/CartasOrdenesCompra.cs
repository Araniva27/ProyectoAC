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
    public partial class CartasOrdenesCompra : UserControl
    {
        public CartasOrdenesCompra()
        {
            InitializeComponent();
        }

        #region Properties

        private string _numeroOC;
        private string _cliente;
        private string _numeroRequerimiento;
        private string _asesor;
        private DateTime _fechaPropuesta;
        private int _colorIndicador;
        private int _diasRestantes;
        private int _idOC;
        private int _productosOC;
        private int _productosPendientesOC;

        [Category("Custom props")]
        public string NumeroOC
        {
            get { return _numeroOC; }
            set { _numeroOC = value; lblNumeroOC.Text = value; }
        }

        [Category("Custom props")]
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; lblEmpresa.Text = value; }
        }

        [Category("Custom props")]
        public string NumeroRequerimiento
        {
            get { return _numeroRequerimiento; }
            set { _numeroRequerimiento = value; lblNumeroR.Text = value; }
        }

        [Category("Custom props")]
        public string Asesor
        {
            get { return _asesor; }
            set { _asesor = value; lblAsesor.Text = value; }
        }

        [Category("Custom props")]
        public DateTime FechaPropuesta
        {
            get { return _fechaPropuesta; }
            set { _fechaPropuesta = value;
                lblFechaPropuesta.Text = Convert.ToString(value);
            }
        }
        
        [Category("Custom props")]
        public int ColorIndicador
        {
            get { return _colorIndicador; }
            set { _colorIndicador = value; 
                if(_colorIndicador == 1)
                {
                    panelIndicador.BackColor = Color.Yellow;
                }else if(_colorIndicador == 2)
                {
                    panelIndicador.BackColor = Color.Red;
                }
                else
                {
                    panelIndicador.BackColor = Color.Blue;
                }
            }
        }
        
        [Category("Custom props")]
        public int DiasRestantes
        {
            get { return _diasRestantes; }
            set { _diasRestantes = value; 
                if(value >= 0)
                {
                    lblDiasR.Text = Convert.ToString(value);
                }
                else
                {
                    int diasR = Math.Abs(value);
                    if (diasR == 1)
                    {
                        lblDiasR.Text = "La orden de compra esta retrasada " + diasR + " día";
                    }
                    else
                    {
                        lblDiasR.Text = "La orden de compra esta retrasada " + diasR + " días";
                    }                    
                }               
            }
        }

        [Category("Custom props")]
        public int IdOC
        {
            get { return _idOC; }
            set { _idOC = value; }
        }

        
        public int ProductosOC
        {
            get { return _productosOC; }
            set { _productosOC = value; }
        }

        [Category("Custom props")]
        public int ProductosPendientesOC
        {
            get { return _productosPendientesOC; }
            set { _productosPendientesOC = value; }
        }


        #endregion


        private void btnDetallesOC_Click(object sender, EventArgs e)
        {
            Forms.DetalleOrdenCompra frmDetalleOC = new Forms.DetalleOrdenCompra(_idOC);
            frmDetalleOC.Show();
            ParentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea finalizar la orden de compra?", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
                objOC.Id_orden_compra = _idOC;
                if (objOC.finalizarOrdenCompra())
                {
                    if (objOC.entregarTodosProductosOC())
                    {
                        MessageBox.Show("Orden de compra finalizada", "INFORMARCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Forms.ControlOrdenes frmControlOC = new Forms.ControlOrdenes();
                        frmControlOC.actualizarCartas();
                    }
                    else
                    {
                        MessageBox.Show("Error al entregar productos de la orden de compra, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                                           
                }
                else
                {
                    MessageBox.Show("Error al finalizar orden de compra, comuniquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se finalizará la orden de compra", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
    }
}
