# Web Development Exams

This folder contains practical exams for the Web Development course. Each exam evaluates the ability to design and implement a REST API under time-constrained conditions.

---

## Partial Exam — Reservations API

**Path:** `Examen_Parcial_DesarrolloWeb1/`
**Stack:** C# · .NET Core 3.1 · ASP.NET Core Web API · Dapper · SQL Server · Swagger

REST API for managing reservations, built with layered architecture.

**Architecture:**
- `Controllers/` — `ControladorReserva`
- `Services/` — `ServicioReserva`
- `Interfaces/` — `IReserva`
- `Models/` — `ModeloReserva`
- `DTOs/` — `CrearReservaDTO`, `ActualizarReservaDTO`

**Endpoints:**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/ControladorReserva/Obtener Todos` | List all reservations |
| POST | `/api/ControladorReserva/Crear Reserva` | Create a reservation |
| PUT | `/api/ControladorReserva/Actualizar Reserva` | Update a reservation |

---

## Final Exam — Events & Inscriptions API

**Path:** `Examen_Final_DesarrolloWeb1/`
**Stack:** C# · .NET 8 · ASP.NET Core Web API · SQL Server · Swagger

REST API for an event management platform with inscriptions, movement history, and alerts.

**Architecture:**
- `Controllers/` — `EventoController`, `PersonaController`, `InscripcionController`
- `Services/` — `EventoService`, `PersonaService`, `InscripcionService`
- `Interfaces/` — `IEventoService`, `IPersonaService`, `IInscripcionService`
- `Models/` — `eventosModel`, `PersonaModel`, `InscripcionesModel`, `Historial_MovimientosModel`, `AlertasModel`
- `DTOs/` — `InscripcionDTO`

**Modules:**

| Module | Description |
|--------|-------------|
| Personas | People registered in the system |
| Eventos | Events that can be created and listed |
| Inscripciones | Registrations linking people to events |
| Historial de Movimientos | Audit trail of system changes |
| Alertas | Automated alerts for system events |

---

## Final Exam — ExploraGT (Front-end)

**Path:** `ExploraGT/`
**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

Single-page Angular application for browsing Guatemalan tourism destinations. Built as a front-end final exam.

**Architecture:**
- `src/app/components/destino-card/` — reusable card component showing image, location, rating, and badges
- `src/app/services/destinos.service.ts` — in-memory data service providing all destinations
- `src/app/interfaces/destino-turistico.interface.ts` — `DestinoTuristico` interface
- `app.html` — root shell: hero header, category filter bar, destination grid, footer

**Features:**

| Feature | Description |
|---------|-------------|
| Category filter | Filter buttons for Arqueológico, Natural, Colonial, Gastronómico, Aventura |
| Destination cards | Image, name, location, description, star rating, "Destacado" badge |
| Reactive count | Shows number of destinations matching the active filter |
| Static data | 10+ pre-loaded Guatemalan destinations (Tikal, Lago de Atitlán, etc.) |

---

## Skills Evaluated

- Layered architecture (Controllers, Services, Interfaces, Models, DTOs)
- RESTful API design and correct HTTP verb usage
- Dependency injection in ASP.NET Core
- Data access with Dapper and SQL Server
- Angular components, services, and reactive template patterns
- Problem-solving under time constraints
