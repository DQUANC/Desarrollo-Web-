import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  pokemonName: string = 'pikachu';
  pokemon: any = null;
  loading: boolean = false;
  error: string = '';

  ngOnInit(): void {
    this.buscarPokemon();
  }

  constructor(private http: HttpClient) {}

  buscarPokemon(): void {
    if (!this.pokemonName.trim()) {
      return;
    }
    this.loading = true;
    this.error = '';
    this.pokemon = null;
    this.http.get<any>(`https://pokeapi.co/api/v2/pokemon/${this.pokemonName.toLowerCase().trim()}`).subscribe({
      next: (response) => {
        this.pokemon = response;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.error = 'Pokemon no encontrado. Intenta con otro nombre o número.';
        this.pokemon = null;
      }
    });
  }

  formatId(id: number): string {
    return id.toString().padStart(3, '0');
  }

  getTypeColor(type: string): string {
    const colors: { [key: string]: string } = {
      fire:     'linear-gradient(135deg, #FF6B35, #F7931E)',
      water:    'linear-gradient(135deg, #1E90FF, #00BFFF)',
      grass:    'linear-gradient(135deg, #78C850, #4CAF50)',
      electric: 'linear-gradient(135deg, #F8D030, #E65100)',
      psychic:  'linear-gradient(135deg, #F85888, #E91E63)',
      ice:      'linear-gradient(135deg, #98D8D8, #4DD0E1)',
      dragon:   'linear-gradient(135deg, #7038F8, #3F51B5)',
      dark:     'linear-gradient(135deg, #705848, #5D4037)',
      fairy:    'linear-gradient(135deg, #EE99AC, #F48FB1)',
      normal:   'linear-gradient(135deg, #A8A878, #9E9E9E)',
      fighting: 'linear-gradient(135deg, #C03028, #F44336)',
      flying:   'linear-gradient(135deg, #A890F0, #9575CD)',
      poison:   'linear-gradient(135deg, #A040A0, #9C27B0)',
      ground:   'linear-gradient(135deg, #E0C068, #FFA000)',
      rock:     'linear-gradient(135deg, #B8A038, #795548)',
      bug:      'linear-gradient(135deg, #A8B820, #8BC34A)',
      ghost:    'linear-gradient(135deg, #705898, #673AB7)',
      steel:    'linear-gradient(135deg, #B8B8D0, #78909C)',
    };
    return colors[type] || 'linear-gradient(135deg, #38bdf8, #2563eb)';
  }

  getStatColor(value: number): string {
    if (value < 50)  return 'linear-gradient(90deg, #ef4444, #f97316)';
    if (value < 80)  return 'linear-gradient(90deg, #f59e0b, #eab308)';
    if (value < 120) return 'linear-gradient(90deg, #22c55e, #16a34a)';
    return 'linear-gradient(90deg, #3b82f6, #8b5cf6)';
  }

  getStatName(name: string): string {
    const names: { [key: string]: string } = {
      'hp':              'PS',
      'attack':          'Ataque',
      'defense':         'Defensa',
      'special-attack':  'Atq. Esp.',
      'special-defense': 'Def. Esp.',
      'speed':           'Velocidad',
    };
    return names[name] || name;
  }
}
