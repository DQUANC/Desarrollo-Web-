import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DestinosService } from './services/destinos.service';
import { DestinoTuristico } from './interfaces/destino-turistico.interface';
import { DestinoCardComponent } from './components/destino-card/destino-card.component';

@Component({
  selector: 'app-root',
  imports: [CommonModule, DestinoCardComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App implements OnInit {
  private readonly destinosService = inject(DestinosService);

  destinos: DestinoTuristico[] = [];
  categoriaActiva = 'Todas';
  readonly categorias = ['Todas', 'Natural', 'Cultural', 'Arqueológico', 'Playa', 'Aventura'];
  readonly categoriaEmoji: Record<string, string> = {
    'Todas': '🗺️',
    'Natural': '🌿',
    'Cultural': '🏛️',
    'Arqueológico': '🗿',
    'Playa': '🏖️',
    'Aventura': '🧗',
  };

  ngOnInit(): void {
    this.destinos = this.destinosService.getDestinos();
  }

  get destinosFiltrados(): DestinoTuristico[] {
    if (this.categoriaActiva === 'Todas') return this.destinos;
    return this.destinos.filter(d => d.categoria === this.categoriaActiva);
  }

  setCategoria(cat: string): void {
    this.categoriaActiva = cat;
  }

  trackById(_i: number, d: DestinoTuristico): number {
    return d.id;
  }
}
