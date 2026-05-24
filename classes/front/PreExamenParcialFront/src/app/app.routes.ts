import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home';
import { ProductsComponent } from './pages/products/products';
import { OffersComponent } from './pages/offers/offers';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'productos', component: ProductsComponent },
  { path: 'ofertas', component: OffersComponent },
  { path: '**', redirectTo: '' },
];
