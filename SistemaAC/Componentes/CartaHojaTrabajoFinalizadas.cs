using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AutoControl.Componentes
{
    public partial class CartaHojaTrabajoFinalizadas : UserControl
    {
        public CartaHojaTrabajoFinalizadas()
        {
            InitializeComponent();
        }

        private int _idHt;
        private string _cliente;
        private DateTime _fechaSalida;
        private string _codigoHoja;
        private string _observacion;
        private int _colorIndicador;
        private DateTime _fechaFinalizacion;
        private string _asesor;

        [Category("Custom props")]
        public int IdHt
        {
            get { return _idHt; }
            set { _idHt = value; }
        }

        [Category("Custom props")]
        public string Cliente
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
            set
            {
                _colorIndicador = value;
                if (_colorIndicador == 1)
                {
                    panelIndicador.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    panelIndicador.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        [Category("Custom props")]
        public DateTime FechaFinalizacion
        {
            get { return _fechaFinalizacion; }
            set { _fechaFinalizacion = value; lblFechaFinalizacion.Text = value.ToString(); }
        }

        [Category("Custom props")]
        public string Asesor
        {
            get { return _asesor; }
            set { _asesor = value; lblAsesor.Text = value; }
        }

        private void crearPDF(int idHT)
        {
            PdfWriter pdfWriter = new PdfWriter(direccion);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(20, 20, 55, 20);

            Paragraph header = new Paragraph("Reporte \"Hoja de trabajo finalizada\" ")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(16);
            LineSeparator ls = new LineSeparator(new SolidLine());

            Table tablaDatos = new Table(1).UseAllAvailableWidth();
           
            LineSeparator ls2 = new LineSeparator(new SolidLine());

            Clases.HojaTrabajo objOC = new Clases.HojaTrabajo();
            objOC.IdHoja = IdHt;
            objOC.obtenerDatosHT(tablaDatos);

            Table tabla = new Table(4).UseAllAvailableWidth().SetMarginTop(10);
            Cell celdaTabla1 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Código del producto")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla2 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Cantidad")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla3 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Descripción")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla4 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Nombre del producto")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);


            Clases.HojaTrabajo objOC2 = new Clases.HojaTrabajo();
            objOC2.IdHoja = idHT;
            objOC2.obtenerDetallesHT(tabla);

            documento.Add(header);
            documento.Add(ls);
            
            tabla.AddHeaderCell(celdaTabla2);
            tabla.AddHeaderCell(celdaTabla1);
            tabla.AddHeaderCell(celdaTabla4);
            tabla.AddHeaderCell(celdaTabla3);
            documento.Add(tablaDatos);
            documento.Add(ls2);
            documento.Add(tabla);

            //Número de paginas
            int numeroPaginas = pdf.GetNumberOfPages();
            for (int i = 1; i <= numeroPaginas; i++)
            {
                documento.ShowTextAligned(new Paragraph(string
                   .Format("Página " + i + " de " + numeroPaginas)),
                    580, 10, i, TextAlignment.RIGHT,
                    VerticalAlignment.BOTTOM, 0);
            }
            
            documento.Close();


        }

        string direccion = "";
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {            
            sfdGuardarPDF.FileName = "Reporte hoja de trabajo";
            if (sfdGuardarPDF.ShowDialog() == DialogResult.OK)
            {
                direccion = sfdGuardarPDF.FileName;
                crearPDF(IdHt);
                MessageBox.Show("Se ha creado el PDF de la orden de compra exitosamente", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
