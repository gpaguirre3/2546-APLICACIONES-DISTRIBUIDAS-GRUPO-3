//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        // Cambia entre LightThemeFactory y DarkThemeFactory para ver el comportamiento
        GUIFactory factory = new LightThemeFactory();
        //GUIFactory factory = new DarkThemeFactory();
        Application app = new Application(factory);
        app.render();
    }
}