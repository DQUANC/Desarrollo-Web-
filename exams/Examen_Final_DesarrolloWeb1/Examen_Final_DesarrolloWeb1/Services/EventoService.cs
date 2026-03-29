using Dapper;
using Examen_Final_DesarrolloWeb1.Interfaces;
using Examen_Final_DesarrolloWeb1.Models;
using Npgsql;

namespace Examen_Final_DesarrolloWeb1.Services
{
    public class EventoService : IEventoService
    {
        private readonly string _connectionString;

        public EventoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<EventosModel>> GetAllAsync()
        {
            const string sql = "SELECT * FROM eventos ORDER BY codigo_evento";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<EventosModel>(sql);
        }
    }
}