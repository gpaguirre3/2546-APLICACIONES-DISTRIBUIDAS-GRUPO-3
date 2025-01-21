package com.espe.ntp;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.nio.ByteBuffer;
import java.text.SimpleDateFormat;
import java.util.Date;

@RestController
public class NTPClientController {

    // Dirección del servidor NTP al que nos conectaremos
    private static final String NTP_SERVER = "time.google.com";
    // Puerto estándar para el protocolo NTP
    private static final int NTP_PORT = 123;
    // Desplazamiento en milisegundos entre 1900 (inicio de NTP) y 1970 (inicio de Unix)
    private static final long NTP_TIMESTAMP_OFFSET = 2208988800000L;

    // Endpoint HTTP que sincroniza la hora cuando se accede a /sync-time
    @GetMapping("/sync-time")
    public String syncTime() {
        try (DatagramSocket socket = new DatagramSocket()) { // Crear un socket para enviar y recibir datos
            InetAddress address = InetAddress.getByName(NTP_SERVER); // Obtener la dirección del servidor NTP

            // Crear un buffer de 48 bytes para la solicitud NTP
            byte[] buffer = new byte[48];
            buffer[0] = 0b00100011; // Configurar el byte inicial según el estándar NTP

            // Crear y enviar un paquete de solicitud NTP al servidor
            DatagramPacket request = new DatagramPacket(buffer, buffer.length, address, NTP_PORT);
            socket.send(request);

            // Recibir la respuesta del servidor NTP
            DatagramPacket response = new DatagramPacket(buffer, buffer.length);
            socket.receive(response);

            // Extraer la marca de tiempo de transmisión del paquete de respuesta (bytes 40-47)
            ByteBuffer byteBuffer = ByteBuffer.wrap(buffer);
            byteBuffer.position(40); // Posicionar el buffer en el byte 40

            // Leer los segundos y fracciones desde 1900 en formato NTP
            long secondsSince1900 = byteBuffer.getInt() & 0xFFFFFFFFL;
            long fraction = byteBuffer.getInt() & 0xFFFFFFFFL;

            // Calcular el tiempo en milisegundos desde 1900
            long millisecondsSince1900 = (secondsSince1900 * 1000) + ((fraction * 1000) / 0x100000000L);
            // Ajustar para obtener el tiempo Unix (desde 1970)
            long unixTime = millisecondsSince1900 - NTP_TIMESTAMP_OFFSET;

            // Formatear la hora sincronizada para mostrarla como una cadena legible
            Date date = new Date(unixTime);
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            return "Hora sincronizada: " + dateFormat.format(date); // Devolver la hora sincronizada

        } catch (Exception e) {
            // Manejar errores y devolver un mensaje informativo
            return "Error al sincronizar con el servidor NTP: " + e.getMessage();
        }
    }
}
