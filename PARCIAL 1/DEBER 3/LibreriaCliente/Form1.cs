using System;
using System.Linq;
using System.Windows.Forms;
using LibreriaCliente.Libreria; // Asegúrate de que esto apunta al espacio de nombres correcto

namespace LibreriaCliente
{
    public partial class Form1 : Form
    {
        
        // Crear una instancia del cliente del servicio SOAP
        private readonly librerianueva.Libreria client = new librerianueva.Libreria();

        public Form1()
        {
            // Deshabilitar la validación del certificado SSL (solo para pruebas)
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
               
                var result = client.AddBook(txtTitle.Text, txtAuthor.Text, int.Parse(txtYear.Text));
                txtResult.Text = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un año válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
        

       
        

      
        

        private void btnUpdateBook_Click_1(object sender, EventArgs e)
        {
            try
            {

                var result = client.UpdateBook(int.Parse(txtId.Text), txtTitle.Text, txtAuthor.Text, int.Parse(txtYear.Text));
                txtResult.Text = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un ID y un año válidos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteBook_Click_1(object sender, EventArgs e)
        {
            try
            {

                var result = client.DeleteBook(int.Parse(txtId.Text));
                txtResult.Text = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
        private void btnGetBooks_Click_1(object sender, EventArgs e)
        {
            try
            {
                int bookId;
                if (int.TryParse(txtId.Text, out bookId))
                {
                    var book = client.GetBookById(bookId); // Llama al método en el servicio
                    txtResult.Text = book;
                }
                else
                {
                    MessageBox.Show("Ingrese un ID válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                var books = client.GetBooks();

                if (books == null || books.Length == 0)
                {
                    txtResult.Text = "No se encontraron libros.";
                    return;
                }

                // Muestra todos los libros en el TextBox
                txtResult.Text = string.Join(Environment.NewLine, books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}

