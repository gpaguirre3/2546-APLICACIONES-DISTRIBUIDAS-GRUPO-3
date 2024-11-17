using System;
using System.Windows.Forms;

namespace G3ClienteSoapCalculadora
{
    public partial class Form1 : Form
    {
        // Crear una instancia del cliente del servicio SOAP
        private readonly clientesoapdneonline.Calculator client = new clientesoapdneonline.Calculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidarEntrada(out int num1, out int num2))
            {
                try
                {
                    // Consumir el método Add del servicio
                    int resultado = client.Add(num1, num2);
                    textResult.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            if (ValidarEntrada(out int num1, out int num2))
            {
                try
                {
                    // Consumir el método Subtract del servicio
                    double resultado = client.Subtract(num1, num2);
                    textResult.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (ValidarEntrada(out int num1, out int num2))
            {
                try
                {
                    // Consumir el método Multiply del servicio
                    double resultado = client.Multiply(num1, num2);
                    textResult.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (ValidarEntrada(out int num1, out int num2))
            {
                try
                {
                    // Consumir el método Divide del servicio
                    if (num2 == 0)
                    {
                        MostrarError("No se puede dividir entre cero.");
                        return;
                    }
                    double resultado = client.Divide(num1, num2);
                    textResult.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reiniciar todos los campos
            txtNum1.Text = string.Empty;
            txtNum2.Text = string.Empty;
            textResult.Text = string.Empty;
        }

        /// <summary>
        /// Valida que los campos de entrada sean numéricos y devuelve sus valores.
        /// </summary>
        /// <param name="num1">Número 1.</param>
        /// <param name="num2">Número 2.</param>
        /// <returns>True si los valores son válidos.</returns>
        private bool ValidarEntrada(out int num1, out int num2)
        {
            num1 = 0;
            num2 = 0;

            if (!int.TryParse(txtNum1.Text, out num1))
            {
                MostrarError("Ingrese un número válido en el campo 1.");
                return false;
            }

            if (!int.TryParse(txtNum2.Text, out num2))
            {
                MostrarError("Ingrese un número válido en el campo 2.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Muestra un mensaje de error en un cuadro de diálogo.
        /// </summary>
        /// <param name="mensaje">Mensaje de error.</param>
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
