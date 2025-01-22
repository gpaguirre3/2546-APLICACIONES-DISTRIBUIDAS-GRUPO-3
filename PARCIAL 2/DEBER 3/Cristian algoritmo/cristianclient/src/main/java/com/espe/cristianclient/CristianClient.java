package com.espe.cristianclient;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.SimpleDateFormat;
import java.util.Date;

public class CristianClient {
    public static void main(String[] args) {
        String serverAddress = "DESKTOP-P3AQF06"; // Dirección del servidor
        int port = 12345; // Puerto del servidor

        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");

        try (Socket socket = new Socket(serverAddress, port)) {
            System.out.println("Conectado al servidor en " + serverAddress + ":" + port);

            // Medir el tiempo antes de enviar la solicitud
            long t0 = System.currentTimeMillis();

            // Enviar solicitud al servidor
            try (PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
                 BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()))) {

                // Leer la hora del servidor
                long serverTime = Long.parseLong(in.readLine());

                // Medir el tiempo después de recibir la respuesta
                long t1 = System.currentTimeMillis();

                // Calcular la latencia de ida y vuelta
                long roundTripTime = t1 - t0;

                // Ajustar la hora local usando el Algoritmo de Cristian
                long adjustedTime = serverTime + (roundTripTime / 2);

                System.out.println("Hora del servidor: " + dateFormat.format(new Date(serverTime)));
                System.out.println("Latencia estimada: " + roundTripTime + " ms");
                System.out.println("Hora ajustada localmente: " + dateFormat.format(new Date(adjustedTime)));
            }

        } catch (Exception e) {
            System.err.println("Error en el cliente: " + e.getMessage());
        }
    }
}
