import java.util.ArrayList;
import java.util.List;

public class Menu implements MenuComponent{

    private String name;
    private List<MenuComponent> components = new ArrayList<>();

    // Constructor
    public Menu(String name) {
        this.name = name;
    }

    // Añadir un componente
    public void add(MenuComponent component) {
        components.add(component);
    }

    // Eliminar un componente
    public void remove(MenuComponent component) {
        components.remove(component);
    }

    // Obtener un hijo por índice
    public MenuComponent getChild(int index) {
        return components.get(index);
    }

    // Implementación del método print
    @Override
    public void print() {
        System.out.println("Menu: " + name);
        for (MenuComponent component : components) {
            component.print();
        }
    }
}
