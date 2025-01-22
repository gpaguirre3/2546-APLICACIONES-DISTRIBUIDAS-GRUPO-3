package com.espe;

import java.rmi.Naming;
import java.rmi.registry.LocateRegistry;

public class ServerRMI {
    public static void main(String[] args) {
        try {
            // Inicia el registro en el puerto 1099
            LocateRegistry.createRegistry(1099);
            // Crea la instancia del servicio
            IHelloService helloService = new HelloServiceImpl();
            // Enlaza el servicio con el registro RMI
            Naming.rebind("rmi://localhost/HelloService", helloService);
            //Naming.rebind("HelloService", helloService);
            //System.out.println("Servidor listo y escuchando en HelloService.");
            System.out.println("Servidor listo y escuchando en rmi://localhost/HelloService.");
        }catch (Exception e) {
            e.printStackTrace();
        }


    }
}