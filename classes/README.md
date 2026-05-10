# Classes

This folder contains work developed during class sessions for the Web Development course, organized by technology layer: **backend** and **frontend**.

---

## Backend – Inventory Management API

**Path:** `backend/Pre_Examen/`
**Stack:** C# · .NET Core 3.1 · ASP.NET Core Web API · Dapper · SQL Server · Swagger

Practice project covering layered architecture and REST API design for managing inventory items (`Producto`).

**Architecture:**
- `Controllers/` — `InventarioController` with HTTP endpoints
- `Services/` — `ServicioInventario` with business logic
- `Interfaces/` — `IServicioInventario`
- `Models/` — `Producto`
- `DTOs/` — `ProductoPorIdDto`, `ProductoCrearPorDto`

**Endpoints:**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Inventario` | List all products |
| GET | `/api/Inventario/{id}` | Get a product by ID |
| POST | `/api/Inventario` | Create a product |
| PUT | `/api/Inventario` | Update a product |
| DELETE | `/api/Inventario/{id}` | Delete a product |

---

## Frontend – Angular Class Project

**Path:** `front/clase2_Front/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

Practice project covering Angular fundamentals through a demo page that renders data from the component class.

**Concepts covered:**

| Section | What it demonstrates |
|---------|---------------------|
| Variables | Template interpolation of `nombre`, `apellido`, `titulo` |
| Operations | Inline arithmetic in templates |
| Functions | `DuplicarNumero`, `SumarNumeros`, `ConcatenarNombres` |
| Object | Single `pelicula` object with title, date, and price |
| Array – Movies | `arregloPelicula` rendered with `@for` loop |
| Array – Games | `arregloVideojuego` with images, dates, and prices |

**Scripts:**

```bash
npm start          # Dev server (ng serve)
npm run build      # Production build
npm test           # Run tests with Vitest
```
