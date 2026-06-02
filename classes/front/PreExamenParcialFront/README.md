# Pre-Exam Front – NexoCommerce

Multi-page Angular e-commerce landing for a fictional platform called **NexoCommerce**. Built as front-end pre-exam practice covering components, services, routing, and reactive template patterns.

**Stack:** Angular 21 · TypeScript · Angular SSR (Express) · Angular Router · Vitest

---

## Pages & Routes

| Route | Component | Description |
|-------|-----------|-------------|
| `/` | `HomeComponent` | Marketing landing — hero, services, about (MVV), CTA, contact |
| `/productos` | `ProductsComponent` | Product catalogue with search and category filter |
| `/ofertas` | `OffersComponent` | Dedicated offers page |
| `**` | redirect → `/` | Wildcard fallback |

## Architecture

```
src/app/
├── pages/
│   ├── home/          # Full landing page (hero, services, about, contact, footer)
│   ├── products/      # Product catalogue (search, category pills, product cards)
│   └── offers/        # Offers page
├── components/
│   └── navbar/        # Shared nav bar (transparent mode, home section links)
├── services/
│   └── products.service.ts   # Product data service
├── models/            # Product interface and static data
└── app.routes.ts      # Client-side route definitions
```

## Features

- **Home page** — animated hero with mock dashboard, services grid, mission/vision/values cards, CTA section, contact cards, footer
- **Products page** — real-time search by name, category filter pills, product cards with discount badges, "Add to cart" toggle, broken image fallback with emoji
- **Navbar** — transparent mode on home, links to in-page sections
- **Routing** — `RouterLink` and `RouterOutlet` with wildcard redirect

---

## Running the project

```bash
npm install        # Install dependencies
npm start          # Dev server at http://localhost:4200
npm run build      # Production build → dist/
npm test           # Run tests with Vitest
```
