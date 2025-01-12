import React, { useState, useEffect } from "react";
import { Button, Container, Row, Col, Form, Card, ListGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

import { Client } from "@stomp/stompjs";
import SockJS from "sockjs-client";
import './App.css'; // Para personalizar estilos adicionales



const App = () => {
  const [messages, setMessages] = useState([]);
  const [message, setMessage] = useState('');
  const [user, setUser] = useState('User');
  const [client, setClient] = useState(null);
  const [roomId, setRoomId] = useState('general'); // Para la sala de chat
  const [connected, setConnected] = useState(false);

  // Establecer la conexión WebSocket
  useEffect(() => {
    const sock = new SockJS("http://localhost:8080/chat-socket");
    const stompClient = new Client({
      webSocketFactory: () => sock,
      onConnect: () => {
        stompClient.subscribe(`/topic/${roomId}`, (messageOutput) => {
          setMessages((prevMessages) => [
            ...prevMessages,
            JSON.parse(messageOutput.body),
          ]);
        });
        setConnected(true);
      },
    });

    stompClient.activate();
    setClient(stompClient);

    return () => {
      if (stompClient) stompClient.deactivate();
    };
  }, [roomId]);

  // Enviar mensaje
  const sendMessage = () => {
    if (message && client) {
      const chatMessage = { user: user, mensaje: message };
      client.publish({
        destination: `/app/chat/${roomId}`,
        body: JSON.stringify(chatMessage),
      });
      setMessage('');
    }
  };

  return (
    <Container className="my-4">
      <Row>
        <Col md={6} className="mx-auto">
          <Card>
            <Card.Header className="text-center">
              <h3>Chat - {roomId}</h3>
            </Card.Header>
            <Card.Body>
              <ListGroup variant="flush" className="mb-3" style={{ maxHeight: '400px', overflowY: 'scroll' }}>
                {messages.map((msg, index) => (
                  <ListGroup.Item key={index} className="d-flex justify-content-between">
                    <strong>{msg.user}:</strong> <span>{msg.mensaje}</span>
                  </ListGroup.Item>
                ))}
              </ListGroup>

              {connected ? (
                <Form>
                  <Row>
                    <Col>
                      <Form.Control
                        type="text"
                        placeholder="Escribe un mensaje..."
                        value={message}
                        onChange={(e) => setMessage(e.target.value)}
                      />
                    </Col>
                    <Col xs="auto">
                      <Button variant="primary" onClick={sendMessage}>
                        Enviar
                      </Button>
                    </Col>
                  </Row>
                </Form>
              ) : (
                <div>Conectando...</div>
              )}
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default App;
