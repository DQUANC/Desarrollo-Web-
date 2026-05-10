import { Component, inject } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { PeliculasService } from '../peliculas.service';

@Component({
  selector: 'app-listado-peliculas',
  imports: [CurrencyPipe, DatePipe, RouterLink],
  templateUrl: './listado-peliculas.html',
  styleUrl: './listado-peliculas.css',
})
export class ListadoPeliculas {
  peliculasService = inject(PeliculasService);
  arregloPeliculas = this.peliculasService.peliculas;
}
