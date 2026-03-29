using Examen_Final_DesarrolloWeb1.Models;

namespace Examen_Final_DesarrolloWeb1.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<EventosModel>> GetAllAsync();
    }
}