using Dapper;
using Examen_Final_DesarrolloWeb1.DTOs;
using Examen_Final_DesarrolloWeb1.Interfaces;
using Examen_Final_DesarrolloWeb1.Models;
using Npgsql;

namespace Examen_Final_DesarrolloWeb1.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly string _connectionString;

        public InscripcionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<InscripcionesModel>> GetAllAsync()
        {
            const string sql = "SELECT * FROM inscripciones ORDER BY id_inscripcion";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<InscripcionesModel>(sql);
        }

        public async Task<InscripcionResponseDTO> RegistrarInscripcionAsync(InscripcionRequestDTO request)
        {
            const string sql = @"SELECT (registrar_inscripcion(@codigo_evento, @codigo_persona, @usuario))::text AS resultado";

            await using var connection = new NpgsqlConnection(_connectionString);

            var json = await connection.QuerySingleAsync<string>(sql, new
            {
                codigo_evento = request.codigo_evento,
                codigo_persona = request.codigo_persona,
                usuario = request.usuario
            });

            var resultado = System.Text.Json.JsonSerializer.Deserialize<InscripcionResponseDTO>(json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return resultado!;
        }
    }
}