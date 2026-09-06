import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Movimiento } from '../../models/movimiento';
import { MovimientoService } from '../../services/movimiento';

@Component({
  selector: 'app-movimientos',

  imports: [
    CommonModule,
    FormsModule
  ],

  templateUrl: './movimientos.html',

  styleUrl: './movimientos.css'
})
export class Movimientos implements OnInit {

  movimientos: Movimiento[] = [];

  movimiento: Movimiento = {
    idTipoMovimiento: 1,
    monto: 0,
    descripcion: '',
    idUsuario: 1
  };

  constructor(
    private movimientoService: MovimientoService
  ) {}

  ngOnInit(): void {

    this.cargarMovimientos();

  }

  cargarMovimientos(): void {

    this.movimientoService
      .obtenerTodos()
      .subscribe({

        next: datos => {

          this.movimientos = datos;

        },

        error: error => {

          console.error(error);

        }

      });

  }

  guardar(): void {

    this.movimientoService
      .ingresar(this.movimiento)
      .subscribe({

        next: () => {

          alert(
            'Movimiento registrado correctamente'
          );

          this.limpiar();

          this.cargarMovimientos();

        },

        error: error => {

          console.error(error);

          alert(
            'Error al registrar movimiento'
          );

        }

      });

  }

  limpiar(): void {

    this.movimiento = {

      idTipoMovimiento: 1,

      monto: 0,

      descripcion: '',

      idUsuario: 1

    };

  }

}