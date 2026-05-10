import { Routes } from '@angular/router';
import { ListadoPeliculas } from './peliculas/listado-peliculas/listado-peliculas';
import { DetallePelicula } from './peliculas/detalle-pelicula/detalle-pelicula';

export const routes: Routes = [
  { path: '', component: ListadoPeliculas },
  { path: 'pelicula/:id', component: DetallePelicula }
];
