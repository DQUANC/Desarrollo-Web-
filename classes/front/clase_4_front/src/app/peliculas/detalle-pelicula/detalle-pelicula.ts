import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { PeliculasService, Pelicula } from '../peliculas.service';

@Component({
  selector: 'app-detalle-pelicula',
  imports: [CurrencyPipe, DatePipe, RouterLink],
  templateUrl: './detalle-pelicula.html',
  styleUrl: './detalle-pelicula.css',
})
export class DetallePelicula implements OnInit {
  private route = inject(ActivatedRoute);
  private peliculasService = inject(PeliculasService);

  pelicula: Pelicula | undefined;

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.pelicula = this.peliculasService.getPelicula(id);
  }
}
