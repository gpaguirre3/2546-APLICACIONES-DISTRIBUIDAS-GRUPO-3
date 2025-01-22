package com.espe;

import java.rmi.Naming;
import java.rmi.registry.LocateRegistry;

public class ServerRMI {
    public static void main(String[] args) {
        try {
            // Inicia el registro RMI en el puerto 1099
            LocateRegistry.createRegistry(1099);

            // Crea e instancia el servicio
            IHelloService helloService = new HelloServiceImpl();

            // Enlaza el servicio con un nombre
            Naming.rebind("HelloServices", helloService);

            System.out.println("Servidor listo y escuchando en HelloService.");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
