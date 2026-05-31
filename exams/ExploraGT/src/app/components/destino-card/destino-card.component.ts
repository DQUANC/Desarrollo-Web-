import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DestinoTuristico } from '../../interfaces/destino-turistico.interface';

@Component({
  selector: 'app-destino-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './destino-card.component.html',
  styleUrl: './destino-card.component.scss',
})
export class DestinoCardComponent {
  @Input({ required: true }) destino!: DestinoTuristico;

  readonly MAX_STARS = 5;

  get stars(): boolean[] {
    return Array.from({ length: this.MAX_STARS }, (_, i) => i < this.destino.calificacion);
  }
}
