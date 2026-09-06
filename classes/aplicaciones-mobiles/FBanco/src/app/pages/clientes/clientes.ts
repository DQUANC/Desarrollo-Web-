import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Cliente } from '../../models/cliente';
import { ClienteService } from '../../services/cliente';
@Component({
  selector: 'app-clientes',

  imports: [
    CommonModule,
    FormsModule
  ],

  templateUrl: './clientes.html',

  styleUrl: './clientes.css'
})
export class Clientes implements OnInit {

  clientes: Cliente[] = [];

  cliente: Cliente = this.nuevoCliente();

  editando = false;

  mensaje = '';

  constructor(
    private clienteService: ClienteService,
      private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {

    this.cargarClientes();

  }

  nuevoCliente(): Cliente {

    return {
      dpi: '',
      nombres: '',
      apellidos: '',
      telefono: '',
      correo: '',
      direccion: '',
      estado: true
    };

  }

  cargarClientes(): void {

    this.clienteService.obtenerTodos().subscribe({

      next: (datos) => {

        this.clientes = datos;
this.cd.detectChanges();
      },
      error: (error) => {
        console.error(error);
        this.mensaje =
          'Error al obtener clientes';

      }

    });

  }

  guardar(): void {
    if (this.editando && this.cliente.idCliente) {

      this.clienteService
        .actualizar(
          this.cliente.idCliente,
          this.cliente
        )
        .subscribe({
          next: () => {
            this.mensaje =
              'Cliente actualizado correctamente';

            this.cancelar();

            this.cargarClientes();
  this.cd.detectChanges();
          },
          error: error => {
            console.error(error);
            this.mensaje =
              'Error al actualizar cliente';
          }
        });

    } else {
      this.clienteService
        .ingresar(this.cliente)
        .subscribe({
          next: () => {
            this.mensaje =
              'Cliente registrado correctamente';
            this.cliente =
              this.nuevoCliente();
            this.cargarClientes();
this.cd.detectChanges();
          },
          error: error => {
            console.error(error);
            this.mensaje =
              'Error al registrar cliente';
          }
        });

    }

  }

  editar(cliente: Cliente): void {

    this.cliente = {
      ...cliente
    };

    this.editando = true;
this.cd.detectChanges();
  }

  cancelar(): void {

    this.cliente =
      this.nuevoCliente();
    this.editando = false;
    this.cd.detectChanges();
  }

  eliminar(id?: number): void {

    if (!id)
      return;

    const confirmar =
      confirm(
        '¿Está seguro de eliminar el cliente?'
      );

    if (!confirmar)
      return;

    this.clienteService
      .eliminar(id)
      .subscribe({

        next: () => {
          this.mensaje =
            'Cliente eliminado';

          this.cargarClientes();
          this.cd.detectChanges();
        },
        error: error => {   console.error(error);
          this.mensaje ='No fue posible eliminar el cliente';    }

      });

  }

  cambiarEstado(id?: number): void {

    if (!id)
      return;

    this.clienteService
      .cambiarEstado(id)
      .subscribe({

        next: () => {
          this.cargarClientes();
        },
        error: error => {
          console.error(error);
        }
      });

  }

}