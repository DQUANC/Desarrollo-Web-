using Pre_Examen.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Pre_Examen.Interfaz;

namespace Pre_Examen.Servicios
{
    public class ServicioInventario: IServicioInventario
    {
        public async Task<Producto> BuscarPorId(
           SqlConnection connection,
           int id_producto)
        {
            try
            {
                var sql = @"SELECT * FROM producto WHERE id_producto = @Id";

                return await connection.QueryFirstOrDefaultAsync<Producto>(
                    sql,
                    new { Id = id_producto }
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Producto", ex);
            }
        }

        public async Task<IEnumerable<Producto>> ObtenerProducto(
            SqlConnection connection)
        {
            try
            {
                var sql = @"SELECT * FROM producto";
                return await connection.QueryAsync<Producto>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Productos", ex);
            }
        }

        public async Task<Producto> CrearProducto(
            SqlConnection connection,
            Producto producto)
        {
            try
            {
                var sql = @"insert into producto(nombre, descripcion, precio, stock, fecha_Creacion)
                            values (@nombre, @descripcion, @precio, @stock, getdate())";

                var newId = await connection.QuerySingleAsync<int>(sql, new
                {
                    producto.nombre,
                    producto.descripcion,
                    producto.precio,
                    producto.stock,
                    producto.fecha_Creacion,
                });

                producto.id_producto = newId;
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Producto", ex);
            }
        }
        public async Task<Producto> ActualizarProducto(
            SqlConnection connection,
            Producto producto, int id_producto)
        {
            try
            {
                var _producto = @"SELECT * FROM producto WHERE id_producto = @Id";

                var exists = await connection.QueryFirstOrDefaultAsync<Producto>(
                    _producto,
                    new { Id = id_producto }
                );

                if (exists == null) {
                    int error = 404;
                    return error;
                } else { 

                    var sql = @"insert into producto(nombre, descripcion, precio, stock, fecha_Creacion)
                                values (@nombre, @descripcion, @precio, @stock, getdate())";

                    var newId = await connection.QuerySingleAsync<int>(sql, new
                    {
                        producto.nombre,
                        producto.descripcion,
                        producto.precio,
                        producto.stock,
                        producto.fecha_Creacion,
                    });

                    producto.id_producto = newId;
                    return producto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Producto", ex);
            }
        }
    }
}
