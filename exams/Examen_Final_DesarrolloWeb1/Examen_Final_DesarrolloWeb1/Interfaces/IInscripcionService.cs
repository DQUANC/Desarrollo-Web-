using Examen_Final_DesarrolloWeb1.DTOs;
using Examen_Final_DesarrolloWeb1.Models;

namespace Examen_Final_DesarrolloWeb1.Interfaces
{
    public interface IInscripcionService
    {
        Task<InscripcionResponseDTO> RegistrarInscripcionAsync(InscripcionRequestDTO request);
        Task<IEnumerable<InscripcionesModel>> GetAllAsync();
    }
}