import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movimiento } from '../models/movimiento';

@Injectable({
  providedIn: 'root'
})
export class MovimientoService {

  private apiUrl = 'http://localhost:5164/api/Movimiento';

  constructor(private http: HttpClient) { }

  obtenerTodos(): Observable<Movimiento[]> {

    return this.http.get<Movimiento[]>(
      this.apiUrl
    );

  }

  obtenerPorId(idMovimiento: number): Observable<Movimiento> {

    return this.http.get<Movimiento>(
      `${this.apiUrl}/${idMovimiento}`
    );

  }

  obtenerPorCuenta(idCuenta: number): Observable<Movimiento[]> {

    return this.http.get<Movimiento[]>(
      `${this.apiUrl}/cuenta/${idCuenta}`
    );

  }

  ingresar(movimiento: Movimiento): Observable<any> {

    return this.http.post(
      this.apiUrl,
      movimiento
    );

  }
}