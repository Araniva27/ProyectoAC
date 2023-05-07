using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
//using iTextSharp.text.pdf;
using System.Drawing;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Colors;
using iText.Layout.Borders;

namespace AutoControl
{
    public partial class CartasOrdenesCompraFinalizadas : UserControl
    {
        public CartasOrdenesCompraFinalizadas()
        {
            InitializeComponent();
        }


        private string _asesor;
        private string _cliente;
        private string _numRequerimiento;
        private DateTime _fechaPropuesta;
        private DateTime _fechaFinalizacion;
        private string _numeroOC;
        private int _idOC;

        public string Asesor
        {
            get { return _asesor; }
            set { _asesor = value; lblAsesor.Text = value; }
        }

        
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; lblEmpresa.Text = value; }
        }

        
        public string NumRequerimiento
        {
            get { return _numRequerimiento; }
            set { _numRequerimiento = value; lblNumRequerimiento.Text = value; }
        }

        

        public DateTime FechaPropuesta
        {
            get { return _fechaPropuesta; }
            set { _fechaPropuesta = value;  lblFechaPropuesta.Text = Convert.ToString(value); }
        }

        
        public DateTime FechaFinalizacion
        {
            get { return _fechaFinalizacion; }
            set { _fechaFinalizacion = value; lblFechaFinalizacion.Text = Convert.ToString(value); }
        }

        
        public string NumeroOC
        {
            get { return _numeroOC; }
            set { _numeroOC = value; lblNumOC.Text = Convert.ToString(value); }
        }
        

        public int IDOC
        {
            get { return _idOC; }
            set { _idOC = value; }
        }


        private void CartasOrdenesCompraFinalizadas_Load(object sender, EventArgs e)
        {

        }

        private void crearPDF(int idOC)
        {
            PdfWriter pdfWriter = new PdfWriter(direccion);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(20, 20, 55, 20);

            Paragraph header = new Paragraph("Reporte \"Orden de compra finalizada\" ")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(16);
            LineSeparator ls = new LineSeparator(new SolidLine());
            
            Table tablaDatos = new Table(1).UseAllAvailableWidth();
            /* Cell celda1 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
                .Add(new Paragraph("Asesor: "));
             Cell celda2 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
               .Add(new Paragraph("Cliente: "));
             Cell celda3 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
              .Add(new Paragraph("Número orden de compra: "));
             Cell celda4 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
             .Add(new Paragraph("Fecha finalización: "));
             Cell celda5 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
             .Add(new Paragraph("Número de requerimiento: "));
             Cell celda6 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER)
             .Add(new Paragraph("Fecha de creación de reporte: "));*/
             LineSeparator ls2 = new LineSeparator(new SolidLine());

            Clases.OrdenesCompra objOC = new Clases.OrdenesCompra();
            objOC.Id_orden_compra = idOC;
            objOC.obtenerDatosOC(tablaDatos);

            Table tabla = new Table(4).UseAllAvailableWidth().SetMarginTop(10);
            Cell celdaTabla1 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Producto")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla2 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Cantidad")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla3 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Descripción")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);
            Cell celdaTabla4 = new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11)
              .Add(new Paragraph("Nombre del producto")).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE);


            Clases.OrdenesCompra objOC2 = new Clases.OrdenesCompra();
            objOC2.Id_orden_compra = idOC;
            objOC2.obtenerDetallesOC(tabla);            

            documento.Add(header);           
            documento.Add(ls);
            /* tablaDatos.AddCell(celda1);
             tablaDatos.AddCell(celda2);
             tablaDatos.AddCell(celda3);
             tablaDatos.AddCell(celda4);
             tablaDatos.AddCell(celda5);
             tablaDatos.AddCell(celda6);*/
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

            /* Paragraph header = new Paragraph("Reporte orden de compra")
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetFontSize(20);

             LineSeparator ls = new LineSeparator(new SolidLine());

             Paragraph numeroOC = new Paragraph("Número orden de compra: " + 16)
                  .SetTextAlignment(TextAlignment.LEFT)
                  .SetFontSize(15);

             documento.Add(header);
             documento.Add(ls);
             documento.Add(numeroOC);*/
            documento.Close();

        }

        string direccion = "";
        
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            sfdGuardarPDF.FileName = "Reporte orden de compra";
            if (sfdGuardarPDF.ShowDialog() == DialogResult.OK)
            {
                direccion = sfdGuardarPDF.FileName;                              
                crearPDF(IDOC);
                MessageBox.Show("Se ha creado el PDF de la orden de compra exitosamente", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
    }
}
