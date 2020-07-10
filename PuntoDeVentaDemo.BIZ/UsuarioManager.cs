using PuntoDeVentaDemo.COMMON.Entidades;
using PuntoDeVentaDemo.COMMON.Interfaces;
using System.Linq;

namespace PuntoDeVentaDemo.BIZ
{
    public class UsuarioManager : GenericManager<usuario>, IUsuarioManager
    {
        #region Constructor
        public UsuarioManager(IGenericRepository<usuario> repositorio) : base(repositorio)
        {
        }

        #endregion

        #region Métodos
        public usuario Login(string nombreUsuario, string password)
        {
            return _repositorio.Query(u => u.NombreDeUsuario == nombreUsuario && u.Password == password).SingleOrDefault();
        }

        #endregion
    }
}