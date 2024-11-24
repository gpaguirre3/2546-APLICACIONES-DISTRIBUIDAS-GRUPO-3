using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Services;

namespace ServicioLibros
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Libreria : System.Web.Services.WebService
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string AddBook(string title, string author, int year)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Books (Title, Author, Year) VALUES (@Title, @Author, @Year)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.ExecuteNonQuery();
            }
            return "Libro agregado correctamente.";
        }

        [WebMethod]
        public List<string> GetBooks()
        {
            List<string> books = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Books";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add($"ID: {reader["Id"]}, Título: {reader["Title"]}, Autor: {reader["Author"]}, Año: {reader["Year"]}");
                }
            }
            return books;
        }

        [WebMethod]
        public string UpdateBook(int id, string title, string author, int year)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Books SET Title = @Title, Author = @Author, Year = @Year WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.ExecuteNonQuery();
            }
            return "Libro actualizado correctamente.";
        }

        [WebMethod]
        public string DeleteBook(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Books WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            return "Libro eliminado correctamente.";
        }
        [WebMethod]
        public string GetBookById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Books WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return $"ID: {reader["Id"]}, Título: {reader["Title"]}, Autor: {reader["Author"]}, Año: {reader["Year"]}";
                }
                else
                {
                    return "Libro no encontrado.";
                }
            }
        }
    }
}
