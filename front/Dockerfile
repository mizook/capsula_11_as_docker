# Etapa de construcción
FROM node:20 as build-stage
WORKDIR /app
COPY package*.json ./
RUN npm install

# Copia el resto del código y construye
COPY . .
RUN npm run build

# Etapa de producción
FROM nginx:stable-alpine as production-stage

# Copia los archivos construidos al contenedor de nginx
COPY --from=build-stage /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
