import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  titulo = "clase 2 desarrollo web - Front end"
  nombre = "Daniel"
  apellido = "Quan"
  protected readonly title = signal('clase2_Front');

  // Funciones
  DuplicarNumero(valor: number): number {
    return valor * 2;
  }
  SumarNumeros(valor1: number, valor2: number): number {
    return valor1 + valor2;
  }
  ConcatenarNombres(nombre: string, nombre2: string, apellido: string, apellido2: string) {
    if (nombre != null && nombre2 != null && apellido != null && apellido2 != null) {
      console.log("Los datos son correctos");
      return nombre + " " + nombre2 + " " + apellido + " " + apellido2;
    } else {
      console.log("El dato es null");
      return "ERROR";
    }
  }

  // Objeto
  pelicula = {
    titulo: "Spider-man",
    FechaDeLanzamiento: new Date(),
    precio: 5000
  }

  // Arreglos - Array
  arregloPelicula = [
    {
      titulo: "Spider-man 1",
      FechaDeLanzamiento: new Date(),
      precio: 1400
    },
    {
      titulo: "Spider-man 2",
      FechaDeLanzamiento: new Date(),
      precio: 1500
    },
    {
      titulo: "Spider-man 3",
      FechaDeLanzamiento: new Date(),
      precio: 2500
    },
    {
      titulo: "Batman: The Dark Knight",
      FechaDeLanzamiento: new Date(),
      precio: 2600
    }
  ]

  arregloVideojuego = [
    {
      titulo: 'The Legend of Zelda',
      fechaLanzamiento: new Date(2017, 2, 3),
      precio: 500,
      imagen: 'https://cdn.pacifiko.com/image/cache/catalog/p/B076P6K4YT-500x500.jpg'
    },
    {
      titulo: 'God of War',
      fechaLanzamiento: new Date(2018, 3, 20),
      precio: 550,
      imagen: 'https://cdn.cloudflare.steamstatic.com/steam/apps/1593500/header.jpg'
    },
    {
      titulo: 'FIFA 24',
      fechaLanzamiento: new Date(2023, 8, 29),
      precio: 600,
      imagen: 'https://cdn.cloudflare.steamstatic.com/steam/apps/2195250/header.jpg'
    },
    {
      titulo: 'Call of Duty',
      fechaLanzamiento: new Date(2022, 9, 28),
      precio: 650,
      imagen: 'https://cdn.cloudflare.steamstatic.com/steam/apps/1938090/header.jpg'
    }
  ]
}