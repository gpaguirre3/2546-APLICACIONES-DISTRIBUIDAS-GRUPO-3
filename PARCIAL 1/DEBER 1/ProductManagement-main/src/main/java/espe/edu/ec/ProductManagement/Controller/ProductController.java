package espe.edu.ec.ProductManagement.Controller;

import espe.edu.ec.ProductManagement.Exception.ProducNotFound;
import espe.edu.ec.ProductManagement.Model.Product;
import espe.edu.ec.ProductManagement.Service.IProductService;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import org.slf4j.Logger;

@RestController
// http://localhost:8080/ProductManagement/products
@RequestMapping("ProductManagement")
@CrossOrigin

public class ProductController {
    private static final Logger logger = LoggerFactory.getLogger(ProductController.class);

    @Autowired
    private IProductService productService;

    @GetMapping("/products")
    public List<Product> getAllProducts() {
        var products = productService.getAllProducts();
        products.forEach(product -> logger.info(product.toString()));
        return products;
    }

    @PostMapping("/products")
    public Product addProduct(@RequestBody Product product) {
        logger.info(product.toString());
        return productService.addProduct(product);
    }

    @GetMapping("/products/{id}")
    public ResponseEntity<Product> getProductById(@PathVariable long id) {
        Product product = productService.getProductById(id);
        if (product == null) {
            throw new ProducNotFound("Product not found with id " + id);
        }
        return ResponseEntity.ok(product);
    }

    @PutMapping("/products/{id}")
    public ResponseEntity<Product> updateProduct(@PathVariable long id, @RequestBody Product product) {
        Product product1 = productService.getProductById(id);
        if (product1 == null) {
            throw new ProducNotFound("Product not found with id " + id);
        }
        product.setId(id);
        return ResponseEntity.ok(productService.addProduct(product));
    }

    @DeleteMapping("/products/{id}")
    public ResponseEntity<Product> deleteProduct(@PathVariable long id) {
        Product product = productService.getProductById(id);
        if (product == null) {
            throw new ProducNotFound("Product not found with id " + id);
        }
        productService.deleteProduct(id);
        return ResponseEntity.ok(product);
    }
}

