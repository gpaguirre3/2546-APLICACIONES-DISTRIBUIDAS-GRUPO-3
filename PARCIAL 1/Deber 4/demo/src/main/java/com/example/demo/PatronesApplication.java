package com.example.demo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;



import org.springframework.boot.CommandLineRunner;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

// Clase principal que ejecuta la aplicación
@SpringBootApplication
public class PatronesApplication implements CommandLineRunner {

	public static void main(String[] args) {
		SpringApplication.run(PatronesApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Scanner scanner = new Scanner(System.in);

		while (true) {
			// Menú interactivo
			System.out.println("Seleccione el patrón de diseño que desea probar:");
			System.out.println("1. Factory Method");
			System.out.println("2. Abstract Factory");
			System.out.println("3. Adapter");
			System.out.println("4. Composite");
			System.out.println("5. Proxy");
			System.out.println("6. Facade");
			System.out.println("7. Command");
			System.out.println("8. Observer");
			System.out.println("9. Strategy");
			System.out.println("0. Salir");
			System.out.print("Opción: ");
			int opcion = scanner.nextInt();

			switch (opcion) {
				case 1: runFactoryMethod(); break;
				case 2: runAbstractFactory(); break;
				case 3: runAdapter(); break;
				case 4: runComposite(); break;
				case 5: runProxy(); break;
				case 6: runFacade(); break;
				case 7: runCommand(); break;
				case 8: runObserver(); break;
				case 9: runStrategy(); break;
				case 0: System.exit(0); break;
				default: System.out.println("Opción no válida."); break;
			}
		}
	}

	// Ejemplo de Factory Method
	private void runFactoryMethod() {
		System.out.println("\n--- Factory Method ---");
		Product product = new ConcreteProduct();
		product.operation();
	}

	// Ejemplo de Abstract Factory
	private void runAbstractFactory() {
		System.out.println("\n--- Abstract Factory ---");
		AbstractFactory factory = new ConcreteFactory();
		ProductA productA = factory.createProductA();
		ProductB productB = factory.createProductB();
		productA.operation();
		productB.operation();
	}

	// Ejemplo de Adapter
	private void runAdapter() {
		System.out.println("\n--- Adapter ---");
		Target target = new Adapter(new Adaptee());
		target.request();
	}

	// Ejemplo de Composite
	private void runComposite() {
		System.out.println("\n--- Composite ---");
		Component leaf1 = new Leaf();
		Component leaf2 = new Leaf();
		Composite composite = new Composite();
		composite.add(leaf1);
		composite.add(leaf2);
		composite.operation();
	}

	// Ejemplo de Proxy
	private void runProxy() {
		System.out.println("\n--- Proxy ---");
		RealSubject realSubject = new RealSubject();
		ProxySubject proxy = new ProxySubject(realSubject);
		proxy.request();
	}

	// Ejemplo de Facade
	private void runFacade() {
		System.out.println("\n--- Facade ---");
		Facade facade = new Facade();
		facade.operation();
	}

	// Ejemplo de Command
	private void runCommand() {
		System.out.println("\n--- Command ---");
		Command command = new ConcreteCommand(new Receiver());
		Invoker invoker = new Invoker(command);
		invoker.execute();
	}

	// Ejemplo de Observer
	private void runObserver() {
		System.out.println("\n--- Observer ---");
		Subject Subject = new ConcreteSubject();
		Observer observer = new ConcreteObserver();
		((ConcreteSubject) Subject).addObserver(observer);
		((ConcreteSubject) Subject).notifyObservers();
	}

	// Ejemplo de Strategy
	private void runStrategy() {
		System.out.println("\n--- Strategy ---");
		Context context = new Context(new ConcreteStrategyA());
		context.executeStrategy();
	}
}

// ---- Factory Method ----
interface Product {
	void operation();
}

class ConcreteProduct implements Product {
	@Override
	public void operation() {
		System.out.println("ConcreteProduct operation.");
	}
}

// ---- Abstract Factory ----
interface ProductA {
	void operation();
}

interface ProductB {
	void operation();
}

abstract class AbstractFactory {
	public abstract ProductA createProductA();
	public abstract ProductB createProductB();
}

class ConcreteFactory extends AbstractFactory {
	@Override
	public ProductA createProductA() {
		return new ConcreteProductA();
	}

	@Override
	public ProductB createProductB() {
		return new ConcreteProductB();
	}
}

class ConcreteProductA implements ProductA {
	@Override
	public void operation() {
		System.out.println("ConcreteProductA operation.");
	}
}

class ConcreteProductB implements ProductB {
	@Override
	public void operation() {
		System.out.println("ConcreteProductB operation.");
	}
}

// ---- Adapter ----
class Adaptee {
	public void specificRequest() {
		System.out.println("Adaptee specificRequest.");
	}
}

interface Target {
	void request();
}

class Adapter implements Target {
	private Adaptee adaptee;

	public Adapter(Adaptee adaptee) {
		this.adaptee = adaptee;
	}

	@Override
	public void request() {
		adaptee.specificRequest();
	}
}

// ---- Composite ----
abstract class Component {
	public abstract void operation();
}

class Leaf extends Component {
	@Override
	public void operation() {
		System.out.println("Leaf operation.");
	}
}

class Composite extends Component {
	private final List<Component> children = new ArrayList<>();

	public void add(Component component) {
		children.add(component);
	}

	@Override
	public void operation() {
		System.out.println("Composite operation.");
		for (Component child : children) {
			child.operation();
		}
	}
}

// ---- Proxy ----
interface Subject {
	void addObserver(Observer observer);

	void removeObserver(Observer observer);

	void notifyObservers();

	void request();
}

class RealSubject implements Subject {
	@Override
	public void addObserver(Observer observer) {

	}

	@Override
	public void removeObserver(Observer observer) {

	}

	@Override
	public void notifyObservers() {

	}

	@Override
	public void request() {
		System.out.println("RealSubject request.");
	}
}

class ProxySubject implements Subject {
	private RealSubject realSubject;

	public ProxySubject(RealSubject realSubject) {
		this.realSubject = realSubject;
	}

	@Override
	public void addObserver(Observer observer) {

	}

	@Override
	public void removeObserver(Observer observer) {

	}

	@Override
	public void notifyObservers() {

	}

	@Override
	public void request() {
		System.out.println("ProxySubject request.");
		realSubject.request();
	}
}

// ---- Facade ----
class SubSystemA {
	public void operationA() {
		System.out.println("SubSystemA operation.");
	}
}

class SubSystemB {
	public void operationB() {
		System.out.println("SubSystemB operation.");
	}
}

class Facade {
	private SubSystemA subsystemA = new SubSystemA();
	private SubSystemB subsystemB = new SubSystemB();

	public void operation() {
		subsystemA.operationA();
		subsystemB.operationB();
	}
}

// ---- Command ----
class Receiver {
	public void action() {
		System.out.println("Receiver action.");
	}
}

interface Command {
	void execute();
}

class ConcreteCommand implements Command {
	private Receiver receiver;

	public ConcreteCommand(Receiver receiver) {
		this.receiver = receiver;
	}

	@Override
	public void execute() {
		receiver.action();
	}
}

class Invoker {
	private Command command;

	public Invoker(Command command) {
		this.command = command;
	}

	public void execute() {
		command.execute();
	}
}

// ---- Observer ----
interface Observer {
	void update();
}



class ConcreteObserver implements Observer {
	@Override
	public void update() {
		System.out.println("ConcreteObserver update.");
	}
}

class ConcreteSubject implements Subject {
	private List<Observer> observers = new ArrayList<>();

	@Override
	public void addObserver(Observer observer) {
		observers.add(observer);
	}

	@Override
	public void removeObserver(Observer observer) {
		observers.remove(observer);
	}

	@Override
	public void notifyObservers() {
		for (Observer observer : observers) {
			observer.update();
		}
	}

	@Override
	public void request() {

	}
}

// ---- Strategy ----
interface Strategy {
	void execute();
}

class ConcreteStrategyA implements Strategy {
	@Override
	public void execute() {
		System.out.println("ConcreteStrategyA execute.");
	}
}

class Context {
	private Strategy strategy;

	public Context(Strategy strategy) {
		this.strategy = strategy;
	}

	public void executeStrategy() {
		strategy.execute();
	}
}
