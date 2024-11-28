namespace ClienteSoapRest
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtUnitsInStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.bbtnGetProductById = new System.Windows.Forms.Button();
            this.btnFilterProducts = new System.Windows.Forms.Button();
            this.txtCategoryDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreateCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnFilterCategories = new System.Windows.Forms.Button();
            this.btnGetCategoryById = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(436, 154);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(158, 23);
            this.btnUpdateProduct.TabIndex = 1;
            this.btnUpdateProduct.Text = "actualizar";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "preciounitario";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(226, 125);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(168, 22);
            this.txtProductId.TabIndex = 5;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(226, 154);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(168, 22);
            this.txtProductName.TabIndex = 6;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(226, 183);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(168, 22);
            this.txtProductPrice.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(436, 123);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(158, 23);
            this.btnAddProduct.TabIndex = 8;
            this.btnAddProduct.Text = "Añadir";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtUnitsInStock
            // 
            this.txtUnitsInStock.Location = new System.Drawing.Point(226, 217);
            this.txtUnitsInStock.Name = "txtUnitsInStock";
            this.txtUnitsInStock.Size = new System.Drawing.Size(168, 22);
            this.txtUnitsInStock.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "unidades en stock";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(226, 248);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(168, 22);
            this.txtCategoryId.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "id de categoria";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(226, 290);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(168, 22);
            this.txtCategoryName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "nombre de categoria";
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(436, 194);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(158, 23);
            this.btnDeleteProduct.TabIndex = 15;
            this.btnDeleteProduct.Text = "Borrar";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // bbtnGetProductById
            // 
            this.bbtnGetProductById.Location = new System.Drawing.Point(436, 232);
            this.bbtnGetProductById.Name = "bbtnGetProductById";
            this.bbtnGetProductById.Size = new System.Drawing.Size(158, 23);
            this.bbtnGetProductById.TabIndex = 16;
            this.bbtnGetProductById.Text = "Consultar por id";
            this.bbtnGetProductById.UseVisualStyleBackColor = true;
            this.bbtnGetProductById.Click += new System.EventHandler(this.bbtnGetProductById_Click);
            // 
            // btnFilterProducts
            // 
            this.btnFilterProducts.Location = new System.Drawing.Point(436, 272);
            this.btnFilterProducts.Name = "btnFilterProducts";
            this.btnFilterProducts.Size = new System.Drawing.Size(158, 23);
            this.btnFilterProducts.TabIndex = 17;
            this.btnFilterProducts.Text = "Consultar por nombre";
            this.btnFilterProducts.UseVisualStyleBackColor = true;
            this.btnFilterProducts.Click += new System.EventHandler(this.btnFilterProducts_Click);
            // 
            // txtCategoryDescription
            // 
            this.txtCategoryDescription.Location = new System.Drawing.Point(260, 341);
            this.txtCategoryDescription.Name = "txtCategoryDescription";
            this.txtCategoryDescription.Size = new System.Drawing.Size(197, 22);
            this.txtCategoryDescription.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Descripcion de categoria";
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Location = new System.Drawing.Point(635, 124);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(193, 23);
            this.btnCreateCategory.TabIndex = 20;
            this.btnCreateCategory.Text = "crear categoria";
            this.btnCreateCategory.UseVisualStyleBackColor = true;
            this.btnCreateCategory.Click += new System.EventHandler(this.btnCreateCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(635, 154);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(193, 23);
            this.btnUpdateCategory.TabIndex = 21;
            this.btnUpdateCategory.Text = "Actualizar categoria";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(635, 194);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(193, 23);
            this.btnDeleteCategory.TabIndex = 22;
            this.btnDeleteCategory.Text = "Borrar categoria";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnFilterCategories
            // 
            this.btnFilterCategories.Location = new System.Drawing.Point(635, 272);
            this.btnFilterCategories.Name = "btnFilterCategories";
            this.btnFilterCategories.Size = new System.Drawing.Size(193, 23);
            this.btnFilterCategories.TabIndex = 23;
            this.btnFilterCategories.Text = "Categoria por nombre";
            this.btnFilterCategories.UseVisualStyleBackColor = true;
            this.btnFilterCategories.Click += new System.EventHandler(this.btnFilterCategories_Click);
            // 
            // btnGetCategoryById
            // 
            this.btnGetCategoryById.Location = new System.Drawing.Point(635, 232);
            this.btnGetCategoryById.Name = "btnGetCategoryById";
            this.btnGetCategoryById.Size = new System.Drawing.Size(193, 23);
            this.btnGetCategoryById.TabIndex = 24;
            this.btnGetCategoryById.Text = "Categoria por id";
            this.btnGetCategoryById.UseVisualStyleBackColor = true;
            this.btnGetCategoryById.Click += new System.EventHandler(this.btnGetCategoryById_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 450);
            this.Controls.Add(this.btnGetCategoryById);
            this.Controls.Add(this.btnFilterCategories);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnUpdateCategory);
            this.Controls.Add(this.btnCreateCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCategoryDescription);
            this.Controls.Add(this.btnFilterProducts);
            this.Controls.Add(this.bbtnGetProductById);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnitsInStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox txtUnitsInStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button bbtnGetProductById;
        private System.Windows.Forms.Button btnFilterProducts;
        private System.Windows.Forms.TextBox txtCategoryDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCreateCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnFilterCategories;
        private System.Windows.Forms.Button btnGetCategoryById;
    }
}

