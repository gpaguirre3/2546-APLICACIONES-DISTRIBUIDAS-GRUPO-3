﻿using System;
using System.Windows.Forms;
using LibreriaCliente.Libreria; // Asegúrate de que esto apunta al espacio de nombres correcto

namespace LibreriaCliente
{
    public partial class Form1 : Form
    {
        // Crear una instancia del cliente del servicio SOAP
        private readonly Libreria.Libreria client = new Libreria.Libreria();
        public Form1()
        {
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

                var books = client.GetBooks();
                txtResult.Text = string.Join(Environment.NewLine, books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
