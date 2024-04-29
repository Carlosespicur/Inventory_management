
using EntregaFinal.Controllers;
using EntregaFinal.Data;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntregaFinal.Services
{
    public class ProductService : IProductService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProductService));
        private readonly DataContext context;

        public ProductService(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> AddProduct(string name, float unitPrice, int stock = 0, string description = "")
        { 
            // Comprobamos si el producto no está registrado en la base de datos:
            var sameName = await context.Products.Where(prod => prod.Name == name).FirstOrDefaultAsync(); // sameName == null si el elemento no está registrado
            if (sameName == null)
            {
                log.Info("Se encontró el producto en la base de datos");
                Product product = new(id: 0, name: name, description: description, stock: stock, unitPrice: unitPrice);
                await this.context.Products.AddAsync(product);
                await this.context.SaveChangesAsync();
            }

            return await this.context.Products.ToListAsync();
        }
        public async Task<List<Product>> DeleteProduct(string name)
        {
            // Buscamos en el inventario si existe un producto con ese nombre:
            var sameName = await this.context.Products.Where(prod => prod.Name == name).FirstOrDefaultAsync(); // sameName == null si el elemento no está registrado
            if (sameName != null)
            {
                log.Info("Se encontró el producto en la base de datos");
                this.context.Products.Remove(sameName); // eliminamos el producto con el nombre introducido
                await this.context.SaveChangesAsync();
            }

            return await this.context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<List<Product>> UpdateProduct(string? name, string? description, float? unitPrice, int sales, int restock)
        {
            if (name != null)
            {
                // Buscamos en el inventario si existe un producto con ese nombre:
                var product = await this.context.Products.Where(prod => prod.Name == name).FirstOrDefaultAsync(); // product == null si el elemento no está registrado
                if (product != null)
                {
                    log.Info("Se encontró el producto en la base de datos");
                    if (description != null)
                    {
                        product.Description = description;
                        log.Info("Descripción actualizada");
                    }
                    if (unitPrice != null)
                    {
                        product.UnitPrice = (float)unitPrice;
                        log.Info("UnitPrice actualizado");
                    }
                    product.PreviousStock = product.Stock;
                    product.Stock += restock - sales;
                    product.ProductSales = sales;
                    product.ReorderQuantity = restock;
                    
                    ProductValidator productVal = new ProductValidator();

                    if (!productVal.Validate(product).IsValid)
                    {
                        log.Info("Formato incorrecto del producto");
                        foreach (var error in productVal.Validate(product).Errors)
                        {
                            Console.WriteLine("ERROR: " + error.PropertyName + " | " + error.ErrorMessage);
                        }
                        throw new Exception("La operación no se completó: datos de actualización inválidos");
                    }
                    else
                    {
                        log.Info("Actualización exitosa");
                        await this.context.SaveChangesAsync();
                    } 
                }
            }
            
            return await this.context.Products.ToListAsync();

        }

    }
}
