﻿# Proyecto con Docker Compose

Este proyecto utiliza Docker Compose para levantar los contenedores del frontend, backend y la base de datos PostgreSQL.

## Requisitos previos

Asegúrate de tener Docker y Docker Compose instalados en tu máquina. Puedes obtenerlos desde los siguientes enlaces:

- [Instalar Docker](https://www.docker.com/get-started)
- [Instalar Docker Compose](https://docs.docker.com/compose/install/)

## Estructura del Proyecto

- **Frontend**: Aplicación cliente construida con el framework Vue.js .
- **Backend**: API construida con .NET que se conecta a la base de datos PostgreSQL.
- **Base de Datos**: Base de datos PostgreSQL para almacenar los datos.

## Instrucciones para ejecutar el proyecto

Sigue los siguientes pasos para ejecutar el proyecto utilizando Docker Compose:

1. **Clonar el repositorio**

   Si aún no tienes el proyecto en tu máquina, clónalo desde GitHub:

   ```bash
   git clone https://github.com/mizook/capsula_11_as_docker
   cd capsula_11_as_docker
   ```

2. **Construir y ejecutar los contenedores**

   En el directorio raíz del proyecto, donde se encuentra el archivo docker-compose.yml, ejecuta el siguiente comando para construir y levantar los contenedores:

   ```bash
   docker-compose up --build
   ```

   Este comando:

   Construye las imágenes de los contenedores si no están construidas previamente.
   Levanta los servicios de frontend, backend y db (base de datos PostgreSQL).

3. **Acceder al frontend**

   Una vez que los contenedores estén en ejecución, podrás acceder al frontend en tu navegador web:

   ```bash
   http://localhost:5173
   ```

4. **Acceder al backend**

   El backend estará disponible en:

   ```bash
   http://localhost:5017
   ```

   El swagger del backend estará disponible en:

   ```bash
   http://localhost:5017/swagger/index.html
   ```

5. **Detener los contenedores**

   Para detener los contenedores, puedes usar el siguiente comando:

   ```bash
   docker-compose down
   ```

   Esto detendrá y eliminará los contenedores.

## Notas:

Si el contenedor de la base de datos tarda en arrancar, el backend puede intentar conectarse antes de que PostgreSQL esté listo. Asegúrate de que el contenedor de la base de datos esté completamente operativo antes de que el backend se conecte.
