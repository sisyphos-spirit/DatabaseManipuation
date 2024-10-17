using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Item
    {
        public static bool ComprobarItem(SqlConnection connection, string item)
        {
            try
            {
                string cadena = "SELECT * FROM Items WHERE Nombre = @item;"; // Cadena con la consulta
                SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión

                comando.Parameters.Add(new SqlParameter("@item", item)); // Añadimos el parametro

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

        public static bool ModificarItem(string connectionString)
        {
            string item;
            string costo;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Abro la conexión
                Console.WriteLine("Introduzca el nombre del item");
                item = Console.ReadLine();
                if (ComprobarItem(connection, item))
                {
                    Console.WriteLine("Introduzca el nuevo costo del item");
                    costo = Console.ReadLine();
                    string cadena = "UPDATE Items SET COSTO = @costo WHERE NOMBRE = @item;"; // Cadena con la consulta
                    SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión  

                    // Añado los parametros
                    comando.Parameters.Add(new SqlParameter("@item", item)); // Añadimos el parametro
                    comando.Parameters.Add(new SqlParameter("@costo", costo)); // Añadimos el parametro

                    if (comando.ExecuteNonQuery() == 1) // Compruebo que se haya modificado una fila
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
    }
}
