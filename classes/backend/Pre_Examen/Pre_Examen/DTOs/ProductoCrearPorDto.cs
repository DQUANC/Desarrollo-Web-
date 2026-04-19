using Microsoft.VisualBasic;
using System;

namespace Pre_Examen.DTOs
{
    public class ProductoCrearPorDto
    {
        public string nombre {  get; set; }
        public string descripcion {  get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public DateTime fecha_Creacion { get; set; }
    }
}
