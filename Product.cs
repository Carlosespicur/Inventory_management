namespace EntregaFinal
{
    public class Product
    {
        public int Id { get; set; } // identificador del producto
        public string Name { get; set; }
        public string Description { get; set; }
        
        public float UnitPrice {  get; set; }
        public int PreviousStock { get; set; }
        public int  ReorderQuantity { get; set; }
        public int ProductSales {  get; set; }
        public int Stock { get; set; }
        

        public Product(int id, string name, float unitPrice, string description = "", int previousStock = 0, int reorderQuantity = 0, int productSales = 0 , int stock = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            PreviousStock = previousStock;
            ReorderQuantity = reorderQuantity;
            ProductSales = productSales;
            Stock = stock;
        }
    }
}
