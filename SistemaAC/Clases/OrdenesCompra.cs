using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using AutoControl.Componentes;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;

namespace AutoControl.Clases
{
    class OrdenesCompra
    {
        private int id_orden_compra;
        private int id_asesor;
        private string nombre_empresa;
        private string numero_orden_compra;
        private string codigo_producto;
        private DateTime fecha_propuesta;
        private string descripcion_item;
        private string numero_requerimiento;
        private string fecha_creacion;
        private int estado;
        private DateTime fecha_recordatorio;
        private string nombre_asesor;
        private int cantidad;
        private int id_detalle;
        private string observacion;
        private string nombreProducto;

        public int Id_orden_compra { get => id_orden_compra; set => id_orden_compra = value; }
        public int Id_asesor { get => id_asesor; set => id_asesor = value; }
        public string Nombre_empresa { get => nombre_empresa; set => nombre_empresa = value; }
        public string Numero_orden_compra { get => numero_orden_compra; set => numero_orden_compra = value; }
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public DateTime Fecha_propuesta { get => fecha_propuesta; set => fecha_propuesta = value; }
        public string Descripcion_item { get => descripcion_item; set => descripcion_item = value; }
        public string Numero_requerimiento { get => numero_requerimiento; set => numero_requerimiento = value; }
        public string Fecha_creacion { get => fecha_creacion; set => fecha_creacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime Fecha_recordatorio { get => fecha_recordatorio; set => fecha_recordatorio = value; }
        public string Nombre_asesor { get => nombre_asesor; set => nombre_asesor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_detalle { get => id_detalle; set => id_detalle = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }

        Conexion con = new Conexion();

        //Método para llenar el combobox de asesores
        public void llenarComboBoxAsesores(ComboBox cmbAsesores)
        {
                con.desconectar();
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader consultar;
                cmd.CommandText = "SELECT id_asesor, nombre_asesor FROM `asesores` WHERE estado_eliminacion = 1";
                cmd.Connection = con.conectar();
                consultar = cmd.ExecuteReader();            
                while (consultar.Read())
                {
                    cmbAsesores.Items.Add(consultar["nombre_asesor"].ToString());
                }

                con.desconectar();
                consultar.Close();
        }       
        
        //Método para obtener el id del asesor por su nombre
        public int obtenerIdAsesor()
        {
            con.desconectar();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar; ;                       
            int idAsesorObtenido = 0;
            cmd.CommandText = "SELECT `id_asesor` FROM `asesores` WHERE `nombre_asesor`= @nombre";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@nombre", Nombre_asesor);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                idAsesorObtenido = consultar.GetInt32(0);
            }
            return idAsesorObtenido;
        }

        //Método para registrar orden de compra
        public bool registrarOrdenCompra()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `orden_compra`(`id_OC`, `id_asesor`, `nombre_empresa`, `numero_oc`, `fecha_propuesta`, `numero_requerimiento`, `fecha_creacion`, `estado`, `fecha_recordatorio`, `estadoEliminacion`, `observaciones`) "+
                " VALUES (NULL, @idAsesor , @nombreEmpresa,@numeroOC,@fechaPropuesta,@numeroRequerimiento, NOW(),'0',@fechaRecordatorio, '1', @observacion)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            cmd.Parameters.AddWithValue("@idAsesor", id_asesor);
            cmd.Parameters.AddWithValue("@nombreEmpresa", nombre_empresa);
            cmd.Parameters.AddWithValue("@numeroOC", numero_orden_compra);            
            cmd.Parameters.AddWithValue("@fechaPropuesta", fecha_propuesta);            
            cmd.Parameters.AddWithValue("@numeroRequerimiento", numero_requerimiento);
            cmd.Parameters.AddWithValue("@fechaRecordatorio", fecha_recordatorio);
            cmd.Parameters.AddWithValue("@observacion", observacion);

            if (cmd.ExecuteNonQuery() >= 1) {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public int obtenerNumeroCompra()
        {
            con.desconectar();
            int retorno = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;             
            cmd.CommandText = "SELECT * FROM orden_compra WHERE `numero_oc`= @numeroOC";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@numeroOC", numero_orden_compra);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                retorno++;
            }
            return retorno;
        }

        public int obtenerUltimaOC()
        {
            con.desconectar();
            int retorno = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            cmd.CommandText = "SELECT MAX(id_OC) as Codigo FROM `orden_compra`";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                retorno = consultar.GetInt32(0);
            }
            return retorno;
        }

        public bool agregarDetalleOC()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `detalle_orden_compra`(`id`, `producto`, `cantidad`, `id_orden_compra`, `descripcion`, `nombreProducto`, `estadoEntrega`) " +
                " VALUES (NULL, @producto, @cantidad, @idoc, @descripcion, @nombreProducto, 0)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@producto", codigo_producto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@idoc", id_orden_compra);
            cmd.Parameters.AddWithValue("@descripcion", descripcion_item);
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            return estado;
        }

        public DataTable mostrarDetallesOC(int idOC)
        {
            string query = "SELECT id as Código, producto as Producto, nombreProducto as Nombre, cantidad as Cantidad, descripcion as Descripcion FROM detalle_orden_compra WHERE id_orden_compra = " + idOC;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, con.conectar());
            DataTable consulta = new DataTable();
            adaptador.Fill(consulta);
            return consulta;
        }

        public bool eliminarDetalle()
        {
            con.desconectar();
            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;
            cmd.Parameters.AddWithValue("@idDetalle", id_detalle);
            cmd.CommandText = "DELETE FROM detalle_orden_compra WHERE id = @idDetalle";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public string obtenerProductoDetalle()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            string codigoProducto = "";           

            cmd.CommandText = "SELECT * FROM `detalle_orden_compra` WHERE producto = @codigoProducto AND id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                codigoProducto = consultar.GetString(1);               
            }
           
            return codigoProducto;
        }

        public int obtenerCantidadProductoDetalle()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;

            cmd.CommandText = "SELECT `cantidad` FROM `detalle_orden_compra` WHERE producto = @codigoProducto AND id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad; ;
        }

        public bool actualizarCantidadProductoDetalle()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.CommandText = "UPDATE detalle_orden_compra SET cantidad = @cantidad WHERE producto = @codigoProducto AND id_orden_compra = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public bool actualizarDetalleOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.Parameters.AddWithValue("@idDetalle", id_detalle);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@descripcion", descripcion_item);
            cmd.CommandText = "UPDATE `detalle_orden_compra` SET `producto`= @codigoProducto,`cantidad`= @cantidad, `descripcion`= @descripcion WHERE id = @idDetalle";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public int obtenerIdDetalle()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;

            cmd.CommandText = "SELECT `id_orden_compra` FROM `detalle_orden_compra` WHERE producto = @codigoProducto AND id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad; 
        }

        public int obtenerCantidadOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;

            cmd.CommandText = "SELECT COUNT(*) as Total FROM `orden_compra` WHERE estado = 0";
            cmd.Connection = con.conectar();           
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad;
        }
       public List<CartasOrdenesCompra> obtenerOrdenesCompra(FlowLayoutPanel flpContenedor)
       {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;            

            cmd.CommandText = "SELECT numero_oc, nombre_empresa, numero_requerimiento, fecha_propuesta, asesores.nombre_asesor, TIMESTAMPDIFF(DAY,CURRENT_DATE(), fecha_propuesta), id_OC "+"" +
                "FROM `orden_compra`, `asesores` WHERE asesores.id_asesor = orden_compra.id_asesor AND estado = 0 AND CURRENT_DATE >= fecha_recordatorio AND estadoEliminacion = 1 ORDER BY (fecha_propuesta) ASC;";
            cmd.Connection = con.conectar();            
            consultar = cmd.ExecuteReader();

            List<CartasOrdenesCompra> listaOC = new List<CartasOrdenesCompra>();

            int i = 0;
            while (consultar.Read())
            {
                int indicador = 0;
                int diasRestantes = consultar.GetInt32(5);
                if (diasRestantes <= 0)
                {
                    indicador = 2;
                }
                else
                {
                    indicador = 1;
                }

                listaOC.Add(new CartasOrdenesCompra
                {
                    NumeroOC = consultar.GetString(0),
                    Cliente = consultar.GetString(1),
                    NumeroRequerimiento = consultar.GetString(2),
                    FechaPropuesta = consultar.GetDateTime(3),
                    Asesor = consultar.GetString(4),
                    DiasRestantes = consultar.GetInt32(5),
                    ColorIndicador = indicador,
                    IdOC = consultar.GetInt32(6)

                }); ;
                flpContenedor.Controls.Add(listaOC[i]);
                i = i + 1;
            }

            return listaOC;                        
       }

        public bool finalizarOrdenCompra()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;
            
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "UPDATE orden_compra SET estado = 1, fechaFinalizacion = NOW() WHERE id_OC = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public void obtenerOC(Label txtCliente, TextBox txtNumeroOC, DateTimePicker dtpFechaPropuesta, Label lblFechaRecordatorio, TextBox txtNumeroR, Label lblAsesores, TextBox txtObservacion )
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;            
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);

            cmd.CommandText = "SELECT `id_OC`, orden_compra.`id_asesor`, asesores.nombre_asesor,`nombre_empresa`, `numero_oc`, `fecha_propuesta`, `numero_requerimiento`, "+"" +
                "`fecha_creacion`, `estado`, `fecha_recordatorio`, `observaciones` FROM `orden_compra`, `asesores` WHERE orden_compra.id_asesor = asesores.id_asesor AND id_OC = @idOC";
            cmd.Connection = con.conectar();            
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                txtCliente.Text = consultar.GetString(3);
                txtNumeroOC.Text = consultar.GetString(4);
                dtpFechaPropuesta.Value = consultar.GetDateTime(5);
                lblFechaRecordatorio.Text = consultar.GetString(9);
                txtNumeroR.Text = consultar.GetString(6);
                lblAsesores.Text = consultar.GetString(2);
                txtObservacion.Text = consultar.GetString(10);

            }            
        }

        public bool actualizarFechaPropuestaOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.Parameters.AddWithValue("@fechaPropuesta", fecha_propuesta);
            cmd.Parameters.AddWithValue("@fechaRecordatorio", fecha_recordatorio);
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.CommandText = "UPDATE orden_compra SET fecha_propuesta = @fechaPropuesta, fecha_recordatorio = @fechaRecordatorio, observaciones = @observacion WHERE id_OC = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public bool eliminarOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);           
            cmd.CommandText = "UPDATE orden_compra SET estadoEliminacion = 0 WHERE id_OC = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public List<CartasProductosDetalle> obtenerProductos(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();           

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "SELECT producto, cantidad, descripcion, nombreProducto, id_orden_compra, estadoEntrega FROM detalle_orden_compra WHERE id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartasProductosDetalle> listaP = new List<CartasProductosDetalle>();
            
            int i = 0;
            while (consultar.Read())
            {               
                listaP.Add(new CartasProductosDetalle
                {
                   CodigoProducto = consultar.GetString(0),
                   CantidadProducto = consultar.GetInt32(1),
                   Descripcion = consultar.GetString(2),
                   NombreProducto = consultar.GetString(3),
                   IdOC = consultar.GetInt32(4),
                   ColorIndicador = consultar.GetInt32(5)
                });
                flpContenedor.Controls.Add(listaP[i]);
                i = i + 1;
            }

            return listaP;

        }

        public List<CartasOrdenesCompraFinalizadas> obtenerOCFinalizadas(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            
            cmd.CommandText = "SELECT asesores.nombre_asesor, nombre_empresa, numero_oc, fecha_propuesta, numero_requerimiento, fechaFinalizacion, id_OC "+"" +
                "FROM orden_compra, asesores WHERE asesores.id_asesor = orden_compra.id_asesor AND estado = 1 ORDER BY(fechaFinalizacion) DESC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartasOrdenesCompraFinalizadas> listaOCFinalizadas = new List<CartasOrdenesCompraFinalizadas>();

            int i = 0;
            while (consultar.Read())
            {
                listaOCFinalizadas.Add(new CartasOrdenesCompraFinalizadas
                {
                    Asesor = consultar.GetString(0),
                    Cliente = consultar.GetString(1),
                    NumeroOC = consultar.GetString(2),
                    FechaPropuesta = consultar.GetDateTime(3),
                    NumRequerimiento = consultar.GetString(4),
                    FechaFinalizacion = consultar.GetDateTime(5),
                    IDOC = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaOCFinalizadas[i]);
                i = i + 1;
            }

            return listaOCFinalizadas;

        }

        public int obtenerCantidadOCPendientes()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;           

            cmd.CommandText = "SELECT COUNT(*) as Total FROM `orden_compra` WHERE estado = 0 AND CURRENT_DATE >= fecha_recordatorio AND estadoEliminacion = 1";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad;
        }

        public void obtenerDatosOC(Table tabla)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;            

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "SELECT asesores.nombre_asesor, nombre_empresa, numero_oc, numero_requerimiento, NOW(), fechaFinalizacion  FROM `orden_compra`, `asesores` WHERE asesores.id_asesor = orden_compra.id_asesor AND id_OC = @idOC ";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Asesor: "+consultar.GetString(0))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Cliente: " + consultar.GetString(1))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Número órden de compra: " + consultar.GetString(2))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Fecha finalización: " + consultar.GetDateTime(5))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Número de requerimiento: " + consultar.GetString(3))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Fecha de creación de reporte: " + consultar.GetDateTime(4))));
            }
            
        }

        public void obtenerDetallesOC(Table tabla)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "SELECT producto, cantidad, descripcion, nombreProducto FROM detalle_orden_compra WHERE id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11).Add(new Paragraph(consultar.GetInt32(1).ToString())));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11).Add(new Paragraph(consultar.GetString(0))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11).Add(new Paragraph(consultar.GetString(3))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(11).Add(new Paragraph(consultar.GetString(2))));                
            }

        }

        public bool borrarOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "DELETE FROM orden_compra WHERE id_OC = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public void buscarOCPendientes(FlowLayoutPanel flpContenedor, string numeroOC)
        {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT numero_oc, nombre_empresa, numero_requerimiento, fecha_propuesta, asesores.nombre_asesor, TIMESTAMPDIFF(DAY,CURRENT_DATE(), fecha_propuesta), id_OC " + "" +
                "FROM `orden_compra`, `asesores` WHERE numero_oc LIKE '%" + numeroOC + "%' AND asesores.id_asesor = orden_compra.id_asesor AND estado = 0 AND CURRENT_DATE >= fecha_recordatorio AND estadoEliminacion = 1 ORDER BY (fecha_propuesta) ASC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartasOrdenesCompra> listaOC = new List<CartasOrdenesCompra>();

            int i = 0;
            while (consultar.Read())
            {
                int indicador = 0;
                int diasRestantes = consultar.GetInt32(5);
                if (diasRestantes <= 0)
                {
                    indicador = 2;
                }
                else
                {
                    indicador = 1;
                }

                listaOC.Add(new CartasOrdenesCompra
                {
                    NumeroOC = consultar.GetString(0),
                    Cliente = consultar.GetString(1),
                    NumeroRequerimiento = consultar.GetString(2),
                    FechaPropuesta = consultar.GetDateTime(3),
                    Asesor = consultar.GetString(4),
                    DiasRestantes = consultar.GetInt32(5),
                    ColorIndicador = indicador,
                    IdOC = consultar.GetInt32(6)

                }); ;
                flpContenedor.Controls.Add(listaOC[i]);
                i = i + 1;
            }            
        }

        public void buscarOCFinalizadas(FlowLayoutPanel flpContenedor, string numeroOC)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT asesores.nombre_asesor, nombre_empresa, numero_oc, fecha_propuesta, numero_requerimiento, fechaFinalizacion, id_OC " + "" +
                "FROM orden_compra, asesores WHERE numero_oc LIKE '%" + numeroOC + "%' AND asesores.id_asesor = orden_compra.id_asesor AND estado = 1 ORDER BY(fechaFinalizacion) DESC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartasOrdenesCompraFinalizadas> listaOCFinalizadas = new List<CartasOrdenesCompraFinalizadas>();

            int i = 0;
            while (consultar.Read())
            {
                listaOCFinalizadas.Add(new CartasOrdenesCompraFinalizadas
                {
                    Asesor = consultar.GetString(0),
                    Cliente = consultar.GetString(1),
                    NumeroOC = consultar.GetString(2),
                    FechaPropuesta = consultar.GetDateTime(3),
                    NumRequerimiento = consultar.GetString(4),
                    FechaFinalizacion = consultar.GetDateTime(5),
                    IDOC = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaOCFinalizadas[i]);
                i = i + 1;
            }            
        }

        public bool actualizarEstadoEntregaProducto()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.Parameters.AddWithValue("@codigoProducto", codigo_producto);
            cmd.CommandText = "UPDATE detalle_orden_compra SET estadoEntrega = 1 WHERE id_orden_compra = @idOC AND producto = @codigoProducto";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public int obtenerCantidadProductoPendienteEntrega()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;
            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);
            cmd.CommandText = "SELECT COUNT(*) as Total FROM `detalle_orden_compra` WHERE estadoEntrega = 0 AND id_orden_compra = @idOC";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }
            return cantidad;
        }

        public bool entregarTodosProductosOC()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idOC", id_orden_compra);            
            cmd.CommandText = "UPDATE detalle_orden_compra SET estadoEntrega = 1 WHERE id_orden_compra = @idOC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }
        
    }
}

