using Dapper;
using Npgsql;
using Clase_7.Modelo;
using Clase_7.Interfaz;

namespace Clase_7.Servicio
{
    public class ClienteServicio: IClienteServicio
    {
        public IEnumerable<Cliente> TodosLosClientes(NpgsqlConnection connection)
        {
            var resultado = connection.QueryAsync<Cliente>("SELECT * FROM clientes");
            return resultado.Result;
        }
    }
}
