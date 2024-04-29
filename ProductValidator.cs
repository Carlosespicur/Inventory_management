using FluentValidation;

namespace EntregaFinal
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("El precio del producto debe ser positivo");
            RuleFor(x => x.ReorderQuantity).GreaterThanOrEqualTo(0).WithMessage("El restock no puede ser negativo");
            RuleFor(x => x.ProductSales).GreaterThanOrEqualTo(0).WithMessage("El número de ventas no puede ser negativo");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("El stock del producto no puede ser negativo");
        }
    }
}
