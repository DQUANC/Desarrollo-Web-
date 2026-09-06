import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private apiUrl = 'http://localhost:5164/api/Usuario';

  constructor(private http: HttpClient) { }

  obtenerTodos(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(
      `${this.apiUrl}/ObtenerTodos`
    );
  }

  obtenerPorId(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(
      `${this.apiUrl}/${id}`
    );
  }

  obtenerPorUsuario(usuario: string): Observable<Usuario> {
    return this.http.get<Usuario>(
      `${this.apiUrl}/usuario/${usuario}`
    );
  }

  ingresar(usuario: Usuario): Observable<any> {
    return this.http.post(
      this.apiUrl,
      usuario
    );
  }

  actualizar(id: number, usuario: Usuario): Observable<any> {
    return this.http.put(
      `${this.apiUrl}/${id}`,
      usuario
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