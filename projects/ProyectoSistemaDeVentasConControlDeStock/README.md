# Proyecto – Sistema de Ventas con Control de Stock

REST API for managing products and sales with automatic stock control, built as the final course project.

**Stack:** C# · .NET 8 · ASP.NET Core Web API · Dapper · PostgreSQL · Swagger

---

## Features

- Full CRUD for products (identified by SKU)
- Sales registration with automatic stock deduction
- Stock validation — a sale is rejected if any product has insufficient stock
- Sales detail view with product names and quantities

---

## Architecture

```
ProyectoSistemaDeVentasConControlDeStock/
├── Controllers/
│   ├── ProductoController.cs    # Product endpoints
│   └── VentaController.cs       # Sale endpoints
├── Services/
│   ├── ProductoServicio.cs      # Product business logic
│   └── VentasServicio.cs        # Sale business logic + stock check
├── Interfaces/
│   ├── IProductoServicio.cs
│   └── IVentaServicio.cs
├── Models/
│   ├── ProductoModel.cs
│   └── VentaModel.cs
└── DTOs/
    ├── ProductosDTOs/
    │   ├── CrearProductoDTO.cs
    │   ├── ActualizarProductoDTO.cs
    │   └── EliminarProductoDTO.cs
    └── VentasDTOs/
        ├── CrearVentaDTO.cs
        └── VentaDetalleDTO.cs
```

---

## API Endpoints

### Productos

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Producto/ObtenerTodos` | List all products |
| GET | `/api/Producto/ObtenerPorId/{sku}` | Get product by SKU |
| POST | `/api/Producto/Crear` | Create a new product |
| PUT | `/api/Producto/Actualizar` | Update a product |
| DELETE | `/api/Producto/Eliminar` | Delete a product |

### Ventas

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Venta/ObtenerTodas` | List all sales with product detail |
| POST | `/api/Venta/Registrar` | Register a sale (validates and deducts stock) |

---

## Database

Uses **PostgreSQL** via `Npgsql`. Configure the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ventas_db;Username=postgres;Password=yourpassword"
  }
}
```

---

## Running the project

```bash
dotnet restore     # Restore NuGet packages
dotnet run         # Start API (default: https://localhost:5001)
```

Swagger UI is available at `/swagger` in development mode.
