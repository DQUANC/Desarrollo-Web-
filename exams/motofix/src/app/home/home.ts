import { Component } from '@angular/core';

interface Service {
  icon: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {
  isMenuOpen = false;

  services: Service[] = [
    {
      icon: '🔧',
      title: 'Cambio de Aceite',
      description:
        'Servicio completo de cambio de aceite con filtros de alta calidad para prolongar la vida de tu motor.',
    },
    {
      icon: '🛑',
      title: 'Sistema de Frenos',
      description:
        'Revisión, ajuste y reemplazo de pastillas, discos y tambores de freno con garantía de calidad.',
    },
    {
      icon: '⚙️',
      title: 'Alineación y Balanceo',
      description:
        'Alineación computarizada y balanceo de ruedas para mayor seguridad y durabilidad de tus neumáticos.',
    },
    {
      icon: '🔩',
      title: 'Suspensión',
      description:
        'Diagnóstico y reparación de amortiguadores, resortes y brazos de control para una conducción suave.',
    },
    {
      icon: '⚡',
      title: 'Sistema Eléctrico',
      description:
        'Diagnóstico computarizado y reparación de todo el sistema eléctrico y electrónico de tu vehículo.',
    },
    {
      icon: '🔍',
      title: 'Diagnóstico General',
      description:
        'Revisión completa del vehículo con equipo de última tecnología para detectar cualquier falla.',
    },
  ];

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }

  closeMenu(): void {
    this.isMenuOpen = false;
  }

  scrollTo(id: string): void {
    this.isMenuOpen = false;
    const el = document.getElementById(id);
    if (el) el.scrollIntoView({ behavior: 'smooth' });
  }
}
