package com.espe.cristianserver;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.text.SimpleDateFormat;
import java.util.Date;

public class CristianServer {
    public static void main(String[] args) {
        int port = 12345; // Puerto donde escucha el servidor
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");

        try (ServerSocket serverSocket = new ServerSocket(port)) {
            System.out.println("Servidor escuchando en el puerto " + port);

            while (true) {
                // Aceptar conexión del cliente
                Socket clientSocket = serverSocket.accept();
                System.out.println("Cliente conectado desde " + clientSocket.getInetAddress());

                // Obtener la hora actual del servidor
                long serverTime = System.currentTimeMillis();

                // Enviar la hora al cliente
                try (PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true)) {
                    out.println(serverTime);
                }

                System.out.println("Hora enviada al cliente: " + dateFormat.format(new Date(serverTime)));
            }
        } catch (IOException e) {
            System.err.println("Error en el servidor: " + e.getMessage());
        }
    }
}
