    package org.example;

    import java.time.Instant;
    import java.time.LocalDateTime;
    import java.time.ZoneId;
    import java.time.format.DateTimeFormatter;
    import java.util.Random;
    import java.util.concurrent.CyclicBarrier;

    class Node extends Thread {
        private String nodeId;
        private long localTime;
        private boolean isMaster;
        private final DateTimeFormatter formatter = DateTimeFormatter.ofPattern("HH:mm:ss.SSS");
        private BerkeleyAlgorithm berkeley;
        private boolean running;
        private CyclicBarrier syncBarrier;

        public Node(String nodeId, boolean isMaster, BerkeleyAlgorithm berkeley, CyclicBarrier syncBarrier) {
            this.nodeId = nodeId;
            this.isMaster = isMaster;
            this.berkeley = berkeley;
            this.syncBarrier = syncBarrier;
            this.running = true;
            Random rand = new Random();
            this.localTime = System.currentTimeMillis() + rand.nextInt(20001) - 10000;
        }

        @Override
        public void run() {
            try {
                while (running) {
                    // Esperar a que todos los nodos estén listos para la sincronización
                    syncBarrier.await();

                    if (isMaster) {
                        // El nodo maestro inicia la sincronización
                        berkeley.synchronizeClocks();
                    }

                    // Esperar a que termine la sincronización
                    syncBarrier.await();

                    // Simular deriva de tiempo
                    if (!isMaster) {
                        simulateTimeDrift();
                    }

                    if (running) {  // Solo mostrar el mensaje si seguimos ejecutando
                        System.out.println("\n>>> Esperando " + (berkeley.getSyncInterval()/1000) +
                                " segundos para la siguiente sincronización... <<<");
                    }

                    // Esperar el intervalo de sincronización
                    Thread.sleep(berkeley.getSyncInterval());
                }
            } catch (Exception e) {
                System.out.println("Error en el nodo " + nodeId + ": " + e.getMessage());
            }

        }

        private void simulateTimeDrift() {
            Random rand = new Random();
            long drift = rand.nextInt(2001) - 1000;
            adjustTime(drift);
        }

        public void stopNode() {
            this.running = false;
        }

        public String getNodeId() {
            return nodeId;
        }

        public long getLocalTime() {
            return localTime;
        }

        public String getFormattedTime() {
            LocalDateTime dateTime = LocalDateTime.ofInstant(
                    Instant.ofEpochMilli(localTime),
                    ZoneId.systemDefault()
            );
            return formatter.format(dateTime);
        }

        public void adjustTime(long adjustment) {
            this.localTime += adjustment;
        }

        public boolean isMaster() {
            return isMaster;
        }

        @Override
        public String toString() {
            return String.format("Nodo %s - Tiempo local: %d ms (%s)",
                    nodeId, localTime, getFormattedTime());
        }
    }

