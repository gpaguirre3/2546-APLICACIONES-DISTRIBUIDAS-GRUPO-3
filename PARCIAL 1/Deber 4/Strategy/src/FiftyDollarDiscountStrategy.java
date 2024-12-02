public class FiftyDollarDiscountStrategy implements DiscountStrategy {
    @Override
    public double applyDiscount(double price) {
        return price > 200 ? price - 50 : price;
    }
}
