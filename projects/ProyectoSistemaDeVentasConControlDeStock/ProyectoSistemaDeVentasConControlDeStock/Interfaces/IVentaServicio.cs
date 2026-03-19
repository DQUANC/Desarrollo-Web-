using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.VentasDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Models;

namespace ProyectoSistemaDeVentasConControlDeStock.Interfaces
{
    public interface IVentaServicio
    {
        Task<(bool exito, string mensaje)> RegistrarVenta(NpgsqlConnection connection, CrearVentaDTO dto);
        Task<IEnumerable<VentaDetalleDTO>> ObtenerTodasLasVentas(NpgsqlConnection connection);
    }
}