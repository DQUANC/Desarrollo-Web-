using Dapper;
using Examen_Final_DesarrolloWeb1.Interfaces;
using Examen_Final_DesarrolloWeb1.Models;
using Npgsql;

namespace Examen_Final_DesarrolloWeb1.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly string _connectionString;

        public PersonaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<PersonaModel>> GetAllAsync()
        {
            const string sql = "SELECT * FROM personas ORDER BY codigo_persona";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<PersonaModel>(sql);
        }
    }
}