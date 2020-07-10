namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class producto : BaseDTO
    {
        #region Propiedades
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobrescribe el método "ToString()" para mostrar un valor concatenado 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nombre} ${Costo}";
        }

        #endregion

    }
}