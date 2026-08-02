# 📚 Classes

This folder contains work developed during class sessions, organized by course and technology layer: **backend**, **frontend**, and **aplicaciones-mobiles**.

| Folder | Stack | Description |
|--------|-------|-------------|
| [backend/Clase2](./backend/Clase2/) | C# · .NET Core 3.1 | 🦸 SuperHeroes & Villanos API |
| [backend/Clase_7](./backend/Clase_7/) | C# · .NET Core 3.1 | 👤 Clientes API |
| [backend/Pre_Examen](./backend/Pre_Examen/) | C# · .NET Core 3.1 | 📦 Inventory management API (Productos) |
| [front/clase2_Front](./front/clase2_Front/) | Angular 21 · TypeScript | 🔤 Frontend basics: variables, functions, objects, arrays |
| [front/clase_4_front](./front/clase_4_front/) | Angular 21 · TypeScript | 🧩 Components, services, routing, and Angular pipes |
| [front/clase_6](./front/clase_6/) | Angular 21 · TypeScript | ⚡ Pokémon search app consuming PokeAPI with HttpClient |
| [front/PreExamenParcialFront](./front/PreExamenParcialFront/) | Angular 21 · TypeScript | 🛒 NexoCommerce — multi-page e-commerce landing with routing |
| [aplicaciones-mobiles/Backend_Banco](./aplicaciones-mobiles/Backend_Banco/) | C# · .NET 9 · PostgreSQL | 🏦 Banco backend API (Usuarios) for the Mobile Applications course |

---

## ⚙️ Backend

### 🦸 Clase 2 – SuperHeroes & Villanos API

**Path:** `backend/Clase2/`
**Stack:** C# · .NET Core 3.1 · ASP.NET Core Web API · Dapper · SQL Server · Swagger

REST API managing superheroes and villains with full CRUD operations.

**🏗️ Architecture:**
- `Controllers/` — `SuperHeroeController`, `VillanoController`
- `Services/` — `ServicioSuperHeroe`, `ServicioVillano`
- `Interfaces/` — `IServicioSuperHeroe`, `IServicioVillano`
- `Models/` — `SuperHeroe`, `Villano`
- `DTOs/` — `VillanoBuscarPorIdDto`, `VillanoCreateDto`

---

### 👤 Clase 7 – Clientes API

**Path:** `backend/Clase_7/`
**Stack:** C# · .NET Core 3.1 · ASP.NET Core Web API · Dapper · SQL Server

REST API for customer management.

**🏗️ Architecture:**
- `Controllers/` — `ClienteController`
- `Servicio/` — `ClienteServicio`
- `Interfaz/` — `IClienteServicio`
- `Modelo/` — `Cliente`

---

### 📦 Pre-Exam – Inventario API

**Path:** `backend/Pre_Examen/`
**Stack:** C# · .NET Core 3.1 · ASP.NET Core Web API · Dapper · SQL Server · Swagger

Inventory management API built as pre-exam practice. Manages products with CRUD operations.

**🏗️ Architecture:**
- `Controllers/` — `InventarioController`
- `Services/` — `ServicioInventario`
- `Interfaces/` — `IServicioInventario`
- `Models/` — `Producto`
- `DTOs/` — `ProductoCrearPorDto`, `ProductoPorIdDto`

**Endpoints:**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Inventario/obtener-todos` | List all products |
| GET | `/api/Inventario/obtener-por-id/{id}` | Get product by ID |
| POST | `/api/Inventario/obtener-por-id-body` | Get product by ID (body) |
| POST | `/api/Inventario/crear-producto` | Create a product |

---

## 🎨 Frontend

### 🔤 Clase 2 – Angular Basics

**Path:** `front/clase2_Front/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

Practice project covering Angular fundamentals: template interpolation, functions, objects, and arrays.

**🧠 Concepts covered:**

| Section | What it demonstrates |
|---------|---------------------|
| 📌 Variables | Binding `nombre`, `apellido`, `titulo` to the template |
| ➕ Operations | Inline arithmetic in templates |
| ⚡ Functions | `DuplicarNumero`, `SumarNumeros`, `ConcatenarNombres` |
| 🎬 Object | Single `pelicula` object with title, date, and price |
| 🎬 Array – Movies | `arregloPelicula` rendered with `@for` loop |
| 🎮 Array – Games | `arregloVideojuego` with images, dates, and prices |

---

### 🧩 Clase 4 – Components, Services & Routing

**Path:** `front/clase_4_front/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

Practice project introducing Angular components, services, and client-side routing.

**🏗️ Architecture:**
- `peliculas/` — feature module for movies
  - `PeliculasService` — data service with `Pelicula` interface and `getPelicula(id)` method
  - `listado-peliculas/` — component listing all movies with `CurrencyPipe` and `DatePipe`
  - `detalle-pelicula/` — component showing a single movie's detail
- `app.routes.ts` — client-side routing configuration

---

### ⚡ Clase 6 – Pokémon Search App

**Path:** `front/clase_6/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · HttpClient

Single-page app that queries the public [PokeAPI](https://pokeapi.co/) by name or number and renders a Pokémon detail card.

**🧠 Concepts covered:**

| Concept | Usage |
|---------|-------|
| `HttpClient` | `GET` request to PokeAPI REST endpoint |
| Two-way binding | `[(ngModel)]` on the search input |
| Control flow | `@if` for loading/error/result states; `@for` for types, stats, abilities |
| Lifecycle hooks | `ngOnInit` to load a default Pokémon on startup |
| Inline helpers | `formatId`, `getTypeColor`, `getStatColor`, `getStatName` |

---

### 🛒 Pre-Exam Front – NexoCommerce

**Path:** `front/PreExamenParcialFront/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Angular Router

Multi-page e-commerce landing for a fictional platform called **NexoCommerce**. Built as front-end pre-exam practice.

**🏗️ Architecture:**
- `pages/home/` — marketing landing with hero, services, about, and contact sections
- `pages/products/` — product catalogue with search and category filtering
- `pages/offers/` — dedicated offers page
- `components/navbar/` — shared navigation bar with transparent mode
- `services/products.service.ts` — product data service
- `models/` — product interface and data models
- `app.routes.ts` — client-side routing (`/`, `/productos`, `/ofertas`)

---

## 📱 Aplicaciones Móviles

### 🏦 Backend Banco – Usuarios API

**Path:** `aplicaciones-mobiles/Backend_Banco/`
**Stack:** C# · .NET 9 · ASP.NET Core Web API · Dapper · PostgreSQL (Npgsql) · Swagger

Backend API built as the server side for a mobile banking app, with full CRUD plus status/password management for users.

**🏗️ Architecture:**
- `Backend_Banco/` — Web API project, `Controllers/UsuarioController`
- `Core/` — `Servicios/UsuarioServicio`, `Interfaz/IUsuario`
- `Modelo/` — `Modelos/MUsuario`

**Endpoints:**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Usuario/ObtenerTodos` | List all users |
| GET | `/api/Usuario/{id}` | Get user by ID |
| GET | `/api/Usuario/usuario/{usuario}` | Get user by login |
| POST | `/api/Usuario` | Create a user |
| PUT | `/api/Usuario/{id}` | Update a user |
| PATCH | `/api/Usuario/{id}/estado` | Toggle a user's status |
| PATCH | `/api/Usuario/{id}/password` | Change a user's password |
| DELETE | `/api/Usuario/{id}` | Delete a user |

---

## 🖥️ Scripts (Frontend projects)

```bash
npm start          # Dev server (ng serve)
npm run build      # Production build
npm test           # Run tests with Vitest
```
