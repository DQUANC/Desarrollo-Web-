import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private apiUrl = 'http://localhost:5164/api/Cliente';

  constructor(private http: HttpClient) { }

  obtenerTodos(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(
      `${this.apiUrl}/ObtenerTodos`
    );
  }

  obtenerPorId(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(
      `${this.apiUrl}/${id}`
    );
  }

  obtenerPorDpi(dpi: string): Observable<Cliente> {
    return this.http.get<Cliente>(
      `${this.apiUrl}/dpi/${dpi}`
    );
  }

  ingresar(cliente: Cliente): Observable<any> {
    return this.http.post(
      `${this.apiUrl}/Ingresar`,
      cliente
    );
  }

  actualizar(id: number, cliente: Cliente): Observable<any> {
    return this.http.put(
      `${this.apiUrl}/${id}`,
      cliente
    );
  }

  cambiarEstado(id: number): Observable<any> {
    return this.http.patch(
      `${this.apiUrl}/${id}/estado`,
      {}
    );
  }

  eliminar(id: number): Observable<any> {
    return this.http.delete(
      `${this.apiUrl}/${id}`
    );
  }
}