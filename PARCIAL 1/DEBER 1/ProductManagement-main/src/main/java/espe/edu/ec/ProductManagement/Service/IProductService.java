package espe.edu.ec.ProductManagement.Service;

import espe.edu.ec.ProductManagement.Model.Product;

import java.util.List;

public interface IProductService {
    public List<Product> getAllProducts();

    public Product getProductById(long id);

    public Product addProduct(Product product);

    public Product updateProduct(Product product);

    public void deleteProduct(long id);
}
