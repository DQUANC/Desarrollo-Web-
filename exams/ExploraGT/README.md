# ExploraGT

Angular app for browsing Guatemalan tourism destinations, built as a front-end final exam.

**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Vitest

---

## What it does

ExploraGT presents a curated gallery of Guatemalan tourist destinations with category filtering. Users can filter by destination type and see a live count of matching results.

## Features

| Feature | Description |
|---------|-------------|
| Category filter | Filter buttons: Arqueológico, Natural, Colonial, Gastronómico, Aventura, (Todos) |
| Destination cards | Photo, name, location (department), description, star rating (1–5), "Destacado" badge |
| Reactive count | Displays how many destinations match the active filter |
| Static data | 10+ pre-loaded destinations (Tikal, Lago de Atitlán, Antigua Guatemala, etc.) |
| Responsive grid | CSS grid layout adapts to screen size |

## Architecture

```
src/app/
├── components/
│   └── destino-card/               # Reusable destination card component
│       ├── destino-card.component.ts
│       ├── destino-card.component.html
│       └── destino-card.component.scss
├── interfaces/
│   └── destino-turistico.interface.ts  # DestinoTuristico interface
├── services/
│   └── destinos.service.ts         # Injectable service with static destination list
├── app.html                        # Root shell (hero, filter bar, gallery grid, footer)
├── app.ts                          # Root component (filter logic, category state)
└── app.routes.ts                   # Route configuration
```

## Data model

```typescript
interface DestinoTuristico {
  id: number;
  nombre: string;
  ubicacion: string;       // Department / region
  descripcion: string;
  categoria: string;       // Arqueológico | Natural | Colonial | Gastronómico | Aventura
  imagenUrl: string;
  calificacion: number;    // 1–5
  destacado: boolean;
}
```

---

## Running the project

```bash
npm install        # Install dependencies
npm start          # Dev server at http://localhost:4200
npm run build      # Production build → dist/
npm test           # Run tests with Vitest
```
