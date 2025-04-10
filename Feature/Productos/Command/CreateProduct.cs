using CQRSCrud.Context;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Command
{
    #region command
    public record CreateProductCommand(string Nombre, string Precio) : IRequest<bool>;
    #endregion
    #region handler
    public class CreateProductoCommandHandler(ConexionDB conexion) : IRequestHandler<CreateProductCommand, bool>
    {
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var query = "INSERT INTO Producto (Nombre, Precio) VALUES (@Nombre, @Precio)";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", request.Nombre, DbType.String);
            parameters.Add("@Precio", request.Precio, DbType.Int32);

            using (var connection = conexion.GetConnection())
            {
                var rowsAfected = await connection.ExecuteAsync(query, parameters, commandType: CommandType.Text);

                return rowsAfected > 0;
            }
        }
    }
    #endregion

}
