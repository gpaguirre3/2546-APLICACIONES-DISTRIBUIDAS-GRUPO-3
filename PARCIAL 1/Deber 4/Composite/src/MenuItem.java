public class MenuItem implements MenuComponent {

    private String name;

    // Constructor
    public MenuItem(String name) {
        this.name = name;
    }

    // Implementación del método print
    @Override
    public void print() {
        System.out.println("  Item: " + name);
    }
}
