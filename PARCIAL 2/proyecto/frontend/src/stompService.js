// src/stompService.js

import { Client } from '@stomp/stompjs';

let stompClient = null;

export const connect = (roomId) => {
  stompClient = new Client({
    brokerURL: 'ws://localhost:8080/ws',  // Cambia esta URL si es necesario
    onConnect: () => {
      console.log(`Conectado al servidor WebSocket en room ${roomId}`);
    },
    onDisconnect: () => {
      console.log("Desconectado del servidor WebSocket");
    },
    onStompError: (frame) => {
      console.error("Error STOMP: ", frame);
    }
  });
  
  stompClient.activate();

  // Suscripción a un topic específico por roomId
  stompClient.onConnect = () => {
    stompClient.subscribe(`/topic/${roomId}`, (messageOutput) => {
      const receivedMessage = JSON.parse(messageOutput.body);
      // Lógica para manejar el mensaje recibido
      console.log("Mensaje recibido:", receivedMessage);
    });
  };
};

export const sendMessage = (roomId, message) => {
  if (stompClient && stompClient.connected) {
    stompClient.publish({
      destination: `/app/chat/${roomId}`, // Enviar el mensaje al roomId
      body: JSON.stringify({ user: "Usuario", mensaje: message })
    });
  } else {
    console.error("STOMP no está conectado");
  }
};

export const disconnect = () => {
  if (stompClient) {
    stompClient.deactivate();
    console.log("Desconectado de STOMP");
  }
};

export const getStompClient = () => stompClient;
