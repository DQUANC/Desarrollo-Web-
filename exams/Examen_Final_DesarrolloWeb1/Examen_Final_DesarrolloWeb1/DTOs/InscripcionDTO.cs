namespace Examen_Final_DesarrolloWeb1.DTOs
{
    public class InscripcionRequestDTO
    {
        public int codigo_evento { get; set; }
        public int codigo_persona { get; set; }
        public string usuario { get; set; } = string.Empty;
    }

    public class InscripcionResponseDTO
    {
        public bool exito { get; set; }
        public string mensaje { get; set; } = string.Empty;
    }
}