# Examen Parcial - API de Pedidos

API REST en ASP.NET 9 para registrar, consultar, modificar y eliminar pedidos.
Sigue la misma arquitectura y convenciones del proyecto `Backend_Banco`
(Web API + Core + Modelo, Dapper contra PostgreSQL, MongoDB para bitácora).

## Estructura

```
Examen_Parcial.slnx
Examen_Parcial/            -> Web API (ASP.NET 9)
  Program.cs                  DI de Npgsql/Mongo, Swagger UI
  appsettings.json            cadenas de conexión
  Controllers/PedidoController.cs
Core/                       -> Dapper, Npgsql, MongoDB.Driver
  Interfaz/IPedido.cs
  Servicios/PedidoServicio.cs
Modelo/                     -> MongoDB.Bson
  Modelos/MPedido.cs           entidad de PostgreSQL
  Modelos/MPedidoMongo.cs      bitácora de MongoDB
database/pedido_postgres.sql -> script de creación de la BD/tabla
```

## Modelo de datos

**PostgreSQL** - tabla `pedido`: número de pedido, nombre del cliente,
dirección de entrega, monto, estado, fecha de registro y usuario que
hizo la operación.

**MongoDB** - colección `Pedido_Historial` (base `ExamenParcial`): un
documento por cada alta (POST) y por cada modificación (PUT), con
número de pedido, ID de PostgreSQL, estado, fecha y una descripción
(en el PUT, el detalle de qué campos cambiaron).

## Endpoints (`Api/Pedido`)

| Método | Ruta                    | Descripción                              |
|--------|-------------------------|-------------------------------------------|
| GET    | `/Api/Pedido/ObtenerTodos` | Lista todos los pedidos                |
| GET    | `/Api/Pedido/{id}`         | Obtiene un pedido por ID               |
| POST   | `/Api/Pedido/Ingresar`     | Registra un pedido (Postgres + Mongo)  |
| PUT    | `/Api/Pedido/{id}`         | Modifica un pedido (Postgres + Mongo)  |
| DELETE | `/Api/Pedido/{id}`         | Elimina un pedido                      |

Ejemplos de request/response en `Examen_Parcial/Examen_Parcial.http`.

## Puesta en marcha local

1. **PostgreSQL**: ejecutar `database/pedido_postgres.sql` para crear la
   base `EXAMEN_PARCIAL` y la tabla `pedido`.
2. **MongoDB**: no requiere script, se crea sola al insertar el primer
   documento.
3. Ajustar `Examen_Parcial/appsettings.json` (`ConnectionStrings`) con
   las credenciales reales de tu Postgres local.
4. Ejecutar:
   ```
   dotnet run --project Examen_Parcial/Examen_Parcial.csproj
   ```
5. Swagger disponible en `http://localhost:5260/swagger`.

## Estado de verificación

- `dotnet build Examen_Parcial.slnx` -> compila sin errores ni warnings.
- La API fue levantada y probada end-to-end a nivel HTTP (validaciones,
  404, manejo de errores) el 2026-08-30.
- **Pendiente**: verificación contra una instancia real de PostgreSQL
  local, porque las credenciales de `appsettings.json` (`postgres`/`1234`)
  no coincidieron con la instancia usada en las pruebas y el servicio de
  Postgres quedó detenido/desregistrado durante las pruebas. Una vez
  disponible, correr el flujo POST -> PUT -> DELETE de
  `Examen_Parcial.http` para confirmar la escritura en PostgreSQL y en
  la colección `Pedido_Historial` de MongoDB.
