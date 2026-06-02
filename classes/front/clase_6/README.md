# Clase 6 – Pokémon Search App

Single-page Angular app that searches the public [PokeAPI](https://pokeapi.co/) by name or number and renders a full Pokémon detail card.

**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · HttpClient · FormsModule

---

## Features

- Search any Pokémon by name or Pokédex number
- Displays official artwork, height, weight, and base experience
- Type badges with color-coded gradients per type (fire, water, grass, etc.)
- Base stats rendered as progress bars with color tiers (red → yellow → green → blue)
- Abilities list
- Loads Pikachu by default on startup (`ngOnInit`)
- Loading and error states handled with `@if`

## Concepts covered

| Concept | Usage |
|---------|-------|
| `HttpClient` | `GET` request to `https://pokeapi.co/api/v2/pokemon/{name}` |
| Two-way binding | `[(ngModel)]` on the search input |
| `@if` / `@for` | Control flow for loading state, types, stats, abilities |
| Lifecycle hooks | `ngOnInit` to search a default Pokémon on load |
| Template helpers | `formatId`, `getTypeColor`, `getStatColor`, `getStatName` |

---

## Running the project

```bash
npm install        # Install dependencies
npm start          # Dev server at http://localhost:4200
npm run build      # Production build → dist/
npm test           # Run tests with Vitest
```
