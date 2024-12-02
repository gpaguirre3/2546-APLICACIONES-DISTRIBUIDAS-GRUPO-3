//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Product product = new Product("Laptop", 250);

        System.out.println(product);

        // Cambiar a una estrategia de descuento del 10%
        product.setDiscountStrategy(new TenPercentDiscountStrategy());
        System.out.println(product);

        // Cambiar a una estrategia de descuento de $50
        product.setDiscountStrategy(new FiftyDollarDiscountStrategy());
        System.out.println(product);
    }




}