using System;
using System.Linq;
using System.Windows.Forms;

namespace ClienteSoapRest
{
    public partial class Form1 : Form
    {
        private readonly Categoryproduct.Producto client = new Categoryproduct.Producto();
        public Form1()
        {
            InitializeComponent();
        }

        // Método para agregar un producto
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los datos ingresados
                if (string.IsNullOrEmpty(txtProductName.Text) ||
                    string.IsNullOrEmpty(txtProductPrice.Text) ||
                    string.IsNullOrEmpty(txtUnitsInStock.Text) ||
                    string.IsNullOrEmpty(txtCategoryId.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un objeto de producto con los datos del formulario
                var product = new Categoryproduct.ProductDTO
                {
                    ProductID = 0, // o cualquier valor por defecto
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtProductPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = int.Parse(txtCategoryId.Text),

                    //CategoryName = txtCategoryName.Text
                    CategoryName=client.GetCategoryById(int.Parse(txtCategoryId.Text)).CategoryName
                };

                // Llamar al método del servicio para agregar el producto
                var result = client.CreateProductDTO(product);

                // Mostrar resultado
                MessageBox.Show("Producto agregado con éxito. ID generado: " + result.ProductID, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores válidos en los campos numéricos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para actualizar un producto
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los datos ingresados
                if (string.IsNullOrEmpty(txtProductId.Text) ||
                    string.IsNullOrEmpty(txtProductName.Text) ||
                    string.IsNullOrEmpty(txtProductPrice.Text) ||
                    string.IsNullOrEmpty(txtUnitsInStock.Text) ||
                    string.IsNullOrEmpty(txtCategoryId.Text) )
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un objeto de producto con los datos del formulario
                var product = new Categoryproduct.ProductDTO
                {
                    ProductID = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtProductPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = int.Parse(txtCategoryId.Text),
                    CategoryName = client.GetCategoryById(int.Parse(txtCategoryId.Text)).CategoryName
                };

                // Llamar al método del servicio para actualizar el producto
                var result = client.UpdateProductDTO(product);

                // Mostrar resultado
                if (result)
                {
                    MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores válidos en los campos numéricos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

        }

        private void bbtnGetProductById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var product = client.GetProductById(id);

            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtProductPrice.Text = product.UnitPrice.ToString();
                txtUnitsInStock.Text = product.UnitsInStock.ToString();
                txtCategoryId.Text = product.CategoryID.ToString();
                
            }
            else
            {
                MessageBox.Show("Producto no encontrado");
            }
        }

        private void btnFilterProducts_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar el filtro por nombre proporcionado por el usuario
                string productName = txtProductName.Text.Trim();

                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Por favor, ingresa un nombre de producto para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método del cliente para filtrar productos por nombre
                var filteredProducts = client.FilterProductsDTO(productName);

                if (filteredProducts != null && filteredProducts.Any())
                {
                    // Mostrar el primer producto encontrado en las cajas de texto
                    var product = filteredProducts.First();
                    txtProductName.Text = product.ProductName;
                    txtProductPrice.Text = product.UnitPrice.ToString();
                    txtUnitsInStock.Text = product.UnitsInStock.ToString();
                    txtCategoryId.Text = product.CategoryID.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron productos con el nombre proporcionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoryName.Text))
                {
                    MessageBox.Show("Por favor, completa el nombre de la categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var category = new Categoryproduct.CategoryDTO
                {
                    CategoryID = 0, // o cualquier valor por defecto
                    CategoryName = txtCategoryName.Text,
                    Description = txtCategoryDescription.Text
                };

                var result = client.CreateCategoryDTO(category);
                MessageBox.Show("Categoría creada con éxito. ID generado: " + result.CategoryID, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoryId.Text) || string.IsNullOrEmpty(txtCategoryName.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var category = new Categoryproduct.CategoryDTO
                {
                    CategoryID = int.Parse(txtCategoryId.Text),
                    CategoryName = txtCategoryName.Text,
                    Description = txtCategoryDescription.Text
                };

                var result = client.UpdateCategoryDTO(category);
                MessageBox.Show(result ? "Categoría actualizada con éxito." : "No se pudo actualizar la categoría.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoryId.Text))
                {
                    MessageBox.Show("Por favor, ingresa el ID de la categoría a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int categoryId = int.Parse(txtCategoryId.Text);
                var result = client.DeleteCategory(categoryId);
                MessageBox.Show(result ? "Categoría eliminada con éxito." : "No se pudo eliminar la categoría.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFilterCategories_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Por favor, ingresa un nombre de categoría para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filteredCategories = client.FilterCategoryDTO(categoryName);

                if (filteredCategories != null && filteredCategories.Any())
                {
                    var category = filteredCategories.First();
                    txtCategoryId.Text = category.CategoryID.ToString();
                    txtCategoryName.Text = category.CategoryName;
                    txtCategoryDescription.Text = category.Description;
                }
                else
                {
                    MessageBox.Show("No se encontraron categorías con el nombre proporcionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetCategoryById_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoryId.Text))
                {
                    MessageBox.Show("Por favor, ingresa el ID de la categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtCategoryId.Text);
                var category = client.GetCategoryById(id);

                if (category != null)
                {
                    txtCategoryName.Text = category.CategoryName;
                    txtCategoryDescription.Text = category.Description;
                }
                else
                {
                    MessageBox.Show("Categoría no encontrada.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un ID válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
