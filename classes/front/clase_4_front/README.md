# Clase 4 – Components, Services & Routing

Practice project introducing Angular component architecture, services, dependency injection, and client-side routing.

**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

---

## What it covers

- **Components** — standalone Angular components with `@Component` decorator
- **Services** — `PeliculasService` providing a `Pelicula` interface and a `getPelicula(id)` method
- **Routing** — `app.routes.ts` wiring up list and detail views
- **Pipes** — `CurrencyPipe` and `DatePipe` applied in templates
- **Component communication** — route params read with `ActivatedRoute`

## Architecture

```
src/app/
└── peliculas/
    ├── peliculas.service.ts          # Data service with Pelicula interface
    ├── listado-peliculas/            # List component (CurrencyPipe, DatePipe)
    └── detalle-pelicula/             # Detail component (single movie view)
app.routes.ts                         # Route definitions
```

---

## Running the project

```bash
npm install        # Install dependencies
npm start          # Dev server at http://localhost:4200
npm run build      # Production build → dist/
npm test           # Run tests with Vitest
```
