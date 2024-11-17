# Usa una imagen base de OpenJDK para Java
FROM openjdk:17-jdk-alpine

WORKDIR /app
# Copia el archivo jar generado en la carpeta target a la carpeta /app
COPY ./target/ProductManagement-0.0.1-SNAPSHOT.jar /app
# Establece el directorio de trabajo en /app

# Exponer el puerto en el que se ejecutará la aplicación
EXPOSE 8080
# Ejecuta el comando java -jar app.jar
ENTRYPOINT ["java", "-jar", "ProductManagement-0.0.1-SNAPSHOT.jar"]
