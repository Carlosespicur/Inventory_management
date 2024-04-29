using EntregaFinal.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EntregaFinal.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProductController));
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET
        
        [HttpGet("products")] // Obtener el listado de productos en el inventario

        public async Task<ActionResult<List<Product>>>GetProductList()
        {
            log.Info("Intento de obtener el listado de productos en el inventario");
            return Ok(await productService.GetProducts());
        }

        // PUT
        [Authorize]
        [HttpPut] // Añadir un artículo al inventario (CREATE)
        public async Task<ActionResult<List<Product>>> AddProduct(string name, string description, float unitPrice, int stock = 0)
        {
            log.Info("Intento de añadir un artículo al inventario");
            return Ok(await productService.AddProduct(name, unitPrice, stock, description));
        }

        // DELETE
        [Authorize]
        [HttpDelete] // Eliminar un artículo del inventario (DELETE)

        public async Task<ActionResult<List<Product>>> DeleteProduct(string name = "")
        {
            log.Info("Intento de eliminar un artículo del inventario");
            return Ok(await productService.DeleteProduct(name));
        }

        // POST
        [Authorize]
        [HttpPost] // Actualizar un artículo del inventario (UPDATE)

        public async Task<ActionResult<List<Product>>> UpdateProduct(string? name, string? description, float? unitPrice, int sales = 0, int restock = 0)
        {
            log.Info("Intento de actualizar un artículo del inventario");
            return Ok(await productService.UpdateProduct(name, description, unitPrice, sales, restock));
        }
    }

}