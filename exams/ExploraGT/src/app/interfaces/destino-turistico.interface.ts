export type CategoriaDestino =
  | 'Natural'
  | 'Cultural'
  | 'Arqueológico'
  | 'Playa'
  | 'Aventura';

export interface DestinoTuristico {
  id: number;
  nombre: string;
  ubicacion: string;
  descripcion: string;
  categoria: CategoriaDestino;
  imagenUrl: string;
  calificacion: number;
  destacado?: boolean;
}
