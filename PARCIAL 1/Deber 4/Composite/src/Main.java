//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        // Crear ítems del menú
        MenuItem item1 = new MenuItem("Pizza");
        MenuItem item2 = new MenuItem("Pasta");
        MenuItem item3 = new MenuItem("Ensalada");

        // Crear menús
        Menu mainMenu = new Menu("Main Menu");
        Menu italianMenu = new Menu("Italian Menu");

        // Añadir ítems al menú italiano
        italianMenu.add(item1);
        italianMenu.add(item2);

        // Añadir menú italiano y ensalada al menú principal
        mainMenu.add(italianMenu);
        mainMenu.add(item3);

        // Imprimir toda la estructura
        mainMenu.print();

    }
}