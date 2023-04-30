
namespace AutoControl.Forms
{
    partial class DetalleOrdenCompra
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleOrdenCompra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCerrarFormulario = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblClienteDetalle = new System.Windows.Forms.Label();
            this.lblAsesoresDetalle = new System.Windows.Forms.Label();
            this.dtpFechaPropuestaDetalle = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarOC = new System.Windows.Forms.Button();
            this.btnActualizarOC = new System.Windows.Forms.Button();
            this.lblFechaRecordatorioDetalle = new System.Windows.Forms.Label();
            this.txtNumRequerimientoDetalle = new System.Windows.Forms.TextBox();
            this.txtNumOCDetalle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCerrarFormulario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.picMinimizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picCerrarFormulario);
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 95);
            this.panel1.TabIndex = 1;
            // 
            // picMinimizar
            // 
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = global::AutoControl.Properties.Resources.icons8_menos_100;
            this.picMinimizar.Location = new System.Drawing.Point(1044, 21);
            this.picMinimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(52, 50);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimizar.TabIndex = 7;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalle orden compra";
            // 
            // picCerrarFormulario
            // 
            this.picCerrarFormulario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCerrarFormulario.Image = global::AutoControl.Properties.Resources.icons8_eliminar_100;
            this.picCerrarFormulario.Location = new System.Drawing.Point(1101, 21);
            this.picCerrarFormulario.Name = "picCerrarFormulario";
            this.picCerrarFormulario.Size = new System.Drawing.Size(46, 50);
            this.picCerrarFormulario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCerrarFormulario.TabIndex = 1;
            this.picCerrarFormulario.TabStop = false;
            this.picCerrarFormulario.Click += new System.EventHandler(this.picCerrarFormulario_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblClienteDetalle);
            this.groupBox1.Controls.Add(this.lblAsesoresDetalle);
            this.groupBox1.Controls.Add(this.dtpFechaPropuestaDetalle);
            this.groupBox1.Controls.Add(this.btnEliminarOC);
            this.groupBox1.Controls.Add(this.btnActualizarOC);
            this.groupBox1.Controls.Add(this.lblFechaRecordatorioDetalle);
            this.groupBox1.Controls.Add(this.txtNumRequerimientoDetalle);
            this.groupBox1.Controls.Add(this.txtNumOCDetalle);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 673);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de orden de compra";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(187, 397);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(276, 204);
            this.txtObservacion.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 397);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Observaciones:";
            // 
            // lblClienteDetalle
            // 
            this.lblClienteDetalle.AutoSize = true;
            this.lblClienteDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDetalle.Location = new System.Drawing.Point(183, 117);
            this.lblClienteDetalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClienteDetalle.Name = "lblClienteDetalle";
            this.lblClienteDetalle.Size = new System.Drawing.Size(19, 20);
            this.lblClienteDetalle.TabIndex = 32;
            this.lblClienteDetalle.Text = "--";
            // 
            // lblAsesoresDetalle
            // 
            this.lblAsesoresDetalle.AutoSize = true;
            this.lblAsesoresDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsesoresDetalle.Location = new System.Drawing.Point(183, 65);
            this.lblAsesoresDetalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAsesoresDetalle.Name = "lblAsesoresDetalle";
            this.lblAsesoresDetalle.Size = new System.Drawing.Size(19, 20);
            this.lblAsesoresDetalle.TabIndex = 31;
            this.lblAsesoresDetalle.Text = "--";
            // 
            // dtpFechaPropuestaDetalle
            // 
            this.dtpFechaPropuestaDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPropuestaDetalle.Location = new System.Drawing.Point(187, 221);
            this.dtpFechaPropuestaDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaPropuestaDetalle.Name = "dtpFechaPropuestaDetalle";
            this.dtpFechaPropuestaDetalle.Size = new System.Drawing.Size(281, 26);
            this.dtpFechaPropuestaDetalle.TabIndex = 10;
            this.dtpFechaPropuestaDetalle.ValueChanged += new System.EventHandler(this.dtpFechaPropuestaDetalle_ValueChanged);
            // 
            // btnEliminarOC
            // 
            this.btnEliminarOC.Location = new System.Drawing.Point(258, 620);
            this.btnEliminarOC.Name = "btnEliminarOC";
            this.btnEliminarOC.Size = new System.Drawing.Size(210, 30);
            this.btnEliminarOC.TabIndex = 30;
            this.btnEliminarOC.Text = "Eliminar orden de compra";
            this.btnEliminarOC.UseVisualStyleBackColor = true;
            this.btnEliminarOC.Click += new System.EventHandler(this.btnEliminarOC_Click);
            // 
            // btnActualizarOC
            // 
            this.btnActualizarOC.Location = new System.Drawing.Point(19, 620);
            this.btnActualizarOC.Name = "btnActualizarOC";
            this.btnActualizarOC.Size = new System.Drawing.Size(210, 30);
            this.btnActualizarOC.TabIndex = 29;
            this.btnActualizarOC.Text = "Actualizar datos";
            this.btnActualizarOC.UseVisualStyleBackColor = true;
            this.btnActualizarOC.Click += new System.EventHandler(this.btnActualizarOC_Click);
            // 
            // lblFechaRecordatorioDetalle
            // 
            this.lblFechaRecordatorioDetalle.AutoSize = true;
            this.lblFechaRecordatorioDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRecordatorioDetalle.Location = new System.Drawing.Point(183, 280);
            this.lblFechaRecordatorioDetalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaRecordatorioDetalle.Name = "lblFechaRecordatorioDetalle";
            this.lblFechaRecordatorioDetalle.Size = new System.Drawing.Size(19, 20);
            this.lblFechaRecordatorioDetalle.TabIndex = 28;
            this.lblFechaRecordatorioDetalle.Text = "--";
            // 
            // txtNumRequerimientoDetalle
            // 
            this.txtNumRequerimientoDetalle.Enabled = false;
            this.txtNumRequerimientoDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRequerimientoDetalle.Location = new System.Drawing.Point(187, 330);
            this.txtNumRequerimientoDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumRequerimientoDetalle.Name = "txtNumRequerimientoDetalle";
            this.txtNumRequerimientoDetalle.Size = new System.Drawing.Size(276, 26);
            this.txtNumRequerimientoDetalle.TabIndex = 27;
            // 
            // txtNumOCDetalle
            // 
            this.txtNumOCDetalle.Enabled = false;
            this.txtNumOCDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOCDetalle.Location = new System.Drawing.Point(187, 162);
            this.txtNumOCDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumOCDetalle.Name = "txtNumOCDetalle";
            this.txtNumOCDetalle.Size = new System.Drawing.Size(276, 26);
            this.txtNumOCDetalle.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 280);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Fecha recordatorio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "N° de Requerimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 221);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fecha propuesta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "N° Orden de compra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Asesor:";
            // 
            // flpProductos
            // 
            this.flpProductos.AutoScroll = true;
            this.flpProductos.Location = new System.Drawing.Point(567, 136);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Size = new System.Drawing.Size(577, 650);
            this.flpProductos.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(563, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Productos de la orden de compra";
            // 
            // DetalleOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 797);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flpProductos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleOrdenCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetalleOrdenCompra";
            this.Load += new System.EventHandler(this.DetalleOrdenCompra_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCerrarFormulario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCerrarFormulario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumRequerimientoDetalle;
        private System.Windows.Forms.TextBox txtNumOCDetalle;
        private System.Windows.Forms.Label lblFechaRecordatorioDetalle;
        private System.Windows.Forms.Button btnEliminarOC;
        private System.Windows.Forms.Button btnActualizarOC;
        private System.Windows.Forms.DateTimePicker dtpFechaPropuestaDetalle;
        private System.Windows.Forms.Label lblAsesoresDetalle;
        private System.Windows.Forms.Label lblClienteDetalle;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picMinimizar;
    }
}