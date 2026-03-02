using System;

namespace Examen_Parcial_DesarrolloWeb1.Modelos
{
    public class ModeloReserva
    {
        public int id_reserva {  get; set; }
        public string nombre_cliente { get; set; }
        public int numero_habitacion { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public int cantidad_personas { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
