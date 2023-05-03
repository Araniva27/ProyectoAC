using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AutoControl.Clases
{
    class Conexion
    {
        MySqlConnection conexion = new MySqlConnection();

        static string servidor = "localhost";
        //static string bd = "autocontrolbd2";
        static string bd = "autoncontrol2";
        static string usuario = "root";
        static string password= "";
        static string puerto = "3306";

        string cadenaConexión = "server = " + servidor + ";" + "port =" + puerto + ";" + "user = " + usuario + ";" + "password = " + password + ";" + "database = " + bd + ";"; 

        public MySqlConnection conectar()
        {
            try {
                conexion.ConnectionString = cadenaConexión;
                conexion.Open();               

            }
            catch (MySqlException e) {
                System.Windows.Forms.MessageBox.Show("No se ha podido conectar con la base de datos. Error "+e.ToString());
            }

            return conexion;
        }

        public void desconectar()
        {
            try
            {
                conexion.Close();
                Console.WriteLine("Se ha desconectado de la base de datos");

            }catch(Exception e)
            {
               Console.WriteLine("Error al desconectar de la base de datos. Error: "+ e);
            }
        }

    }
}
