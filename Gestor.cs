using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3TP6
{
    class Gestor: Conexion
    {
        public List<Escritor> ConsultaEscritores()
        {
            MySqlDataReader reader;
            List<Escritor> lista = new List<Escritor>();
            string sql;
            sql = $"SELECT * FROM escritor ORDER BY id;";

            MySqlConnection conexionDB = null;

            try
            {
                conexionDB = base.ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Escritor escritor = new Escritor();
                    escritor.id = int.Parse(reader.GetString("id"));
                    escritor.apellido = reader.GetString("apellido");
                    escritor.nombre = reader.GetString("nombre");
                    escritor.dni = int.Parse(reader.GetString("dni"));
                    escritor.libros = ConsultaLibros(int.Parse(reader.GetString("id")));

                    lista.Add(escritor);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }
            return lista;
        }

        public List<Libro> ConsultaLibros(int idEscritor)
        {
            MySqlDataReader reader;
            List<Libro> lista = new List<Libro>();
            string sql;
            sql = $"SELECT * FROM libro WHERE idEscritor={idEscritor};";

            MySqlConnection conexionDB = null;

            try
            {
                conexionDB = base.ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.nombre = reader.GetString("nombre");
                    libro.anioPublicacion = int.Parse(reader.GetString("anioPublicacion"));
                    libro.editorial = reader.GetString("editorial");
                    libro.idEscritor = int.Parse(reader.GetString("idEscritor"));

                    lista.Add(libro);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conexionDB.Close();
            }
            return lista;
        }
    }
}
