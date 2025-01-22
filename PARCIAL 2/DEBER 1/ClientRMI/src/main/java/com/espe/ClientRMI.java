package com.espe;

import java.rmi.Naming;

public class ClientRMI {
    public static void main(String[] args) {
        try {
            // Busca el servicio en el registro
            IHelloService helloService = (IHelloService) Naming.lookup("rmi://localhost/HelloServices");

            // Llama al método remoto
            //String response = helloService.sayHello("Juan");
            String response = helloService.sayHello("Juan");
            System.out.println("Respuesta del servidor: " + response);
            response = helloService.sayGoodbye("Juan");
            System.out.println("Respuesta del servidor: " + response);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
