using AutoControl.Componentes;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoControl.Clases
{
    class HojaTrabajo
    {
        private int idHoja;
        private int idAsesor;
        private string cliente;
        private DateTime fechaSalida;
        private string codigoHoja;
        private string codigoProducto;
        private string nombreProducto;
        private int cantidad;
        private string descripcion;
        private string observacion;
        private int idDetalleHT;

        public int IdHoja { get => idHoja; set => idHoja = value; }
        public int IdAsesor { get => idAsesor; set => idAsesor = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string CodigoHoja { get => codigoHoja; set => codigoHoja = value; }
        public string CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int IdDetalleHT { get => idDetalleHT; set => idDetalleHT = value; }

        Conexion con = new Conexion();

        public bool agregarHojaTrabajo()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `hoja_trabajo`(`id_hoja`, `id_asesor`, `cliente`, `fecha_salida`, `codigo_hoja`, `estado`, `observacion`, `fechaRegistro`) " +
                "VALUES (NULL, @idAsesor, @cliente, @fechaSalida, @codigoHoja, 1, @observacion, NOW())";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@idAsesor", idAsesor);
            cmd.Parameters.AddWithValue("@cliente", cliente);
            cmd.Parameters.AddWithValue("@fechaSalida", fechaSalida);
            cmd.Parameters.AddWithValue("@codigoHoja", codigoHoja);
            cmd.Parameters.AddWithValue("@observacion", observacion);

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

        public int obtenerCodigoHojaTrabajo()
        {
            con.desconectar();
            int retorno = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            cmd.CommandText = "SELECT * FROM hoja_trabajo WHERE `codigo_hoja`= @codigoHoja";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoHoja", codigoHoja);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                retorno++;
            }
            return retorno;
        }

        //Método para obtener la cantidad de productos que posee cada hoja de trabajo y poder validar que no quede vacío
        public int obtenerCantidadProductosHojaTrabajo()
        {
            con.desconectar();
            int retorno = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            cmd.CommandText = "SELECT * FROM detalle_hoja_trabajo WHERE `id_hoja_trabajo`= @codigoHoja";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoHoja", codigoHoja);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                retorno++;
            }
            return retorno;
        }

        public int obtenerUltimaHT()
        {
            con.desconectar();
            int retorno = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            cmd.CommandText = "SELECT MAX(id_hoja) as Codigo FROM `hoja_trabajo`";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                retorno = consultar.GetInt32(0);
            }
            return retorno;
        }

        public bool agregarDetalleHT()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `detalle_hoja_trabajo`(`id_detalle_hoja`, `codigo_producto`, `nombre_producto`, `cantidad`, `descripcion`, `id_hoja_trabajo`) " +
                "VALUES (NULL, @codigoProducto, @nombreProducto, @cantidad, @descripcion, @idHT)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@idHT", codigoHoja);

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

        public bool eliminarHT()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM `hoja_trabajo` WHERE id_hoja = @idHT";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@idHT", idHoja);

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

        public DataTable mostrarDetallesHT(int idHT)
        {
            string query = "SELECT id_detalle_hoja as `Código detalle`, codigo_producto as Código, nombre_producto as Nombre, cantidad as Cantidad, descripcion as Descripción FROM detalle_hoja_trabajo WHERE id_hoja_trabajo = " + idHT;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, con.conectar());
            DataTable consulta = new DataTable();
            adaptador.Fill(consulta);
            return consulta;
        }

        public bool eliminarDetalleHT(int idDetalleHT)
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM `detalle_hoja_trabajo` WHERE id_detalle_hoja = " + idDetalleHT;
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

        public bool actualizarDetalleHT()
        {
            con.desconectar();
            bool estado = false;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE detalle_hoja_trabajo SET codigo_producto = @codigoProducto, nombre_producto = @nombreProducto, cantidad = @cantidad, descripcion = @descripcion WHERE id_detalle_hoja = @idDetalleHT";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@idHT", codigoHoja);
            cmd.Parameters.AddWithValue("@idDetalleHT", idDetalleHT);

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

        public string obtenerProductoDetalleHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            string codigoP = "";

            cmd.CommandText = "SELECT * FROM `detalle_hoja_trabajo` WHERE codigo_producto = @codigoProducto AND id_hoja_trabajo = @idHT";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            cmd.Parameters.AddWithValue("@idHT", CodigoHoja);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                codigoP = consultar.GetString(1);
            }

            return codigoP;
        }

        public int obtenerCantidadProductoDetalleHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;

            cmd.CommandText = "SELECT `cantidad` FROM `detalle_hoja_trabajo` WHERE codigo_producto = @codigoProducto AND id_hoja_trabajo = @idHT";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            cmd.Parameters.AddWithValue("@idHT", CodigoHoja);
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad; ;
        }

        public bool actualizarCantidadProductoDetalleHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
            cmd.Parameters.AddWithValue("@idHT", CodigoHoja);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.CommandText = "UPDATE detalle_hoja_trabajo SET cantidad = @cantidad WHERE codigo_producto = @codigoProducto AND id_hoja_trabajo = @idHT";
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

        //Obtener hojas de trabajo finalizadas
        public void obtenerHojasTrabajo(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT codigo_hoja, asesores.nombre_asesor, cliente, fecha_salida, fechaRegistro, estado, id_hoja " +
                "FROM asesores, hoja_trabajo WHERE asesores.id_asesor = hoja_trabajo.id_asesor AND estado = 1 AND estadoEliminacion = 0";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartaHojaTrabajo> listaHT = new List<CartaHojaTrabajo>();

            int i = 0;
            while (consultar.Read())
            {

                listaHT.Add(new CartaHojaTrabajo
                {
                    CodigoHoja = consultar.GetString(0),
                    Cliente = consultar.GetString(2),
                    Asesor = consultar.GetString(1),
                    FechaSalida = consultar.GetDateTime(3),
                    FechaRegistro = consultar.GetDateTime(4),
                    ColorIndicador = consultar.GetInt32(5),
                    IdHt = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaHT[i]);
                i = i + 1;
            }
        }

        public void obtenerHojasTrabajoFinalizadas(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT codigo_hoja, asesores.nombre_asesor, cliente, fecha_salida, fechaFinalizacion, estado, id_hoja " +
                "FROM asesores, hoja_trabajo WHERE asesores.id_asesor = hoja_trabajo.id_asesor AND estado = 0 AND estadoEliminacion = 0";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartaHojaTrabajoFinalizadas> listaHT = new List<CartaHojaTrabajoFinalizadas>();

            int i = 0;
            while (consultar.Read())
            {

                listaHT.Add(new CartaHojaTrabajoFinalizadas
                {
                    CodigoHoja = consultar.GetString(0),
                    Cliente = consultar.GetString(2),
                    Asesor = consultar.GetString(1),
                    FechaSalida = consultar.GetDateTime(3),
                    FechaFinalizacion = consultar.GetDateTime(4),
                    IdHt = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaHT[i]);
                i = i + 1;
            }
        }

        public void obtenerHTPendientesAsesor(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT codigo_hoja, asesores.nombre_asesor, cliente, fecha_salida, fechaRegistro, estado, id_hoja " +
                "FROM asesores, hoja_trabajo WHERE hoja_trabajo.id_asesor = @idAsesor AND asesores.id_asesor = hoja_trabajo.id_asesor AND estado = 1 AND estadoEliminacion = 0";
            cmd.Parameters.AddWithValue("@idAsesor", idAsesor);
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartaHojaTrabajo> listaHT = new List<CartaHojaTrabajo>();

            int i = 0;
            while (consultar.Read())
            {

                listaHT.Add(new CartaHojaTrabajo
                {
                    CodigoHoja = consultar.GetString(0),
                    Cliente = consultar.GetString(2),
                    Asesor = consultar.GetString(1),
                    FechaSalida = consultar.GetDateTime(3),
                    FechaRegistro = consultar.GetDateTime(4),
                    ColorIndicador = consultar.GetInt32(5),
                    IdHt = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaHT[i]);
                i = i + 1;
            }
        }

        public void obtenerHTFinalizadasAsesor(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();
            //CartasOrdenesCompra CartaOC = new CartasOrdenesCompra();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT codigo_hoja, asesores.nombre_asesor, cliente, fecha_salida, fechaFinalizacion, estado, id_hoja " +
                "FROM asesores, hoja_trabajo WHERE asesores.id_asesor = hoja_trabajo.id_asesor AND estado = 0 AND hoja_trabajo.id_asesor = @idAsesor AND estadoEliminacion = 0";
            cmd.Parameters.AddWithValue("@idAsesor", idAsesor);
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartaHojaTrabajoFinalizadas> listaHT = new List<CartaHojaTrabajoFinalizadas>();

            int i = 0;
            while (consultar.Read())
            {

                listaHT.Add(new CartaHojaTrabajoFinalizadas
                {
                    CodigoHoja = consultar.GetString(0),
                    Cliente = consultar.GetString(2),
                    Asesor = consultar.GetString(1),
                    FechaSalida = consultar.GetDateTime(3),
                    FechaFinalizacion = consultar.GetDateTime(4),
                    IdHt = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaHT[i]);
                i = i + 1;
            }
        }

        public bool finalizarHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "UPDATE hoja_trabajo SET estado = 0, fechaFinalizacion = NOW() WHERE id_hoja = @idHT";
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

        public void obtenerDatosHT(Table tabla)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "SELECT asesores.nombre_asesor, cliente, codigo_hoja, NOW(), fechaFinalizacion, observacion FROM `hoja_trabajo`, `asesores` WHERE asesores.id_asesor = hoja_trabajo.id_asesor AND id_hoja = @idHT ";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Asesor: " + consultar.GetString(0))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Cliente: " + consultar.GetString(1))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Código de hoja: " + consultar.GetString(2))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Fecha finalización: " + consultar.GetDateTime(4))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Observación: " + consultar.GetString(5))));
                tabla.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontSize(11).SetBorder(Border.NO_BORDER).Add(new Paragraph("Fecha de creación de reporte: " + consultar.GetDateTime(3))));
            }
        }

        public void obtenerDetallesHT(Table tabla)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "SELECT codigo_producto, cantidad, descripcion, nombre_producto FROM detalle_hoja_trabajo WHERE id_hoja_trabajo = @idHT";
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

        public void obtenerHT(Label lblHojaTrabajo, Label lblAsesor, Label lblCliente, Label lblFechaSalida, TextBox txtDescripcion)
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "SELECT asesores.nombre_asesor, cliente, fecha_salida, codigo_hoja, observacion   FROM hoja_trabajo, asesores WHERE asesores.id_asesor = hoja_trabajo.id_asesor AND id_hoja = @idHT";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                lblHojaTrabajo.Text = consultar.GetString(3);
                lblAsesor.Text = consultar.GetString(0);
                lblCliente.Text = consultar.GetString(1);
                lblFechaSalida.Text = consultar.GetDateTime(2).ToString();
                txtDescripcion.Text = consultar.GetString(4);
            }
        }


        public bool actualizarObservacion()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.CommandText = "UPDATE hoja_trabajo SET observacion = @observacion WHERE id_hoja = @idHT";
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

        public bool actualizarEstadoEliminacionHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idHT", idHoja);            
            cmd.CommandText = "UPDATE hoja_trabajo SET estadoEliminacion = 1 WHERE id_hoja = @idHT";
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

        public void obtenerProductosHojaTrabajo(FlowLayoutPanel flpContenedor)
        {
            con.desconectar();            

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;

            cmd.CommandText = "SELECT id_detalle_hoja, codigo_producto, nombre_producto, cantidad, descripcion, estadoEntrada, id_hoja_trabajo FROM detalle_hoja_trabajo WHERE id_hoja_trabajo = @idHt";
            cmd.Parameters.AddWithValue("@idHt", idHoja);
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            List<CartaProductoHojaTrabajo> listaHT = new List<CartaProductoHojaTrabajo>();

            int i = 0;
            while (consultar.Read())
            {

                listaHT.Add(new CartaProductoHojaTrabajo
                {
                   IdDetalleHT = consultar.GetInt32(0),
                   CodigoProducto = consultar.GetString(1),
                   NombreProducto = consultar.GetString(2),
                   Cantidad = consultar.GetInt32(3),
                   Descripcion = consultar.GetString(4),
                   EstadoEntrada = consultar.GetInt32(5),
                   IdHojaTrabajo = consultar.GetInt32(6)
                });
                flpContenedor.Controls.Add(listaHT[i]);
                i = i + 1;
            }           
        }

        public bool entregarProductoHojaTrabajo()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idDetalleHT", idDetalleHT);
            cmd.CommandText = "UPDATE detalle_hoja_trabajo SET estadoEntrada = 1 WHERE id_detalle_hoja = @idDetalleHT";
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

        public int cantidadProductoPendienteEntregaHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader consultar;
            int cantidad = 0;
            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "SELECT COUNT(*) as Total FROM `detalle_hoja_trabajo` WHERE estadoEntrada = 0 AND id_hoja_trabajo = @idHT";
            cmd.Connection = con.conectar();
            consultar = cmd.ExecuteReader();

            while (consultar.Read())
            {
                cantidad = consultar.GetInt32(0);
            }

            return cantidad;
        }

        public bool entregarProductosHT()
        {
            con.desconectar();

            MySqlCommand cmd = new MySqlCommand();
            bool estado = false;

            cmd.Parameters.AddWithValue("@idHT", idHoja);
            cmd.CommandText = "UPDATE detalle_hoja_trabajo SET estadoEntrada = 1 WHERE id_hoja_trabajo = @idHT";
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
