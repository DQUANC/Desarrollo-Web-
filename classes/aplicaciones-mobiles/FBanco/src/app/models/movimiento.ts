export interface Movimiento {
  idMovimiento?: number;
  idCuentaOrigen?: number;
  idCuentaDestino?: number;
  idTipoMovimiento: number;
  monto: number;
  saldoAnterior?: number;
  saldoNuevo?: number;
  descripcion?: string;
  fecha?: string;
  idUsuario: number;
}