using System;

namespace Examen_Parcial_DesarrolloWeb1.DTOs
{
    public class CrearReservaDTO
    {
        public string nombre_cliente { get; set; }
        public int numero_habitacion { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public int cantidad_personas { get; set; }
    }
}
