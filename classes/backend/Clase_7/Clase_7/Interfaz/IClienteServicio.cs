using Npgsql;
using Clase_7.Modelo;

namespace Clase_7.Interfaz
{
    public interface IClienteServicio
    {

        public IEnumerable<Cliente> TodosLosClientes(NpgsqlConnection connection);
    }
}
