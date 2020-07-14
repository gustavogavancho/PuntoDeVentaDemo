using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class ProductoValidator : AbstractValidator<producto>
    {
        #region Constructor

        /// <summary>
        /// Se especifican los requisitos que debe tener el modelo de datos "Producto" para su validación
        /// </summary>
        public ProductoValidator()
        {
            RuleFor(p => p.Costo).NotNull().GreaterThan(0);
            RuleFor(p => p.Nombre).NotNull().NotEmpty().Length(1, 50);
        }

        #endregion

    }
}
