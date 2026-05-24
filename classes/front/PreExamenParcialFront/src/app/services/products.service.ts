import { Injectable } from '@angular/core';
import { Product } from '../models/product';

const BASE = 'https://images.unsplash.com/';
const Q = '?w=500&h=400&fit=crop&auto=format&q=80';

const CATALOG: Product[] = [
  {
    id: 1,
    name: 'Apple MacBook Air M2 13"',
    category: 'Electrónica',
    description:
      'Chip Apple M2 de 8 núcleos, 8 GB RAM unificada, SSD 256 GB y pantalla Liquid Retina 13.6" con 500 nits de brillo. Batería de hasta 18 horas.',
    price: 6500,
    discount: 20,
    imageUrl: BASE + 'photo-1517336714731-489689fd1ca8' + Q,
    emoji: '💻',
    gradient: 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
  },
  {
    id: 2,
    name: 'Samsung Galaxy S24 128 GB',
    category: 'Electrónica',
    description:
      'Pantalla Dynamic AMOLED 2X de 6.2", procesador Exynos 2400, cámara triple de 50 MP con IA integrada y batería 4000 mAh con carga rápida 25W.',
    price: 4999,
    imageUrl: BASE + 'photo-1511707171634-5f897ff02aa9' + Q,
    emoji: '📱',
    gradient: 'linear-gradient(135deg, #0093E9 0%, #80D0C7 100%)',
    isNew: true,
  },
  {
    id: 3,
    name: 'Sony WH-1000XM5',
    category: 'Electrónica',
    description:
      'Cancelación de ruido líder del mercado con 8 micrófonos integrados, 30 horas de autonomía, carga rápida y audio Hi-Res certificado.',
    price: 2400,
    discount: 25,
    imageUrl: BASE + 'photo-1505740420928-5e560c06d30e' + Q,
    emoji: '🎧',
    gradient: 'linear-gradient(135deg, #f093fb 0%, #f5576c 100%)',
  },
  {
    id: 4,
    name: 'LG 27UK850-W Monitor 4K',
    category: 'Electrónica',
    description:
      'Panel IPS 4K UHD (3840×2160), HDR10, USB-C 60W y HDMI 2.0. Diseño sin bordes con ajuste ergonómico de altura y rotación.',
    price: 3899,
    imageUrl: BASE + 'photo-1527443224154-c4a573d5b6a4' + Q,
    emoji: '🖥️',
    gradient: 'linear-gradient(135deg, #4facfe 0%, #00f2fe 100%)',
  },
  {
    id: 5,
    name: 'Canon EOS R50 Kit 18–45 mm',
    category: 'Electrónica',
    description:
      'Sensor APS-C de 24.2 MP, vídeo 4K sin recorte, enfoque automático con seguimiento de ojos y pantalla táctil giratoria. Incluye lente 18–45 mm.',
    price: 6000,
    discount: 35,
    imageUrl: BASE + 'photo-1516035069371-29a1b244cc32' + Q,
    emoji: '📷',
    gradient: 'linear-gradient(135deg, #43e97b 0%, #38f9d7 100%)',
  },
  {
    id: 6,
    name: 'Nespresso Vertuo Pop',
    category: 'Hogar',
    description:
      'Sistema Centrifusion™, 5 tamaños de taza (espresso hasta 230 ml), calentamiento en 15 segundos y apagado automático. Compatible con más de 30 variedades.',
    price: 1200,
    discount: 15,
    imageUrl: BASE + 'photo-1495474472287-4d71bcdd2085' + Q,
    emoji: '☕',
    gradient: 'linear-gradient(135deg, #f6d365 0%, #fda085 100%)',
  },
  {
    id: 7,
    name: 'Herman Miller Aeron Talla B',
    category: 'Hogar',
    description:
      'Soporte PostureFit SL ajustable, malla 8Z Pellicle®, reposabrazos 4D y tilt system de precisión. Garantía de 12 años incluida.',
    price: 9999,
    imageUrl: BASE + 'photo-1586023492125-27b2c045efd7' + Q,
    emoji: '🪑',
    gradient: 'linear-gradient(135deg, #a1c4fd 0%, #c2e9fb 100%)',
  },
  {
    id: 8,
    name: 'Nike Air Zoom Pegasus 41',
    category: 'Deportes',
    description:
      'Amortiguación React con Air Zoom en el antepié, upper de tejido Flyknit transpirable y suela de goma duradera. Ideal para hasta 80 km por semana.',
    price: 1400,
    discount: 30,
    imageUrl: BASE + 'photo-1542291026-7eec264c27ff' + Q,
    emoji: '👟',
    gradient: 'linear-gradient(135deg, #ff0844 0%, #ffb199 100%)',
  },
  {
    id: 9,
    name: 'Manduka PRO Yoga Mat 6 mm',
    category: 'Deportes',
    description:
      'Mat profesional de PVC eco-certificado, 6 mm de grosor, superficie antideslizante húmeda/seca y garantía de por vida. Incluye correa de transporte.',
    price: 800,
    discount: 40,
    imageUrl: BASE + 'photo-1518611012118-696072aa579a' + Q,
    emoji: '🧘',
    gradient: 'linear-gradient(135deg, #96fbc4 0%, #f9f586 100%)',
  },
  {
    id: 10,
    name: 'Dior Sauvage EDP 100 ml',
    category: 'Belleza',
    description:
      'Eau de Parfum con notas de pimienta de Sichuan, lavanda y madera de oud. Fragancia masculina icónica con duración superior a 12 horas. Fabricada en Francia.',
    price: 850,
    imageUrl: BASE + 'photo-1590736704728-f4730bb30770' + Q,
    emoji: '🧴',
    gradient: 'linear-gradient(135deg, #fccb90 0%, #d57eeb 100%)',
    isNew: true,
  },
  {
    id: 11,
    name: 'Atomic Habits – James Clear',
    category: 'Libros',
    description:
      'El sistema probado para construir buenos hábitos y eliminar los malos. Más de 10 millones de copias vendidas en el mundo. Edición en español, pasta dura.',
    price: 189,
    imageUrl: BASE + 'photo-1512820790803-83ca734da794' + Q,
    emoji: '📚',
    gradient: 'linear-gradient(135deg, #a18cd1 0%, #fbc2eb 100%)',
  },
  {
    id: 12,
    name: 'Samsonite Cityscape BP 15.6"',
    category: 'Moda',
    description:
      'Mochila ejecutiva con compartimiento acolchado para laptop 15.6", sistema Add-a-Bag, puerto USB integrado y cierre de seguridad TSA. Material: poliéster reforzado.',
    price: 1299,
    imageUrl: BASE + 'photo-1553062407-98eeb64c6a62' + Q,
    emoji: '🎒',
    gradient: 'linear-gradient(135deg, #30cfd0 0%, #330867 100%)',
  },
];

@Injectable({ providedIn: 'root' })
export class ProductsService {
  getAll(): Product[] {
    return CATALOG;
  }

  getOffers(): Product[] {
    return CATALOG.filter((p) => p.discount != null && p.discount > 0);
  }

  getCategories(): string[] {
    return [...new Set(CATALOG.map((p) => p.category))];
  }
}
