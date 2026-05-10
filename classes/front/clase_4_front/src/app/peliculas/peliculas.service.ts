import { Injectable } from '@angular/core';

export interface Pelicula {
  id: number;
  titulo: string;
  fechaLanzamiento: Date;
  precio: number;
  poster: string;
  sinopsis: string;
  genero: string;
  calificacion: number;
  duracion: number;
}

@Injectable({ providedIn: 'root' })
export class PeliculasService {
  peliculas: Pelicula[] = [
    {
      id: 1,
      titulo: 'Inside Out 2',
      fechaLanzamiento: new Date('2024-06-14'),
      precio: 500.00,
      poster: 'https://image.tmdb.org/t/p/w500/vpnVM9B6NMmQpWeZvzLvDESb2QY.jpg',
      sinopsis: 'Riley entra a la preparatoria y sus emociones originales deben hacer espacio para nuevas emociones inesperadas, como Ansiedad.',
      genero: 'Animación / Comedia / Familiar',
      calificacion: 7.6,
      duracion: 100,
    },
    {
      id: 2,
      titulo: 'Moana 2',
      fechaLanzamiento: new Date('2024-11-27'),
      precio: 400.00,
      poster: 'https://image.tmdb.org/t/p/w500/aLVkiINlIeCkcZIzb7XHzPYgO6L.jpg',
      sinopsis: 'Moana recibe un llamado inesperado de sus ancestros y debe viajar a los mares lejanos de Oceanía junto a un equipo de navegantes.',
      genero: 'Animación / Aventura / Familiar',
      calificacion: 6.7,
      duracion: 100,
    }
  ];

  getPelicula(id: number): Pelicula | undefined {
    return this.peliculas.find(p => p.id === id);
  }
}
