using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class VentaValidator : AbstractValidator<venta>
    {
        public VentaValidator()
        {
            RuleFor(v => v.FechaHora).NotNull().NotEmpty();
            RuleFor(v => v.NombreDeUsuario).NotNull().NotEmpty().Length(1,50);
            RuleFor(v => v.Cliente).NotNull().NotEmpty().Length(1, 100);
        }
    }
}
