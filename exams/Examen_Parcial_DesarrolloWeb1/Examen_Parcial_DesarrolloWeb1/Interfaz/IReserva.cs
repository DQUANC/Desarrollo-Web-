using Examen_Parcial_DesarrolloWeb1.DTOs;
using Examen_Parcial_DesarrolloWeb1.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Examen_Parcial_DesarrolloWeb1.Interfaz
{
    public interface IReserva
    {
        public IEnumerable<ModeloReserva> ObtenerReserva(SqlConnection connection);
        public IEnumerable<ModeloReserva> CrearReserva(SqlConnection connection, CrearReservaDTO modelo);
        public IEnumerable<ModeloReserva> ActualizarReserva(SqlConnection connection, ActualizarReservaDTO modelo);
    }
}
