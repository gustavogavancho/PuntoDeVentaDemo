using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class VentaValidator : AbstractValidator<venta>
    {
        #region Constructor

        /// <summary>
        /// Se especifican los requisitos que debe tener el modelo de datos "Venta" para su validación
        /// </summary>
        public VentaValidator()
        {
            RuleFor(v => v.FechaHora).NotNull().NotEmpty();
            RuleFor(v => v.NombreDeUsuario).NotNull().NotEmpty().Length(1, 50);
            RuleFor(v => v.Cliente).NotNull().NotEmpty().Length(1, 100);
        }

        #endregion
    }
}
