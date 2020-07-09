namespace PuntoDeVentaDemo.COMMON.Entidades
{
    public class producto : BaseDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ${Costo}";
        }
    }
}