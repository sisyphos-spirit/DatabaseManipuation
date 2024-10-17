using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Campeon
    {
        public static bool ComprobarCampeon(SqlConnection connection, string campeon)
        {
            try
            {
                string cadena = "SELECT * FROM Campeones WHERE Nombre = @campeon;"; // Cadena con la consulta
                SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión

                comando.Parameters.Add(new SqlParameter("@campeon", campeon)); // Añadimos el parametro

                SqlDataReader reader = comando.ExecuteReader(); // Ejecuto la consulta
                if (reader.HasRows) //Comprueba si ha devuelto filas
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close(); //Cierro el DataReader
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void ConsultarCampeon(string connectionString)
        {
            string campeon;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Abro la conexión
                Console.WriteLine("Introduzca el nombre del campeón");
                campeon = Console.ReadLine();

                if (ComprobarCampeon(connection, campeon))
                {
                    string cadena = "SELECT Nombre, Tipo FROM Habilidades WHERE ID_CAMPEON = (SELECT ID_CAMPEON FROM Campeones WHERE Nombre = @campeon);"; // Cadena con la consulta
                    SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión
                    comando.Parameters.Add(new SqlParameter("@campeon", campeon)); // Añadimos el parametro

                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuto la consulta
                    if (reader.HasRows) //Comprueba si ha devuelto filas
                    {
                        while (reader.Read()) // Recorro el SqlDataReader
                        {
                            // Accedo como si fuera un array al reader para imprimir
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine(reader["Tipo"].ToString()); // Campo id
                            Console.WriteLine(reader["Nombre"].ToString()); // Campo id
                        }
                    }
                    else
                    {
                        Console.WriteLine("El campeón introducido no tiene habilidades");
                    }
                    reader.Close(); //Cierro el DataReader
                }
                else
                {
                    Console.WriteLine("El campeón introducido no existe");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Cierro la conexión
                    connection.Dispose();
                }
            }
        }
    }
}
