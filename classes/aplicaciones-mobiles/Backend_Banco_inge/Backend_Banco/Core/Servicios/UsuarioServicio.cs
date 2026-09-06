using Core.Interfaz;
using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class UsuarioServicio : IUsuario
    {
        private readonly string _connectionString;

        public UsuarioServicio(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena de conexión DefaultConnection.");
        }

        private NpgsqlConnection CrearConexion()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<List<MUsuario>> ObtenerTodos()
        {

            try
            {
                const string sql = @"
                SELECT
                    id_usuario AS IdUsuario,
                    nombre AS Nombre,
                    usuario AS UsuarioLogin,
                    password AS Password,
                    id_rol AS IdRol,
                    estado AS Estado,
                    fecha_creacion AS FechaCreacion
                FROM usuario
                ORDER BY id_usuario;";

                await using var connection = CrearConexion();

                var resultado = await connection.QueryAsync<MUsuario>(sql);

                return resultado.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);

                return new List<MUsuario>();

            }
        }


        public async Task<bool> Actualizar(MUsuario usuario)
        {
            try
            {
                const string sql = @"
                    UPDATE usuario
                    SET
                        nombre = @Nombre,
                        usuario = @UsuarioLogin,
                        id_rol = @IdRol,
                        estado = @Estado
                    WHERE id_usuario = @IdUsuario;";

                await using var connection = CrearConexion();

                int resultado =
                    await connection.ExecuteAsync(sql, usuario);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al actualizar usuario: " + ex.Message);

                return false;
            }
        }

        public async Task<bool> CambiarEstado(int id, bool estado)
        {
            try
            {
                const string sql = @"
                    UPDATE usuario
                    SET estado = @Estado
                    WHERE id_usuario = @IdUsuario;";

                await using var connection = CrearConexion();

                int resultado =
                    await connection.ExecuteAsync(   sql,   new   { IdUsuario = id, Estado = estado   });

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al cambiar estado: " + ex.Message);

                return false;
            }
        }

        public async Task<bool>  CambiarPassword(int id, string password)
        {
            try
            {
                const string sql = @"
                    UPDATE usuario
                    SET password = @Password
                    WHERE id_usuario = @IdUsuario;";

                await using var connection = CrearConexion();

                int resultado =
                    await connection.ExecuteAsync( sql,  new
                        {  IdUsuario = id,
                            Password = password
                        });

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al cambiar contraseña: " + ex.Message);

                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                const string sql = @"
                    DELETE FROM usuario
                    WHERE id_usuario = @IdUsuario;";

                await using var connection = CrearConexion();

                int resultado =
                    await connection.ExecuteAsync(
                        sql, new
                        {
                            IdUsuario = id
                        });

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al eliminar usuario: " + ex.Message);

                return false;
            }
        }

        public async Task<bool> Insertar(MUsuario usuario)
        {
            try
            {
                const string sql = @"
                    INSERT INTO usuario
                    (
                        nombre,
                        usuario,
                        password,
                        id_rol,
                        estado
                    )
                    VALUES
                    (
                        @Nombre,
                        @UsuarioLogin,
                        @Password,
                        @IdRol,
                        @Estado
                    );";

                await using var connection = CrearConexion();

                int resultado =
                    await connection.ExecuteAsync(sql, usuario);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al insertar usuario: " + ex.Message);

                return false;
            }
        }

        public async Task<MUsuario?> ObtenerPorId(int id)
        {
            try
            {
                const string sql = @"
                    SELECT
                        id_usuario AS IdUsuario,
                        nombre AS Nombre,
                        usuario AS UsuarioLogin,
                        password AS Password,
                        id_rol AS IdRol,
                        estado AS Estado,
                        fecha_creacion AS FechaCreacion
                    FROM usuario
                    WHERE id_usuario = @IdUsuario;";

                await using var connection = CrearConexion();

                var resultado =
                    await connection.QueryFirstOrDefaultAsync<MUsuario>( sql,  new { IdUsuario = id });

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al obtener usuario por ID: " + ex.Message);

                return null;
            }
        }

        public async Task<MUsuario?> ObtenerPorUsuario(string usuario)
        {
            try
            {
                const string sql = @"
                    SELECT
                        id_usuario AS IdUsuario,
                        nombre AS Nombre,
                        usuario AS UsuarioLogin,
                        password AS Password,
                        id_rol AS IdRol,
                        estado AS Estado,
                        fecha_creacion AS FechaCreacion
                    FROM usuario
                    WHERE usuario = @UsuarioLogin;";

                await using var connection = CrearConexion();

                var resultado =
                    await connection.QueryFirstOrDefaultAsync<MUsuario>( sql,  new   { UsuarioLogin = usuario });

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error al obtener usuario: " + ex.Message);

                return null;
            }
        }

     
    }
}
