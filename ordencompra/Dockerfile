# Usa una imagen base de OpenJDK para Java
FROM openjdk:17-jdk-alpine

WORKDIR /app

# Copia el archivo jar generado en la carpeta target
COPY ./target/ordencompra-0.0.1-SNAPSHOT.jar /app

# Exponer el puerto en el que se ejecutará la aplicación
EXPOSE 8002
# Ejecuta el comando java -jar app.jar
ENTRYPOINT ["java", "-jar", "ordencompra-0.0.1-SNAPSHOT.jar"]
