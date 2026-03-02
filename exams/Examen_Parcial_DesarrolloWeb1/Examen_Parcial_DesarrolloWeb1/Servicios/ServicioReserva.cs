using Dapper;
using Examen_Parcial_DesarrolloWeb1.DTOs;
using Examen_Parcial_DesarrolloWeb1.Interfaz;
using Examen_Parcial_DesarrolloWeb1.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Examen_Parcial_DesarrolloWeb1.Servicios
{
    public class ServicioReserva : IReserva
    {
        public IEnumerable<ModeloReserva> ObtenerReserva(SqlConnection connection)
        {
            try
            {
                var resultado = connection.QueryAsync<ModeloReserva>("select * from reserva");
                return resultado.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener Reservas ", ex);
            }
        }

        public IEnumerable<ModeloReserva> CrearReserva(SqlConnection connection, CrearReservaDTO modelo)
        {
            // 1. Validar que los campos obligatorios no sean nulos o vacíos
            if (string.IsNullOrWhiteSpace(modelo.nombre_cliente) ||
                modelo.numero_habitacion <= 0 ||
                modelo.cantidad_personas <= 0)
            {
                throw new ArgumentException("Todos los campos son obligatorios y deben tener valores válidos.");
            }

            // 2. Validar que la fecha de salida sea mayor a la de ingreso
            if (modelo.fecha_salida <= modelo.fecha_ingreso)
            {
                throw new ArgumentException("La fecha de salida debe ser posterior a la fecha de ingreso.");
            }

            try
            {
                var sql = @"INSERT INTO reserva (nombre_cliente, numero_habitacion, fecha_ingreso, 
                    fecha_salida, cantidad_personas, fecha_creacion) 
                    VALUES (@nombre_cliente, @numero_habitacion, @fecha_ingreso, 
                    @fecha_salida, @cantidad_personas, GETDATE());";

                var resultado = connection.Query<ModeloReserva>(sql, modelo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la creación de la reserva.", ex);
            }
        }

        public IEnumerable<ModeloReserva> ActualizarReserva(SqlConnection connection, ActualizarReservaDTO modelo)
        {
            try
            {
                var resultado = connection.QueryAsync<ModeloReserva>("UPDATE reserva " +
                    "SET " +
                    "nombre_cliente = '" + modelo.nombre_cliente + "', " +
                    "numero_habitacion = " + modelo.numero_habitacion + ", " +
                    "fecha_ingreso = '" + modelo.fecha_ingreso + "', " +
                    "fecha_salida = '" + modelo.fecha_salida + "', " +
                    "cantidad_personas = " + modelo.cantidad_personas + ", " +
                    "fecha_modificacion = GETDATE() " +
                    "WHERE id_reserva = " + modelo.id_reserva + ";");
                return resultado.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener Reservas ", ex);
            }
        }
    }
}
