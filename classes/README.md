# 📚 Classes

This folder contains work developed during class sessions for the Web Development course, organized by technology layer: **backend** and **frontend**.

| Folder | Stack | Description |
|--------|-------|-------------|
| [backend/Clase2](./backend/Clase2/) | C# · .NET Core 3.1 | 🦸 SuperHeroes & Villanos API |
| [backend/Clase_7](./backend/Clase_7/) | C# · .NET Core 3.1 | 👤 Clientes API |
| [front/clase2_Front](./front/clase2_Front/) | Angular 21 · TypeScript | 🔤 Frontend basics: variables, functions, objects, arrays |
| [front/clase_4_front](./front/clase_4_front/) | Angular 21 · TypeScript | 🧩 Components, services, routing, and Angular pipes |

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

## 🖥️ Scripts (Frontend projects)

```bash
npm start          # Dev server (ng serve)
npm run build      # Production build
npm test           # Run tests with Vitest
```
