package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CyclicBarrier;

class BerkeleyAlgorithm {
    private List<Node> nodes;
    private Node masterNode;
    private static final int SYNC_INTERVAL = 5000; // 5 segundos entre sincronizaciones
    private CyclicBarrier syncBarrier;
    private int iterations;
    private int currentIteration;

    public BerkeleyAlgorithm(int iterations) {
        this.nodes = new ArrayList<>();
        this.iterations = iterations;
        this.currentIteration = 0;
    }

    public void addNode(Node node) {
        nodes.add(node);
        if (node.isMaster()) {
            masterNode = node;
        }
    }

    public int getSyncInterval() {
        return SYNC_INTERVAL;
    }

    public void startSystem() {
        // Crear barrera cíclica para sincronización
        syncBarrier = new CyclicBarrier(nodes.size(), () -> {
            currentIteration++;
            if (currentIteration >= iterations) {
                stopAllNodes();
            }
        });

        // Iniciar todos los nodos
        for (Node node : nodes) {
            node.start();
        }

        // Esperar a que todos los nodos terminen
        try {
            for (Node node : nodes) {
                node.join();
            }
        } catch (InterruptedException e) {
            System.out.println("Error esperando a los nodos: " + e.getMessage());
        }
    }

    private void stopAllNodes() {
        for (Node node : nodes) {
            node.stopNode();
        }
    }

    public synchronized void synchronizeClocks() {
        if (masterNode == null || nodes.isEmpty()) {
            System.out.println("Error: Se necesita al menos un nodo maestro y nodos esclavos");
            return;
        }

        System.out.println("\n====================================================");
        System.out.println("           INICIANDO SINCRONIZACIÓN " );
        System.out.println("====================================================");

        // Paso 1: Obtener tiempos de todos los nodos
        System.out.println("\nRecolectando tiempos actuales de todos los nodos:");
        System.out.println("----------------------------------------------------");
        for (Node node : nodes) {
            System.out.println(node);
        }

        // Paso 2: Calcular diferencias respecto al maestro
        System.out.println("\nCalculando diferencias respecto al nodo maestro:");
        System.out.println("----------------------------------------------------");
        long masterTime = masterNode.getLocalTime();
        List<Long> timeDifferences = new ArrayList<>();

        for (Node node : nodes) {
            long diff = node.getLocalTime() - masterTime;
            timeDifferences.add(diff);
            System.out.printf("Diferencia para %s: %d ms%n", node.getNodeId(), diff);
        }

        // Paso 3: Calcular el promedio de las diferencias
        long averageDifference = calculateAverage(timeDifferences);
        System.out.println("\nPromedio de diferencias calculado: " + averageDifference + " ms");

        // Paso 4: Ajustar todos los relojes
        System.out.println("\nAjustando relojes al tiempo promedio:");
        System.out.println("----------------------------------------------------");
        for (int i = 0; i < nodes.size(); i++) {
            Node node = nodes.get(i);
            long adjustment = averageDifference - timeDifferences.get(i);
            node.adjustTime(adjustment);
            System.out.printf("Ajuste para %s: %d ms%n", node.getNodeId(), adjustment);
        }

        // Mostrar resultados finales
        System.out.println("\nEstado final después de la sincronización:");
        System.out.println("----------------------------------------------------");
        for (Node node : nodes) {
            System.out.println(node);
        }
        System.out.println("====================================================\n");
    }

    private long calculateAverage(List<Long> differences) {
        long sum = 0;
        for (Long diff : differences) {
            sum += diff;
        }
        return sum / differences.size();
    }
}