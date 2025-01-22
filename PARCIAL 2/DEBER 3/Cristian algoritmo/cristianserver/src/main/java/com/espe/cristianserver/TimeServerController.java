package com.espe.cristianserver;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.Map;

@RestController
public class TimeServerController {

    @GetMapping("/time")
    public Map<String, Long> getServerTime() {
        // Obtiene la hora actual del sistema en milisegundos
        long serverTime = System.currentTimeMillis();

        // Devuelve la hora como respuesta JSON
        Map<String, Long> response = new HashMap<>();
        response.put("serverTime", serverTime);
        return response;
    }
}
