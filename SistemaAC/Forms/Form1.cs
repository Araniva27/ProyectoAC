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

namespace AutoControl
{
    public partial class frmMenu : Form
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


        public frmMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAsesores_Click(object sender, EventArgs e)
        {
            Forms.frmAsesores asesores = new Forms.frmAsesores();
            asesores.Show();
            this.Hide();


        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            Forms.OrdenesCompra oc = new Forms.OrdenesCompra();
            oc.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHojasTrabajo_Click(object sender, EventArgs e)
        {
            Forms.HojasTrabajo ht = new Forms.HojasTrabajo();
            ht.Show();
            this.Hide();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Clases.OrdenesCompra objOC = new OrdenesCompra();
            int cantidad = objOC.obtenerCantidadOCPendientes();
            lblCantidad.Text = Convert.ToString(cantidad);
        }

        private void btnControlOrdenes_Click(object sender, EventArgs e)
        {
            Forms.ControlOrdenes frmCO = new Forms.ControlOrdenes();
            frmCO.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnControlHojasTrabajo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.ControlHojasTrabajo frmHojasTrabajo = new Forms.ControlHojasTrabajo();
            frmHojasTrabajo.Show();
        }

        private void picInformacion_Click(object sender, EventArgs e)
        {
            Forms.Informacion frmInfo = new Forms.Informacion();
            frmInfo.Show();
            this.Hide();
        }
    }
}
