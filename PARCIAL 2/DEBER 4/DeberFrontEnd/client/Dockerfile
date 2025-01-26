# Usar la imagen de Node.js
FROM node:18-alpine

# Configurar directorio de trabajo
WORKDIR /app

# Copiar archivos del proyecto
COPY package.json yarn.lock ./

# Instalar dependencias
RUN yarn install

# Copiar el resto del proyecto
COPY . .

# Construir el proyecto
RUN yarn build

# Exponer el puerto del front-end
EXPOSE 3000

# Comando para ejecutar la aplicación
CMD ["yarn", "start"]
