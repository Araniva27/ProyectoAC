using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoControl.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace AutoControl.Clases
{
    class Asesores
    {
        private int id_asesor;
        private string nombre_asesor;

        public int Id_asesor { get => id_asesor; set => id_asesor = value; }
        public string Nombre_asesor { get => nombre_asesor; set => nombre_asesor = value; }

        public Asesores() 
        {
        }
        
        Conexion con = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader consultar;

        //Método para insertar asesores
        public Boolean insertarAsesor()
        {
            con.desconectar();
            bool estado = false;
            cmd.CommandText = "INSERT INTO `asesores`(`id_asesor`, `nombre_asesor`) VALUES (NULL, @nombre)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            cmd.Parameters.AddWithValue("@nombre", nombre_asesor);

            if (cmd.ExecuteNonQuery() >= 1) {
                estado = true;            
            }
            else
            {
                estado = false;
            }

            return estado;            
        }

       
        //Método para obtener un asesor en especifico
        public string obtenerAsesor()
        {
            con.desconectar();
            string nombreA = "";
            cmd.CommandText = "SELECT `nombre_asesor` FROM `asesores` WHERE `nombre_asesor` = @nombreA AND estado_eliminacion = 1";
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@nombreA", nombre_asesor);
            consultar = cmd.ExecuteReader();
           
            while (consultar.Read()) {
                nombreA = consultar.GetString(0);                
            }

            return nombreA;
        }

        //Método para mostrar los asesores almacenados
        public DataTable mostrarAsesores()
        {
            string query = "SELECT `id_asesor` AS Código, `nombre_asesor` AS Nombre FROM `asesores` WHERE estado_eliminacion = 1";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, con.conectar());
            DataTable consulta = new DataTable();
            adaptador.Fill(consulta);
            return consulta;

        }

        //Método para actualizar nombre de asesor
        public Boolean actualizarAsesor()
        {
            con.desconectar();
            bool estado = false;
            cmd.Parameters.AddWithValue("@nombreNuevo", nombre_asesor);
            cmd.Parameters.AddWithValue("@idAsesor", id_asesor);
            cmd.CommandText = "UPDATE `asesores` SET `nombre_asesor`= @nombreNuevo WHERE `id_asesor` = @idAsesor";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1) {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        //Método para eliminar asesor, para eliminar un asesor solo se actualiza el estado de eliminación. 
        //1=Activo, 0=Eliminado
        public Boolean eliminarAsesor() 
        {
            con.desconectar();
            bool estado = false;
            cmd.Parameters.AddWithValue("@idAsesor", Id_asesor);
            cmd.CommandText = "UPDATE `asesores` SET `estado_eliminacion`= 0 WHERE `id_asesor` = @idAsesor";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conectar();

            if (cmd.ExecuteNonQuery() >= 1) {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        //Método para obtener el id de un asesor en base a su nombre
        public int obtenerIdAsesor() 
        {
            con.desconectar();
            int idAsesorObtenido = 0;            
            cmd.CommandText = "SELECT `id_asesor` FROM `asesores` WHERE `nombre_asesor`= @nombre";           
            cmd.Connection = con.conectar();
            cmd.Parameters.AddWithValue("@nombre", nombre_asesor);
            consultar = cmd.ExecuteReader();

            while (consultar.Read()) {
                idAsesorObtenido = consultar.GetInt32(0);
            }

            return idAsesorObtenido;
        }

    }
}
