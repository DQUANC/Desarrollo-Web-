import { Component } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class HomeComponent {
  scrollTo(id: string) {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' });
  }

  services = [
    {
      emoji: '🛍️',
      title: 'Tienda en Línea',
      description:
        'Plataforma completa para vender productos con catálogos dinámicos, búsqueda avanzada y carrito de compras intuitivo.',
    },
    {
      emoji: '📦',
      title: 'Gestión de Inventario',
      description:
        'Control total de tu stock en tiempo real con alertas automáticas, control de lotes y reportes detallados.',
    },
    {
      emoji: '🔒',
      title: 'Pagos Seguros',
      description:
        'Integración con pasarelas de pago líderes, cifrado SSL de extremo a extremo y protección antifraude.',
    },
    {
      emoji: '📊',
      title: 'Analítica y Reportes',
      description:
        'Dashboards intuitivos con métricas de ventas, comportamiento del cliente y tendencias del mercado en tiempo real.',
    },
    {
      emoji: '🚚',
      title: 'Logística Integrada',
      description:
        'Gestión de envíos multioperador con rastreo en tiempo real para tus clientes desde cualquier dispositivo.',
    },
    {
      emoji: '💬',
      title: 'Soporte 24/7',
      description:
        'Equipo de atención al cliente disponible todo el día por chat, correo y teléfono para resolver cualquier incidencia.',
    },
  ];

  values = [
    {
      emoji: '🎯',
      name: 'Innovación',
      description: 'Adoptamos tecnologías de vanguardia para mantener tu negocio competitivo.',
    },
    {
      emoji: '🤝',
      name: 'Confianza',
      description: 'Operamos con total transparencia y honestidad en cada transacción.',
    },
    {
      emoji: '⚡',
      name: 'Eficiencia',
      description: 'Optimizamos procesos continuamente para ahorrarte tiempo y recursos.',
    },
    {
      emoji: '🌱',
      name: 'Compromiso',
      description: 'Nos comprometemos con tu crecimiento y con un impacto positivo en la sociedad.',
    },
  ];

  stats = [
    { number: '10K+', label: 'Clientes Activos' },
    { number: '500K+', label: 'Productos Listados' },
    { number: '50+', label: 'Países Alcanzados' },
    { number: '99.9%', label: 'Uptime Garantizado' },
  ];
}
