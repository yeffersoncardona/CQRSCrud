using CQRSCrud.Entities;
using CQRSCrud.Feature.Productos.Command;
using CQRSCrud.Feature.Productos.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Producto>>> GetAll()
        {
            var solicitud = new GetAllProductsQuery();
            var result = await _sender.Send(solicitud);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById/{id}")] 
        public async Task<ActionResult<List<Producto>>> GetById(int id)
        {
            var solicitud = new GetProductByIdQuery(id);
            var result = await _sender.Send(solicitud);
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(CreateProductCommand value)
        {            
            var result = await _sender.Send(value);
            return Ok(result);
        }

    }
}
