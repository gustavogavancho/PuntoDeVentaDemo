using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class ProductoValidator : AbstractValidator<producto>
    {
        #region Constructor
        public ProductoValidator()
        {
            RuleFor(p => p.Costo).NotNull().GreaterThan(0);
            RuleFor(p => p.Nombre).NotNull().NotEmpty().Length(1, 50);
        }

        #endregion

    }
}
