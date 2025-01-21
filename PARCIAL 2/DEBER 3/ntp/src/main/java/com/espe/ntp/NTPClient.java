package com.espe.ntp;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.nio.ByteBuffer;
import java.text.SimpleDateFormat;
import java.util.Date;

public class NTPClient {

    private static final String NTP_SERVER = "time.google.com"; // Servidor NTP
    private static final int NTP_PORT = 123; // Puerto estándar para NTP
    private static final long NTP_TIMESTAMP_OFFSET = 2208988800000L; // Desplazamiento desde 1900 a 1970 en milisegundos

    public static void main(String[] args) {
        try {
            // Crear un socket para comunicarse con el servidor NTP
            DatagramSocket socket = new DatagramSocket();
            InetAddress address = InetAddress.getByName(NTP_SERVER);

            // Crear un paquete de solicitud NTP (48 bytes)
            byte[] buffer = new byte[48];
            buffer[0] = 0b00100011; // Cabecera de la solicitud NTP

            // Enviar el paquete de solicitud
            DatagramPacket request = new DatagramPacket(buffer, buffer.length, address, NTP_PORT);
            socket.send(request);

            // Recibir el paquete de respuesta
            DatagramPacket response = new DatagramPacket(buffer, buffer.length);
            socket.receive(response);

            // Extraer la marca de tiempo de transmisión (bytes 40-47 en la respuesta)
            ByteBuffer byteBuffer = ByteBuffer.wrap(buffer);
            byteBuffer.position(40);
            long secondsSince1900 = byteBuffer.getInt() & 0xFFFFFFFFL; // Segundos desde 1900
            long fraction = byteBuffer.getInt() & 0xFFFFFFFFL; // Parte fraccionaria

            // Convertir a milisegundos desde la época Unix (1 de enero de 1970)
            long millisecondsSince1900 = (secondsSince1900 * 1000) + ((fraction * 1000) / 0x100000000L);
            long unixTime = millisecondsSince1900 - NTP_TIMESTAMP_OFFSET;

            // Formatear y mostrar la hora sincronizada
            Date date = new Date(unixTime);
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            System.out.println("Hora sincronizada: " + dateFormat.format(date));

            // Cerrar el socket
            socket.close();
        } catch (Exception e) {
            System.err.println("Error al sincronizar con el servidor NTP: " + e.getMessage());
        }
    }
}
