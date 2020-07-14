using FluentValidation;
using PuntoDeVentaDemo.COMMON.Entidades;

namespace PuntoDeVentaDemo.COMMON.Validadores
{
    public class UsuarioValidator : AbstractValidator<usuario>
    {
        #region Constructor

        /// <summary>
        /// Se especifican los requisitos que debe tener el modelo de datos "Usuario" para su validación
        /// </summary>
        public UsuarioValidator()
        {
            RuleFor(u => u.Apellidos).NotNull().NotEmpty().Length(1, 50);
            RuleFor(u => u.NombreDeUsuario).NotNull().NotEmpty().Length(1, 50);
            RuleFor(u => u.Nombres).NotNull().NotEmpty().Length(1, 50);
            RuleFor(u => u.Password).NotNull().NotEmpty().Length(1, 50);
        }

        #endregion
    }
}