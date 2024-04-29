namespace EntregaFinal.Services
{
    public interface IProductService
    {
        // GET
        Task<List<Product>> GetProducts(); // 

        // POST
        Task<List<Product>> AddProduct(string name, float unitPrice, int stock, string description);

        // PUT
        Task<List<Product>> UpdateProduct(string? name, string? description, float? unitPrice, int sales, int restock);

        // DELETE
        Task<List<Product>> DeleteProduct (string name);
    }
}
