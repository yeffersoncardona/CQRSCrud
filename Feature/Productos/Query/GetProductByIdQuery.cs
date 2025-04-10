using CQRSCrud.Entities;
using MediatR;

namespace CQRSCrud.Feature.Productos.Query
{
    //public class GetProductByIdQuery:IRequest<Producto>
    //{
    //    public int Id { get; set; }

    //}
    public record GetProductByIdQuery(int Id) : IRequest<Producto?>;
}
