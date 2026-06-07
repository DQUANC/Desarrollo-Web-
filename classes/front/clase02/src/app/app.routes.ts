import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { Productos } from './pages/productos/productos';
import { Clientes } from './pages/clientes/clientes';
import { Contactos } from './pages/contactos/contactos';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'productos', component: Productos },
    { path: 'clientes', component: Clientes },
    { path: 'contactos', component: Contactos },
    { path: '**', redirectTo: '' },
];
