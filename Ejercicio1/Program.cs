using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static string LoginSql()
        {
            const string SERVER = ""; // IP SQL Server "PCNAME\\SQLEXPRESS"
            const string DB = "LeagueOfLegendsDB"; // Nombre de la base de datos
            const string USUARIO = ""; // User
            const string CLAVE = ""; // Password
            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = SERVER;
            connStringBuilder.InitialCatalog = DB;
            connStringBuilder.UserID = USUARIO;
            connStringBuilder.Password = CLAVE;
            string connectionString = connStringBuilder.ToString();
            return connectionString;
        }

        static bool ComprobarTabla(SqlConnection connection, string tabla)
        {
            try
            {
                string cadena = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tabla;"; // Cadena con la consulta
                SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión

                comando.Parameters.Add(new SqlParameter("@tabla", tabla)); // Añadimos el parametro

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

        static void ConsultarTabla(string connectionString)
        {
            string tabla;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Abro la conexión
                Console.WriteLine("Introduzca el nombre de la tabla que desea consultar");
                Console.WriteLine("Las tablas disponibles son: Campeones, Habilidades, HistorialJugador,Campeon, items, Jugadores");
                tabla = Console.ReadLine();

                if (ComprobarTabla(connection, tabla))
                {
                    string cadena = "SELECT * FROM " + tabla; // Cadena con la consulta
                    SqlCommand comando = new SqlCommand(cadena, connection); // Cadena y conexión
                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuto la consulta
                    if (reader.HasRows) //Comprueba si ha devuelto filas
                    {
                        while (reader.Read()) // Recorro el SqlDataReader
                        {
                            // Accedo como si fuera un array al reader para imprimir
                            Console.WriteLine("---------------------------------");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader[i].ToString()); // Campo id
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("La tabla está vacía");
                    }
                    reader.Close(); //Cierro el DataReader
                }
                else
                {
                    Console.WriteLine("La tabla introducida no existe");
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

        static void menu(string connectionString)
        {
            string opcion = "";
            do
            {
                Console.WriteLine("1. Consultar una tabla");
                Console.WriteLine("2. Consultar campeones");
                Console.WriteLine("3. Insertar un nuevo jugador");
                Console.WriteLine("4. Modificar costo de un item");
                Console.WriteLine("5. Borrar jugador y su historial");
                Console.WriteLine("6. Salir del programa");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ConsultarTabla(connectionString);
                        break;
                    case "2":
                        Campeon.ConsultarCampeon(connectionString);
                        break;
                    case "3":
                        if (Jugador.InsertarJugador(connectionString))
                        {
                            Console.WriteLine("Jugador añadido correctamente\n");
                        }
                        else
                        {
                            Console.WriteLine("El jugador introducido ya existe\n");
                        }
                        break;
                    case "4":
                        if (Item.ModificarItem(connectionString))
                        {
                            Console.WriteLine("Item modificado correctamente\n");
                        }
                        else
                        {
                            Console.WriteLine("El item introducido no existe\n");
                        }
                        break;
                    case "5":
                        if (Jugador.EliminarJugador(connectionString))
                        {
                            Console.WriteLine("Jugador eliminado correctamente\n");
                        }
                        else
                        {
                            Console.WriteLine("No se ha borrado nada\n");
                        }
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("El valor introducido es incorrecto, pruebe de nuevo\n");
                        break;
                }
            } while (opcion != "6");
        }


        static void Main(string[] args)
        {
            string connectionString;
            connectionString = LoginSql();

            menu(connectionString);
        }
    }
}
