using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Jugador
    {
        public static bool ComprobarJugador(SqlConnection connection, string jugador)
        {
            try
            {
                string cadena = "SELECT * FROM Jugadores WHERE Nombre = @jugador;"; // Cadena con la consulta
                SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión

                comando.Parameters.Add(new SqlParameter("@jugador", jugador)); // Añadimos el parametro

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

        public static bool InsertarJugador(string connectionString)
        {
            string jugador;
            string nivel;
            string region;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Abro la conexión
                Console.WriteLine("Introduzca el nombre del jugador");
                jugador = Console.ReadLine();
                if (!ComprobarJugador(connection, jugador))
                {
                    Console.WriteLine("Introduzca el nivel del jugador");
                    nivel = Console.ReadLine();
                    Console.WriteLine("Introduzca la región del jugador");
                    region = Console.ReadLine();
                    string cadena = "INSERT INTO Jugadores(Nombre, Nivel, Region) VALUES (@jugador, @nivel, @region);"; // Cadena con la consulta
                    SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión  

                    // Añado los parametros
                    comando.Parameters.Add(new SqlParameter("@jugador", jugador)); // Añadimos el parametro
                    comando.Parameters.Add(new SqlParameter("@nivel", nivel)); // Añadimos el parametro
                    comando.Parameters.Add(new SqlParameter("@region", region)); // Añadimos el parametro

                    if (comando.ExecuteNonQuery() == 1) // Compruebo que se haya añadido una fila
                    {
                        connection.Close(); // Cierro la conexión
                        connection.Dispose();
                        return true;
                    }
                }
                else
                {
                    connection.Close(); // Cierro la conexión
                    connection.Dispose();
                    return false;
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
            return false;
        }

        public static bool EliminarJugador(string connectionString)
        {
            string jugador;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Abro la conexión
                Console.WriteLine("Introduzca el nombre del jugador");
                jugador = Console.ReadLine();
                if (ComprobarJugador(connection, jugador))
                {
                    string cadena = "DELETE FROM HistorialJugadorCampeon WHERE ID_Jugador = (SELECT ID_JUGADOR FROM Jugadores WHERE Nombre = @jugador);"; // Cadena con la consulta
                    SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión
                    // Añado los parametros
                    comando.Parameters.Add(new SqlParameter("@jugador", jugador)); // Añadimos el parametro
                    comando.ExecuteNonQuery();

                    cadena = "DELETE FROM Jugadores WHERE Nombre = @jugador";
                    SqlCommand comando2 = new SqlCommand(cadena, connection); // Cadena y conexión
                    comando2.Parameters.Add(new SqlParameter("@jugador", jugador)); // Añadimos el parametro
                    comando2.ExecuteNonQuery();
                    connection.Close(); // Cierro la conexión
                    connection.Dispose();
                    return true;
                }
                else
                {
                    connection.Close(); // Cierro la conexión
                    connection.Dispose();
                    return false;
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
            return false;
        }
    }
}
