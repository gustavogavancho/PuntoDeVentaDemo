using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class ProductoVendidoValidator : AbstractValidator<productovendido>
    {
        #region Constructor
        public ProductoVendidoValidator()
        {
            RuleFor(p => p.Cantidad).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.IdProducto).NotNull().NotEmpty();
            RuleFor(p => p.IdVenta).NotNull().NotEmpty();
        }

        #endregion
    }
}