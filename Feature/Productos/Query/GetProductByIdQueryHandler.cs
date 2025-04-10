using CQRSCrud.Context;
using CQRSCrud.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CQRSCrud.Feature.Productos.Query
{
    public class GetProductByIdQueryHandler(ConexionDB _conexion) : IRequestHandler<GetProductByIdQuery, Producto?>
    {

        public async Task<Producto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Producto WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id, DbType.Int32); //agregamos el tipo de dato para evitar sql inyection 

            using (var connection = _conexion.GetConnection())
            {
                await connection.OpenAsync(cancellationToken);
                var producto = await connection.QueryFirstOrDefaultAsync<Producto>(query, parameters, commandType: CommandType.Text);
                //await connection.CloseAsync();

                return producto;
            }


        }
    }

}

