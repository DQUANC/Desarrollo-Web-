import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Usuario } from '../../models/usuario';
import { UsuarioService } from '../../services/usuario';

@Component({
  selector: 'app-usuarios',

  imports: [
    CommonModule,
    FormsModule
  ],

  templateUrl: './usuarios.html',

  styleUrl: './usuarios.css'
})
export class Usuarios implements OnInit {

  usuarios: Usuario[] = [];

  usuario: Usuario = this.nuevoUsuario();

  editando = false;

  constructor(
    private usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {

    this.cargarUsuarios();

  }

  nuevoUsuario(): Usuario {

    return {
      usuario: '',
      password: '',
      nombre: '',
      correo: '',
      idRol: 1,
      estado: true
    };

  }

  cargarUsuarios(): void {

    this.usuarioService
      .obtenerTodos()
      .subscribe({

        next: datos => {

          this.usuarios = datos;

        },

        error: error => {

          console.error(error);

        }

      });

  }

  guardar(): void {

    if (
      this.editando &&
      this.usuario.idUsuario
    ) {

      this.usuarioService
        .actualizar(
          this.usuario.idUsuario,
          this.usuario
        )
        .subscribe({

          next: () => {

            this.cancelar();

            this.cargarUsuarios();

          },

          error: error => {

            console.error(error);

          }

        });

    } else {

      this.usuarioService
        .ingresar(this.usuario)
        .subscribe({

          next: () => {

            this.usuario =
              this.nuevoUsuario();

            this.cargarUsuarios();

          },

          error: error => {

            console.error(error);

          }

        });

    }

  }

  editar(usuario: Usuario): void {

    this.usuario = {
      ...usuario
    };

    this.editando = true;

  }

  cancelar(): void {

    this.usuario =
      this.nuevoUsuario();

    this.editando = false;

  }

  eliminar(id?: number): void {

    if (!id)
      return;

    if (!confirm('¿Eliminar usuario?'))
      return;

    this.usuarioService
      .eliminar(id)
      .subscribe({

        next: () => {

          this.cargarUsuarios();

        }

      });

  }

  cambiarEstado(id?: number): void {

    if (!id)
      return;

    this.usuarioService
      .cambiarEstado(id)
      .subscribe({

        next: () => {

          this.cargarUsuarios();

        }

      });

  }

}