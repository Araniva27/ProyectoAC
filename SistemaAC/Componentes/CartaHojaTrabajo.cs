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
    public partial class CartaHojaTrabajo : UserControl
    {
        public CartaHojaTrabajo()
        {
            InitializeComponent();
        }

        private int _idHt;
        private string _cliente;
        private DateTime _fechaSalida;
        private string _codigoHoja;
        private string _observacion;
        private int _colorIndicador;
        private DateTime _fechaRegistro;
        private string _asesor;

        [Category("Custom props")]
        public int IdHt
        {
            get { return _idHt; }
            set { _idHt = value; }
        }

        [Category("Custom props")]
        public  string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; lblCliente.Text = value; }
        }

        [Category("Custom props")]
        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set { _fechaSalida = value; lblFechaSalida.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public string CodigoHoja
        {
            get { return _codigoHoja; }
            set { _codigoHoja = value; lblCodigoHT.Text = value; }
        }

        [Category("Custom props")]
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        [Category("Custom props")]
        public int ColorIndicador
        {
            get { return _colorIndicador; }
            set { _colorIndicador = value; 
                if(_colorIndicador == 1)
                {
                    panelIndicador.BackColor = Color.Yellow;
                }
                else
                {
                    panelIndicador.BackColor = Color.Red;
                }
            }
        }

        [Category("Custom props")]
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; lblFechaRegistro.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public string Asesor
        {
            get { return _asesor; }
            set { _asesor = value; lblAsesor.Text = value; }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizarHT_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea finalizar la hoja de trabajo?", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Clases.HojaTrabajo objHT = new Clases.HojaTrabajo();
                objHT.IdHoja = IdHt;
                if (objHT.finalizarHT())
                {                    
                    if (objHT.entregarProductosHT())
                    {
                        MessageBox.Show("Hoja de trabajo finalizada correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al entregar productos de la hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al finalizar hoja de trabajo, comuníquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se finalizará la hoja de trabajo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetallesHT_Click(object sender, EventArgs e)
        {
            Forms.DetalleHojaTrabajocs frmDetalleHT = new Forms.DetalleHojaTrabajocs(_idHt);
            frmDetalleHT.Show();
            ParentForm.Hide();
        }
    }
}
