public class Product {
    private String name;
    private double price;
    private DiscountStrategy discountStrategy;

    public Product(String name, double price) {
        this.name = name;
        this.price = price;
        this.discountStrategy = new NoDiscountStrategy(); // Estrategia por defecto
    }

    public void setDiscountStrategy(DiscountStrategy discountStrategy) {
        this.discountStrategy = discountStrategy;
    }

    public double getPriceAfterDiscount() {
        return discountStrategy.applyDiscount(price);
    }

    @Override
    public String toString() {
        return name + ": $" + price + " (con descuento: $" + getPriceAfterDiscount()
                + ")";
    }
}
