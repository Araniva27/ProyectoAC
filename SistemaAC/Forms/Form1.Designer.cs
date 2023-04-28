
namespace AutoControl
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picInformacion = new System.Windows.Forms.PictureBox();
            this.btnControlHojasTrabajo = new System.Windows.Forms.Button();
            this.btnControlOrdenes = new System.Windows.Forms.Button();
            this.btnHojasTrabajo = new System.Windows.Forms.Button();
            this.btnOrdenCompra = new System.Windows.Forms.Button();
            this.btnAsesores = new System.Windows.Forms.Button();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.picCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInformacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.picMinimizar);
            this.panel1.Controls.Add(this.picCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 85);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.picMin);
            this.panel2.Controls.Add(this.picSalir);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 85);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "¡Bienvenido!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "¡Bienvenido!";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblCantidad);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(16, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(824, 35);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(166, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(515, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "órdenes de compra pendientes que estan próximas a entregar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Red;
            this.lblCantidad.Location = new System.Drawing.Point(111, -1);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 34);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "--";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tienes ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.panel4.Location = new System.Drawing.Point(-2, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 35);
            this.panel4.TabIndex = 7;
            // 
            // picInformacion
            // 
            this.picInformacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInformacion.Image = ((System.Drawing.Image)(resources.GetObject("picInformacion.Image")));
            this.picInformacion.Location = new System.Drawing.Point(808, 709);
            this.picInformacion.Name = "picInformacion";
            this.picInformacion.Size = new System.Drawing.Size(47, 38);
            this.picInformacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInformacion.TabIndex = 7;
            this.picInformacion.TabStop = false;
            this.picInformacion.Click += new System.EventHandler(this.picInformacion_Click);
            // 
            // btnControlHojasTrabajo
            // 
            this.btnControlHojasTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.btnControlHojasTrabajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnControlHojasTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControlHojasTrabajo.ForeColor = System.Drawing.Color.White;
            this.btnControlHojasTrabajo.Image = global::AutoControl.Properties.Resources.icons8_reloj_arena_arriba_100;
            this.btnControlHojasTrabajo.Location = new System.Drawing.Point(449, 467);
            this.btnControlHojasTrabajo.Margin = new System.Windows.Forms.Padding(2);
            this.btnControlHojasTrabajo.Name = "btnControlHojasTrabajo";
            this.btnControlHojasTrabajo.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.btnControlHojasTrabajo.Size = new System.Drawing.Size(345, 280);
            this.btnControlHojasTrabajo.TabIndex = 5;
            this.btnControlHojasTrabajo.Text = "Control de hojas de trabajo";
            this.btnControlHojasTrabajo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnControlHojasTrabajo.UseVisualStyleBackColor = false;
            this.btnControlHojasTrabajo.Click += new System.EventHandler(this.btnControlHojasTrabajo_Click);
            // 
            // btnControlOrdenes
            // 
            this.btnControlOrdenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.btnControlOrdenes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnControlOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControlOrdenes.ForeColor = System.Drawing.Color.White;
            this.btnControlOrdenes.Image = global::AutoControl.Properties.Resources.icons8_historial_de_pedidos_100;
            this.btnControlOrdenes.Location = new System.Drawing.Point(581, 165);
            this.btnControlOrdenes.Margin = new System.Windows.Forms.Padding(2);
            this.btnControlOrdenes.Name = "btnControlOrdenes";
            this.btnControlOrdenes.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.btnControlOrdenes.Size = new System.Drawing.Size(265, 280);
            this.btnControlOrdenes.TabIndex = 4;
            this.btnControlOrdenes.Text = "Control de órdenes";
            this.btnControlOrdenes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnControlOrdenes.UseVisualStyleBackColor = false;
            this.btnControlOrdenes.Click += new System.EventHandler(this.btnControlOrdenes_Click);
            // 
            // btnHojasTrabajo
            // 
            this.btnHojasTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.btnHojasTrabajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHojasTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHojasTrabajo.ForeColor = System.Drawing.Color.White;
            this.btnHojasTrabajo.Image = global::AutoControl.Properties.Resources.icons8_orden_de_compra_100;
            this.btnHojasTrabajo.Location = new System.Drawing.Point(69, 467);
            this.btnHojasTrabajo.Margin = new System.Windows.Forms.Padding(2);
            this.btnHojasTrabajo.Name = "btnHojasTrabajo";
            this.btnHojasTrabajo.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.btnHojasTrabajo.Size = new System.Drawing.Size(345, 280);
            this.btnHojasTrabajo.TabIndex = 3;
            this.btnHojasTrabajo.Text = "Hojas de trabajo";
            this.btnHojasTrabajo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHojasTrabajo.UseVisualStyleBackColor = false;
            this.btnHojasTrabajo.Click += new System.EventHandler(this.btnHojasTrabajo_Click);
            // 
            // btnOrdenCompra
            // 
            this.btnOrdenCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.btnOrdenCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenCompra.ForeColor = System.Drawing.Color.White;
            this.btnOrdenCompra.Image = global::AutoControl.Properties.Resources.icons8_camión_100__1_;
            this.btnOrdenCompra.Location = new System.Drawing.Point(298, 165);
            this.btnOrdenCompra.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenCompra.Name = "btnOrdenCompra";
            this.btnOrdenCompra.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.btnOrdenCompra.Size = new System.Drawing.Size(265, 280);
            this.btnOrdenCompra.TabIndex = 2;
            this.btnOrdenCompra.Text = "Órdenes de compra";
            this.btnOrdenCompra.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOrdenCompra.UseVisualStyleBackColor = false;
            this.btnOrdenCompra.Click += new System.EventHandler(this.btnOrdenCompra_Click);
            // 
            // btnAsesores
            // 
            this.btnAsesores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(35)))));
            this.btnAsesores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsesores.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsesores.ForeColor = System.Drawing.Color.White;
            this.btnAsesores.Image = global::AutoControl.Properties.Resources.icons8_grupo_de_usuarios_hombre_hombre_100;
            this.btnAsesores.Location = new System.Drawing.Point(15, 165);
            this.btnAsesores.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsesores.Name = "btnAsesores";
            this.btnAsesores.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.btnAsesores.Size = new System.Drawing.Size(265, 280);
            this.btnAsesores.TabIndex = 1;
            this.btnAsesores.Text = "Asesores";
            this.btnAsesores.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAsesores.UseVisualStyleBackColor = false;
            this.btnAsesores.Click += new System.EventHandler(this.btnAsesores_Click);
            // 
            // picMin
            // 
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::AutoControl.Properties.Resources.icons8_menos_100;
            this.picMin.Location = new System.Drawing.Point(726, 25);
            this.picMin.Margin = new System.Windows.Forms.Padding(2);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(52, 50);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMin.TabIndex = 3;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picSalir
            // 
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = global::AutoControl.Properties.Resources.icons8_eliminar_100;
            this.picSalir.Location = new System.Drawing.Point(795, 25);
            this.picSalir.Margin = new System.Windows.Forms.Padding(2);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(46, 50);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSalir.TabIndex = 2;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // picMinimizar
            // 
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = global::AutoControl.Properties.Resources.icons8_menos_100;
            this.picMinimizar.Location = new System.Drawing.Point(726, 25);
            this.picMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(52, 50);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimizar.TabIndex = 3;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // picCerrar
            // 
            this.picCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCerrar.Image = global::AutoControl.Properties.Resources.icons8_eliminar_100;
            this.picCerrar.Location = new System.Drawing.Point(795, 25);
            this.picCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.picCerrar.Name = "picCerrar";
            this.picCerrar.Size = new System.Drawing.Size(46, 50);
            this.picCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCerrar.TabIndex = 2;
            this.picCerrar.TabStop = false;
            this.picCerrar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(867, 781);
            this.Controls.Add(this.picInformacion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnControlHojasTrabajo);
            this.Controls.Add(this.btnControlOrdenes);
            this.Controls.Add(this.btnHojasTrabajo);
            this.Controls.Add(this.btnOrdenCompra);
            this.Controls.Add(this.btnAsesores);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picInformacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCerrar;
        private System.Windows.Forms.PictureBox picMinimizar;
        private System.Windows.Forms.Button btnAsesores;
        private System.Windows.Forms.Button btnOrdenCompra;
        private System.Windows.Forms.Button btnHojasTrabajo;
        private System.Windows.Forms.Button btnControlOrdenes;
        private System.Windows.Forms.Button btnControlHojasTrabajo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.PictureBox picInformacion;
    }
}

