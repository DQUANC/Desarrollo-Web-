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

## Skills Evaluated

- Layered architecture (Controllers, Services, Interfaces, Models, DTOs)
- RESTful API design and correct HTTP verb usage
- Dependency injection in ASP.NET Core
- Data access with Dapper and SQL Server
- Problem-solving under time constraints
