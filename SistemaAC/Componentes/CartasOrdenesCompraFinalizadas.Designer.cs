
namespace AutoControl
{
    partial class CartasOrdenesCompraFinalizadas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.lblNumOC = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblNumRequerimiento = new System.Windows.Forms.Label();
            this.lblAsesor = new System.Windows.Forms.Label();
            this.lblFechaPropuesta = new System.Windows.Forms.Label();
            this.lblFechaFinalizacion = new System.Windows.Forms.Label();
            this.sfdGuardarPDF = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-3, -3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(38, 309);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Número de requerimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha de finalización:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha propuesta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Empresa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Número de orden compra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Asesor:";
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDF.Location = new System.Drawing.Point(202, 229);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(169, 48);
            this.btnGenerarPDF.TabIndex = 9;
            this.btnGenerarPDF.Text = "Generar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // lblNumOC
            // 
            this.lblNumOC.AutoSize = true;
            this.lblNumOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOC.Location = new System.Drawing.Point(264, 21);
            this.lblNumOC.Name = "lblNumOC";
            this.lblNumOC.Size = new System.Drawing.Size(19, 20);
            this.lblNumOC.TabIndex = 10;
            this.lblNumOC.Text = "--";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(264, 55);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(19, 20);
            this.lblEmpresa.TabIndex = 11;
            this.lblEmpresa.Text = "--";
            // 
            // lblNumRequerimiento
            // 
            this.lblNumRequerimiento.AutoSize = true;
            this.lblNumRequerimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRequerimiento.Location = new System.Drawing.Point(264, 87);
            this.lblNumRequerimiento.Name = "lblNumRequerimiento";
            this.lblNumRequerimiento.Size = new System.Drawing.Size(19, 20);
            this.lblNumRequerimiento.TabIndex = 12;
            this.lblNumRequerimiento.Text = "--";
            // 
            // lblAsesor
            // 
            this.lblAsesor.AutoSize = true;
            this.lblAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsesor.Location = new System.Drawing.Point(264, 120);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(19, 20);
            this.lblAsesor.TabIndex = 13;
            this.lblAsesor.Text = "--";
            // 
            // lblFechaPropuesta
            // 
            this.lblFechaPropuesta.AutoSize = true;
            this.lblFechaPropuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPropuesta.Location = new System.Drawing.Point(264, 153);
            this.lblFechaPropuesta.Name = "lblFechaPropuesta";
            this.lblFechaPropuesta.Size = new System.Drawing.Size(19, 20);
            this.lblFechaPropuesta.TabIndex = 14;
            this.lblFechaPropuesta.Text = "--";
            // 
            // lblFechaFinalizacion
            // 
            this.lblFechaFinalizacion.AutoSize = true;
            this.lblFechaFinalizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinalizacion.Location = new System.Drawing.Point(264, 194);
            this.lblFechaFinalizacion.Name = "lblFechaFinalizacion";
            this.lblFechaFinalizacion.Size = new System.Drawing.Size(19, 20);
            this.lblFechaFinalizacion.TabIndex = 15;
            this.lblFechaFinalizacion.Text = "--";
            // 
            // sfdGuardarPDF
            // 
            this.sfdGuardarPDF.Filter = "Archivos PDF(*.pdf)|*.pdf";
            // 
            // CartasOrdenesCompraFinalizadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblFechaFinalizacion);
            this.Controls.Add(this.lblFechaPropuesta);
            this.Controls.Add(this.lblAsesor);
            this.Controls.Add(this.lblNumRequerimiento);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblNumOC);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CartasOrdenesCompraFinalizadas";
            this.Size = new System.Drawing.Size(627, 304);
            this.Load += new System.EventHandler(this.CartasOrdenesCompraFinalizadas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Label lblNumOC;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblNumRequerimiento;
        private System.Windows.Forms.Label lblAsesor;
        private System.Windows.Forms.Label lblFechaPropuesta;
        private System.Windows.Forms.Label lblFechaFinalizacion;
        private System.Windows.Forms.SaveFileDialog sfdGuardarPDF;
    }
}
