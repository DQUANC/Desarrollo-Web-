export interface Usuario {
  idUsuario?: number;
  usuario: string;
  password?: string;
  nombre?: string;
  correo?: string;
  idRol?: number;
  estado?: boolean;
  fechaCreacion?: string;
}
