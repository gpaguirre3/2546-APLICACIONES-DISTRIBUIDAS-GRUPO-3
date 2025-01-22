package org.example;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.CyclicBarrier;


public class Main {
    public static void main(String[] args) {
        // Crear el algoritmo de Berkeley con 3 iteraciones
        BerkeleyAlgorithm berkeley = new BerkeleyAlgorithm(3);

        // Crear barrera cíclica para la sincronización
        CyclicBarrier syncBarrier = new CyclicBarrier(5); // 5 nodos en total

        // Crear nodos (1 maestro y 4 esclavos)
        Node masterNode = new Node("Master", true, berkeley, syncBarrier);
        Node slave1 = new Node("Slave1", false, berkeley, syncBarrier);
        Node slave2 = new Node("Slave2", false, berkeley, syncBarrier);
        Node slave3 = new Node("Slave3", false, berkeley, syncBarrier);
        Node slave4 = new Node("Slave4", false, berkeley, syncBarrier);
        Node slave5 = new Node("Slave5", false, berkeley, syncBarrier);
        // Agregar nodos al sistema
        berkeley.addNode(masterNode);
        berkeley.addNode(slave1);
        berkeley.addNode(slave2);
        berkeley.addNode(slave3);
        berkeley.addNode(slave4);
        berkeley.addNode(slave5);

        // Iniciar la simulación
        System.out.println("Iniciando simulación con hilos del Algoritmo de Berkeley");
        berkeley.startSystem();

        System.out.println("\nSimulación completada.");
    }
}