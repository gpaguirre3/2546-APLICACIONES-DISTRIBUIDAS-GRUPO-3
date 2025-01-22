package com.espe.cristianclient;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Map;

@RestController
public class CristianClientController {

    @Value("${server.url:http://DESKTOP-P3AQF06:8080/time}")
    private String serverUrl; // URL del servidor, configurable desde application.properties

    @GetMapping("/sync-time")
    public String syncTime() {
        try {
            RestTemplate restTemplate = new RestTemplate();

            // Tiempo antes de enviar la solicitud
            long t0 = System.currentTimeMillis();

            // Realiza la solicitud al servidor
            Map<String, Long> response = restTemplate.getForObject(serverUrl, Map.class);

            // Tiempo después de recibir la respuesta
            long t1 = System.currentTimeMillis();

            if (response == null || !response.containsKey("serverTime")) {
                return "Error: No se pudo obtener la hora del servidor.";
            }

            // Obtiene la hora del servidor
            long serverTime = response.get("serverTime");

            // Calcula la latencia de ida y vuelta
            long roundTripTime = t1 - t0;

            // Ajusta la hora local considerando la latencia
            long adjustedTime = serverTime + (roundTripTime / 2);

            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
            return String.format(
                    "Hora del servidor: %s%nLatencia estimada: %d ms%nHora ajustada localmente: %s",
                    dateFormat.format(new Date(serverTime)),
                    roundTripTime,
                    dateFormat.format(new Date(adjustedTime))
            );

        } catch (Exception e) {
            return "Error al sincronizar el tiempo: " + e.getMessage();
        }
    }
}
