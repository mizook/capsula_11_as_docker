# API

Esta es una API REST creada en .NET que permite poblar una base de datos PostgreSQL con estudiantes.

## Requisitos previos

Asegúrate de tener instalados los siguientes elementos antes de ejecutar el proyecto:

1. .NET 8.
2. PostgreSQL

## Instalación

1. Clonar este repositorio:

   ```
   git clone https://github.com/mizook/capsula_11_as_docker
   cd capsula_11_as_docker
   ```

2. Restaurar las dependencias del proyecto:

   ```
   dotnet restore
   ```

## Ejecutar

1. Ejecutar el proyecto en local:

   ```
   dotnet run
   ```

2. La API estará disponible por defecto en http://localhost:5017.

## Uso

### Obtener datos

Realiza una solicitud GET al siguiente endpoint para obtener los datos:

```
GET /api/student
```

### Poblar la base de datos

Realiza una solicitud POST al siguiente endpoint para poblar la base de datos:

```
POST /api/student
```

## Contribuir

Este proyecto es un ejemplo educativo. Las contribuciones no son necesarias, pero puedes clonar y modificar el proyecto según tus necesidades.
