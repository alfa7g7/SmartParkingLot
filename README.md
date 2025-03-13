# Smart Parking Lot Management System

Este proyecto implementa un backend para un sistema de gestión de estacionamiento inteligente.

## Requisitos

- .NET 6 o .NET 8
- Visual Studio 2022 o Visual Studio Code

## Configuración

1. Clona el repositorio
2. Abre la solución en Visual Studio o el proyecto en Visual Studio Code
3. Restaura los paquetes NuGet

## Ejecución

1. Compila el proyecto
2. Ejecuta la aplicación
3. La API estará disponible en `https://localhost:5001` o `http://localhost:5000`

## Endpoints

- GET /api/parking-spots: Obtiene todos los espacios de estacionamiento
- POST /api/parking-spots/{id}/occupy: Ocupa un espacio de estacionamiento
- POST /api/parking-spots/{id}/free: Libera un espacio de estacionamiento
- POST /api/parking-spots: Agrega un nuevo espacio de estacionamiento
- DELETE /api/parking-spots/{id}: Elimina un espacio de estacionamiento

## Pruebas

Ejecuta las pruebas unitarias desde Visual Studio o usando el comando `dotnet test` en la terminal.
