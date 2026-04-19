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
  apellido = "Latorre"
  protected readonly title = signal('clase2_Front');
  DuplicarNumero(valor: number): number{
  return valor*2;
  }
  SumarNumeros(valor1:number, valor2: number): number{
    return valor1 + valor2
  }
  pelicula = {
    titulo: "Spider-man",
    FechaDeLanzamiento: new Date(),
    precio: 5000
  }
}

