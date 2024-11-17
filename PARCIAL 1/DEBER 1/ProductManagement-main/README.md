# ProductManagement
Este proyecto es un microservicio de gestión de productos desarrollado con Spring Boot, que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre una base de datos PostgreSQL alojada en Docker.

## Requisitos
- Tener instalado **Docker**
- Tener instalado **Postman**

## Configuración del entorno
1. Clona o descargar el repositorio:
2. Asegúrate de que Docker esté instalado y ejecutándose en tu sistema.

## Ejecución del proyecto
El proyecto incluye un archivo `docker-compose.yml` para configurar y levantar la base de datos PostgreSQL y el microservicio en un contenedor Docker.

Para iniciar el proyecto acceda a la teorminar de window y dirigirse a la ruta del proyecto.

Estando ya estando en la ruta del proyecto ejecutar el siguiente comando.

docker-compose up -d.

Esto descargará y configurará PostgreSQL y el  microservicio en un contenedor Docker en segundo plano.

Una vez comprobado que se este ejecutando el contenedor de docker utilizaremos el Programa de Postman para poder realizar la pruebas nesesarias del microservicio

utilizaremos la siguiente ruta: http://localhost:8080/ProductManagement/products para pobra el microservicio

# Endpoints
## GET /productos

Recupera la lista completa de productos almacenados en la base de datos.

Devuelve un arreglo de productos, donde cada producto contiene detalles como id, nombre, descripcion y precio.

## GET /productos/{id}
Busca y devuelve la información de un producto específico a través de su ID.

Parámetro: ID del producto que se desea obtener.

Devuelve un objeto JSON con los detalles del producto solicitado. Si el producto no existe, devuelve un código de error 404 Not Found.

## POST /productos
Crea un nuevo producto y lo guarda en la base de datos.

Debe incluir un objeto JSON con los campos nombre, descripcion y precio.

Devuelve el objeto del producto creado con su id asignado, y un código de respuesta 201 Created.

## PUT /productos/{id}
Actualiza los detalles de un producto existente.

Parámetros: ID del producto que se desea actualizar.

Un objeto JSON con los campos que deseas actualizar (nombre, descripcion y/o precio).

Devuelve el producto actualizado en formato JSON. Si el producto no existe, devuelve un código de error 404 Not Found.

## DELETE /productos/{id}
Elimina un producto específico de la base de datos.

Parámetro: ID del producto que se desea eliminar.

Devuelve un código de respuesta 204 No Content si la eliminación es exitosa. Si el producto no existe, devuelve un código de error 404 Not Found.

# Pruebas de ejecución

## Metodo POST
![post](https://github.com/user-attachments/assets/2f5bc503-4cc0-4b8b-a686-67d65f5a80a8)

## Metodo Get
![get](https://github.com/user-attachments/assets/37f3ce96-83d8-4e75-b55b-3f10271865de)

## Metodo Get ID
![get id](https://github.com/user-attachments/assets/63a13ddf-9ee8-4971-a6a3-c77ef4f34ed7)

## Metodo DELETE
![delete](https://github.com/user-attachments/assets/5dac1e60-8535-48ef-bee6-e67eb4336528)

## Metodo PUT 
![put](https://github.com/user-attachments/assets/31a22328-f855-4059-9545-6ee933a7b058)








