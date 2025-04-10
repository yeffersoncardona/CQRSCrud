using CQRSCrud.Context;
using CQRSCrud.Entities;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Query
{
    #region query
    public record GetAllProductsQuery() : IRequest<List<Producto>>;
    #endregion

    #region handler
    public class GetAllProductsQueryHandler(ConexionDB conexionDB) : IRequestHandler<GetAllProductsQuery, List<Producto>>
    {


        public async Task<List<Producto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Producto";
            using (var connection = conexionDB.GetConnection())
            {
                await connection.OpenAsync(cancellationToken);
                var productos = await connection.QueryAsync<Producto>(query, commandType: CommandType.Text);
                return productos.ToList();
            }
        }
    }
    #endregion
}
