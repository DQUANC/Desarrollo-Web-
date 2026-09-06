import { Routes } from '@angular/router';

import { Inicio } from './pages/inicio/inicio';
import { Clientes } from './pages/clientes/clientes';
import { Usuarios } from './pages/usuarios/usuarios';
import { Movimientos } from './pages/movimientos/movimientos';

export const routes: Routes = [

  {
    path: '',
    component: Inicio
  },

  {
    path: 'clientes',
    component: Clientes
  },

  {
    path: 'usuarios',
    component: Usuarios
  },

  {
    path: 'movimientos',
    component: Movimientos
  },

  {
    path: '**',
    redirectTo: ''
  }

];