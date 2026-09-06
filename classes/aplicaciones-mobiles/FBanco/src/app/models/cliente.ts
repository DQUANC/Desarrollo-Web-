export interface Cliente {
  idCliente?: number;
  dpi: string;
  nombres: string;
  apellidos: string;
  telefono: string;
  correo: string;
  direccion: string;
  fechaRegistro?: Date;
  estado?: boolean;
}